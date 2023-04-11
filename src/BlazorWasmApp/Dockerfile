FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/", "./"]
RUN dotnet restore BlazorWasmApp/BlazorWasmApp.csproj
COPY . .
WORKDIR "/src/BlazorWasmApp"
RUN dotnet build BlazorWasmApp.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish BlazorWasmApp.csproj -c Release -o /app/publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY .docker/nginx.conf /etc/nginx/nginx.conf
EXPOSE 80
