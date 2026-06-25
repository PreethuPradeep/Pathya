"use client";

import AppShell from "@/components/AppShell";
import { getFoodHistory } from "@/services/food-history.service";
import { FoodHistory } from "@/types/FoodHistory";
import { useEffect, useState } from "react";

export default function HistoryPage(){
    const [history,setHistory] = useState<FoodHistory[]>([]);
    const [loading, setLoading] = useState(true);

    useEffect(()=>{
        async function load(){
            const data = await getFoodHistory();
            setHistory(data);
            setLoading(false);
        }
        load();
    },[]);
    if(loading){
        return(
            <p>Loading...</p>
        );
    }
    const grouped =
    history.reduce(
        (acc, item) =>
        {
            if (!acc[item.date])
            {
                acc[item.date] = [];
            }

            acc[item.date].push(item);

            return acc;
        },
        {} as Record<
            string,
            FoodHistory[]
        >
    );
    return (
    <AppShell>
        <main className="max-w-5xl mx-auto p-8">
            <h1 className="text-3xl font-bold mb-6">
                Food History
            </h1>
            <div className="space-y-4">
                {
                Object.entries(grouped)
                    .map(
                        ([date, foods]) => (

                        <div
                            key={date}
                            className="
                            border
                            rounded-lg
                            p-4"
                        >

                            <h2
                                className="
                                text-xl
                                font-bold
                                mb-3"
                            >
                                {date}
                            </h2>

                            {
                                foods.map(
                                    food => (

                                    <div
                                        key={
                                            food.food
                                        }
                                    >
                                        • {food.food}
                                        {" "}
                                        (
                                        {food.weightInGrams}
                                        g
                                        )
                                    </div>

                                ))
                            }

                        </div>

                    ))
            }
                </div>

            </main>

        </AppShell>

    );
}
