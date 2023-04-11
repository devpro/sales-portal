# Contributing

## Build & run a local image

Create an image with `docker build . -t sales-portal-wasm -f src/BlazorWasmApp/Dockerfile`.

Runs the image with `docker run -it --rm -p 9001:80 -e ASPNETCORE_ENVIRONMENT=Development sales-portal-wasm`.

Open [localhost:9001](http://localhost:9001/) in a browser.
