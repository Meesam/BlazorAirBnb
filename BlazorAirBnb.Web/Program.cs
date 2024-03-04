using BlazorAirBnb.DataAccess;
using BlazorAirBnb.DataAccess.Services.Implementations;
using BlazorAirBnb.DataAccess.Services.Interfaces;
using BlazorAirBnb.Models;
using BlazorAirBnb.Web.Authentication;
using BlazorAirBnb.Web.Components;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Radzen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddRadzenComponents();

builder.Services.AddAuthenticationCore();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddDbContext<AirBnbDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ProtectedSessionStorage>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AirBnbDbContext>().AddDefaultTokenProviders();


builder.Services.AddScoped<ICategoryService, CategoryService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthentication();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
