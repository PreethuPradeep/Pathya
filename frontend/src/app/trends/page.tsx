"use client";

import AppShell from "@/components/AppShell";
import TrendsSection from "@/components/TrendsSection";
import { getTrends } from "@/services/trend.service";
import { Trend } from "@/types/Trend";
import { useEffect, useState } from "react";

export default function TrendsPage() {
    const [trends,setTrends] = useState<Trend[]>([]);

    useEffect(() => {
        getTrends().then(setTrends);
    }, []);

    return (
        <AppShell>
            <main className="max-w-6xl mx-auto p-8">
                <TrendsSection
                    trends={trends}
                />
            </main>
        </AppShell>
);
}