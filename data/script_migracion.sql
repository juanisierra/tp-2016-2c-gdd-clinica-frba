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
GO

--Inserta personas en la tabla
INSERT INTO ELIMINAR_CAR.Persona
(numero_doc,nombre,apellido,direccion,telefono,mail,fecha_nac,estado_civil)
SELECT DISTINCT Paciente_Dni, Paciente_Nombre, Paciente_Apellido,Paciente_direccion,Paciente_Telefono,Paciente_Mail,Paciente_Fecha_Nac, 'soltero'
From gd_esquema.Maestra
UNION
SELECT DISTINCT Medico_Dni,Medico_Nombre,Medico_Apellido,Medico_Direccion,Medico_Telefono,Medico_Mail,Medico_Fecha_Nac, 'soltero'
from gd_esquema.Maestra
WHERE Medico_DNI is NOT NULL
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
(id_afiliado,id_persona,id_plan,id_familia,familiares_a_cargo,activo)
SELECT  (row_number() OVER (ORDER BY p.numero_doc))*100+1,p.id_persona,m.Plan_Med_Codigo,row_number() OVER (ORDER BY p.numero_doc),0,1
FROM ELIMINAR_CAR.Persona p JOIN gd_esquema.maestra m on (p.numero_doc=m.Paciente_Dni)
GROUP BY p.numero_doc,m.Plan_Med_Codigo,p.id_persona


--Medicos  --Matricula autogenerada con id_persona
INSERT INTO eliminar_car.profesional
(matricula,id_persona)
SELECT DISTINCT p.numero_doc,p.id_persona
FROM ELIMINAR_CAR.Persona p JOIN gd_esquema.maestra m on (p.numero_doc=m.Medico_dni)

--Especialidad por profesional
INSERT INTO ELIMINAR_CAR.especialidad_por_profesional
(matricula,id_especialidad)
select	matricula,Especialidad_Codigo
FROM gd_esquema.maestra m  join ELIMINAR_CAR.Persona p on (m.Medico_Dni = p.numero_doc) JOIN ELIMINAR_CAR.Profesional a on (p.id_persona = a.id_persona)
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
FROM gd_esquema.Maestra m  JOIN ELIMINAR_CAR.Persona p on (p.numero_doc=m.Paciente_Dni) JOIN ELIMINAR_CAR.Afiliado a on (p.id_persona= a.id_persona) JOIN (
select m2.bono_consulta_numero, a2.id_afiliado comprador,m2.Plan_Med_Precio_Bono_Consulta,m2.Compra_Bono_Fecha					--bonos comprados sin usar
FROM gd_esquema.Maestra m2 JOIN ELIMINAR_CAR.Persona p2 on (p2.numero_doc=m2.Paciente_Dni) JOIN ELIMINAR_CAR.Afiliado a2 on(p2.id_persona= a2.id_persona)
WHERE m2.Medico_DNI is NULL
) bonos_comprados_sin_usar ON (bonos_comprados_sin_usar.Bono_consulta_numero=m.Bono_Consulta_Numero)
WHERE m.Bono_Consulta_Numero is not null AND Medico_Dni is NOT NULL
UNION  --Bonos no usados
(
SELECT DISTINCT m.Bono_Consulta_Numero,m.Plan_Med_Codigo,NULL,a.id_afiliado,0,m.Plan_Med_Precio_Bono_Consulta,bonos_comprados_sin_usar.Compra_Bono_Fecha,m.Bono_Consulta_Fecha_Impresion--TODOS LOS BONOS
FROM gd_esquema.Maestra m JOIN ELIMINAR_CAR.Persona p on(p.numero_doc=m.Paciente_dni) JOIN ELIMINAR_CAR.Afiliado a on (p.id_persona=a.id_persona) JOIN (
select m2.bono_consulta_numero, a2.id_afiliado comprador,m2.Plan_Med_Precio_Bono_Consulta,m2.Compra_Bono_Fecha					
FROM gd_esquema.Maestra m2 JOIN ELIMINAR_CAR.Persona p2 on (p2.numero_doc=m2.Paciente_Dni) JOIN ELIMINAR_CAR.Afiliado a2 on(p2.id_persona= a2.id_persona)
WHERE m2.Medico_DNI is NULL
) bonos_comprados_sin_usar ON (bonos_comprados_sin_usar.Bono_consulta_numero=m.Bono_Consulta_Numero)
WHERE m.Bono_Consulta_Numero is not null
EXCEPT
SELECT  DISTINCT m.Bono_Consulta_Numero,m.Plan_Med_Codigo,NULL,a.id_afiliado,0,m.Plan_Med_Precio_Bono_Consulta,bonos_comprados_sin_usar.Compra_Bono_Fecha,m.Bono_Consulta_Fecha_Impresion --BONOS USADOS
FROM gd_esquema.Maestra m JOIN ELIMINAR_CAR.Persona p on(p.numero_doc=m.Paciente_dni) JOIN ELIMINAR_CAR.Afiliado a on (p.id_persona=a.id_persona) JOIN (
select m2.bono_consulta_numero, a2.id_afiliado comprador,m2.Plan_Med_Precio_Bono_Consulta,m2.Compra_Bono_Fecha					
FROM gd_esquema.Maestra m2 JOIN ELIMINAR_CAR.Persona p2 on (p2.numero_doc=m2.Paciente_Dni) JOIN ELIMINAR_CAR.Afiliado a2 on(p2.id_persona= a2.id_persona)
WHERE m2.Medico_DNI is NULL
) bonos_comprados_sin_usar ON (bonos_comprados_sin_usar.Bono_consulta_numero=m.Bono_Consulta_Numero)
WHERE m.Bono_Consulta_Numero is not null AND m.Medico_Dni IS NOT NULL and m.Compra_Bono_Fecha is   null
)
EXEC ELIMINAR_CAR.Migrar_Bonos
--Turnos atendidos
INSERT INTO ELIMINAR_CAR.Turno
(id_turno,fecha_estipulada,matricula,id_afiliado,id_bono,momento_llegada,id_especialidad,activo)
SELECT DISTINCT m.Turno_Numero, m.Turno_Fecha,pr.matricula,a.id_afiliado,m.Bono_Consulta_Numero,m.Turno_Fecha,m.Especialidad_Codigo,1
FROM gd_esquema.Maestra m  JOIN ELIMINAR_CAR.Persona p on (m.Medico_Dni=p.numero_doc) JOIN ELIMINAR_CAR.Persona p2 on (m.Paciente_Dni=p2.numero_doc) JOIN ELIMINAR_CAR.Afiliado a ON (a.id_persona=p2.id_persona) JOIN ELIMINAR_CAR.Profesional pr on (p.id_persona=pr.id_persona)
WHERE m.Turno_Numero is not null and Bono_consulta_numero is not null

--Consultas
INSERT INTO ELIMINAR_CAR.Consulta
(id_turno,fecha_consulta,sintomas,diagnostico)
SELECT DISTINCT m.Turno_Numero, m.Turno_Fecha,Consulta_Sintomas,Consulta_Enfermedades
FROM gd_esquema.Maestra m
WHERE m.Turno_Numero is not null and Consulta_Sintomas is not null