import { api } from "@/lib/api";
import { getUserId } from "@/lib/user";
import { GapRecommendation } from "@/types/GapRecomendation";

export async function getGapRecommendations(){
    const userId = getUserId();
    const response = await api.get<GapRecommendation[]>(`/users/${userId}/gap-recommendations`);
    return response.data;
}