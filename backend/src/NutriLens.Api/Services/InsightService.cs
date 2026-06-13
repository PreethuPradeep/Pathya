using Microsoft.Extensions.FileSystemGlobbing.Internal;
using Pathya.Api.Data;
using Pathya.Api.DTOs;
using Pathya.Api.Entities;

namespace Pathya.Api.Services
{
    public class InsightService : IInsightService
    {
        private readonly ApplicationDbContext _context;
        private readonly IAnalysisService _analysisService;
        private readonly IRecommendationService _recommendationSErvice;
        private readonly IPatternService _patternService;
        private readonly INutrientImpactService _nutrientImpactSErvice;
        public InsightService(ApplicationDbContext context,
            IAnalysisService analysisService,
            IRecommendationService recommendationService,
            IPatternService patternService,
            INutrientImpactService nutrientImpactService)
        {
            _context = context;
            _nutrientImpactSErvice = nutrientImpactService;
            _patternService = patternService;
            _recommendationSErvice = recommendationService;
            _analysisService = analysisService;
        }
        public async Task<List<InsightDto>> GetInsights(int userId)
        {
            var analysis =
                await _analysisService
                    .GetAnalysisAsync(userId);

            var recommendations =
                await _recommendationSErvice
                    .GetRecommendationsAsync(userId);

            var patterns =
                await _patternService
                    .GetPatternsAsync(userId);

            var result =
                new List<InsightDto>();

            foreach (var nutrient in analysis)
            {
                var pattern =
                    patterns.FirstOrDefault(
                        x => x.Nutrient == nutrient.Nutrient);

                var recommendation =
                    recommendations.FirstOrDefault(
                        x => x.Nutrient == nutrient.Nutrient);

                var impact =
                    await _nutrientImpactSErvice
                        .GetInsightAsync(
                            nutrient.Nutrient);

                result.Add(
                    new InsightDto
                    {
                        Nutrient = nutrient.Nutrient,

                        Observation =
                            pattern == null
                                ? ""
                                : $"{nutrient.Nutrient} intake {pattern.Pattern.ToLower()}",

                        WhyItMatters =
                            impact?.Supports ?? "",

                        WhatToDo =
                            recommendation == null
                                ? ""
                                : $"Consider {string.Join(", ",
                                    recommendation.Foods.Take(3))}"
                    });
            }

            return result;
        }
    }
}
