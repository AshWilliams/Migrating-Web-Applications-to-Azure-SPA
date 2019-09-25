FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["tailwind-api.csproj", ""]
RUN dotnet restore "tailwind-api.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "tailwind-api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "tailwind-api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "tailwind-api.dll"]