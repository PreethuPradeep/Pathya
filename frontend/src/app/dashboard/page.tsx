"use client";

import { useEffect, useState } from "react";
import InsightCard from "@/components/InsightCard";
import { getInsights } from "@/services/insight.service";
import { Insight } from "@/types/Insight";
import CoverageCard from "@/components/CoverageCard";
import { NutritionCoverage } from "@/types/NutritionCoverage";
import { getCoverage }
    from "@/services/coverage.service";
import TodaySummary from "@/components/TodaySummary";

export default function Dashboard() {
    const [insights, setInsights] = useState<Insight[]>([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState("");
    const [coverage, setCoverage] = useState<NutritionCoverage | null>(null);

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
                coverageData
            ] = await Promise.all([
                getInsights(),
                getCoverage()
            ]);

            setInsights(insightsData);
            setCoverage(coverageData);
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

            {
                coverage && (
                    <TodaySummary
                        insights={insights}
                        coverage={coverage}
                    />
                )
            }

            {
                coverage && (
                    <CoverageCard
                        coverage={coverage}
                    />
                )
            }

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
    );
}