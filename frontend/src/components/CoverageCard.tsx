import * as Progress from "@radix-ui/react-progress";
import { Card, CardHeader, CardTitle, CardContent } from "./ui/card";

interface Props {
    score: number;
}

export default function CoverageCard({
    score
}: Props){
    return (
        <Card>
            <CardHeader>
                <CardTitle>
                    Nutrition Coverage
                </CardTitle>
            </CardHeader>

            <CardContent>
                <div className="space-y-4">
                    <p className="text-4xl font-bold">
                        {score}%
                    </p>

                    <Progress.Root className="h-2 overflow-hidden rounded-full bg-slate-200">
                        <Progress.Indicator
                            className="h-full bg-sky-500 transition-all"
                            style={{ transform: `translateX(-${100 - score}%)` }}
                        />
                    </Progress.Root>
                </div>
            </CardContent>
        </Card>
    );
}