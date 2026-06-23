import { api } from "@/lib/api";
import { Food } from "@/types/Food";

export async function getFoods(){
    const response = await api.get<Food[]>("/api/foods");
    return response.data;
}