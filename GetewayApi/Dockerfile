#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["GetewayApi/GetewayApi.csproj", "GetewayApi/"]
RUN dotnet restore "GetewayApi/GetewayApi.csproj"
COPY . .
WORKDIR "/src/GetewayApi"
RUN dotnet build "GetewayApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GetewayApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GetewayApi.dll"]