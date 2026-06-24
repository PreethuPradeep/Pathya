import { api } from "@/lib/api";
import { getUserId } from "@/lib/user";
import { CreateFoodLog } from "@/types/CreateFoodLog";
import { FoodLogItem } from "@/types/FoodLogItem";

export async function addFoodLog(
    request: CreateFoodLog
){
    await api.post("/food-log", request);
}

export async function getTodaysFoodLog() {
    const userId = getUserId();
    const response = await api.get<FoodLogItem[]>(
            `/users/${userId}/food-log`
        );

    return response.data;
}

export async function deleteFoodLogItem(
    id: number
) {
    await api.delete(
        `/api/foods/${id}`
    );
}