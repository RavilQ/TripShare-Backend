using ApiPracitce.Profiles;
using ApiPractice.Core.Repositories;
using ApiPractice.Data;
using ApiPractice.Data.Repositories;
using Microsoft.EntityFrameworkCore;




var builder = WebApplication.CreateBuilder(args);


//       CONTENT
// ---------------------
// 1 DataBase
// 2 AutoMapper
// 3 Custom Services



//-----------------
// 1 Cors usecors


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// ==========================
// 1 DataBase
// ==========================

builder.Services.AddDbContext<StoreDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

// ==========================
// 2 AutoMapper
// ==========================

builder.Services.AddAutoMapper(opt =>
{
    opt.AddProfile(new Mapper());
});

// ==========================
// 3 Custom Services
// ==========================

builder.Services.AddScoped<ICityRepository, CityRepository>();





// ==========================
// 4 Custom Services
// ==========================
builder.Services.AddCors();








var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//=========================
// 1 Cors usecors
//=========================


app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
