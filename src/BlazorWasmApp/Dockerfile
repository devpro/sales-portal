FROM registry.suse.com/bci/dotnet-sdk:8.0 AS build
WORKDIR /src
COPY ["src/", "./"]
RUN dotnet restore BlazorWasmApp/BlazorWasmApp.csproj
COPY . .
WORKDIR "/src/BlazorWasmApp"
RUN dotnet build BlazorWasmApp.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish BlazorWasmApp.csproj -c Release -o /app/publish

FROM registry.suse.com/suse/nginx:1.21 AS final
RUN useradd -m -s /bin/bash web
USER web
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY .docker/nginx.conf /etc/nginx/nginx.conf
EXPOSE 80
