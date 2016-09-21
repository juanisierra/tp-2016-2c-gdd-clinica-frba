USE [GD2C2016]
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