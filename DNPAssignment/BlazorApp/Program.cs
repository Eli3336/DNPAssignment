using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorApp;
<<<<<<< Updated upstream
using BlazorApp.Auth;
using BlazorApp.Services.Http;
using Microsoft.AspNetCore.Components.Authorization;
=======
using HttpClients.ClientInterfaces;
using HttpClients.Implementations;
>>>>>>> Stashed changes

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped(
    sp => 
        new HttpClient { 
            BaseAddress = new Uri("https://localhost:7162") 
        }
);
<<<<<<< Updated upstream
builder.Services.AddScoped<IAuthService, JwtAuthService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthProvider>();



AuthorizationPolicies.AddPolicies(builder.Services);
=======
builder.Services.AddScoped<IUserService, UserHttpClient>();
>>>>>>> Stashed changes

await builder.Build().RunAsync();