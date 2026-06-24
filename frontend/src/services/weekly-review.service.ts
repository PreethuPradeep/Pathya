import { api } from "@/lib/api";
import { getUserId } from "@/lib/user";
import { WeeklyReview } from "@/types/WeeklyReview";

export async function getWeeklyReview() {
    const userId = getUserId();
    const response =
        await api.get<WeeklyReview>(`/users/${userId}/weekly-review`);
    return response.data;
}