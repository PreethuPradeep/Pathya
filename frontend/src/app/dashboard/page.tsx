"use client";
import { getTodaysFoodLog } from "@/services/food-log.service";
import { useEffect, useState } from "react";
import InsightCard from "@/components/InsightCard";
import { getInsights } from "@/services/insight.service";
import { Insight } from "@/types/Insight";
import CoverageCard from "@/components/CoverageCard";
import { NutritionCoverage } from "@/types/NutritionCoverage";
import { getCoverage }
    from "@/services/coverage.service";
import TodaySummary from "@/components/TodaySummary";
import { Trend } from "@/types/Trend";
import { getTrends } from "@/services/trend.service";
import TrendsSection from "@/components/TrendsSection";
import AppShell from "@/components/AppShell";
import { FoodLogItem } from "@/types/FoodLogItem";
import TodaysFoodLog from "@/components/TodaysFoodLog";
import {deleteFoodLogItem} from "@/services/food-log.service";
import RequireUser from "@/components/RequireUser";
import DashboardHeader from "@/components/DashboardHeader";

export default function Dashboard() {
    const [insights, setInsights] = useState<Insight[]>([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState("");
    const [coverage, setCoverage] = useState<NutritionCoverage | null>(null);
    const [trends, setTrends] = useState<Trend[]>([]);
    const [foodLog,setFoodLog] = useState<FoodLogItem[]>([]);
    const sortedInsights =
    [...insights]
        .sort((a, b) => {

            const order = {
                High: 1,
                Medium: 2,
                Low: 3,
                Success: 4
            };
    

            return (
                order[a.severity as keyof typeof order]
                -
                order[b.severity as keyof typeof order]
            );
        });


    useEffect(() => {

    async function loadData() {
        try {
            const [
                    insightsData,
                    coverageData,
                    trendsData,
                    foodLogData
                ] =
                await Promise.all([
                    getInsights(),
                    getCoverage(),
                    getTrends(),
                    getTodaysFoodLog()
                ]);

            setInsights(insightsData);
            setCoverage(coverageData);
            setTrends(trendsData);
            setFoodLog(foodLogData);
        }
        catch (err) {
            console.error(err);
            setError("Failed to load dashboard.");
        }
        finally {
            setLoading(false);
        }
    }

    loadData();
}, []);

    async function handleDelete(
    id: number
        ) {
            try {

                await deleteFoodLogItem(id);
                 await refreshDashboard();
                const updated =
                    await getTodaysFoodLog();

                setFoodLog(updated);

            }
            catch (err) {

                console.error(err);

                alert(
                    "Failed to delete food."
                );
            }
        }
        async function refreshDashboard()
        {
            const [
                insightsData,
                coverageData,
                trendsData,
                foodLogData
            ] =
            await Promise.all([
                getInsights(),
                getCoverage(),
                getTrends(),
                getTodaysFoodLog()
            ]);

            setInsights(insightsData);
            setCoverage(coverageData);
            setTrends(trendsData);
            setFoodLog(foodLogData);
        }
        useEffect(() => {
            refreshDashboard();
        }, []);
    if (loading) {
        return (
            <main>
                <h1>Pathya Dashboard</h1>
                <p>Loading insights...</p>
            </main>
        );
    }

    if (error) {
        return (
            <main>
                <h1>Pathya Dashboard</h1>
                <p>{error}</p>
            </main>
        );
    }

    return (
        <RequireUser>
        <AppShell>
            <main className="max-w-6xl mx-auto p-8 space-y-8">

                <section>
                    <h1 className="text-4xl font-bold">
                        Pathya
                    </h1>

                    <p className="text-muted-foreground mt-2">
                        Understand what your body is missing,
                        not just what you ate.
                    </p>
                </section>
                <DashboardHeader
                    coverage={coverage}
                />
                {coverage && (
                    <TodaySummary
                        insights={insights}
                        coverage={coverage}
                    />
                )}

                <TodaysFoodLog
                    items={foodLog}
                    onDelete={handleDelete}
                />

                {coverage && (
                    <CoverageCard
                        coverage={coverage}
                    />
                )}

                <TrendsSection
                    trends={trends}
                />

                <section>
                    <h2 className="text-2xl font-semibold mb-4">
                        Nutrition Insights
                    </h2>

                    <div className="grid gap-4 md:grid-cols-2">
                        {sortedInsights.map(insight => (
                            <InsightCard
                                key={insight.nutrient}
                                insight={insight}
                            />
                        ))}
                    </div>
                </section>

            </main>
        </AppShell>
        </RequireUser>
    );
}