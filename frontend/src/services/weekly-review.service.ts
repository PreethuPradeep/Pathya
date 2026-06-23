import { api } from "@/lib/api";
import { WeeklyReview } from "@/types/WeeklyReview";

export async function getWeeklyReview() {
    const response =
        await api.get<WeeklyReview>(
            "/users/1/weekly-review"
        );
    return response.data;
}