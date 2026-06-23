"use client";

import { useEffect, useState } from "react";
import { getWeeklyReview } from "@/services/weekly-review.service";
import { WeeklyReview } from "@/types/WeeklyReview";
import WeeklyReviewCard from "@/components/WeeklyReviewCard";

export default function WeeklyReviewPage() {
    const [review, setReview] = useState<WeeklyReview | null>(null);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        async function loadReview() {
            try {
                const data = await getWeeklyReview();
                setReview(data);
            }
            finally {
                setLoading(false);
            }
        }

        loadReview();
    }, []);

    if (loading) {
        return <div>Loading...</div>;
    }   
    if (!review) {
        return <div>No review available.</div>;
    }
    return (
        <main className="max-w-4xl mx-auto p-8">
            <WeeklyReviewCard review={review} />
        </main>
    );
}