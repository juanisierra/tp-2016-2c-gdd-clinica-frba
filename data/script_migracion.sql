USE [GD2C2016]
GO
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

--Compras bonos
INSERT INTO ELIMINAR_CAR.Compra_Bonos --Suponemos que las compras en un mismo dia son la misma
(id_afiliado_comprador,precio_total,fecha_compra,cantidad_bonos)
SELECT id_afiliado_comprador,sum(precio),fecha_compra,count(id_bono)
FROM ELIMINAR_CAR.Bono
GROUP BY id_afiliado_comprador,fecha_compra

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

--Inserta user default
INSERT INTO ELIMINAR_CAR.Usuario (id_usuario,contrasenia,intentos_fallidos,habilitado) VALUES
('admin',HASHBYTES('SHA2_256','w23e'),0,1);



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
INSERT INTO ELIMINAR_CAR.Rol (nombre_rol,habilitado) VALUES ('Administrador',1)
--Le damos a admin rol de administrador
INSERT INTO ELIMINAR_CAR.Roles_por_usuarios(id_rol,id_usuario) VALUES (4,'admin')

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


--Darle todas las funcionalidades al administrador
INSERT INTO ELIMINAR_CAR.Funcionalidades_por_rol
(id_rol,id_funcionalidad)
SELECT 4,id_funcionalidad
FROM ELIMINAR_CAR.Funcionalidad

--Darle Alta Agenda a profesional
INSERT INTO ELIMINAR_CAR.Funcionalidades_por_rol
(id_rol,id_funcionalidad)
Values (3,7);
--Registro diagnostico a profesional
INSERT INTO ELIMINAR_CAR.Funcionalidades_por_rol
(id_rol,id_funcionalidad)
Values (3,11);
--Cancelacion a profesional
INSERT INTO ELIMINAR_CAR.Funcionalidades_por_rol
(id_rol,id_funcionalidad)
Values (3,12);
--Darle Pedir Turno a afiliado
INSERT INTO ELIMINAR_CAR.Funcionalidades_por_rol
(id_rol,id_funcionalidad)
Values (1,9);
--Darle Cancelar Atencion a afiliado
INSERT INTO ELIMINAR_CAR.Funcionalidades_por_rol
(id_rol,id_funcionalidad)
Values (1,8);
--Darle Comprar Bonos a afiliado
INSERT INTO ELIMINAR_CAR.Funcionalidades_por_rol
(id_rol,id_funcionalidad)
Values (1,12);

--TODO darle funcionalidades a los otros roles