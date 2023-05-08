using BlazorStore;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//var uri = new Uri(builder.HostEnvironment.BaseAddress);
// string requested = uri.Scheme + Uri.SchemeDelimiter + uri.Host + ":" + uri.Port;
// builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new UriBuilder(uri.Scheme, uri.Host, uri.Port).Uri });
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new UriBuilder("https://localhost:7207").Uri });

await builder.Build().RunAsync();