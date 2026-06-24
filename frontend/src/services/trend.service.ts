import { api } from "@/lib/api";
import { getUserId } from "@/lib/user";
import { Trend } from "@/types/Trend";

export async function getTrends() {
    const userId = getUserId();
    const response = await api.get<Trend[]>(`/users/${userId}/trends`);

    return response.data;
}