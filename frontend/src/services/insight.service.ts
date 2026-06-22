import { api } from "@/lib/api";
import { Insight } from "@/types/Insight";

export async function getInsights() {
  const response =
    await api.get<Insight[]>(
      "/users/1/insights"
    );

  return response.data;
}