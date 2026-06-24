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

    const isDeclining =
        trend.trend === "Declining" ||
        trend.trend === "Strongly Declining";

    return (
        <div className="border rounded-lg p-4">

            <h3 className="font-semibold">
                {trend.nutrient}
            </h3>

            {
                trend.trend === "New Intake"
                    ? (
                        <p className="text-2xl font-bold">
                            NEW
                        </p>
                    )
                    : trend.trend === "Stable"
                        ? (
                            <p className="text-2xl font-bold">
                                →
                                {" "}
                                0%
                            </p>
                        )
                        : (
                            <p className="text-2xl font-bold">
                                {isImproving
                                    ? "↑"
                                    : "↓"}
                                {" "}
                                {Math.abs(
                                    trend.changePercent
                                )}%
                            </p>
                        )
            }

            <p>
                {trend.trend}
            </p>

            <p className="text-sm text-muted-foreground mt-2">
                {trend.insight}
            </p>

        </div>
    );
}