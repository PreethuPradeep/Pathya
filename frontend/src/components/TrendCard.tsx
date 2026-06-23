import { Trend } from "@/types/Trend";

interface Props {
    trend: Trend;
}

export default function TrendCard({
    trend
}: Props) {

    const isImproving =
        trend.trend === "Improving" ||
        trend.trend === "Strongly Improving";

    return (
        <div className="border rounded-lg p-4">

            <h3 className="font-semibold">
                {trend.nutrient}
            </h3>

            <p className="text-2xl font-bold">
                {isImproving ? "↑" : "↓"}
                {" "}
                {Math.abs(trend.changePercent)}%
            </p>

            <p>
                {trend.trend}
            </p>

        </div>
    );
}