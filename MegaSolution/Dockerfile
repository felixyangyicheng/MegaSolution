#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app


FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["MegaSolution/MegaSolution.csproj", "MegaSolution/"]
RUN dotnet restore "MegaSolution/MegaSolution.csproj"
COPY . .
WORKDIR "/src/MegaSolution"
RUN dotnet build "MegaSolution.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MegaSolution.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MegaSolution.dll"]


## https://hub.docker.com/_/microsoft-dotnet
#FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
#WORKDIR /source
#
## copy csproj and restore as distinct layers
#COPY *.sln .
#COPY aspnetapp/*.csproj ./aspnetapp/
#RUN dotnet restore
#
## copy everything else and build app
#COPY aspnetapp/. ./aspnetapp/
#WORKDIR /source/aspnetapp
#RUN dotnet publish -c release -o /app --no-restore
#
## final stage/image
#FROM mcr.microsoft.com/dotnet/aspnet:5.0
#WORKDIR /app
#COPY --from=build /app ./
#ENTRYPOINT ["dotnet", "MegaSolution.dll"]