using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Veterianria;
using Veterinaria.Frontend;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<PropietarioService>();




builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7042")
});
builder.Services.AddSingleton<ApiConfig>(sp =>
{
    var config = sp.GetRequiredService<IConfiguration>();
    return new ApiConfig { ApiBaseUrl = config["ApiBaseUrl"]! };
});


await builder.Build().RunAsync();
