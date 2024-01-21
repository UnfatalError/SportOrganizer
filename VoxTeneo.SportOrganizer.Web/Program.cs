using System.Net.Http.Headers;
using VoxTeneo.SportOrganizer.Application.Interfaces;
using VoxTeneo.SportOrganizer.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseStatusCodePages();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapRazorPages();

app.Run();

void ConfigureServices(IServiceCollection services)
{
    services.AddRazorPages();
    services.AddTransient<IOrganizerService, OrganizerService>();
    services.AddHttpClient<IOrganizerService, OrganizerService>(client =>
    {
        client.BaseAddress = new Uri(builder.Configuration["SportOrganizerApi:BaseUrl"]);
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", builder.Configuration["SportOrganizerApi:AccessToken"]);
    });
}