using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pathya.Api.Data;
using Pathya.Api.DTOs;
using Pathya.Api.Entities;
using Pathya.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(
    builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IRequirementService, RequirementService>();
builder.Services.AddScoped<IFoodLogService, FoodLogService>();
builder.Services.AddScoped<IAnalysisService, AnalysisService>();
builder.Services.AddScoped<INutrientRecommendationService, NutrientRecommendationService>();
builder.Services.AddScoped<IRecommendationService, RecomendationService>();
builder.Services.AddScoped<IPatternService, PatternService>();
builder.Services.AddScoped<IWeeklyReviewService, WeeklyReviewService>();
builder.Services.AddScoped<INutrientImpactService,NutrientImpactService>();
builder.Services.AddScoped<IInsightService, InsightService>();
builder.Services.AddScoped<ICoverageService, CoverageService>();
builder.Services.AddScoped<IDailyNutritionService,DailyNutritionService>();
builder.Services.AddScoped<ITrendService,TrendService>();
builder.Services.AddScoped<IGapRecommendationService, GapRecomendationService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/health", () =>
{
    return Results.Ok(new
    {
        Status = "Healthy",
        Application = "Pathya",
        TimeStamp = DateTime.UtcNow
    });
});

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    if (!db.Nutrients.Any())
    {
        db.Nutrients.AddRange(NutrientSeeder.GetNutrients());
        db.SaveChanges();
    }
    if (!db.DailyRequirements.Any())
    {
        db.DailyRequirements.AddRange(
            DailyRequirementSeeder.GetRequirements());

        db.SaveChanges();
    }
    if (!db.Users.Any())
    {
        db.Users.Add(new User
        {
            DateOfBirth = new DateOnly(1998, 1, 1),
            Gender = "Female",
            IsPregnant = true,
            IsBreastfeeding = false,
            HeightCm = 165,
            WeightKg = 60,
            ActivityLevel = "Moderate"
        });

        db.SaveChanges();
    }
    if (!db.Foods.Any())
    {
        db.Foods.AddRange(
            NutritionJsonImporter.GetFoods());

        db.SaveChanges();
    }
    if (!db.FoodNutrients.Any())
    {
        var foods = db.Foods.ToList();

        var nutrients =
            NutritionJsonImporter
                .GetFoodNutrients(foods);

        db.FoodNutrients.AddRange(nutrients);

        db.SaveChanges();
    }
    if (!db.nutrientFoodRecomendations.Any())
    {
        db.nutrientFoodRecomendations.AddRange(
            NutrientFoodRecommendationSeeder.GetNutrientFoodRecomendations());
        db.SaveChanges();
    }
    if (!db.NutrientImpacts.Any())
    {
        db.NutrientImpacts.AddRange(
            NutrientImpactSeeder.GetImpacts());

        db.SaveChanges();
    }
}
app.MapPost(
    "/food-log",
    async (
        [FromBody] CreateFoodLogDto request,
        [FromServices] IFoodLogService service) =>
    {
        await service.AddFoodAsync(request);
        return Results.Ok();
    });
app.MapGet(
    "/users/{id}/requirements",
    async (
        int id,
        IRequirementService requirementService) =>
    {
        var result = await requirementService.GetRequirementsAsync(id);
        return Results.Ok(result);
    });
app.MapGet(
    "/users/{id}/consumed",
    async (
        int id,
        IFoodLogService service) =>
    {
        var result =
            await service
                .GetConsumedNutrientsAsync(id);

        return Results.Ok(result);
    });
app.MapGet(
    "/users/{id}/analysis",
    async (
        int id,
        IAnalysisService service) =>
    {
        var result =
            await service
                .GetAnalysisAsync(id);

        return Results.Ok(result);
    });
app.MapGet(
    "/seed-test",
    () =>
    {
        return NutritionJsonImporter
            .LoadFoods();
    });
app.MapGet(
    "/nutrients/{name}/foods",
    async (
        string name,
        INutrientRecommendationService service) =>
    {
        var result =
            await service
                .GetFoodsForNutrientAsync(name);

        return Results.Ok(result);
    });
app.MapGet(
    "/users/{id}/recommendations",
    async (
        int id,
        [FromServices] IRecommendationService service) =>
    {
        var result =
            await service
                .GetRecommendationsAsync(id);

        return Results.Ok(result);
    });
app.MapGet(
    "/users/{id}/patterns",
    async (
        int id,
        [FromServices]
        IPatternService service) =>
    {
        var result =
            await service
                .GetPatternsAsync(id);

        return Results.Ok(result);
    });
app.MapGet("/users/{id}/weekly-review",
    async (int id, IWeeklyReviewService service) =>
    {
        var result = await service.GetWeeklyReviewAsync(id);
        return Results.Ok(result);
    });
app.MapGet(
    "/nutrients/{name}/insight",
    async (
        string name,
        [FromServices]
        INutrientImpactService service) =>
    {
        var result =
            await service
                .GetInsightAsync(name);

        return Results.Ok(result);
    });
app.MapGet(
    "/users/{id}/insights",
    async (
        int id,
        [FromServices] IInsightService service) =>
    {
        return Results.Ok(
            await service.GetInsights(id));
    });
app.MapGet(
    "/users/{id}/coverage",
    async (
        int id,
        [FromServices]
        ICoverageService service) =>
    {
        return Results.Ok(
            await service
                .GetCoverageAsync(id));
    });
app.MapGet(
    "/users/{id}/daily/{date}",
    async (
        int id,
        DateOnly date,
        [FromServices]
        IDailyNutritionService service) =>
    {
        return Results.Ok(
            await service
                .GetDailyNutrientsAsync(
                    id,
                    date));
    });
app.MapGet(
    "/users/{id}/trends",
    async (
        int id,
        [FromServices]
        ITrendService service) =>
    {
        var result =
            await service
                .GetTrendsAsync(id);

        return Results.Ok(result);
    });
app.MapPost(
    "/seed-trend-data",
    async (
        ApplicationDbContext db) =>
    {
        for (int i = 13; i >= 7; i--)
        {
            var log =
                new FoodLog
                {
                    UserId = 1,
                    Date =
                        DateOnly.FromDateTime(
                            DateTime.Today.AddDays(-i))
                };

            db.FoodLogs.Add(log);
            await db.SaveChangesAsync();

            db.FoodLogItems.Add(
                new FoodLogItem
                {
                    FoodLogId = log.Id,
                    FoodId = 7, // Rice
                    WeightInGrams = 100
                });
        }
        for (int i = 6; i >= 0; i--)
        {
            var log =
                new FoodLog
                {
                    UserId = 1,
                    Date =
                        DateOnly.FromDateTime(
                            DateTime.Today.AddDays(-i))
                };

            db.FoodLogs.Add(log);
            await db.SaveChangesAsync();

            db.FoodLogItems.Add(
                new FoodLogItem
                {
                    FoodLogId = log.Id,
                    FoodId = 19, // Soy Chunks
                    WeightInGrams = 100
                });

            db.FoodLogItems.Add(
                new FoodLogItem
                {
                    FoodLogId = log.Id,
                    FoodId = 10, // Rajma
                    WeightInGrams = 100
                });
        }
    });
app.MapGet(
    "/users/{id}/gap-recommendations",
    async (
        int id,
        [FromServices]
        IGapRecommendationService service) =>
    {
        return Results.Ok(
            await service
                .GetGapRecommednationsAsync(
                    id));
    });
app.Run();