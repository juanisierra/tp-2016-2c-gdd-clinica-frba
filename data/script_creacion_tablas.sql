USE [GD2C2016]
GO
CREATE SCHEMA [ELIMINAR_CAR] AUTHORIZATION [gd]
GO
CREATE TABLE ELIMINAR_CAR.Tipo_Cancelacion (
id_tipo SMALLINT PRIMARY KEY IDENTITY(1,1),
descripcion VARCHAR(30));

CREATE TABLE ELIMINAR_CAR.Tipo_Especialidad (
id_tipo_especialidad INT PRIMARY KEY,
descripcion VARCHAR(50));



CREATE TABLE ELIMINAR_CAR.Familia (
id_familia BIGINT PRIMARY KEY IDENTITY(1,1),
n_familiares_a_cargo INT);

CREATE TABLE ELIMINAR_CAR.Persona (
id_persona BIGINT PRIMARY KEY IDENTITY(1,1),
tipo_doc INT DEFAULT 1,  --Cambiar
numero_doc DECIMAL(8,0),
nombre VARCHAR(40),
apellido VARCHAR(40),
direccion VARCHAR(100),
telefono BIGINT,
mail VARCHAR(60),
fecha_nac DATE,
estado_civil VARCHAR(12) CHECK(estado_civil IN ('soltero','casado','viudo','concubinato','divorciado')),
sexo CHAR CHECK(sexo IN ('m','f')));

CREATE TABLE ELIMINAR_CAR.Rol (
id_rol SMALLINT PRIMARY KEY IDENTITY(1,1),
nombre_rol VARCHAR(20),
habilitado BIT);

CREATE TABLE ELIMINAR_CAR.Usuario (
id_usuario VARCHAR(20) PRIMARY KEY,
contrasenia BINARY(32),
intentos_fallidos SMALLINT,
habilitado BIT,
id_persona BIGINT,
FOREIGN KEY (id_persona) REFERENCES ELIMINAR_CAR.Persona(id_persona));

CREATE TABLE ELIMINAR_CAR.Planes (
id_plan INT PRIMARY KEY,
desc_plan VARCHAR(50),
precio_bono_consulta INT);

CREATE TABLE ELIMINAR_CAR.Roles_por_usuarios (
id_rol SMALLINT,
id_usuario VARCHAR(20),
FOREIGN KEY (id_rol) REFERENCES ELIMINAR_CAR.Rol(id_rol),
FOREIGN KEY(id_usuario) REFERENCES ELIMINAR_CAR.Usuario(id_usuario),
PRIMARY KEY(id_rol,id_usuario));

CREATE TABLE ELIMINAR_CAR.Funcionalidad (
id_funcionalidad SMALLINT PRIMARY KEY IDENTITY(1,1),
descripcion VARCHAR(30));

CREATE TABLE ELIMINAR_CAR.Funcionalidades_por_rol (
id_rol SMALLINT,
id_funcionalidad SMALLINT,
FOREIGN KEY (id_rol) REFERENCES ELIMINAR_CAR.Rol(id_rol),
FOREIGN KEY(id_funcionalidad) REFERENCES ELIMINAR_CAR.Funcionalidad(id_funcionalidad),
PRIMARY KEY(id_rol,id_funcionalidad));

CREATE TABLE ELIMINAR_CAR.Especialidad (
id_especialidad INT PRIMARY KEY,
desc_especialidad VARCHAR(100),
id_tipo_especialidad INT,
FOREIGN KEY (id_tipo_especialidad) REFERENCES ELIMINAR_CAR.Tipo_Especialidad(id_tipo_especialidad));

CREATE TABLE ELIMINAR_CAR.Profesional (
matricula BIGINT PRIMARY KEY,
id_persona BIGINT,
FOREIGN KEY (id_persona) REFERENCES ELIMINAR_CAR.Persona(id_persona));

CREATE TABLE ELIMINAR_CAR.Especialidad_por_profesional (
id_especialidad INT,
matricula BIGINT,
PRIMARY KEY(id_especialidad,matricula),
FOREIGN KEY (matricula) REFERENCES ELIMINAR_CAR.Profesional(matricula),
FOREIGN KEY (id_especialidad) REFERENCES ELIMINAR_CAR.Especialidad(id_especialidad));

CREATE TABLE ELIMINAR_CAR.Agenda_Diaria (
id_agenda BIGINT PRIMARY KEY,
dia CHAR CHECK (dia IN ('l','m','x','j','v','s','d')),
matricula BIGINT,
hora_desde TIME,
hora_hasta TIME,
id_especialidad INT,
FOREIGN KEY (matricula) REFERENCES ELIMINAR_CAR.Profesional(matricula),
FOREIGN KEY (id_especialidad) REFERENCES ELIMINAR_CAR.Especialidad(id_especialidad));

CREATE TABLE ELIMINAR_CAR.Afiliado (
id_afiliado BIGINT PRIMARY KEY,
id_persona BIGINT,
id_plan INT,
id_familia BIGINT,
familiares_a_cargo INT,
activo BIT,
fecha_baja DATE,
num_consulta_actual BIGINT
FOREIGN KEY (id_persona) REFERENCES ELIMINAR_CAR.Persona(id_persona),
FOREIGN KEY (id_plan) REFERENCES ELIMINAR_CAR.Planes(id_plan),
FOREIGN KEY (id_familia) REFERENCES ELIMINAR_CAR.Familia(id_familia));

CREATE TABLE ELIMINAR_CAR.Bono (
id_bono BIGINT PRIMARY KEY,
id_afiliado_comprador BIGINT,
id_afiliado_consumidor BIGINT,
num_consulta BIGINT,
id_plan INT,
utilizado BIT,
precio INT,
fecha_compra DATETIME,
fecha_uso DATETIME,
FOREIGN KEY (id_afiliado_comprador) REFERENCES ELIMINAR_CAR.Afiliado(id_afiliado),
FOREIGN KEY (id_afiliado_consumidor) REFERENCES ELIMINAR_CAR.Afiliado(id_afiliado),
FOREIGN KEY (id_plan) REFERENCES ELIMINAR_CAR.Planes(id_plan));

CREATE TABLE ELIMINAR_CAR.Turno (
id_turno BIGINT PRIMARY KEY,
fecha_estipulada DATETIME,
matricula BIGINT,
id_afiliado BIGINT,
id_bono BIGINT,
momento_llegada DATETIME,
id_especialidad INT,
activo BIT,
FOREIGN KEY (id_afiliado) REFERENCES ELIMINAR_CAR.Afiliado(id_afiliado),
FOREIGN KEY (id_bono) REFERENCES ELIMINAR_CAR.Bono(id_bono),
FOREIGN KEY (matricula) REFERENCES ELIMINAR_CAR.Profesional(matricula),
FOREIGN KEY (id_especialidad) REFERENCES ELIMINAR_CAR.Especialidad(id_especialidad));

CREATE TABLE ELIMINAR_CAR.Cancelacion (
id_cancelacion BIGINT PRIMARY KEY IDENTITY(1,1),
id_turno BIGINT,
id_usuario VARCHAR(20),
id_tipo SMALLINT,
motivo VARCHAR(100),
FOREIGN KEY (id_turno) REFERENCES ELIMINAR_CAR.Turno(id_turno),
FOREIGN KEY (id_usuario) REFERENCES ELIMINAR_CAR.Usuario(id_usuario),
FOREIGN KEY (id_tipo) REFERENCES ELIMINAR_CAR.Tipo_Cancelacion(id_tipo));

CREATE TABLE ELIMINAR_CAR.Consulta (
id_consulta BIGINT PRIMARY KEY IDENTITY(1,1),
fecha_consulta DATETIME,
id_turno BIGINT,
sintomas VARCHAR(100),
diagnostico VARCHAR(100),
FOREIGN KEY (id_turno) REFERENCES ELIMINAR_CAR.Turno(id_turno));

CREATE TABLE ELIMINAR_CAR.Rango_Atencion (
id_rango BIGINT PRIMARY KEY IDENTITY(1,1),
matricula BIGINT,
fecha_desde DATE,
fecha_hasta DATE,
FOREIGN KEY (matricula) REFERENCES ELIMINAR_CAR.Profesional(matricula));

CREATE TABLE ELIMINAR_CAR.Cambio_de_Plan (
id_cambio_plan BIGINT PRIMARY KEY IDENTITY(1,1),
id_afiliado BIGINT,
id_plan_anterior INT,
id_plan_nuevo INT,
fecha_cambio DATE,
motivo_cambio VARCHAR(100),
FOREIGN KEY (id_plan_anterior) REFERENCES ELIMINAR_CAR.Planes(id_plan),
FOREIGN KEY (id_plan_nuevo) REFERENCES ELIMINAR_CAR.Planes(id_plan),
FOREIGN KEY (id_afiliado) REFERENCES ELIMINAR_CAR.Afiliado(id_afiliado));