FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["CompanyName.DistanceCalculator/CompanyName.DistanceCalculator.csproj", "CompanyName.DistanceCalculator/"]
RUN dotnet restore "CompanyName.DistanceCalculator/CompanyName.DistanceCalculator.csproj"
COPY . .
WORKDIR "/src/CompanyName.DistanceCalculator"
RUN dotnet build "CompanyName.DistanceCalculator.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CompanyName.DistanceCalculator.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CompanyName.DistanceCalculator.dll"]