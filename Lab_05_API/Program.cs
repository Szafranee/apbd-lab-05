using Lab_05_API;
using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IShelterDb, ShelterDb>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// GETs
app.MapGet("/animals", (IShelterDb shelterDb) =>
{
    return Results.Ok(shelterDb.GetAll());
});

app.MapGet("/animals/{animalId:int}", (IShelterDb shelterDb, int animalId) =>
{
    var animal = shelterDb.GetById(animalId);
    return animal is null ? Results.NotFound() : Results.Ok(animal);
});

app.MapGet("/animals/{animalId:int}/visits", (IShelterDb shelterDb, int animalId) =>
{
    var animal = shelterDb.GetById(animalId);
    return animal is null ? Results.NotFound() : Results.Ok(animal.GetVetVisits());
});

// POSTs
app.MapPost("/animals", (IShelterDb shelterDb, Animal animalToAdd) =>
{
    shelterDb.Add(animalToAdd);
    return Results.Created();
});

app.MapPost("/animals/{animalId:int}/visits", (IShelterDb shelterDb, int animalId, Visit visitToAdd) =>
{
    var animal = shelterDb.GetById(animalId);
    if (animal is null) return Results.NotFound();

    visitToAdd.AnimalId = animalId;
    animal.AddVetVisit(visitToAdd);
    return Results.Created();
});

// PUTs
app.MapPut("/animals/{animalId:int}", (IShelterDb shelterDb, int animalId, Animal animalToUpdate) =>
{
    var animal = shelterDb.GetById(animalId);
    if (animal is null) return Results.NotFound();

    animal.Id = animalToUpdate.Id;
    animal.Name = animalToUpdate.Name;
    animal.Type = animalToUpdate.Type;
    animal.Weight = animalToUpdate.Weight;
    animal.Color = animalToUpdate.Color;
    return Results.NoContent();
});

// DELETEs
app.MapDelete("/animals/{animalId:int}", (IShelterDb shelterDb, int animalId) =>
{
    var animal = shelterDb.GetById(animalId);
    if (animal is null) return Results.NotFound();

    shelterDb.Delete(animalId);
    return Results.NoContent();
});

app.Run();