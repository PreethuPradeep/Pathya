"use client";

import AppShell from "@/components/AppShell";
import { getNutritionHistory } from "@/services/food-history.service";
import { NutritionHistory } from "@/types/NutritionHistory";
import { useState, useEffect } from "react";

export default function NutritionHistoryPage(){
    const [history,setHistory] = useState<NutritionHistory[]>([]);
    const [loading,setLoading] = useState(true);
    const [error, setError] = useState("");

    useEffect(()=>{
        async function load(){
            try{
                const data = await getNutritionHistory();
                console.log(data);
                setHistory(data);
            }
            catch{
                setError("Failed to load nutrition history.")
            }
            finally{
                setLoading(false);
            }
        }
        load();
    },[]);
    if(loading){
        return(
            <AppShell>
                <main className="max-w-6xl mx-auto p-8">
                    Loading...
                </main>
            </AppShell>
        )
    }
    return (
        <AppShell>
            <main className="max-w-6xl mx-auto p-8">
                <h1 className="text-3xl font-bold mb-6">Nutrition History</h1>
                <div className="space-y-6">
                    {history.map(day=>(
                        <div key={day.date} className="border rounded-lg p-5">
                            <h2 className="text-xl font-semibold mb-4">{day.date}</h2>
                            {day.nutrients.length === 0 ? (
                                <p className="text-muted-foreground">No food logged.</p>
                            ) : (
                                <table className="w-full">
                                    <thead>
                                        <tr>
                                            <th  className="text-left">Nutrient</th>
                                            <th className="text-left">Amount</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        {day.nutrients.map(nutrient => (
                                            <tr key={nutrient.nutrient}>
                                                <td>{nutrient.nutrient}</td>
                                                <td>{nutrient.amount}{" "}{nutrient.unit}</td>
                                            </tr>
                                        ))}
                                    </tbody>
                                </table>
                            )}
                            </div>
                            ))}
                        </div>
            </main>
        </AppShell>
    )
}