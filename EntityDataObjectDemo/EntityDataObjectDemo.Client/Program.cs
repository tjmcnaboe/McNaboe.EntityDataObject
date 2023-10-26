using EntityDataObjectDemo.Client;
using EntityDataObjectDemo.Client.EntityObjectServices;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Refit;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();

builder.Services
    .AddRefitClient<IProductDtoHttpService>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress + "api/productdto"));
builder.Services.AddScoped<IProductDtoEntityService, ProductDtoHttpApiService>();

await builder.Build().RunAsync();
