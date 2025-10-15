using RecipeBook.Web.Components;
using Microsoft.EntityFrameworkCore;
using RecipeBook.Web.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// --- Configure EF Core based on environment ---
if (builder.Environment.IsDevelopment())
{
    // Use SQLite for local development
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
}
else
{
    // Use PostgreSQL in production (Render)
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
}

// --- Configure Identity ---
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;
    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders()
.AddDefaultUI();

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();

// --- Razor and Blazor services ---
builder.Services.AddRazorPages();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// --- Seed the database ---
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    AppDbContext.Seed(db);
}

// --- HTTP request pipeline ---
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

// Optional: disable HTTPS redirection on Render
// app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorPages(); // Identity UI

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// --- Logout endpoint ---
app.MapGet("/logout", async (SignInManager<ApplicationUser> signInManager) =>
{
    await signInManager.SignOutAsync();
    return Results.Redirect("/");
});

// --- Listen on Render dynamic port ---
var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
app.Urls.Add($"http://*:{port}");

app.Run();
