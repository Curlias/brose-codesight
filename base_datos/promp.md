Eres un desarrollador senior de ASP.NET. Crea una aplicación MVC en .NET 8 llamada “Brose_OnboardingDashboard” usando SQL Server y Entity Framework Core. No uses librerías externas de JavaScript (solamente Bootstrap 5 para estilos). La base de datos ya existe con tablas como Roles, Estados_Empleado, Riesgos_Rotacion, Categorias_Checklist, Responsables_Checklist, Tipos_Encuesta, Tipos_Pregunta, Estados_Tarea, Departamentos, Puestos, Empleados (con campos id_empleado, nombre, apellido_paterno, apellido_materno, fecha_ingreso, id_puesto, id_departamento, id_jefe, id_mentor, correo, telefono, id_estado, id_riesgo), Usuarios (id_usuario, nombre_usuario, contrasena_hash, id_rol, id_empleado), Actividades_Checklist, Estado_Checklist (clave compuesta id_empleado + id_actividad), Planes_Entrenamiento, Tareas_Entrenamiento, Encuestas, Preguntas_Encuesta, Respuestas_Encuesta, Detalle_Respuestas, Historial_Riesgo, Archivos.

Tareas:
1. Configura el `DbContext` y las clases de entidad en C# con nombres y comentarios en español. Usa Entity Framework Core para acceder a la base de datos existente.
2. Implementa un sistema de autenticación con cookies usando la tabla `Usuarios` y roles; crea un área de “RH” (Administrador RH) y un área de “Empleado”, con filtros para restringir acceso según el rol.
3. Crea controladores y vistas Razor en español para CRUD de Empleados, Planes_Entrenamiento, Tareas_Entrenamiento, Actividades_Checklist y gestión de encuestas (Encuestas y Preguntas_Encuesta). Incluye formularios con etiquetas en español y mensajes de validación en español.
4. Construye un controlador `DashboardController` con dos acciones:
   • `DashboardRH`: Muestra los KPIs definidos en el reto (nuevos ingresos por mes, porcentaje de checklist completado, promedio de satisfacción por tipo de encuesta, distribución del riesgo de rotación) usando tarjetas de Bootstrap y gráficos simples hechos con `<div>` y CSS (no Chart.js).  
   • `DashboardEmpleado`: Muestra el avance del empleado autenticado (checklist pendientes/completados, tareas del plan de entrenamiento, respuestas de encuestas y nivel de riesgo).
5. Añade un sistema de carga y gestión de archivos para almacenar certificados y evidencias en la tabla `Archivos`.
6. Incluye comentarios detallados en cada clase, método y vista explicando su propósito en español. Documenta en el README cómo configurar la cadena de conexión y desplegar en Azure App Service (.NET 8).

Asegúrate de que todos los textos visibles al usuario, nombres de variables y comentarios estén en español.
