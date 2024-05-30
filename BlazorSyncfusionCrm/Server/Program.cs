using Microsoft.AspNetCore.ResponseCompression;
using BlazorSyncfusionCrm.Server.Data;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Blazor;
using BlazorSyncfusionCrm.Shared;
using BlazorSyncfusionCrm.Server.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddSyncfusionBlazor();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<DataContext>(options => options.UseSqlite("Data Source=Database.db"));
builder.Services.AddScoped<ContactService>();


 
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseRouting();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
