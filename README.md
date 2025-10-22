# Brose Onboarding Dashboard

Sistema integral de gestión de onboarding para nuevos empleados de Brose.

## 🚀 Características

- **Dashboard Ejecutivo (RH)**: KPIs, métricas de onboarding, análisis de riesgo de rotación
- **Dashboard Personal (Empleado)**: Seguimiento individual de checklist, tareas y encuestas
- **Gestión de Checklist**: Actividades personalizadas por categoría y responsable
- **Planes de Entrenamiento**: Seguimiento de capacitación estructurada
- **Encuestas de Satisfacción**: Evaluación continua del proceso de onboarding
- **Análisis de Riesgo**: Detección temprana de rotación potencial

## 🛠️ Tecnologías

- **ASP.NET Core 8.0** - Framework MVC
- **Entity Framework Core 9.0** - ORM para SQL Server
- **Bootstrap 5** - UI responsiva (solo CSS, sin JavaScript externo)
- **Bootstrap Icons** - Iconografía
- **SQL Server** - Base de datos
- **Azure App Service** - Hosting

## 🏃‍♂️ Ejecución Local

```bash
git clone https://github.com/Curlias/brose-codesight.git
cd brose-codesight
dotnet run
```

Accede a: `http://localhost:5153`

## 🌐 Deployed on Azure

**Live Demo**: https://brose-dashboard.azurewebsites.net

## 📝 Modo Demo

Actualmente en **modo demo** sin autenticación. Puedes explorar:
- Dashboard RH: `/RH/Dashboard`
- Dashboard Empleado: `/Empleado/Dashboard`

## 📊 Estructura

```
Brose_OnboardingDashboard/
├── Areas/RH/           # Dashboard y gestión de RH
├── Areas/Empleado/     # Dashboard personal empleados
├── Controllers/        # Login y páginas públicas
├── Data/              # Context de EF Core
├── Models/            # 20+ entidades del dominio
└── Views/             # Razor views con Bootstrap
```

## 🔧 Configuración Azure

Configura el connection string en Azure Portal > Configuration:

```
DefaultConnection: Server=tcp:tu-server.database.windows.net,1433;Database=BroseOnboarding;...
```

## 📄 Licencia

Propiedad de Brose. Todos los derechos reservados.
