using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Brose_OnboardingDashboard.Data;

var builder = WebApplication.CreateBuilder(args);

// Configuración de la base de datos con SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configuración de autenticación con cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Cuenta/Login";
        options.LogoutPath = "/Cuenta/Logout";
        options.AccessDeniedPath = "/Cuenta/AccesoDenegado";
        options.ExpireTimeSpan = TimeSpan.FromHours(8);
        options.SlidingExpiration = true;
        options.Cookie.Name = "BroseOnboarding.Auth";
    });

// Configuración de autorización
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequiereRH", policy => policy.RequireRole("Administrador RH"));
    options.AddPolicy("RequiereEmpleado", policy => policy.RequireRole("Empleado", "Administrador RH"));
});

// Agregar servicios MVC con soporte para Areas
builder.Services.AddControllersWithViews();

// Configuración de sesiones
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(2);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configuración del pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// app.UseHttpsRedirection(); // Deshabilitado temporalmente para desarrollo
app.UseStaticFiles();

app.UseRouting();

// IMPORTANTE: Primero autenticación, luego autorización
app.UseAuthentication();
app.UseAuthorization();

app.UseSession();

// Configuración de rutas para Areas
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

// Ruta predeterminada
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
