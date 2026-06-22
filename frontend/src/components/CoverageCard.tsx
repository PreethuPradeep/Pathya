import { Progress } from "@radix-ui/react-progress";
import { Card, CardHeader, CardTitle, CardContent } from "./ui/card";
import { NutritionCoverage } from "@/types/NutritionCoverage";

interface Props {
    coverage: NutritionCoverage;
}

export default function CoverageCard({
    coverage
}: Props){
    return (
        <Card>
            <CardHeader>
                <CardTitle>
                    Nutrition Coverage
                </CardTitle>
            </CardHeader>

            <CardContent className="space-y-4">

                <p className="text-5xl font-bold">
                    {coverage.coveragePercentage}%
                </p>

                <Progress
                    value={
                        Number(
                            coverage.coveragePercentage
                        )
                    }
                />

                <p className="text-sm text-muted-foreground">
                    {coverage.metNutrients}
                    {" / "}
                    {coverage.trackedNutrients}
                    {" nutrients covered"}
                </p>

                {
                    coverage.missingNutrients.length > 0 && (
                        <div>
                            <p className="font-medium mb-2">
                                Missing Nutrients
                            </p>

                            <div className="space-y-1">
                                {coverage
                                    .missingNutrients
                                    .map(x => (
                                        <p key={x}>
                                            • {x}
                                        </p>
                                    ))}
                            </div>
                        </div>
                    )
                }

            </CardContent>
        </Card>
    );
}