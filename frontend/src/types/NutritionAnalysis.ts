export interface NutritionAnalysis {
    nutrient: string;
    required: number;
    consumed: number;
    remaining: number;
    percentageMet: number;
    unit: string;
}