FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 63793
EXPOSE 44334

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["SwaggerGeneratorAPI/SwaggerGeneratorAPI.csproj", "SwaggerGeneratorAPI/"]
RUN dotnet restore "SwaggerGeneratorAPI/SwaggerGeneratorAPI.csproj"
COPY . .
WORKDIR "/src/SwaggerGeneratorAPI"
RUN dotnet build "SwaggerGeneratorAPI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "SwaggerGeneratorAPI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SwaggerGeneratorAPI.dll"]