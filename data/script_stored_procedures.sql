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