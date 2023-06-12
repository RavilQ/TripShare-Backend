using ApiPracitce.Profiles;
using ApiPractice.Core.Entities;
using ApiPractice.Core.Repositories;
using ApiPractice.Data;
using ApiPractice.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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

builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
{
    opt.Password.RequireNonAlphanumeric = false;
}).AddDefaultTokenProviders().AddEntityFrameworkStores<StoreDbContext>();

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


builder.Services.AddAuthentication(opt =>
{
    opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; ;
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; ;
}).AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidAudience = builder.Configuration.GetSection("JWT:audience").Value,
        ValidIssuer = builder.Configuration.GetSection("JWT:issure").Value,
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration.GetSection("JWT:Secret").Value))
    };
});





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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
