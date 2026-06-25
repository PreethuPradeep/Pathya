import { api } from "@/lib/api";
import { getUserId } from "@/lib/user";
import { FoodHistory } from "@/types/FoodHistory";
import { NutritionHistory } from "@/types/NutritionHistory";

export async function getFoodHistory(){
    const userId = getUserId();
    const response = await api.get<FoodHistory[]>(`/users/${userId}/food-history`);
    return response.data;
}

export async function getNutritionHistory(){
    const userId = getUserId();
    const  response = await api.get<NutritionHistory[]>(`/users/${userId}/nutrition-history`);
    return response.data;
}