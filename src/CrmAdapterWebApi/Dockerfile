FROM registry.suse.com/bci/dotnet-aspnet:9.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM registry.suse.com/bci/dotnet-sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/", "./"]
RUN dotnet restore "CrmAdapterWebApi/CrmAdapterWebApi.csproj"
COPY . .
WORKDIR "/src/CrmAdapterWebApi"
RUN dotnet build "CrmAdapterWebApi.csproj" -c "$BUILD_CONFIGURATION" -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "CrmAdapterWebApi.csproj" -c "$BUILD_CONFIGURATION" -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Devpro.SalesPortal.CrmAdapterWebApi.dll"]
