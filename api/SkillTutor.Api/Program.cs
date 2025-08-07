using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SkillTutor.Api.Extensions;
using SkillTutor.Database;
using SkillTutor.Models.Core;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();
builder.Services.AddAuthentication()
    .AddBearerToken(IdentityConstants.BearerScheme);
builder.Services.AddIdentityCore<User>()
    .AddEntityFrameworkStores<SkillTutorDbContext>()
    .AddApiEndpoints();
builder.Services.AddDbContext<SkillTutorDbContext>(options => 
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}

app.UseHttpsRedirection();
app.Run();