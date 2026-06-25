"use client";

import AppShell from "@/components/AppShell";
import { getUserId } from "@/lib/user";
import { addFoodLog } from "@/services/food-log.service";
import { getGapRecommendations } from "@/services/gap-recommendation.service";
import { GapRecommendation } from "@/types/GapRecomendation";
import { useState, useEffect } from "react";

export default function RecommendationsPage(){
    const [recomendations,setRecomendations] = useState<GapRecommendation[]>([]);
    const [loading,setLoading] = useState(true);

    useEffect(()=>{
        async function load(){
            const data = await getGapRecommendations();
            setRecomendations(data);
            setLoading(false);
        }
        load();
    },[]);
    if (loading){
        return (
            <p>Loading...</p>
        );
    }
    return (
        <AppShell>
            <main className="max-w-6xl mx-auto p-8 space-y-6">
                <h1
                    className="
                    text-3xl
                    font-bold"
                >
                    Recommended Foods
                </h1>

                {
                    recomendations.map(
                        nutrient => (

                        <div
                            key={
                                nutrient.nutrient
                            }
                            className="
                            border
                            rounded-lg
                            p-5
                            space-y-4"
                        >

                            <div>

                                <h2
                                    className="
                                    text-xl
                                    font-semibold"
                                >
                                    {
                                        nutrient.nutrient
                                    }
                                </h2>

                                <p>
                                    Remaining:
                                    {" "}
                                    {
                                        nutrient.remainingAmount
                                    }
                                    {
                                        nutrient.unit
                                    }
                                </p>

                                <p>
                                    Current Coverage:
                                    {" "}
                                    {
                                        nutrient.percentageMet.toFixed(1)
                                    }
                                    %
                                </p>

                            </div>

                            <div
                                className="
                                space-y-3"
                            >

                                {
                                    nutrient.foods.map(
                                        food => (

                                        <div
                                            key={
                                                food.food
                                            }
                                            className="
                                            border
                                            rounded
                                            p-3"
                                        >

                                            <h3
                                                className="
                                                font-medium"
                                            >
                                                {
                                                    food.food
                                                }
                                            </h3>

                                            <p>
                                                {
                                                    food.gramsNeeded.toFixed(0)
                                                }
                                                g needed
                                            </p>

                                            <p
                                                className="
                                                text-sm
                                                text-muted-foreground"
                                            >
                                                {
                                                    food.reason
                                                }
                                            </p>
                                                                                <button
                                        onClick={() =>
                                            addFoodLog({
                                                userId: Number(getUserId()),
                                                foodId: food.foodId,
                                                quantity: 1
                                            })
                                        }
                                    >
                                        Log Food
                                    </button>
                                        </div>

                                    ))
                                }

                            </div>

                        </div>

                    ))
                }

            </main>

        </AppShell>
    );
}
