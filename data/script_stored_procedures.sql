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