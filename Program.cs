using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using StudentGradingSystem;
using StudentGradingSystem.Services;  

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddDbContext<StudentDbContext>(options =>
    options.UseSqlite("Data Source=studentgrading.db"));
builder.Services.AddScoped<StudentService>();

await builder.Build().RunAsync();
