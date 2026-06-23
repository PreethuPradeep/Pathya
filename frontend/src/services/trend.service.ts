import { api } from "@/lib/api";
import { Trend } from "@/types/Trend";

export async function getTrends() {
    const response =
        await api.get<Trend[]>(
            "/users/1/trends"
        );

    return response.data;
}