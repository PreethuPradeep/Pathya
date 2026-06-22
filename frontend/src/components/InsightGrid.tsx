import { Insight } from "@/types/Insight";
import InsightCard from "./InsightCard";

interface Props {
    insights: Insight[]
}

export default function InsightGrid({
    insights
}: Props) {
    return (
        <section>
            <h2>Insights</h2>
            {insights.map((insight) => (
                <InsightCard key={insight.nutrient} insight={insight} />
            ))}
        </section>
    );
}
