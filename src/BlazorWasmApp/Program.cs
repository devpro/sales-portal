using Devpro.SalesPortal.BlazorWasmApp;
using Devpro.SalesPortal.BlazorWasmApp.Configuration;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// TODO: be able to update this information from a user setting
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = ServiceUriGuesser.GuessBackendUri(builder) });

await builder.Build().RunAsync();
