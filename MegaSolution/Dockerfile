#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
#WORKDIR /app
#
#
#FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
#WORKDIR /src
#COPY ["MegaSolution/MegaSolution.csproj", "MegaSolution/"]
#RUN dotnet restore "MegaSolution/MegaSolution.csproj"
#COPY . .
#WORKDIR "/src/MegaSolution"
#RUN dotnet build "MegaSolution.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "MegaSolution.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "MegaSolution.dll"]


FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
COPY MegaSolution/*.csproj ./app/MegaSolution/
WORKDIR /app/MegaSolution
RUN dotnet restore

COPY MegaSolution/. ./
RUN dotnet publish -o out /p:PublishWithAspNetCoreTargetManifest="false"

FROM microsoft/dotnet:5.0-runtime AS runtime
#ENV ASPNETCORE_URLS http://+:80
WORKDIR /app
COPY --from=build /app/MegaSolution/out ./
ENTRYPOINT ["dotnet", "MegaSolution.dll"]