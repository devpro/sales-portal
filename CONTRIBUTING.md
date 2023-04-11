# Contributing

## Build & run a local image

### Individual build of Sales Portal WebAssembly

Create an image with `docker build . -t salesportalwasm -f src/BlazorWasmApp/Dockerfile`.

Runs the image with `docker run -it --rm -p 9001:80 -e ASPNETCORE_ENVIRONMENT=Development salesportalwasm`.

Open [localhost:9001](http://localhost:9001/) in a browser.

### Invidual build of CRM Adapter Web API

Create an image with `docker build . -t crmadapterwebapi -f src/CrmAdapterWebApi/Dockerfile`.

Runs the image with `docker run -it --rm -p 9002:80 -e ASPNETCORE_ENVIRONMENT=Development crmadapterwebapi`.

Open [localhost:9002/swagger](http://localhost:9002/swagger) in a browser.
