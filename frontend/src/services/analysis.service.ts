import { api } from "@/lib/api";
import { getUserId } from "@/lib/user";
import { NutritionAnalysis } from "@/types/NutritionAnalysis";

export async function getAnalysis(){
    const userId = getUserId();
    const response = await api.get<NutritionAnalysis[]>(`/users/${userId}/analysis`);
    return response.data;
}