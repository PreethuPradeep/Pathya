import { api } from "@/lib/api";
import { getUserId } from "@/lib/user";
import { NutritionCoverage } from "@/types/NutritionCoverage";

export async function getCoverage(){
    const userId = getUserId();
    const response = await api.get<NutritionCoverage>(
        `/users/${userId}/coverage`
    );
    return response.data;
}