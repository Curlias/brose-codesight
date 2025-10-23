------------------------------------------------

-- Estado laboral
CREATE TABLE Estados_Empleado (
    id_estado INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(20) UNIQUE NOT NULL
);

-- Riesgo de rotación
CREATE TABLE Riesgos_Rotacion (
    id_riesgo INT IDENTITY(1,1) PRIMARY KEY,
    nivel NVARCHAR(10) UNIQUE NOT NULL
);

-- Categorías de checklist
CREATE TABLE Categorias_Checklist (
    id_categoria INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(50) UNIQUE NOT NULL
);

-- Roles responsables de checklist
CREATE TABLE Responsables_Checklist (
    id_responsable INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(20) UNIQUE NOT NULL
);

-- Tipos de encuesta
CREATE TABLE Tipos_Encuesta (
    id_tipo INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(30) UNIQUE NOT NULL
);

-- Tipos de pregunta de encuesta
CREATE TABLE Tipos_Pregunta (
    id_tipo_pregunta INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(20) UNIQUE NOT NULL
);

-- Estados de tareas o checklist
CREATE TABLE Estados_Tarea (
    id_estado INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(20) UNIQUE NOT NULL
);

------------------------------------------------------------
-- 2️⃣ TABLAS DE CATÁLOGOS FUNCIONALES
------------------------------------------------------------

CREATE TABLE Roles (
    id_rol INT IDENTITY(1,1) PRIMARY KEY,
    nombre_rol NVARCHAR(50) NOT NULL UNIQUE,
    descripcion NVARCHAR(255)
);

CREATE TABLE Departamentos (
    id_departamento INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(100) NOT NULL,
    id_jefe VARCHAR(10) NULL
);

CREATE TABLE Puestos (
    id_puesto INT IDENTITY(1,1) PRIMARY KEY,
    titulo NVARCHAR(100) NOT NULL,
    descripcion NVARCHAR(255),
    nivel_competencia NVARCHAR(50)
);

------------------------------------------------------------
-- 3️⃣ EMPLEADOS
------------------------------------------------------------

CREATE TABLE Empleados (
    id_empleado VARCHAR(10) PRIMARY KEY,
    nombre NVARCHAR(50) NOT NULL,
    apellido_paterno NVARCHAR(50) NOT NULL,
    apellido_materno NVARCHAR(50),
    fecha_ingreso DATE NOT NULL,
    id_puesto INT NOT NULL,
    id_departamento INT NOT NULL,
    id_jefe VARCHAR(10) NULL,
    id_mentor VARCHAR(10) NULL,
    correo NVARCHAR(100),
    telefono NVARCHAR(15),
    id_estado INT NOT NULL,
    id_riesgo INT NOT NULL,
    CONSTRAINT FK_Emp_Puesto FOREIGN KEY (id_puesto) REFERENCES Puestos(id_puesto),
    CONSTRAINT FK_Emp_Dep FOREIGN KEY (id_departamento) REFERENCES Departamentos(id_departamento),
    CONSTRAINT FK_Emp_Estado FOREIGN KEY (id_estado) REFERENCES Estados_Empleado(id_estado),
    CONSTRAINT FK_Emp_Riesgo FOREIGN KEY (id_riesgo) REFERENCES Riesgos_Rotacion(id_riesgo)
);

ALTER TABLE Departamentos
ADD CONSTRAINT FK_Dep_Jefe FOREIGN KEY (id_jefe) REFERENCES Empleados(id_empleado);

------------------------------------------------------------
-- 4️⃣ USUARIOS
------------------------------------------------------------

CREATE TABLE Usuarios (
    id_usuario INT IDENTITY(1,1) PRIMARY KEY,
    nombre_usuario NVARCHAR(50) NOT NULL UNIQUE,
    contrasena_hash NVARCHAR(255) NOT NULL,
    id_rol INT NOT NULL,
    id_empleado VARCHAR(10),
    fecha_creacion DATETIME DEFAULT GETDATE(),
    ultimo_acceso DATETIME NULL,
    CONSTRAINT FK_Usuario_Rol FOREIGN KEY (id_rol) REFERENCES Roles(id_rol),
    CONSTRAINT FK_Usuario_Emp FOREIGN KEY (id_empleado) REFERENCES Empleados(id_empleado)
);

------------------------------------------------------------
-- 5️⃣ CHECKLIST DE ONBOARDING
------------------------------------------------------------

CREATE TABLE Actividades_Checklist (
    id_actividad INT IDENTITY(1,1) PRIMARY KEY,
    descripcion NVARCHAR(255) NOT NULL,
    id_categoria INT NOT NULL,
    id_responsable INT NOT NULL,
    CONSTRAINT FK_Act_Cat FOREIGN KEY (id_categoria) REFERENCES Categorias_Checklist(id_categoria),
    CONSTRAINT FK_Act_Resp FOREIGN KEY (id_responsable) REFERENCES Responsables_Checklist(id_responsable)
);

CREATE TABLE Estado_Checklist (
    id_empleado VARCHAR(10) NOT NULL,
    id_actividad INT NOT NULL,
    fecha_limite DATE,
    fecha_completado DATETIME,
    id_estado INT NOT NULL,
    PRIMARY KEY (id_empleado, id_actividad),
    CONSTRAINT FK_Estado_Emp FOREIGN KEY (id_empleado) REFERENCES Empleados(id_empleado),
    CONSTRAINT FK_Estado_Act FOREIGN KEY (id_actividad) REFERENCES Actividades_Checklist(id_actividad),
    CONSTRAINT FK_Estado_Estado FOREIGN KEY (id_estado) REFERENCES Estados_Tarea(id_estado)
);

------------------------------------------------------------
-- 6️⃣ PLANES Y TAREAS DE ENTRENAMIENTO
------------------------------------------------------------

CREATE TABLE Planes_Entrenamiento (
    id_plan INT IDENTITY(1,1) PRIMARY KEY,
    id_empleado VARCHAR(10) NOT NULL,
    fecha_inicio DATE,
    fecha_fin DATE,
    id_estado INT NOT NULL,
    CONSTRAINT FK_Plan_Emp FOREIGN KEY (id_empleado) REFERENCES Empleados(id_empleado),
    CONSTRAINT FK_Plan_Estado FOREIGN KEY (id_estado) REFERENCES Estados_Tarea(id_estado)
);

CREATE TABLE Tareas_Entrenamiento (
    id_tarea INT IDENTITY(1,1) PRIMARY KEY,
    id_plan INT NOT NULL,
    descripcion NVARCHAR(255),
    id_responsable VARCHAR(10),
    fecha_limite DATE,
    fecha_completado DATETIME,
    id_estado INT NOT NULL,
    CONSTRAINT FK_Tarea_Plan FOREIGN KEY (id_plan) REFERENCES Planes_Entrenamiento(id_plan),
    CONSTRAINT FK_Tarea_Resp FOREIGN KEY (id_responsable) REFERENCES Empleados(id_empleado),
    CONSTRAINT FK_Tarea_Estado FOREIGN KEY (id_estado) REFERENCES Estados_Tarea(id_estado)
);

------------------------------------------------------------
-- 7️⃣ ENCUESTAS Y RESPUESTAS
------------------------------------------------------------

CREATE TABLE Encuestas (
    id_encuesta INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(100),
    descripcion NVARCHAR(255),
    dias_desde_ingreso INT,
    id_tipo INT NOT NULL,
    CONSTRAINT FK_Encuesta_Tipo FOREIGN KEY (id_tipo) REFERENCES Tipos_Encuesta(id_tipo)
);

CREATE TABLE Preguntas_Encuesta (
    id_pregunta INT IDENTITY(1,1) PRIMARY KEY,
    id_encuesta INT NOT NULL,
    texto_pregunta NVARCHAR(500),
    id_tipo_pregunta INT NOT NULL,
    opciones NVARCHAR(MAX),
    CONSTRAINT FK_Pregunta_Encuesta FOREIGN KEY (id_encuesta) REFERENCES Encuestas(id_encuesta),
    CONSTRAINT FK_Pregunta_Tipo FOREIGN KEY (id_tipo_pregunta) REFERENCES Tipos_Pregunta(id_tipo_pregunta)
);

CREATE TABLE Respuestas_Encuesta (
    id_respuesta INT IDENTITY(1,1) PRIMARY KEY,
    id_encuesta INT NOT NULL,
    id_empleado VARCHAR(10) NOT NULL,
    fecha_respuesta DATETIME DEFAULT GETDATE(),
    puntaje_general DECIMAL(5,2),
    comentarios NVARCHAR(MAX),
    CONSTRAINT FK_Resp_Encuesta FOREIGN KEY (id_encuesta) REFERENCES Encuestas(id_encuesta),
    CONSTRAINT FK_Resp_Emp FOREIGN KEY (id_empleado) REFERENCES Empleados(id_empleado)
);

CREATE TABLE Detalle_Respuestas (
    id_detalle INT IDENTITY(1,1) PRIMARY KEY,
    id_respuesta INT NOT NULL,
    id_pregunta INT NOT NULL,
    valor_numerico INT,
    valor_texto NVARCHAR(MAX),
    CONSTRAINT FK_Det_Resp FOREIGN KEY (id_respuesta) REFERENCES Respuestas_Encuesta(id_respuesta),
    CONSTRAINT FK_Det_Preg FOREIGN KEY (id_pregunta) REFERENCES Preguntas_Encuesta(id_pregunta)
);

------------------------------------------------------------
-- 8️⃣ HISTORIAL DE RIESGO Y ARCHIVOS
------------------------------------------------------------

CREATE TABLE Historial_Riesgo (
    id_historial INT IDENTITY(1,1) PRIMARY KEY,
    id_empleado VARCHAR(10),
    fecha_calculo DATETIME DEFAULT GETDATE(),
    id_riesgo INT NOT NULL,
    factores NVARCHAR(MAX),
    CONSTRAINT FK_RiesgoHist_Emp FOREIGN KEY (id_empleado) REFERENCES Empleados(id_empleado),
    CONSTRAINT FK_RiesgoHist_Riesgo FOREIGN KEY (id_riesgo) REFERENCES Riesgos_Rotacion(id_riesgo)
);

CREATE TABLE Archivos (
    id_archivo INT IDENTITY(1,1) PRIMARY KEY,
    id_empleado VARCHAR(10),
    nombre_archivo NVARCHAR(200),
    ruta NVARCHAR(255),
    fecha_subida DATETIME DEFAULT GETDATE(),
    subido_por INT,
    tipo NVARCHAR(50),
    CONSTRAINT FK_Archivo_Emp FOREIGN KEY (id_empleado) REFERENCES Empleados(id_empleado),
    CONSTRAINT FK_Archivo_Usuario FOREIGN KEY (subido_por) REFERENCES Usuarios(id_usuario)
);

------------------------------------------------------------
-- 9️⃣ CARGA DE DATOS BÁSICOS
------------------------------------------------------------

INSERT INTO Estados_Empleado (nombre) VALUES ('Activo'), ('Inactivo'), ('Baja');
INSERT INTO Riesgos_Rotacion (nivel) VALUES ('Bajo'), ('Medio'), ('Alto');
INSERT INTO Categorias_Checklist (nombre) VALUES ('Antes de ingreso'), ('Primer día'), ('Primera semana'), ('Primeros meses');
INSERT INTO Responsables_Checklist (nombre) VALUES ('RH'), ('Gerente'), ('Mentor'), ('Empleado');
INSERT INTO Tipos_Encuesta (nombre) VALUES ('PrimeraSemana'), ('Adaptacion2_5'), ('OnboardingFinal'), ('Examen');
INSERT INTO Tipos_Pregunta (nombre) VALUES ('Likert'), ('OpcionMultiple'), ('Texto');
INSERT INTO Estados_Tarea (nombre) VALUES ('Pendiente'), ('En proceso'), ('Completado');

INSERT INTO Roles (nombre_rol, descripcion) VALUES
('Administrador RH', 'Acceso completo al sistema'),
('Gerente', 'Visualiza KPIs del equipo'),
('Mentor', 'Acompaña onboarding'),
('Empleado', 'Consulta su avance');

INSERT INTO Departamentos (nombre) VALUES ('Recursos Humanos'), ('Producción'), ('Calidad'), ('Mantenimiento');
INSERT INTO Puestos (titulo, descripcion, nivel_competencia)
VALUES ('Analista RH', 'Gestión de personal y encuestas', 'Medio'),
       ('Gerente Producción', 'Control de línea y supervisión', 'Alto'),
       ('Técnico Mantenimiento', 'Soporte preventivo', 'Básico'),
       ('Supervisor Calidad', 'Control de estándares', 'Medio');

INSERT INTO Empleados (id_empleado, nombre, apellido_paterno, apellido_materno, fecha_ingreso, id_puesto, id_departamento, correo, telefono, id_estado, id_riesgo)
VALUES
('E001', 'Tania', 'Rodríguez', 'López', '2023-01-10', 1, 1, 'tania@brose.com', '4421112233', 1, 1),
('E002', 'Carlos', 'Guerra', 'Hernández', '2023-02-15', 2, 2, 'carlos@brose.com', '4425556677', 1, 1),
('E003', 'Ana', 'Lira', 'Martínez', '2024-06-01', 3, 4, 'ana@brose.com', '4429988776', 1, 2),
('E004', 'Luis', 'Pérez', 'Gómez', '2024-09-15', 4, 3, 'luis@brose.com', '4427776655', 1, 2);

UPDATE Empleados SET id_jefe = 'E002' WHERE id_empleado = 'E004';
UPDATE Empleados SET id_mentor = 'E001' WHERE id_empleado IN ('E003','E004');

INSERT INTO Usuarios (nombre_usuario, contrasena_hash, id_rol, id_empleado)
VALUES ('tania.rh', 'hash123', 1, 'E001'),
       ('carlos.gerente', 'hash456', 2, 'E002'),
       ('ana.mentor', 'hash789', 3, 'E003'),
       ('luis.op', 'hash321', 4, 'E004');

INSERT INTO Actividades_Checklist (descripcion, id_categoria, id_responsable)
VALUES ('Enviar correo de bienvenida', 1, 1),
       ('Asignar equipo de cómputo', 2, 3),
       ('Recorrido por planta', 2, 3),
       ('Registro en sistema', 3, 4);

INSERT INTO Estado_Checklist (id_empleado, id_actividad, id_estado)
VALUES ('E004', 1, 3), ('E004', 2, 3), ('E004', 3, 2);

INSERT INTO Planes_Entrenamiento (id_empleado, fecha_inicio, fecha_fin, id_estado)
VALUES ('E004', '2024-09-16', '2024-12-16', 2);

INSERT INTO Tareas_Entrenamiento (id_plan, descripcion, id_responsable, fecha_limite, id_estado)
VALUES (1, 'Capacitación en seguridad', 'E003', '2024-09-30', 3),
       (1, 'Entrenamiento técnico', 'E002', '2024-10-15', 2);

INSERT INTO Encuestas (nombre, descripcion, dias_desde_ingreso, id_tipo)
VALUES ('Encuesta Inicial', 'Evaluación semana 1', 7, 1);

INSERT INTO Preguntas_Encuesta (id_encuesta, texto_pregunta, id_tipo_pregunta)
VALUES (1, '¿Cómo calificarías la inducción inicial?', 1),
       (1, '¿Tu líder te brindó apoyo?', 1);

INSERT INTO Respuestas_Encuesta (id_encuesta, id_empleado, puntaje_general, comentarios)
VALUES (1, 'E004', 4.5, 'Muy buena experiencia');

INSERT INTO Detalle_Respuestas (id_respuesta, id_pregunta, valor_numerico, valor_texto)
VALUES (1, 1, 5, 'Excelente'), (1, 2, 4, 'Buena guía');

INSERT INTO Historial_Riesgo (id_empleado, id_riesgo, factores)
VALUES ('E004', 2, '{"asistencia":"98%","encuestas":"4.5"}');

INSERT INTO Archivos (id_empleado, nombre_archivo, ruta, subido_por, tipo)
VALUES ('E004', 'certificado_induccion.pdf', '/docs/E004.pdf', 1, 'Certificación');
GO