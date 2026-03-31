using Northwind.Blazor.Client.Pages;
using Northwind.Blazor.Components;
using Northwind.Blazor.Services; // To use INorthwindService.

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder
    .Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

// If you are using SQLite that uses a database file.
builder.Services.AddNorthwindContext(relativePath: @"..\..");

// If you are using SQL Server.
// builder.Services.AddNorthwindContext();
builder.Services.AddTransient<INorthwindService, NorthwindServiceServerSide>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Northwind.Blazor.Client._Imports).Assembly);

app.Run();
