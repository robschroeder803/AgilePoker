using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PointerStar.Client;
using PointerStar.Client.ViewModels;
using PointerStar.Shared;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton<IRoomHubConnection>(x => new RoomHubConnection(x.GetRequiredService<NavigationManager>().ToAbsoluteUri("/RoomHub").ToString()));


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<CounterViewModel>();
builder.Services.AddScoped<RoomViewModel>();

await builder.Build().RunAsync();
