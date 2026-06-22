import { Insight } from "@/types/Insight";
import { Card, CardContent, CardHeader, CardTitle } from "./ui/card";
import { Badge } from "./ui/badge";

interface Props {
    insight: Insight;
}

export default function InsightCard({
    insight
}: Props) {
    const severityColor =
    insight.severity === "High"
        ? "destructive"
        : "secondary";
    return (
        <Card>
            <CardHeader>
                <div className="flex items-center justify-between">
                    <CardTitle>
                        {insight.nutrient}
                    </CardTitle>

                    <Badge variant={severityColor}>
                        {insight.severity}
                    </Badge>
                </div>
            </CardHeader>

            <CardContent className="space-y-4">
                <p>
                    {insight.observation}
                </p>

                <div>
                    <p className="font-medium">
                        Why it matters
                    </p>

                    <p className="text-sm text-muted-foreground">
                        {insight.whyItMatters}
                    </p>
                </div>

                <div>
                    <p className="font-medium">
                        What to do
                    </p>

                    <p className="text-sm">
                        {insight.whatToDo}
                    </p>
                </div>
            </CardContent>
        </Card>
    );
}