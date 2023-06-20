FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["API/API.csproj", "API/"]
COPY ["Core.Data/Core.Data.csproj", "Core.Data/"]
COPY ["Core.Entities/Core.Entities.csproj", "Core.Entities/"]
COPY ["Core.Services/Core.Services.csproj", "Core.Services/"]
COPY ["Core.Handlers/Core.Handlers.csproj", "Core.Handlers/"]
COPY ["Core.Requests/Core.Requests.csproj", "Core.Requests/"]
COPY ["Core.Responses/Core.Responses.csproj", "Core.Responses/"]
COPY ["Core.Models/Core.Models.csproj", "Core.Models/"]
COPY ["Core.Exceptions/Core.Exceptions.csproj", "Core.Exceptions/"]
COPY ["Core.Mappers/Core.Mappers.csproj", "Core.Mappers/"]
COPY ["Core.Validators/Core.Validators.csproj", "Core.Validators/"]
RUN dotnet restore "API/API.csproj"
COPY . .
WORKDIR "/src/API"
RUN dotnet build "API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.dll"]
