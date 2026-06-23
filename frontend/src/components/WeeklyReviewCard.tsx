import { WeeklyReview } from "@/types/WeeklyReview";
import AppShell from "./AppShell";
interface Props {
    review: WeeklyReview;
}
export default function WeeklyReviewCard({
    review
}: Props){
    return (
        <AppShell>
        <section className="border rounded-lg p-6">
            <h2 className="text-2xl font-semibold mb-4">
                Weekly Review
            </h2>

            <div className="mb-6">
                <h3 className="font-medium mb-2">Summary</h3>

                {review.summary.map((item: string) => (
                    <p key={item}>
                            • {item}
                    </p>
                ))}
            </div>

            <div>
                <h3 className="font-medium mb-2">Recommendations</h3>

                {review.recommendations.map((item: string) => (
                    <p key={item}>
                            • {item}
                    </p>
                ))}
            </div>
        </section>
        </AppShell>
    )
}