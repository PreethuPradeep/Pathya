import { api } from "@/lib/api";
import { NutritionCoverage } from "@/types/NutritionCoverage";

export async function getCoverage(){
    const response = await api.get<NutritionCoverage>(
        "/users/1/coverage"
    );
    return response.data;
}