using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Brose_OnboardingDashboard.Data;
using Brose_OnboardingDashboard.Models;

namespace Brose_OnboardingDashboard.Controllers
{
    /// <summary>
    /// Controlador para manejar la autenticación de usuarios
    /// </summary>
    [AllowAnonymous]
    public class CuentaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CuentaController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Muestra la página de inicio de sesión
        /// </summary>
        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        /// <summary>
        /// Procesa el inicio de sesión del usuario
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string nombreUsuario, string contrasena, string? returnUrl = null)
        {
            if (string.IsNullOrEmpty(nombreUsuario) || string.IsNullOrEmpty(contrasena))
            {
                ViewData["Error"] = "Por favor ingrese usuario y contraseña";
                ViewData["ReturnUrl"] = returnUrl;
                return View();
            }

            // Buscar usuario en la base de datos
            var usuario = await _context.Usuarios
                .Include(u => u.Rol)
                .Include(u => u.Empleado)
                .FirstOrDefaultAsync(u => u.NombreUsuario == nombreUsuario);

            if (usuario == null)
            {
                ViewData["Error"] = "Usuario o contraseña incorrectos";
                ViewData["ReturnUrl"] = returnUrl;
                return View();
            }

            // Verificar contraseña (en tu BD ya están hasheadas)
            // Si usas BCrypt: bool esValida = BCrypt.Net.BCrypt.Verify(contrasena, usuario.ContrasenaHash);
            // Por ahora comparación simple (CAMBIAR EN PRODUCCIÓN)
            bool esValida = usuario.ContrasenaHash == contrasena;

            if (!esValida)
            {
                ViewData["Error"] = "Usuario o contraseña incorrectos";
                ViewData["ReturnUrl"] = returnUrl;
                return View();
            }

            // Crear claims para el usuario
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuario.NombreUsuario),
                new Claim(ClaimTypes.NameIdentifier, usuario.IdUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuario.Rol?.NombreRol ?? "Empleado"),
                new Claim("IdEmpleado", usuario.IdEmpleado ?? "")
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddHours(8)
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            // Actualizar último acceso
            usuario.UltimoAcceso = DateTime.Now;
            await _context.SaveChangesAsync();

            // Redirigir según el rol
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            if (usuario.Rol?.NombreRol == "Administrador RH")
            {
                return RedirectToAction("Index", "Dashboard", new { area = "RH" });
            }
            else
            {
                return RedirectToAction("Index", "Dashboard", new { area = "Empleado" });
            }
        }

        /// <summary>
        /// Cierra la sesión del usuario
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Muestra la página de acceso denegado
        /// </summary>
        public IActionResult AccesoDenegado()
        {
            return View();
        }
    }
}
