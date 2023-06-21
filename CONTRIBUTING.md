# Contributing

## Local development

[.NET SDK](https://dotnet.microsoft.com/en-us/download) is required to run the code.

Make sure to have local certificates for https debugging: `dotnet dev-certs https`.

## Build & run

ℹ Examples are made with Docker CLI and expect a running container engine, which can be available with Docker Desktop or Rancher Desktop on developer workstations.

### All-in-one

All the definitions are written in `compose.yaml` file at the root of the repository.

Build images with `docker compose build`.

Use `docker compose <up|start|stop|down>` to manage running containers.

Open [localhost:9001](http://localhost:9001/) in a browser.

### Individual validation

#### Sales Portal WebAssembly image

Create an image with `docker build . -t salesportalwasmapp -f src/BlazorWasmApp/Dockerfile`.

Runs the image with `docker run -it --rm -p 9001:80 -e ASPNETCORE_ENVIRONMENT=Development salesportalwasmapp`.

Open [localhost:9001](http://localhost:9001/) in a browser.

#### CRM Adapter Web API image

Create an image with `docker build . -t crmadapterwebapi -f src/CrmAdapterWebApi/Dockerfile`.

Runs the image with `docker run -it --rm -p 9002:80 -e ASPNETCORE_ENVIRONMENT=Development crmadapterwebapi`.

Open [localhost:9002/swagger](http://localhost:9002/swagger) in a browser.

#### CRM Data Web API image

Create an image with `docker build . -t crmdatawebapi -f src/CrmDataWebApi/Dockerfile`.

Runs the image with `docker run -it --rm -p 9002:80 -e ASPNETCORE_ENVIRONMENT=Development crmdatawebapi`.

Open [localhost:9003/swagger](http://localhost:9003/swagger) in a browser.

## Debug

Use Chrome to be able to debug the Blazor WebAssembly application (breakpoints are not hit in Firefox). In Visual Studio 2022, click on the Run menu (displaying http for example) and select Chrome as browser.
