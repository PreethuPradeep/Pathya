using Microsoft.Extensions.FileSystemGlobbing.Internal;
using Pathya.Api.Data;
using Pathya.Api.DTOs;
using Pathya.Api.Entities;

namespace Pathya.Api.Services
{
    public class InsightService : IInsightService
    {
        private readonly IAnalysisService _analysisService;
        private readonly IPatternService _patternService;
        private readonly INutrientImpactService _nutrientImpactSErvice;
        private readonly ITrendService _trendService;
        private readonly IGapRecommendationService _gapService;
        public InsightService(
            IAnalysisService analysisService,
            IPatternService patternService,
            INutrientImpactService nutrientImpactService,
            ITrendService trendService,
            IGapRecommendationService gapService)
        {
            _nutrientImpactSErvice = nutrientImpactService;
            _patternService = patternService;
            _analysisService = analysisService;
            _trendService = trendService;
            _gapService = gapService;
        }
        public async Task<List<InsightDto>> GetInsights(int userId)
        {
            var analysis =
                await _analysisService
                    .GetAnalysisAsync(userId);


            var patterns =
                await _patternService
                    .GetPatternsAsync(userId);

            var trends =
                await _trendService
                    .GetTrendsAsync(userId);

            var gaps =
                await _gapService
                    .GetGapRecommednationsAsync(userId);

            var result =
                new List<InsightDto>();

            foreach (var nutrient in analysis)
            {
                var pattern =
                    patterns.FirstOrDefault(
                        x => x.Nutrient == nutrient.Nutrient);


                var impact =
                    await _nutrientImpactSErvice
                        .GetInsightAsync(
                            nutrient.Nutrient);
                var trend =
                        trends.FirstOrDefault(
                            x => x.Nutrient ==
                                 nutrient.Nutrient);

                string observation = "";

                if (pattern != null)
                {
                    observation =
                        $"{nutrient.Nutrient} was below target on {pattern.DaysBelowTarget} of the last 30 days. " +
                        $"Current coverage is {Math.Round(nutrient.PercentageMet, 0)}%.";
                }

                if (trend?.Trend == "New Intake")
                {
                    observation +=
                        $" {nutrient.Nutrient} appeared in your diet this week.";
                }
                else if (trend != null &&
                         trend.Trend != "Stable")
                {
                    observation +=
                        $" {nutrient.Nutrient} is {trend.Trend.ToLower()} compared to last week.";
                }
                var gap =
                    gaps.FirstOrDefault(
                        x => x.Nutrient ==
                             nutrient.Nutrient);
                string whatToDo = "";

                if (gap != null &&
                    gap.Foods.Any())
                {
                    var topFood =
                        gap.Foods.First();

                    whatToDo =
                        $"Try adding {topFood.GramsNeeded}g of {topFood.Food} today.";
                }
                if (nutrient.PercentageMet >= 100)
                {
                    result.Add(
                        new InsightDto
                        {
                            Nutrient = nutrient.Nutrient,

                            Observation =
                                $"{nutrient.Nutrient} intake has been adequate.",

                            WhyItMatters =
                                impact?.Supports ?? "",

                            WhatToDo =
                                "Keep following your current eating pattern.",

                            Severity = "Success"
                        });

                    continue;
                }
                string severity;

                if (nutrient.PercentageMet < 25)
                {
                    severity = "High";
                }
                else if (nutrient.PercentageMet < 50)
                {
                    severity = "Medium";
                }
                else
                {
                    severity = "Low";
                }

                if (
                string.IsNullOrWhiteSpace(observation) &&
                string.IsNullOrWhiteSpace(whatToDo))
                            {
                                continue;
                            }
                result.Add(
                    new InsightDto
                    {
                        Nutrient = nutrient.Nutrient,

                        Observation = observation,

                        WhyItMatters =
                            impact?.Supports ?? "",

                        WhatToDo =
                            whatToDo,
                        Severity = severity
                    });
            }

            return result
                .OrderBy(x =>
                    x.Severity == "High" ? 1 :
                    x.Severity == "Medium" ? 2 :
                    x.Severity == "Low" ? 3 :
                    4).ToList();
        }
    }
}
