using Microsoft.AspNetCore.Authentication.Cookies;
using repz_core.mysql;
using repz_core.services.product;
using repz_core.services.recipes;
using repz_core.services.user;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
    options =>
    {
        options.LoginPath = new PathString("/auth/SignIn");
        options.AccessDeniedPath = new PathString("/auth/SignIn");
    });

// Add services to the container.
builder.Services.AddRazorPages();

string dbConnection = "Server=studmysql01.fhict.local;Uid=dbi480877;Database=dbi480877;Pwd=ZwbbRPP68c62tvs;";

RecipeStore rStore = new RecipeStore(dbConnection);
ProductStore pStore = new ProductStore(dbConnection);
UserStore uStore = new UserStore(dbConnection);
RoleStore roleStore = new RoleStore(dbConnection);

UserService uService = new UserService(uStore, roleStore);
RecipeService rService = new RecipeService(rStore, pStore);
ProductService pService = new ProductService(pStore);

builder.Services.AddSingleton<UserService>(uService);
builder.Services.AddSingleton<RecipeService>(rService);
builder.Services.AddSingleton<ProductService>(pService);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapRazorPages();
});

app.MapRazorPages();

app.Run();
