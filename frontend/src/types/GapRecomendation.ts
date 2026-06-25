import { FoodRecommendation } from "./FoodRecommendations";

export interface GapRecommendation{
    nutrient: string;
    remainingAmount: number;
    unit:string;
    percentageMet: number;
    foods: FoodRecommendation[];
}