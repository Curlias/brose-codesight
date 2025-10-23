using Microsoft.AspNetCore.Mvc;

namespace Brose_OnboardingDashboard.Areas.RH.Controllers
{
    [Area("RH")]
    public class EmpleadosController : Controller
    {
        public IActionResult Index()
        {
            // Mock data de empleados
            var empleados = new List<dynamic>
            {
                new { Id = 1, Nombre = "Juan Pérez García", Puesto = "Ingeniero de Manufactura", Area = "GE", Departamento = "Producción", Planta = "Benito Juárez", Lider = "María González", FechaIngreso = "2025-01-15", Estado = "Activo", Progreso = 85, Satisfaccion = 4.5 },
                new { Id = 2, Nombre = "María López Hernández", Puesto = "Analista de Calidad", Area = "GKL", Departamento = "Calidad", Planta = "El Marqués", Lider = "Carlos Rodríguez", FechaIngreso = "2025-01-20", Estado = "Activo", Progreso = 92, Satisfaccion = 4.8 },
                new { Id = 3, Nombre = "Carlos Ramírez Sánchez", Puesto = "Técnico de Mantenimiento", Area = "FL", Departamento = "Mantenimiento", Planta = "Aeropuerto", Lider = "Ana Martínez", FechaIngreso = "2025-02-01", Estado = "Activo", Progreso = 78, Satisfaccion = 4.2 },
                new { Id = 4, Nombre = "Ana Martínez Torres", Puesto = "Supervisor de Línea", Area = "WS", Departamento = "Producción", Planta = "Puebla", Lider = "Juan Pérez", FechaIngreso = "2025-02-10", Estado = "Activo", Progreso = 95, Satisfaccion = 4.9 },
                new { Id = 5, Nombre = "Pedro González Ruiz", Puesto = "Ingeniero de Procesos", Area = "ATS", Departamento = "Ingeniería", Planta = "Benito Juárez", Lider = "María González", FechaIngreso = "2025-02-15", Estado = "Activo", Progreso = 88, Satisfaccion = 4.6 },
                new { Id = 6, Nombre = "Laura Sánchez Morales", Puesto = "Coordinadora de RH", Area = "GE", Departamento = "Recursos Humanos", Planta = "El Marqués", Lider = "Carlos Rodríguez", FechaIngreso = "2025-03-01", Estado = "Activo", Progreso = 100, Satisfaccion = 5.0 },
                new { Id = 7, Nombre = "Roberto Díaz Flores", Puesto = "Técnico de Control", Area = "GKL", Departamento = "Calidad", Planta = "Aeropuerto", Lider = "Ana Martínez", FechaIngreso = "2025-03-05", Estado = "Activo", Progreso = 82, Satisfaccion = 4.4 },
                new { Id = 8, Nombre = "Carmen Vega Castillo", Puesto = "Analista Financiero", Area = "FL", Departamento = "Finanzas", Planta = "Puebla", Lider = "Juan Pérez", FechaIngreso = "2025-03-10", Estado = "Activo", Progreso = 90, Satisfaccion = 4.7 },
                new { Id = 9, Nombre = "Luis Torres Méndez", Puesto = "Ingeniero de Calidad", Area = "WS", Departamento = "Calidad", Planta = "Benito Juárez", Lider = "María González", FechaIngreso = "2025-03-15", Estado = "Activo", Progreso = 75, Satisfaccion = 4.1 },
                new { Id = 10, Nombre = "Patricia Reyes Luna", Puesto = "Especialista en Logística", Area = "ATS", Departamento = "Logística", Planta = "El Marqués", Lider = "Carlos Rodríguez", FechaIngreso = "2025-03-20", Estado = "Activo", Progreso = 87, Satisfaccion = 4.5 },
                new { Id = 11, Nombre = "Jorge Castro Silva", Puesto = "Supervisor de Calidad", Area = "GE", Departamento = "Calidad", Planta = "Aeropuerto", Lider = "Ana Martínez", FechaIngreso = "2025-04-01", Estado = "En Onboarding", Progreso = 65, Satisfaccion = 4.0 },
                new { Id = 12, Nombre = "Gabriela Ortiz Vargas", Puesto = "Ingeniera Industrial", Area = "GKL", Departamento = "Ingeniería", Planta = "Puebla", Lider = "Juan Pérez", FechaIngreso = "2025-04-05", Estado = "En Onboarding", Progreso = 70, Satisfaccion = 4.3 },
                new { Id = 13, Nombre = "Fernando Muñoz Herrera", Puesto = "Técnico Electrónico", Area = "FL", Departamento = "Mantenimiento", Planta = "Benito Juárez", Lider = "María González", FechaIngreso = "2025-04-10", Estado = "En Onboarding", Progreso = 60, Satisfaccion = 3.9 },
                new { Id = 14, Nombre = "Silvia Moreno Chávez", Puesto = "Analista de Datos", Area = "WS", Departamento = "IT", Planta = "El Marqués", Lider = "Carlos Rodríguez", FechaIngreso = "2025-04-15", Estado = "En Onboarding", Progreso = 68, Satisfaccion = 4.2 },
                new { Id = 15, Nombre = "Ricardo Jiménez Ramos", Puesto = "Coordinador de Producción", Area = "ATS", Departamento = "Producción", Planta = "Aeropuerto", Lider = "Ana Martínez", FechaIngreso = "2025-04-20", Estado = "En Onboarding", Progreso = 72, Satisfaccion = 4.4 },
                new { Id = 16, Nombre = "Mónica Guerrero Pérez", Puesto = "Especialista en Compras", Area = "GE", Departamento = "Compras", Planta = "Puebla", Lider = "Juan Pérez", FechaIngreso = "2025-05-01", Estado = "En Onboarding", Progreso = 55, Satisfaccion = 3.8 },
                new { Id = 17, Nombre = "Alberto Navarro Cruz", Puesto = "Ingeniero de Planta", Area = "GKL", Departamento = "Ingeniería", Planta = "Benito Juárez", Lider = "María González", FechaIngreso = "2025-05-05", Estado = "En Onboarding", Progreso = 62, Satisfaccion = 4.1 },
                new { Id = 18, Nombre = "Diana Campos Rojas", Puesto = "Supervisora de Almacén", Area = "FL", Departamento = "Logística", Planta = "El Marqués", Lider = "Carlos Rodríguez", FechaIngreso = "2025-05-10", Estado = "Nuevo Ingreso", Progreso = 45, Satisfaccion = 3.7 },
                new { Id = 19, Nombre = "Héctor Rubio Mendoza", Puesto = "Técnico de Seguridad", Area = "WS", Departamento = "Seguridad", Planta = "Aeropuerto", Lider = "Ana Martínez", FechaIngreso = "2025-05-15", Estado = "Nuevo Ingreso", Progreso = 50, Satisfaccion = 3.9 },
                new { Id = 20, Nombre = "Verónica Acosta León", Puesto = "Analista de Nómina", Area = "ATS", Departamento = "Recursos Humanos", Planta = "Puebla", Lider = "Juan Pérez", FechaIngreso = "2025-05-20", Estado = "Nuevo Ingreso", Progreso = 48, Satisfaccion = 3.8 },
                
                // Empleados con estado NETP Verde (≥70% completado)
                new { Id = 21, Nombre = "Claudia Mendoza Ruiz", Puesto = "Ingeniera de Calidad", Area = "GE", Departamento = "Calidad", Planta = "Benito Juárez", Lider = "María González", FechaIngreso = "2025-06-01", Estado = "NETP Verde", Progreso = 85, Satisfaccion = 4.6 },
                new { Id = 22, Nombre = "Miguel Ángel Soto", Puesto = "Supervisor de Producción", Area = "GKL", Departamento = "Producción", Planta = "El Marqués", Lider = "Carlos Rodríguez", FechaIngreso = "2025-06-05", Estado = "NETP Verde", Progreso = 92, Satisfaccion = 4.8 },
                new { Id = 23, Nombre = "Rosa Elena Fuentes", Puesto = "Analista de Procesos", Area = "FL", Departamento = "Ingeniería", Planta = "Aeropuerto", Lider = "Ana Martínez", FechaIngreso = "2025-06-10", Estado = "NETP Verde", Progreso = 78, Satisfaccion = 4.4 },
                new { Id = 24, Nombre = "Eduardo Ramírez Luna", Puesto = "Técnico de Automatización", Area = "WS", Departamento = "Mantenimiento", Planta = "Puebla", Lider = "Juan Pérez", FechaIngreso = "2025-06-15", Estado = "NETP Verde", Progreso = 88, Satisfaccion = 4.7 },
                new { Id = 25, Nombre = "Adriana Torres Gil", Puesto = "Coordinadora de Logística", Area = "ATS", Departamento = "Logística", Planta = "Benito Juárez", Lider = "María González", FechaIngreso = "2025-06-20", Estado = "NETP Verde", Progreso = 95, Satisfaccion = 4.9 },
                new { Id = 26, Nombre = "Francisco Delgado Cruz", Puesto = "Ingeniero de Producto", Area = "GE", Departamento = "Ingeniería", Planta = "El Marqués", Lider = "Carlos Rodríguez", FechaIngreso = "2025-06-25", Estado = "NETP Verde", Progreso = 82, Satisfaccion = 4.5 },
                
                // Empleados con estado NETP Naranja (40-69% completado)
                new { Id = 27, Nombre = "Sandra Mejía Ortiz", Puesto = "Especialista en SQE", Area = "GKL", Departamento = "Calidad", Planta = "Aeropuerto", Lider = "Ana Martínez", FechaIngreso = "2025-07-01", Estado = "NETP Naranja", Progreso = 65, Satisfaccion = 4.1 },
                new { Id = 28, Nombre = "Daniel Castro Pérez", Puesto = "Analista de Mejora Continua", Area = "FL", Departamento = "Ingeniería", Planta = "Puebla", Lider = "Juan Pérez", FechaIngreso = "2025-07-05", Estado = "NETP Naranja", Progreso = 58, Satisfaccion = 3.9 },
                new { Id = 29, Nombre = "Isabel Hernández Valle", Puesto = "Técnico de IT", Area = "WS", Departamento = "IT", Planta = "Benito Juárez", Lider = "María González", FechaIngreso = "2025-07-10", Estado = "NETP Naranja", Progreso = 52, Satisfaccion = 3.8 },
                new { Id = 30, Nombre = "Rodrigo Flores Sánchez", Puesto = "Supervisor de Mantenimiento", Area = "ATS", Departamento = "Mantenimiento", Planta = "El Marqués", Lider = "Carlos Rodríguez", FechaIngreso = "2025-07-15", Estado = "NETP Naranja", Progreso = 62, Satisfaccion = 4.0 },
                
                // Empleados con estado NETP Rojo (<40% completado)
                new { Id = 31, Nombre = "Beatriz Ramírez Vega", Puesto = "Analista de Compras", Area = "GE", Departamento = "Compras", Planta = "Aeropuerto", Lider = "Ana Martínez", FechaIngreso = "2025-08-01", Estado = "NETP Rojo", Progreso = 35, Satisfaccion = 3.5 },
                new { Id = 32, Nombre = "Julio Martínez Rojas", Puesto = "Técnico de Seguridad Industrial", Area = "GKL", Departamento = "Seguridad", Planta = "Puebla", Lider = "Juan Pérez", FechaIngreso = "2025-08-05", Estado = "NETP Rojo", Progreso = 28, Satisfaccion = 3.3 },
                new { Id = 33, Nombre = "Marcela González Téllez", Puesto = "Especialista en Finanzas", Area = "FL", Departamento = "Finanzas", Planta = "Benito Juárez", Lider = "María González", FechaIngreso = "2025-08-10", Estado = "NETP Rojo", Progreso = 32, Satisfaccion = 3.4 }
            };

            // Datos para filtros
            var plantas = new List<string> { "Todas", "Benito Juárez", "El Marqués", "Aeropuerto", "Puebla" };
            
            // BU (Business Units)
            var businessUnits = new List<string> 
            { 
                "Todas",
                "Seat Systems",
                "Door Systems", 
                "Window Regulators & Door Drives",
                "Mechatronic Drives",
                "E-Mobility Drives",
                "Thermal Management Mechatronics"
            };
            
            // Áreas funcionales
            var areas = new List<string> 
            { 
                "Todas",
                "Producción / Operaciones",
                "Mantenimiento",
                "Calidad",
                "Ingeniería de Manufactura",
                "Ingeniería de Producto / Desarrollo",
                "Lanzamiento / Industrialización",
                "Logística / Supply Chain",
                "Compras / Procurement",
                "SQE",
                "Programa/Project Management",
                "Mejora Continua / Lean / Six Sigma",
                "IT & OT",
                "Automatización / Control",
                "Seguridad, Salud y Medio Ambiente",
                "Mantenimiento de Herramentales / Tooling",
                "Facilities & Utilities",
                "Finanzas / Controlling",
                "Recursos Humanos",
                "Jurídico & Compliance",
                "Seguridad Patrimonial",
                "Atención al Cliente / Servicio Postventa"
            };
            
            var departamentos = new List<string> { "Todos", "Producción", "Calidad", "Mantenimiento", "Ingeniería", "Recursos Humanos", "Finanzas", "Logística", "IT", "Compras", "Seguridad" };
            var estados = new List<string> { "Todos", "Activo", "En Onboarding", "Nuevo Ingreso", "NETP Verde", "NETP Naranja", "NETP Rojo" };
            var lideres = new List<string> { "Todos", "María González", "Carlos Rodríguez", "Ana Martínez", "Juan Pérez" };

            ViewBag.Empleados = empleados;
            ViewBag.TotalEmpleados = empleados.Count;
            ViewBag.Plantas = plantas;
            ViewBag.BusinessUnits = businessUnits;
            ViewBag.Areas = areas;
            ViewBag.Departamentos = departamentos;
            ViewBag.Estados = estados;
            ViewBag.Lideres = lideres;

            return View();
        }
    }
}
