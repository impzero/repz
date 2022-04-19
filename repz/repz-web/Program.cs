using Microsoft.AspNetCore.Authentication.Cookies;
using repz_core.mysql;
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

string dbConnection = "Server=localhost;Uid=root;Database=repz;Pwd=123456";
RecipeStore rStore = new RecipeStore(dbConnection);
UserStore uStore = new UserStore(dbConnection);
RoleStore roleStore = new RoleStore(dbConnection);

UserService uService = new UserService(uStore, roleStore);

builder.Services.AddSingleton<UserService>(uService);

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
