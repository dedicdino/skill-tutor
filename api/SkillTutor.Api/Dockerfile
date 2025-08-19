# Use .NET SDK to build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy csproj files and restore
COPY SkillTutor.Api/SkillTutor.Api.csproj SkillTutor.Api/
COPY SkillTutor.Application/SkillTutor.Application.csproj SkillTutor.Application/
COPY SkillTutor.Infrastructure/SkillTutor.Infrastructure.csproj SkillTutor.Infrastructure/
COPY SkillTutor.Domain/SkillTutor.Domain.csproj SkillTutor.Domain/
RUN dotnet restore SkillTutor.Api/SkillTutor.Api.csproj

# Copy the rest and build
COPY . .
WORKDIR /src/SkillTutor.Api
RUN dotnet publish -c Release -o /app/publish

# Final runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "SkillTutor.Api.dll"]
