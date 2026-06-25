import { ConsumeNutrient } from "./ConsumeNutrient";

export interface NutritionHistory {

    date: string;

    nutrients: ConsumeNutrient[];
}