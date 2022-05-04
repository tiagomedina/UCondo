#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/UCondo.Bff.Gateway/UCondo.Bff.Gateway.csproj", "src/UCondo.Bff.Gateway/"]
RUN dotnet restore "src/UCondo.Bff.Gateway/UCondo.Bff.Gateway.csproj"
COPY . .
WORKDIR "/src/src/UCondo.Bff.Gateway"
RUN dotnet build "UCondo.Bff.Gateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UCondo.Bff.Gateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UCondo.Bff.Gateway.dll"]