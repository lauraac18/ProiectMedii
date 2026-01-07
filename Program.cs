using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GestiuneRestaurant.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// 1. Configurare Bază de Date
builder.Services.AddDbContext<GestiuneRestaurantContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GestiuneRestaurantContext") ?? throw new InvalidOperationException("Connection string 'GestiuneRestaurantContext' not found.")));

// 2. Configurare Identity 

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    
    .AddEntityFrameworkStores<GestiuneRestaurantContext>();

// 3. Configurare Autorizare pe Foldere
builder.Services.AddRazorPages(options =>
{
   
    options.Conventions.AuthorizeFolder("/Rezervari");
    options.Conventions.AuthorizeFolder("/Mese");


    options.Conventions.AuthorizeFolder("/ProduseDestinate");
    options.Conventions.AuthorizeFolder("/CategoriiProdus");

   
    options.Conventions.AllowAnonymousToPage("/ProduseMeniu/Index");


    options.Conventions.AuthorizePage("/ProduseMeniu/Create");
    options.Conventions.AuthorizePage("/ProduseMeniu/Edit");
    options.Conventions.AuthorizePage("/ProduseMeniu/Delete");
});


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();