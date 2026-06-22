"use client";

import { useEffect, useState } from "react";
import InsightCard from "@/components/InsightCard";
import { getInsights } from "@/services/insight.service";
import { Insight } from "@/types/Insight";
import DashboardHeader from "@/components/DashboardHeader";
import CoverageCard from "@/components/CoverageCard";
import InsightGrid from "@/components/InsightGrid";

export default function Dashboard() {
    const [insights, setInsights] = useState<Insight[]>([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState("");

    useEffect(() => {
        async function loadInsights() {
            try {
                const data = await getInsights();
                setInsights(data);
            }
            catch (err) {
                console.error(err);
                setError("Failed to load insights.");
            }
            finally {
                setLoading(false);
            }
        }

        loadInsights();
    }, []);

    const coverage =
    insights.length === 0
        ? 0
        : Math.round(
            insights.reduce(
                (total, insight) =>
                    total +
                    (
                        insight.severity === "Success"
                            ? 100
                            : insight.severity === "Low"
                                ? 75
                                : insight.severity === "Medium"
                                    ? 50
                                    : 25
                    ),
                0
            ) / insights.length
        );

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

            <CoverageCard
                score={coverage}
            />

            <section>
                <h2 className="text-2xl font-semibold mb-4">
                    Nutrition Insights
                </h2>

                <div className="grid gap-4 md:grid-cols-2">
                    {insights.map(insight => (
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