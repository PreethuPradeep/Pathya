import { Insight } from "@/types/Insight";
import { NutritionCoverage } from "@/types/NutritionCoverage";

interface Props{
    insights: Insight[];
    coverage: NutritionCoverage;
}

export default function TodaySummary({
    insights,
    coverage
}: Props) {

    const topThree = insights.filter(x=>x.severity === "High").slice(0,3);

    return (
        <section className="space-y-4">
            <div>
                <h2 className="text-3xl font-bold">Today&apos;s Nutrition</h2>
                <p className="text-muted-foreground">
                    Understand what your body is missing,
                    not just what you ate.
                </p>
            </div>
            <div>
                <p className="text-6xl font-bold">
                    {coverage.coveragePercentage}%
                </p>

                <p className="text-muted-foreground">
                    Nutrition Coverage
                </p>
            </div>
            <div>
                <h3 className="ont-semibold">Needs Attention</h3>

                {topThree.map(x=>(
                    <p key={x.nutrient}>
                         • {x.nutrient}
                    </p>
                ))}
            </div>
        </section>

    );
}