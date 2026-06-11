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
            FoodSeeder.GetFoods());

        db.SaveChanges();
    }
    if (!db.FoodNutrients.Any())
    {
        db.FoodNutrients.AddRange(
            FoodNutrientSeeeder.GetFoodNutrients());
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
app.Run();