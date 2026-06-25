import { NutritionCoverage } from "@/types/NutritionCoverage";

interface Props {
    coverage: NutritionCoverage | null;
}

export default function DashboardHeader({
    coverage
}: Props) {
    return (
        <section>
            <h1
                className="
                text-4xl
                font-bold"
            >
                Dashboard
            </h1>

            <p
                className="
                text-muted-foreground"
            >
                Nutrition coverage:{" "}
                {coverage
                    ? `${coverage.coveragePercentage.toFixed(1)}%`
                    : "Loading..."}
            </p>
        </section>
    );
}