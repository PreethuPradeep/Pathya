import TrendCard from "./TrendCard";
import { Trend } from "@/types/Trend";

interface Props {
    trends: Trend[];
}

export default function TrendsSection({
    trends
}: Props) {

    return (
        <section>

            <h2 className="text-2xl font-semibold mb-4">
                Weekly Trends
            </h2>

            <div className="grid gap-4 md:grid-cols-3">

                {trends.map(trend => (
                    <TrendCard
                        key={trend.nutrient}
                        trend={trend}
                    />
                ))}

            </div>

        </section>
    );
}