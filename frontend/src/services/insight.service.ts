import { api } from "@/lib/api";
import { getUserId } from "@/lib/user";
import { Insight } from "@/types/Insight";

export async function getInsights() {
  const userId = getUserId();
  const response =
    await api.get<Insight[]>(`/users/${userId}/insights`);

  return response.data;
}