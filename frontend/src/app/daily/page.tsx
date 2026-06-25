"use client";

import AppShell from "@/components/AppShell";
import { getAnalysis } from "@/services/analysis.service";
import { NutritionAnalysis } from "@/types/NutritionAnalysis";
import { useState, useEffect } from "react";

export default function DailyPage(){
    const [nutrients,setNutrients] = useState<NutritionAnalysis[]>([]);
    const [loading,setLoading] = useState(true);
    useEffect(() => {
        async function load(){
            const data = await getAnalysis();
            setNutrients(data);
            setLoading(false);
        }
        load();
    },[]);
    if (loading){
        return (<p>Loading...</p>)
    }
    return (
        <AppShell>
            <main className="max-w-5xl mx-auto p-8 space-y-6">
                <h1 className="text-3xl font-bold">
                    Daily Nutrition
                </h1>
                {nutrients.map(nutrient =>(
                    <div key={nutrient.nutrient} className="border rounded-lg p-4">
                        <h2 className="text-xl font-semibold">
                            {nutrient.nutrient}
                        </h2>
                        <p>
                            Consumed:
                            {" "}
                            {nutrient.consumed}
                            {nutrient.unit}
                        </p>
                        <p>
                            Required:
                            {" "}
                            {nutrient.required}
                            {nutrient.unit}
                        </p>
                        <p>
                            Remaining:
                            {" "}
                            {nutrient.remaining}
                            {nutrient.unit}
                        </p>
                        <div className="w-full bg-gray-200 rounded h-4 mt-3">
                            <div className="bg-green-500 h-4 rounded" style={{width:`${Math.min(nutrient.percentageMet,100)}%`}}/>
                        </div>
                        <p className="mt-2 font-medium">
                            {nutrient.percentageMet.toFixed(1)}%
                        </p>
                    </div>
                ))}
            </main>
        </AppShell>
    )
}