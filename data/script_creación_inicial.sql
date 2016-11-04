CREATE SCHEMA [ELIMINAR_CAR] AUTHORIZATION [gd]
GO

CREATE TABLE ELIMINAR_CAR.Tipo_Especialidad (
id_tipo_especialidad INT PRIMARY KEY,
descripcion VARCHAR(50));



CREATE TABLE ELIMINAR_CAR.Familia (
id_familia BIGINT PRIMARY KEY IDENTITY(1,1),
n_familiares_a_cargo INT);


CREATE TABLE ELIMINAR_CAR.Rol (
id_rol SMALLINT PRIMARY KEY IDENTITY(1,1),
nombre_rol VARCHAR(20),
habilitado BIT);

CREATE TABLE ELIMINAR_CAR.Usuario (
id_usuario VARCHAR(20) PRIMARY KEY,
contrasenia BINARY(32),
intentos_fallidos SMALLINT,
habilitado BIT);

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
tipo_doc INT DEFAULT 1,  
numero_doc DECIMAL(8,0),
nombre VARCHAR(40),
apellido VARCHAR(40),
direccion VARCHAR(100),
telefono BIGINT,
mail VARCHAR(60),
fecha_nac DATE,
usuario VARCHAR(20),
FOREIGN KEY (usuario) REFERENCES ELIMINAR_CAR.Usuario(id_usuario),
CONSTRAINT doc_unico_profesional UNIQUE(tipo_doc,numero_doc));

CREATE TABLE ELIMINAR_CAR.Especialidad_por_profesional (
id_especialidad INT,
matricula BIGINT,
PRIMARY KEY(id_especialidad,matricula),
FOREIGN KEY (matricula) REFERENCES ELIMINAR_CAR.Profesional(matricula),
FOREIGN KEY (id_especialidad) REFERENCES ELIMINAR_CAR.Especialidad(id_especialidad));

CREATE TABLE ELIMINAR_CAR.Agenda_Diaria (
id_agenda BIGINT IDENTITY(1,1) PRIMARY KEY,
dia INT, --0 domingo...
matricula BIGINT,
hora_desde TIME,
hora_hasta TIME,
id_especialidad INT,
FOREIGN KEY (matricula) REFERENCES ELIMINAR_CAR.Profesional(matricula),
FOREIGN KEY (id_especialidad) REFERENCES ELIMINAR_CAR.Especialidad(id_especialidad));

CREATE TABLE ELIMINAR_CAR.Afiliado (
id_afiliado BIGINT PRIMARY KEY,
tipo_doc INT DEFAULT 1,  --Cambiar
numero_doc DECIMAL(8,0),
nombre VARCHAR(40),
apellido VARCHAR(40),
direccion VARCHAR(100),
telefono BIGINT,
mail VARCHAR(60),
fecha_nac DATE,
estado_civil INT CHECK(estado_civil>=0 AND estado_civil<=4), --Casado, Soltero, Viudo, Concubinato, Divorciado
sexo INT CHECK(sexo>=0 AND sexo<=2) DEFAULT 0, --NoEspecificado, Masculino, Femenino
id_plan INT,
id_familia BIGINT,
familiares_a_cargo INT,
activo BIT,
fecha_baja DATE,
num_consulta_actual BIGINT,
usuario VARCHAR(20),
FOREIGN KEY (usuario) REFERENCES ELIMINAR_CAR.Usuario(id_usuario),
FOREIGN KEY (id_plan) REFERENCES ELIMINAR_CAR.Planes(id_plan),
FOREIGN KEY (id_familia) REFERENCES ELIMINAR_CAR.Familia(id_familia),
CONSTRAINT doc_unico UNIQUE(tipo_doc,numero_doc));

CREATE TABLE ELIMINAR_CAR.Compra_Bonos (
id_compra BIGINT PRIMARY KEY IDENTITY(1,1),
id_afiliado_comprador BIGINT,
precio_total INT,
fecha_compra DATETIME,
cantidad_bonos INT,
FOREIGN KEY (id_afiliado_comprador) REFERENCES ELIMINAR_CAR.Afiliado(id_afiliado));

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
id_compra BIGINT,
FOREIGN KEY (id_compra) REFERENCES ELIMINAR_CAR.Compra_Bonos(id_compra),
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

CREATE TABLE ELIMINAR_CAR.Cancelacion_Afiliado (
id_cancelacion BIGINT PRIMARY KEY IDENTITY(1,1),
id_turno BIGINT,
id_afiliado BIGINT,
motivo VARCHAR(200),
FOREIGN KEY (id_turno) REFERENCES ELIMINAR_CAR.Turno(id_turno),
FOREIGN KEY (id_afiliado) REFERENCES ELIMINAR_CAR.Afiliado(id_afiliado));

CREATE TABLE ELIMINAR_CAR.Cancelacion_Profesional (
id_cancelacion BIGINT PRIMARY KEY IDENTITY(1,1),
matricula BIGINT,
motivo VARCHAR(200),
fecha_desde DATE,
fecha_hasta DATE,
FOREIGN KEY (matricula) REFERENCES ELIMINAR_CAR.Profesional(matricula));

CREATE TABLE ELIMINAR_CAR.Consulta (
id_consulta BIGINT PRIMARY KEY IDENTITY(1,1),
fecha_consulta DATETIME,
id_turno BIGINT,
sintomas VARCHAR(202),
diagnostico VARCHAR(202),
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
GO

--Migracion
CREATE PROCEDURE ELIMINAR_CAR.Migrar_Bonos
AS
DECLARE @Afiliado_id BIGINT

DECLARE afiliadoActual CURSOR FOR
SELECT id_afiliado
FROM ELIMINAR_CAR.Afiliado

OPEN afiliadoActual
FETCH Next FROM afiliadoActual INTO @Afiliado_id
WHILE @@FETCH_STATUS = 0 BEGIN
INSERT INTO ELIMINAR_CAR.Bono
(id_bono,id_plan,id_afiliado_consumidor,id_afiliado_comprador,utilizado,precio,num_consulta,fecha_compra,fecha_uso)
SELECT id_bono,id_plan,id_afiliado_consumidor,id_afiliado_comprador,utilizado,precio,row_number() OVER (ORDER BY id_bono),fecha_compra,fecha_uso
FROM ELIMINAR_CAR.#Bonos
WHERE id_afiliado_comprador=@Afiliado_id

UPDATE ELIMINAR_CAR.Afiliado
SET num_consulta_actual=(
	select Max(num_consulta)
	FROM ELIMINAR_CAR.Bono
	WHERE id_afiliado_comprador=@Afiliado_id)
WHERE id_afiliado=@Afiliado_id

FETCH NEXT FROM afiliadoActual INTO @Afiliado_id
END
CLOSE afiliadoActual
DEALLOCATE afiliadoActual
DROP TABLE ELIMINAR_CAR.#Bonos
GO


--Planes
INSERT INTO ELIMINAR_CAR.Planes
(id_plan,desc_plan,precio_bono_consulta)
SELECT DISTINCT plan_med_codigo,plan_med_descripcion,plan_med_precio_bono_consulta
from gd_esquema.Maestra
WHERE plan_med_codigo is not NULL

--Tipo Especialidad
INSERT INTO ELIMINAR_CAR.Tipo_Especialidad
Select distinct Tipo_Especialidad_Codigo,Tipo_Especialidad_descripcion
from gd_esquema.maestra
where Tipo_Especialidad_Codigo Is NOT NULL

--Especialidad
INSERT INTO ELIMINAR_CAR.especialidad
(id_especialidad,desc_especialidad,id_tipo_especialidad)
SELECT DISTINCT m.especialidad_codigo,m.especialidad_descripcion,t.id_tipo_especialidad
FROM gd_esquema.maestra m JOIN ELIMINAR_CAR.Tipo_Especialidad t on m.Tipo_Especialidad_Codigo= t.id_tipo_especialidad
WHERE m.Especialidad_Codigo IS NOT NULL

--Familias
INSERT INTO ELIMINAR_CAR.FAMILIA
(n_familiares_a_cargo)
SELECT 0
FROM gd_esquema.Maestra
GROUP BY Paciente_DNI

--Afiliados		Usamos row number para generar los numeros de las familias
INSERT INTO eliminar_car.afiliado
(numero_doc,tipo_doc,nombre,apellido,direccion,telefono,mail,fecha_nac,estado_civil,id_afiliado,id_plan,id_familia,familiares_a_cargo,activo)
SELECT  DISTINCT m.Paciente_Dni,1,m.Paciente_Nombre,m.Paciente_Apellido,m.Paciente_Direccion,m.Paciente_Telefono,m.Paciente_Mail,m.Paciente_Fecha_nac,1,(row_number() OVER (ORDER BY m.Paciente_Dni))*100+1,m.Plan_Med_Codigo,row_number() OVER (ORDER BY m.Paciente_Dni),0,1
FROM gd_esquema.maestra m 
GROUP BY m.Paciente_Dni,m.Paciente_Nombre,m.Paciente_Apellido,m.Paciente_Direccion,m.Paciente_Telefono,m.Paciente_Mail,m.Paciente_Fecha_nac,m.Plan_Med_Codigo

--Medicos  --Matricula autogenerada con id_persona
INSERT INTO eliminar_car.profesional
(matricula,numero_doc,tipo_doc,nombre,apellido,direccion,telefono,mail,fecha_nac)
SELECT DISTINCT Medico_Dni,Medico_Dni,1,Medico_Nombre,Medico_Apellido,Medico_Direccion,Medico_Telefono,Medico_Mail,Medico_Fecha_Nac
FROM gd_esquema.maestra
WHERE Medico_Dni is not NULL
--Especialidad por profesional
INSERT INTO ELIMINAR_CAR.especialidad_por_profesional
(matricula,id_especialidad)
select	matricula,Especialidad_Codigo
FROM gd_esquema.maestra m  JOIN ELIMINAR_CAR.Profesional a on (m.Medico_Dni=a.numero_doc)
WHERE matricula is not null
group by matricula,Especialidad_Codigo 

CREATE TABLE ELIMINAR_CAR.#Bonos (
id_bono BIGINT PRIMARY KEY,
id_afiliado_comprador BIGINT,
id_afiliado_consumidor BIGINT,
id_plan INT,
utilizado BIT,
precio INT,
fecha_compra DATETIME,
fecha_uso DATETIME,
FOREIGN KEY (id_afiliado_comprador) REFERENCES ELIMINAR_CAR.Afiliado(id_afiliado),
FOREIGN KEY (id_afiliado_consumidor) REFERENCES ELIMINAR_CAR.Afiliado(id_afiliado),
FOREIGN KEY (id_plan) REFERENCES ELIMINAR_CAR.Planes(id_plan));

--Todos los bonos comprados y usados
INSERT INTO ELIMINAR_CAR.#Bonos
(id_bono,id_plan,id_afiliado_consumidor,id_afiliado_comprador,utilizado,precio,fecha_compra,fecha_uso)
SELECT distinct m.Bono_Consulta_Numero id_bono,m.plan_med_codigo plan_comprado,a.id_afiliado consumidor,bonos_comprados_sin_usar.comprador,1,bonos_comprados_sin_usar.Plan_Med_Precio_Bono_Consulta,bonos_comprados_sin_usar.Compra_Bono_Fecha,m.Bono_Consulta_Fecha_Impresion
FROM gd_esquema.Maestra m  JOIN ELIMINAR_CAR.Afiliado a on (m.Paciente_Dni= a.numero_doc) JOIN (
select m2.bono_consulta_numero, a2.id_afiliado comprador,m2.Plan_Med_Precio_Bono_Consulta,m2.Compra_Bono_Fecha					--bonos comprados sin usar
FROM gd_esquema.Maestra m2 JOIN ELIMINAR_CAR.Afiliado a2 on(m2.Paciente_Dni= a2.numero_doc)
WHERE m2.Medico_DNI is NULL
) bonos_comprados_sin_usar ON (bonos_comprados_sin_usar.Bono_consulta_numero=m.Bono_Consulta_Numero)
WHERE m.Bono_Consulta_Numero is not null AND Medico_Dni is NOT NULL
UNION  --Bonos no usados
(
SELECT DISTINCT m.Bono_Consulta_Numero,m.Plan_Med_Codigo,NULL,a.id_afiliado,0,m.Plan_Med_Precio_Bono_Consulta,bonos_comprados_sin_usar.Compra_Bono_Fecha,m.Bono_Consulta_Fecha_Impresion--TODOS LOS BONOS
FROM gd_esquema.Maestra m JOIN ELIMINAR_CAR.Afiliado a on (m.Paciente_Dni=a.numero_doc) JOIN (
select m2.bono_consulta_numero, a2.id_afiliado comprador,m2.Plan_Med_Precio_Bono_Consulta,m2.Compra_Bono_Fecha					
FROM gd_esquema.Maestra m2 JOIN ELIMINAR_CAR.Afiliado a2 on(m2.Paciente_Dni=a2.numero_doc)
WHERE m2.Medico_DNI is NULL
) bonos_comprados_sin_usar ON (bonos_comprados_sin_usar.Bono_consulta_numero=m.Bono_Consulta_Numero)
WHERE m.Bono_Consulta_Numero is not null
EXCEPT
SELECT  DISTINCT m.Bono_Consulta_Numero,m.Plan_Med_Codigo,NULL,a.id_afiliado,0,m.Plan_Med_Precio_Bono_Consulta,bonos_comprados_sin_usar.Compra_Bono_Fecha,m.Bono_Consulta_Fecha_Impresion --BONOS USADOS
FROM gd_esquema.Maestra m JOIN ELIMINAR_CAR.Afiliado a on (m.Paciente_Dni=a.numero_doc) JOIN (
select m2.bono_consulta_numero, a2.id_afiliado comprador,m2.Plan_Med_Precio_Bono_Consulta,m2.Compra_Bono_Fecha					
FROM gd_esquema.Maestra m2 JOIN ELIMINAR_CAR.Afiliado a2 on(m2.Paciente_Dni=a2.numero_doc)
WHERE m2.Medico_DNI is NULL
) bonos_comprados_sin_usar ON (bonos_comprados_sin_usar.Bono_consulta_numero=m.Bono_Consulta_Numero)
WHERE m.Bono_Consulta_Numero is not null AND m.Medico_Dni IS NOT NULL and m.Compra_Bono_Fecha is   null
)
EXEC ELIMINAR_CAR.Migrar_Bonos
DROP PROCEDURE ELIMINAR_CAR.Migrar_Bonos;
--Compras bonos
INSERT INTO ELIMINAR_CAR.Compra_Bonos --Suponemos que las compras en un mismo dia son la misma
(id_afiliado_comprador,precio_total,fecha_compra,cantidad_bonos)
SELECT id_afiliado_comprador,sum(precio),fecha_compra,count(id_bono)
FROM ELIMINAR_CAR.Bono
GROUP BY id_afiliado_comprador,fecha_compra
--Poner los ids de cada compra en los bonos
MERGE INTO ELIMINAR_CAR.Bono b
   USING ELIMINAR_CAR.Compra_Bonos c 
      ON c.fecha_compra = b.fecha_compra AND c.id_afiliado_comprador=b.id_afiliado_comprador
WHEN MATCHED THEN
   UPDATE 
      SET b.id_compra = c.id_compra;
--Turnos atendidos
INSERT INTO ELIMINAR_CAR.Turno
(id_turno,fecha_estipulada,matricula,id_afiliado,id_bono,momento_llegada,id_especialidad,activo)
SELECT DISTINCT m.Turno_Numero, m.Turno_Fecha,pr.matricula,a.id_afiliado,m.Bono_Consulta_Numero,m.Turno_Fecha,m.Especialidad_Codigo,1
FROM gd_esquema.Maestra m JOIN ELIMINAR_CAR.Afiliado a ON (a.numero_doc=m.Paciente_Dni) JOIN ELIMINAR_CAR.Profesional pr on (m.Medico_Dni=pr.numero_doc)
WHERE m.Turno_Numero is not null and Bono_consulta_numero is not null

--Consultas
INSERT INTO ELIMINAR_CAR.Consulta
(id_turno,fecha_consulta,sintomas,diagnostico)
SELECT DISTINCT m.Turno_Numero, m.Turno_Fecha,Consulta_Sintomas,Consulta_Enfermedades
FROM gd_esquema.Maestra m
WHERE m.Turno_Numero is not null and Consulta_Sintomas is not null

--Usuarios   --El usuario es apellido, primera letra del nombre y ultimos 5 digitos del dni, la contraseña es el numero de documento
INSERT INTO ELIMINAR_CAR.Usuario
(id_usuario,contrasenia,intentos_fallidos,habilitado)
SELECT  distinct REPLACE(apellido+Left(nombre,1)+Right(numero_doc,5), ' ', ''),HASHBYTES('SHA2_256',CONVERT(varchar(10), numero_doc)),0,1
FROM ELIMINAR_CAR.Afiliado
UNION
SELECT distinct REPLACE(apellido+Left(nombre,1)+Right(numero_doc,5), ' ', ''),HASHBYTES('SHA2_256',CONVERT(varchar(10), numero_doc)),0,1
FROM ELIMINAR_CAR.Profesional;


--Pone los id de usuario en afiliados
MERGE INTO ELIMINAR_CAR.Afiliado a
   USING ELIMINAR_CAR.Usuario u 
      ON u.id_usuario = REPLACE(a.apellido+Left(a.nombre,1)+Right(a.numero_doc,5), ' ', '')
WHEN MATCHED THEN
   UPDATE 
      SET a.usuario = u.id_usuario;
--pone los id de usuario en profesionales
MERGE INTO ELIMINAR_CAR.Profesional a
   USING ELIMINAR_CAR.Usuario u 
      ON u.id_usuario = REPLACE(a.apellido+Left(a.nombre,1)+Right(a.numero_doc,5), ' ', '')
WHEN MATCHED THEN
   UPDATE 
      SET a.usuario =  u.id_usuario;

--Insertar roles estandar
INSERT INTO ELIMINAR_CAR.Rol (nombre_rol,habilitado) VALUES ('Afiliado',1)
INSERT INTO ELIMINAR_CAR.Rol (nombre_rol,habilitado) VALUES ('Administrativo',1)
INSERT INTO ELIMINAR_CAR.Rol (nombre_rol,habilitado) VALUES ('Profesional',1)


--Dar a los usuarios de afiliados el rol de afiliado y a los profesionales de profesional
INSERT INTO ELIMINAR_CAR.Roles_por_Usuarios
(id_usuario,id_rol)
SELECT id_usuario,1 --Afiliado
FROM ELIMINAR_CAR.Afiliado a JOIN ELIMINAR_CAR.Usuario u on (u.id_usuario=a.usuario)
UNION
SELECT id_usuario,3 --Profesional
FROM ELIMINAR_CAR.Profesional p JOIN ELIMINAR_CAR.Usuario u on (u.id_usuario=p.usuario)

--Insercion de Funcionalidades
INSERT INTO ELIMINAR_CAR.Funcionalidad (descripcion) VALUES ('ABM Rol')
INSERT INTO ELIMINAR_CAR.Funcionalidad (descripcion) VALUES ('Registro Usuario')
INSERT INTO ELIMINAR_CAR.Funcionalidad (descripcion) VALUES ('ABM Afiliado')
INSERT INTO ELIMINAR_CAR.Funcionalidad (descripcion) VALUES ('ABM Profesional')
INSERT INTO ELIMINAR_CAR.Funcionalidad (descripcion) VALUES ('ABM Especialidades Medicas')
INSERT INTO ELIMINAR_CAR.Funcionalidad (descripcion) VALUES ('ABM Planes')
INSERT INTO ELIMINAR_CAR.Funcionalidad (descripcion) VALUES ('Registar Agendas')
INSERT INTO ELIMINAR_CAR.Funcionalidad (descripcion) VALUES ('Compra Bono')
INSERT INTO ELIMINAR_CAR.Funcionalidad (descripcion) VALUES ('Pedir Turno')
INSERT INTO ELIMINAR_CAR.Funcionalidad (descripcion) VALUES ('Registrar Llegada Atencion')
INSERT INTO ELIMINAR_CAR.Funcionalidad (descripcion) VALUES ('Registrar Resultado Atencion')
INSERT INTO ELIMINAR_CAR.Funcionalidad (descripcion) VALUES ('Cancelar Atencion')
INSERT INTO ELIMINAR_CAR.Funcionalidad (descripcion) VALUES ('Ver Listados Estadisticos')

--Darle funcionalidades al afiliado
--Darle Comprar Bonos
INSERT INTO ELIMINAR_CAR.Funcionalidades_por_rol
(id_rol,id_funcionalidad)
Values (1,8);
--Darle Pedir Turno
INSERT INTO ELIMINAR_CAR.Funcionalidades_por_rol
(id_rol,id_funcionalidad)
Values (1,9);
--Darle Cancelar Atencion
INSERT INTO ELIMINAR_CAR.Funcionalidades_por_rol
(id_rol,id_funcionalidad)
Values (1,12);

--Darle funcionalidades al Administrativo
--ABM ROL
INSERT INTO ELIMINAR_CAR.Funcionalidades_por_rol
(id_rol,id_funcionalidad) values (2,1);
--ABM Afiliado
INSERT INTO ELIMINAR_CAR.Funcionalidades_por_rol
(id_rol,id_funcionalidad) values (2,3);
--Registar Agenda
INSERT INTO ELIMINAR_CAR.Funcionalidades_por_rol
(id_rol,id_funcionalidad) values (2,7);
--Comprar bono
INSERT INTO ELIMINAR_CAR.Funcionalidades_por_rol
(id_rol,id_funcionalidad) values (2,8);
--Registar Llegada
INSERT INTO ELIMINAR_CAR.Funcionalidades_por_rol
(id_rol,id_funcionalidad) values (2,10);
--Listado Estadistico
INSERT INTO ELIMINAR_CAR.Funcionalidades_por_rol
(id_rol,id_funcionalidad) values (2,13);

--Darle Funcionalidades a Profesional
--Registrar Agenda
INSERT INTO ELIMINAR_CAR.Funcionalidades_por_rol
(id_rol,id_funcionalidad)
Values (3,7);
--Registro diagnostico
INSERT INTO ELIMINAR_CAR.Funcionalidades_por_rol
(id_rol,id_funcionalidad)
Values (3,11);
--Cancelacion
INSERT INTO ELIMINAR_CAR.Funcionalidades_por_rol
(id_rol,id_funcionalidad)
Values (3,12);
GO

--Stored procedures

CREATE PROCEDURE ELIMINAR_CAR.matricula_por_usuario(@usuario varchar(20),@matricula BIGINT OUTPUT)
AS  
SELECT TOP 1 @matricula=matricula FROM ELIMINAR_CAR.Profesional p JOIN ELIMINAR_CAR.Usuario u on (p.usuario = u.id_usuario) WHERE id_usuario=@usuario
GO  

CREATE PROCEDURE ELIMINAR_CAR.afiliado_por_usuario(@usuario varchar(20),@afiliado BIGINT OUTPUT)
AS  
SELECT TOP 1 @afiliado=p.id_afiliado FROM ELIMINAR_CAR.Afiliado p JOIN ELIMINAR_CAR.Usuario u on (p.usuario = u.id_usuario) WHERE id_usuario=@usuario
GO  

CREATE PROCEDURE ELIMINAR_CAR.proximoIdTurno
AS
DECLARE @retorno BIGINT
 SELECT @retorno = MAX(id_turno)+1 FROM ELIMINAR_CAR.Turno
 RETURN @retorno
GO

CREATE PROCEDURE ELIMINAR_CAR.insertarNuevoTurno (@fecha DATETIME,@matricula BIGINT,@id_afiliado BIGINT,@id_especialidad INT)
AS
DECLARE  @prox_id BIGINT
EXEC @prox_id = ELIMINAR_CAR.proximoIdTurno
--Devuelve las filas afectadas
 INSERT INTO ELIMINAR_CAR.Turno (id_turno,fecha_estipulada,matricula,id_afiliado,id_especialidad,activo) 
VALUES(@prox_id,@fecha,@matricula,@id_afiliado,@id_especialidad,1)
GO

CREATE PROCEDURE ELIMINAR_CAR.turnosFuturosPorProfesionalYEspecialidad (@matricula BIGINT,@id_especialidad INT)
AS
SELECT id_turno,fecha_estipulada,matricula,t.id_afiliado,id_bono,momento_llegada,t.id_especialidad,t.activo,e.desc_especialidad,a.nombre,a.apellido FROM ELIMINAR_CAR.Turno t JOIN ELIMINAR_CAR.Afiliado a ON(a.id_afiliado=t.id_afiliado) JOIN ELIMINAR_CAR.Especialidad e ON (t.id_especialidad=e.id_especialidad) WHERE fecha_estipulada>=GETDATE() AND matricula=@matricula  AND t.id_especialidad=@id_especialidad
GO

CREATE PROCEDURE ELIMINAR_CAR.turnosDelDiaPorProfesional (@matricula BIGINT,@fecha DATETIME)
AS
SELECT id_turno,fecha_estipulada,matricula,t.id_afiliado,id_bono,momento_llegada,t.id_especialidad,t.activo,e.desc_especialidad,a.nombre,a.apellido FROM ELIMINAR_CAR.Turno t JOIN ELIMINAR_CAR.Afiliado a ON(a.id_afiliado=t.id_afiliado) JOIN ELIMINAR_CAR.Especialidad e ON (t.id_especialidad=e.id_especialidad)  WHERE CAST(fecha_estipulada AS DATE)=CAST(@fecha AS DATE) AND @matricula=matricula
GO
--Trae todos los bonos disponibles para un afiliado
CREATE PROCEDURE ELIMINAR_CAR.bonosDisponibles(@id_afiliado BIGINT)
AS
SELECT DISTINCT id_bono FROM ELIMINAR_CAR.Bono b JOIN ELIMINAR_CAR.Afiliado a ON (b.id_afiliado_comprador=a.id_afiliado) JOIN ELIMINAR_CAR.Familia f on(a.id_familia= f.id_familia)
WHERE id_afiliado_consumidor IS NULL AND f.id_familia=(SELECT id_familia FROM ELIMINAR_CAR.Afiliado WHERE id_afiliado=@id_afiliado) AND b.id_plan=(SELECT id_plan FROM ELIMINAR_CAR.Afiliado WHERE id_afiliado=@id_afiliado)
GO

--RegistrarLlegada
CREATE PROCEDURE ELIMINAR_CAR.registrarLlegada(@id_afiliado BIGINT ,@id_bono BIGINT ,@id_turno BIGINT,@fecha_llegada DATETIME)
AS
UPDATE ELIMINAR_CAR.Bono
SET id_afiliado_consumidor=@id_afiliado, utilizado=1 ,fecha_uso=@fecha_llegada,num_consulta=(SELECT TOP 1 num_consulta_actual+1 FROM ELIMINAR_CAR.Afiliado WHERE id_afiliado=@id_afiliado)
WHERE id_bono=@id_bono

UPDATE ELIMINAR_CAR.Turno
SET id_bono=@id_bono,momento_llegada=@fecha_llegada
WHERE id_turno=@id_turno

UPDATE ELIMINAR_CAR.Afiliado
SET num_consulta_actual=num_consulta_actual+1
GO

CREATE PROCEDURE ELIMINAR_CAR.turnosParaDiagnosticar (@matricula BIGINT,@fecha DATETIME)
AS
SELECT t.id_turno,fecha_estipulada,matricula,t.id_afiliado,id_bono,momento_llegada,t.id_especialidad,t.activo,e.desc_especialidad,a.nombre,a.apellido FROM ELIMINAR_CAR.Turno t LEFT JOIN ELIMINAR_CAR.Consulta c on (c.id_turno=t.id_turno) JOIN ELIMINAR_CAR.Afiliado a ON(a.id_afiliado=t.id_afiliado) JOIN ELIMINAR_CAR.Especialidad e ON (t.id_especialidad=e.id_especialidad)  WHERE t.momento_llegada IS NOT NULL AND c.id_consulta IS NULL AND CAST(fecha_estipulada AS DATE)=CAST(@fecha AS DATE) AND @matricula=matricula
GO

CREATE PROCEDURE ELIMINAR_CAR.registrarConsulta (@fecha DATETIME,@turno BIGINT,@sintomas VARCHAR(202),@diagnostico VARCHAR(202))
AS
INSERT INTO ELIMINAR_CAR.Consulta
(fecha_consulta,id_turno,sintomas,diagnostico)
VALUES (@fecha,@turno,@sintomas,@diagnostico)
GO

CREATE PROCEDURE ELIMINAR_CAR.turnosCancelablesAfiliado (@id_afiliado BIGINT,@fecha DATETIME)
AS
SELECT t.id_turno,fecha_estipulada,t.matricula,p.nombre,p.apellido,t.id_especialidad,e.desc_especialidad FROM ELIMINAR_CAR.Turno t JOIN ELIMINAR_CAR.Especialidad e ON (t.id_especialidad=e.id_especialidad)  JOIN ELIMINAR_CAR.Profesional p on (t.matricula=p.matricula) WHERE t.momento_llegada IS NULL AND t.activo=1 AND CAST(fecha_estipulada AS DATE)>CAST(@fecha AS DATE) AND id_afiliado=@id_afiliado
GO

CREATE PROCEDURE ELIMINAR_CAR.cancelarTurnoAfiliado (@id_turno BIGINT,@id_afiliado BIGINT, @motivo VARCHAR(200))
AS
UPDATE ELIMINAR_CAR.Turno
SET activo=0
WHERE id_turno=@id_turno
INSERT INTO ELIMINAR_CAR.Cancelacion_Afiliado
(id_afiliado,id_turno,motivo)
VALUES (@id_afiliado,@id_turno,@motivo)
GO

CREATE PROCEDURE ELIMINAR_CAR.cancelarTurnoProfesional(@matricula BIGINT,@motivo VARCHAR(200),@fecha_desde DATE,@fecha_hasta DATE)
AS
SELECT * FROM ELIMINAR_CAR.Turno
INSERT INTO ELIMINAR_CAR.Cancelacion_Profesional (matricula,motivo,fecha_desde,fecha_hasta)
VALUES (@matricula,@motivo,@fecha_desde,@fecha_hasta)
UPDATE ELIMINAR_CAR.Turno
SET activo=0
WHERE matricula=@matricula AND CAST(fecha_estipulada AS DATE)>=@fecha_desde AND CAST(fecha_estipulada AS DATE)<=@fecha_hasta
GO

CREATE PROCEDURE ELIMINAR_CAR.profesionales_mas_consultados (@id_plan INT, @fecha DATETIME)
AS
SELECT TOP 5  p.nombre 'Nombre', p.apellido 'Apellido', pl.desc_plan 'Plan', e.desc_especialidad 'Especialidad', count(t.matricula) 'Consultas'
FROM ELIMINAR_CAR.Turno t JOIN ELIMINAR_CAR.Consulta c ON (c.id_turno = t.id_turno) JOIN ELIMINAR_CAR.Profesional p ON (t.matricula = p.matricula) JOIN ELIMINAR_CAR.Afiliado a ON (a.id_afiliado = t.id_afiliado) JOIN ELIMINAR_CAR.Planes pl ON (a.id_plan = pl.id_plan) JOIN ELIMINAR_CAR.Especialidad e ON (e.id_especialidad = t.id_especialidad)
WHERE a.id_plan =
	CASE @id_plan
	WHEN -1 THEN a.id_plan
	ELSE @id_plan
	END
	and YEAR(c.fecha_consulta) = YEAR(@fecha) and MONTH(c.fecha_consulta) = MONTH(@fecha)
GROUP BY p.nombre, p.apellido, pl.desc_plan, e.desc_especialidad
ORDER BY count(t.matricula) desc
GO

CREATE PROCEDURE ELIMINAR_CAR.comprar_bono (@id_afiliado BIGINT,@cant_bonos INT,@fecha_compra DATETIME)
AS
DECLARE @id_plan INT,@precio INT,@id_bono_max BIGINT,@cnt INT = 0,@id_compra BIGINT;

BEGIN TRANSACTION
SELECT @id_plan=p.id_plan,@precio=precio_bono_consulta FROM ELIMINAR_CAR.Afiliado a JOIN ELIMINAR_CAR.Planes p on (a.id_plan=p.id_plan) WHERE a.id_afiliado = @id_afiliado
SELECT @id_bono_max=MAX(id_bono) FROM ELIMINAR_CAR.Bono

INSERT INTO ELIMINAR_CAR.Compra_Bonos (id_afiliado_comprador,precio_total,fecha_compra,cantidad_bonos) VALUES (@id_afiliado,@precio*@cant_bonos,@fecha_compra,@cant_bonos)
SELECT TOP 1 @id_compra = id_compra FROM ELIMINAR_CAR.Compra_Bonos ORDER BY id_compra DESC
WHILE @cnt < @cant_bonos
BEGIN
	INSERT INTO ELIMINAR_CAR.Bono (id_bono,id_afiliado_comprador,id_plan,utilizado,precio,fecha_compra,id_compra) VALUES (@id_bono_max+1+@cnt,@id_afiliado,@id_plan,0,@precio,@fecha_compra,@id_compra)
   SET @cnt = @cnt + 1;
END;
COMMIT TRANSACTION
GO


CREATE PROCEDURE ELIMINAR_CAR.cancelaciones_totales (@fecha DATETIME)
AS
SELECT TOP 5 e.desc_especialidad Especialidad, count(t.id_especialidad) Cancelaciones
FROM ELIMINAR_CAR.Turno t JOIN ELIMINAR_CAR.Especialidad e ON (t.id_especialidad = e.id_especialidad)
WHERE activo = 0 and YEAR(t.fecha_estipulada) = YEAR(@fecha) and MONTH(t.fecha_estipulada) = MONTH(@fecha)
GROUP BY e.desc_especialidad
ORDER BY Cancelaciones desc
GO

CREATE PROCEDURE ELIMINAR_CAR.cancelaciones_afiliado (@fecha DATETIME)
AS
SELECT TOP 5 e.desc_especialidad Especialidad, count(t.id_especialidad) Cancelaciones
FROM ELIMINAR_CAR.Turno t JOIN ELIMINAR_CAR.Especialidad e ON (t.id_especialidad = e.id_especialidad) JOIN ELIMINAR_CAR.Cancelacion_Afiliado c ON (t.id_turno = c.id_turno)
WHERE activo = 0 and YEAR(t.fecha_estipulada) = YEAR(@fecha) and MONTH(t.fecha_estipulada) = MONTH(@fecha)
GROUP BY e.desc_especialidad
ORDER BY Cancelaciones desc
GO

CREATE PROCEDURE ELIMINAR_CAR.cancelaciones_profesional (@fecha DATETIME)
AS
SELECT TOP 5 e.desc_especialidad Especialidad, count(c.id_especialidad) Cancelaciones
FROM (	SELECT *
		FROM ELIMINAR_CAR.Turno t
		WHERE activo = 0 and YEAR(t.fecha_estipulada) = YEAR(@fecha) and MONTH(t.fecha_estipulada) = MONTH(@fecha)

		EXCEPT

		SELECT t.id_turno, t.fecha_estipulada, t.matricula, t.id_afiliado, t.id_bono, t.momento_llegada, t.id_especialidad, t.activo
		FROM ELIMINAR_CAR.Turno t JOIN ELIMINAR_CAR.Cancelacion_Afiliado c ON (t.id_turno = c.id_turno)
		WHERE activo = 0 and YEAR(t.fecha_estipulada) = YEAR(@fecha) and MONTH(t.fecha_estipulada) = MONTH(@fecha)) c
		JOIN ELIMINAR_CAR.Especialidad e ON (c.id_especialidad = e.id_especialidad)
GROUP BY e.desc_especialidad
ORDER BY Cancelaciones desc
GO


CREATE FUNCTION ELIMINAR_CAR.proximoIdAfiliado(@id_familia BIGINT) RETURNS BIGINT
AS
BEGIN
DECLARE @id BIGINT
SELECT @id=MAX(id_afiliado)+1 FROM ELIMINAR_CAR.Afiliado WHERE id_familia=@id_familia
IF @id<=@id_familia*100 + 2
BEGIN
SET @id=@id_familia*100+3
END
RETURN @id
END
GO

CREATE PROCEDURE ELIMINAR_CAR.insertarAfiliadoRaiz(@tipo_doc INT,@n_doc DECIMAL(8,0),@nombre VARCHAR(40),@apellido VARCHAR(40),@direccion VARCHAR(100),@telefono BIGINT,@mail VARCHAR(60),
@fecha_nac DATE,@estado_civil INT,@sexo INT,@id_plan INT,@familiares_a_cargo INT,@id_familia_out BIGINT OUTPUT,@id_afiliado_out BIGINT OUTPUT)
AS
BEGIN
INSERT INTO ELIMINAR_CAR.Familia (n_familiares_a_cargo) VALUES (@familiares_a_cargo);
SELECT @id_familia_out=MAX(id_familia) FROM ELIMINAR_CAR.Familia;
SET @id_afiliado_out = @id_familia_out*100 + 1;
INSERT INTO ELIMINAR_CAR.Afiliado (id_afiliado,tipo_doc,numero_doc,nombre,apellido,direccion,telefono,mail,fecha_nac,estado_civil,sexo,id_plan,id_familia,familiares_a_cargo,activo,num_consulta_actual)
						Values (@id_afiliado_out,@tipo_doc,@n_doc,@nombre,@apellido,@direccion,@telefono,@mail,@fecha_nac,@estado_civil,@sexo,@id_plan,@id_familia_out,@familiares_a_cargo,1,0);
END
GO

CREATE PROCEDURE ELIMINAR_CAR.insertarConyuge(@id_familia BIGINT,@tipo_doc INT,@n_doc DECIMAL(8,0),@nombre VARCHAR(40),@apellido VARCHAR(40),@direccion VARCHAR(100),@telefono BIGINT,@mail VARCHAR(60),
@fecha_nac DATE,@estado_civil INT,@sexo INT,@id_plan INT,@id_afiliado_out BIGINT OUTPUT)
AS
DECLARE @hayConyuge INT;
BEGIN
SELECT @hayConyuge=COUNT(*) FROM ELIMINAR_CAR.Afiliado WHERE id_afiliado=@id_familia*100 +2;
if @hayConyuge=0
BEGIN
SET @id_afiliado_out=@id_familia*100+ 2;
END
ELSE 
BEGIN
SET @id_afiliado_out = ELIMINAR_CAR.proximoIdAfiliado(@id_familia);
UPDATE ELIMINAR_CAR.Familia SET n_familiares_a_cargo=n_familiares_a_cargo+1 WHERE id_familia=@id_familia; --Si es el 2do conyuge se cuenta como familiar a cargo
UPDATE ELIMINAR_CAR.AFiliado SET familiares_a_cargo=familiares_a_cargo+1 WHERE id_afiliado=@id_familia*100+1;
END
INSERT INTO ELIMINAR_CAR.Afiliado (id_afiliado,tipo_doc,numero_doc,nombre,apellido,direccion,telefono,mail,fecha_nac,estado_civil,sexo,id_plan,id_familia,familiares_a_cargo,activo,num_consulta_actual)
						Values (@id_afiliado_out,@tipo_doc,@n_doc,@nombre,@apellido,@direccion,@telefono,@mail,@fecha_nac,@estado_civil,@sexo,@id_plan,@id_familia,0,1,0);
END
GO

CREATE PROCEDURE ELIMINAR_CAR.insertarDependiente(@id_familia BIGINT,@tipo_doc INT,@n_doc DECIMAL(8,0),@nombre VARCHAR(40),@apellido VARCHAR(40),@direccion VARCHAR(100),@telefono BIGINT,@mail VARCHAR(60),
@fecha_nac DATE,@estado_civil INT,@sexo INT,@id_plan INT,@id_afiliado_out BIGINT OUTPUT)
AS
BEGIN
SET @id_afiliado_out = ELIMINAR_CAR.proximoIdAfiliado(@id_familia);
UPDATE ELIMINAR_CAR.Familia SET n_familiares_a_cargo=n_familiares_a_cargo+1 WHERE id_familia=@id_familia; --Agregamos otro familiar
UPDATE ELIMINAR_CAR.AFiliado SET familiares_a_cargo=familiares_a_cargo+1 WHERE id_afiliado=@id_familia*100+1

INSERT INTO ELIMINAR_CAR.Afiliado (id_afiliado,tipo_doc,numero_doc,nombre,apellido,direccion,telefono,mail,fecha_nac,estado_civil,sexo,id_plan,id_familia,familiares_a_cargo,activo,num_consulta_actual)
						Values (@id_afiliado_out,@tipo_doc,@n_doc,@nombre,@apellido,@direccion,@telefono,@mail,@fecha_nac,@estado_civil,@sexo,@id_plan,@id_familia,0,1,0);
END
GO
--direccion telefono estado civi mail plan medico cant fam sexo
CREATE PROCEDURE ELIMINAR_CAR.modificarAfiliado(@id_afiliado BIGINT,@telefono BIGINT,@direccion VARCHAR(100),@estado_civil INT, @mail VARCHAR(60),@sexo INT, @id_plan INT,@fecha_cambio DATETIME,@motivo_cambio_plan VARCHAR(100))
AS
BEGIN
IF @direccion IS NOT NULL
BEGIN
UPDATE ELIMINAR_CAR.Afiliado SET direccion=@direccion WHERE id_afiliado=@id_afiliado
END
IF @estado_civil IS NOT NULL
BEGIN
UPDATE ELIMINAR_CAR.Afiliado SET estado_civil=@estado_civil WHERE id_afiliado=@id_afiliado
END
IF @mail IS NOT NULL
BEGIN
UPDATE ELIMINAR_CAR.Afiliado SET mail=@mail WHERE id_afiliado=@id_afiliado
END
IF @sexo IS NOT NULL
BEGIN
UPDATE ELIMINAR_CAR.Afiliado SET sexo=@sexo WHERE id_afiliado=@id_afiliado
END
IF @telefono IS NOT NULL
BEGIN
UPDATE ELIMINAR_CAR.Afiliado SET telefono=@telefono WHERE id_afiliado=@id_afiliado
END
IF @id_plan IS NOT NULL
BEGIN
INSERT INTO ELIMINAR_CAR.Cambio_de_Plan (id_afiliado,id_plan_anterior,id_plan_nuevo,fecha_cambio,motivo_cambio)
VALUES (@id_afiliado,(SELECT id_plan FROM ELIMINAR_CAR.Afiliado where id_afiliado=@id_afiliado),@id_plan,@fecha_cambio,@motivo_cambio_plan)
UPDATE ELIMINAR_CAR.Afiliado SET id_plan=@id_plan WHERE id_afiliado=@id_afiliado
END
END
GO

CREATE PROCEDURE ELIMINAR_CAR.eliminarAfiliadoRaiz(@id_afiliado BIGINT,@id_familia BIGINT,@fecha_baja DATETIME)
AS
BEGIN --Si es el raiz damos de baja a toda la familia
UPDATE ELIMINAR_CAR.Afiliado SET activo=0,fecha_baja=@fecha_baja WHERE id_familia=@id_familia;
UPDATE ELIMINAR_CAR.TURNO SET activo=0 WHERE id_afiliado IN (SELECT id_afiliado FROM ELIMINAR_CAR.Afiliado WHERE id_familia=@id_familia) AND fecha_estipulada>=GETDATE()
UPDATE ELIMINAR_CAR.Familia SET n_familiares_a_cargo=0 WHERE id_familia=@id_familia;
END
GO

CREATE PROCEDURE ELIMINAR_CAR.eliminarAfiliadoNoRaiz(@id_afiliado BIGINT,@id_familia BIGINT,@fecha_baja DATETIME)
AS
BEGIN
UPDATE ELIMINAR_CAR.Afiliado SET activo=0,fecha_baja=@fecha_baja WHERE id_afiliado=@id_afiliado;
UPDATE ELIMINAR_CAR.TURNO SET activo=0 WHERE id_afiliado=@id_afiliado AND fecha_estipulada>=GETDATE();
if @id_afiliado NOT LIKE '%02' --Si no es el conyuge original
BEGIN
 UPDATE ELIMINAR_CAR.Familia SET n_familiares_a_cargo=n_familiares_a_cargo-1 WHERE id_familia=@id_familia;
 END
END
GO

CREATE FUNCTION ELIMINAR_CAR.SumarHoras(@MATRICULA BIGINT, @DIA INT) RETURNS DECIMAL(6,2)
AS
BEGIN
	DECLARE @TIEMPO_TRABAJADO DECIMAL(6,2), @HORA_DESDE TIME, @HORA_HASTA TIME
	SELECT @HORA_DESDE=A.hora_desde, @HORA_HASTA = A.hora_hasta FROM ELIMINAR_CAR.Agenda_Diaria A WHERE matricula=@MATRICULA and dia = @DIA
	IF @@ROWCOUNT>0
		BEGIN
		SET @TIEMPO_TRABAJADO = (convert(DECIMAL(6,2),datediff(minute, @HORA_DESDE, @HORA_HASTA))/60.00)
		END
	ELSE
		BEGIN
		SET @TIEMPO_TRABAJADO = 0
		END

		RETURN @TIEMPO_TRABAJADO
END
GO

CREATE FUNCTION ELIMINAR_CAR.horas_prof (@matricula BIGINT, @id_especialidad INT, @fecha DATETIME) RETURNS DECIMAL(6,2)
AS
BEGIN
	DECLARE @desde DATETIME, @hasta DATETIME, @horas DECIMAL(6,2)
	SET @horas=0
	SET @desde = @fecha
	SELECT DISTINCT @hasta = fecha_hasta FROM ELIMINAR_CAR.Agenda_Diaria a JOIN ELIMINAR_CAR.Rango_Atencion r ON (r.matricula = a.matricula) WHERE @matricula = a.matricula 
	and a.id_especialidad =
		CASE @id_especialidad
			WHEN -1 THEN a.id_especialidad
			ELSE @id_especialidad
		END
	WHILE (@desde <= @hasta and MONTH(@fecha) = MONTH(@desde))
	BEGIN
		SET @horas =
		CASE datepart(weekday, @desde)
			WHEN 1 THEN @horas + ELIMINAR_CAR.SumarHoras(@matricula, 1)
			WHEN 2 THEN @horas + ELIMINAR_CAR.SumarHoras(@matricula, 2)
			WHEN 3 THEN @horas + ELIMINAR_CAR.SumarHoras(@matricula, 3)
			WHEN 4 THEN @horas + ELIMINAR_CAR.SumarHoras(@matricula, 4)
			WHEN 5 THEN @horas + ELIMINAR_CAR.SumarHoras(@matricula, 5)
			WHEN 6 THEN @horas + ELIMINAR_CAR.SumarHoras(@matricula, 6)
			ELSE @horas
		END
		SELECT @desde = DATEADD(day, 1, @desde)
	END

	RETURN @horas
END
GO

CREATE PROCEDURE ELIMINAR_CAR.profesionales_con_menos_horas (@id_especialidad INT, @fecha DATETIME)
AS
	SELECT TOP 5 p.nombre Nombre, p.apellido Apellido, p.matricula 'Matrícula', ELIMINAR_CAR.horas_prof(p.matricula, @id_especialidad, @fecha) Horas
	FROM ELIMINAR_CAR.Profesional p
	ORDER BY Horas asc
GO

CREATE PROCEDURE ELIMINAR_CAR.afiliados_con_mas_bonos (@fecha DATETIME)
AS
	SELECT TOP 5 a.nombre Nombre, a.apellido Apellido, sum(cantidad_bonos) Bonos, (case familiares_a_cargo when 0 then 'No pertenece' else 'Pertenece' end) 'Grupo familiar'
	FROM ELIMINAR_CAR.Afiliado A JOIN ELIMINAR_CAR.Compra_Bonos CB ON (A.id_afiliado=CB.id_afiliado_comprador)
	WHERE MONTH(@fecha) = MONTH(fecha_compra) and YEAR(@fecha)=YEAR(fecha_compra)
	GROUP BY a.id_afiliado,a.nombre, a.apellido, (case familiares_a_cargo when 0 then 'No pertenece' else 'Pertenece' end)
	ORDER BY sum(cantidad_bonos) desc
GO

CREATE PROCEDURE ELIMINAR_CAR.especialidades_con_mas_bonos (@fecha DATETIME)
AS
	SELECT TOP 5 E.desc_especialidad Especialidad, count(T.id_especialidad) Bonos
	FROM ELIMINAR_CAR.Consulta C JOIN ELIMINAR_CAR.Turno T ON (C.id_turno=T.id_turno) JOIN ELIMINAR_CAR.Especialidad E ON (T.id_especialidad=E.id_especialidad)
	WHERE id_bono IS NOT NULL and MONTH(@fecha) = MONTH(fecha_consulta) and YEAR(@fecha)=YEAR(fecha_consulta)
	GROUP BY E.desc_especialidad
	ORDER BY count(T.id_especialidad) desc
GO
--Devuelve la cantidad de personas con ese dni
CREATE PROCEDURE ELIMINAR_CAR.verificar_doc_afiliado(@tipo INT,@dni BIGINT,@resultado INT OUTPUT)
AS
	SELECT @resultado=count(*) FROM ELIMINAR_CAR.Afiliado where tipo_doc=@tipo AND numero_doc=@dni 
GO


--Inserta user default
INSERT INTO ELIMINAR_CAR.Usuario (id_usuario,contrasenia,intentos_fallidos,habilitado) VALUES
('admin',HASHBYTES('SHA2_256','w23e'),0,1);
INSERT INTO ELIMINAR_CAR.Profesional (matricula,tipo_doc,numero_doc,nombre,apellido,direccion,telefono,mail,fecha_nac,usuario)
VALUES	((SELECT MAX(matricula)+1 FROM ELIMINAR_CAR.Profesional),1,(SELECT MAX(matricula)+1 FROM ELIMINAR_CAR.Profesional),'Administrador','ApellidoAdministrador','DireccionAdministrador',45001122,'admin@sistema.com','2016-10-10','admin');
INSERT INTO ELIMINAR_CAR.Especialidad_por_profesional (id_especialidad,matricula)
VALUES ((SELECT MIN(id_especialidad) FROM ELIMINAR_CAR.Especialidad),(SELECT matricula FROM ELIMINAR_CAR.Profesional where usuario='admin'))
DECLARE @doc DECIMAL(8,0),@plan INT;
SELECT @doc=numero_doc FROM ELIMINAR_CAR.Profesional where usuario='admin'
SELECT @plan=MAX(id_plan) FROM ELIMINAR_CAR.Planes
EXEC ELIMINAR_CAR.insertarAfiliadoRaiz 1,@doc,'Administrador','ApellidoAdministrador','DireccionAdministrador',45001122,'admin@sistema.com',
'2016-10-10',0,0,@plan,0,null,null;
UPDATE ELIMINAR_CAR.Afiliado SET usuario='admin' where numero_doc=@doc
--Le damos a admin los 3 roles
INSERT INTO ELIMINAR_CAR.Roles_por_usuarios(id_rol,id_usuario) VALUES (1,'admin')
INSERT INTO ELIMINAR_CAR.Roles_por_usuarios(id_rol,id_usuario) VALUES (2,'admin')
INSERT INTO ELIMINAR_CAR.Roles_por_usuarios(id_rol,id_usuario) VALUES (3,'admin')