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
SELECT @id=n_familiares_a_cargo+3 FROM ELIMINAR_CAR.Familia WHERE id_familia=@id_familia
RETURN @id_familia*100 + @id
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

CREATE PROCEDURE ELIMINAR_CAR.eliminarAfiliadoRaiz(@id_afiliado BIGINT,@id_familia BIGINT)
AS
BEGIN --Si es el raiz damos de baja a toda la familia
UPDATE ELIMINAR_CAR.Afiliado SET activo=0 WHERE id_familia=@id_familia;
UPDATE ELIMINAR_CAR.TURNO SET activo=0 WHERE id_afiliado IN (SELECT id_afiliado FROM ELIMINAR_CAR.Afiliado WHERE id_familia=@id_familia) AND fecha_estipulada>=GETDATE()
UPDATE ELIMINAR_CAR.Familia SET n_familiares_a_cargo=0 WHERE id_familia=@id_familia;
END
GO

CREATE PROCEDURE ELIMINAR_CAR.eliminarAfiliadoNoRaiz(@id_afiliado BIGINT,@id_familia BIGINT)
AS
BEGIN
UPDATE ELIMINAR_CAR.Afiliado SET activo=0 WHERE id_afiliado=@id_afiliado;
UPDATE ELIMINAR_CAR.TURNO SET activo=0 WHERE id_afiliado=@id_afiliado AND fecha_estipulada>=GETDATE();
if @id_afiliado NOT LIKE '%02' --Si no es el conyuge original
BEGIN
 UPDATE ELIMINAR_CAR.Familia SET n_familiares_a_cargo=n_familiares_a_cargo-1 WHERE id_familia=@id_familia;
 END
END
GO

CREATE FUNCTION ELIMINAR_CAR.SumarHoras(@MATRICULA BIGINT, @DIA INT) RETURNS INT
AS
BEGIN
	DECLARE @TIEMPO_TRABAJADO INT, @HORA_DESDE TIME, @HORA_HASTA TIME
	SELECT @HORA_DESDE=A.hora_desde, @HORA_HASTA = A.hora_hasta FROM ELIMINAR_CAR.Agenda_Diaria A WHERE matricula=@MATRICULA and dia = @DIA
	IF @@ROWCOUNT>0
		BEGIN
		SET @TIEMPO_TRABAJADO = datediff(hour, @HORA_DESDE, @HORA_HASTA)
		END
	ELSE
		BEGIN
		SET @TIEMPO_TRABAJADO = 0
		END

		RETURN @TIEMPO_TRABAJADO
END
GO

CREATE FUNCTION ELIMINAR_CAR.horas_prof (@matricula BIGINT, @id_especialidad INT, @fecha DATETIME) RETURNS INT
AS
BEGIN
	DECLARE @desde DATETIME, @hasta DATETIME, @horas INT
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

CREATE PROCEDURE ELIMINAR_CAR.profesionales_con_mas_horas (@id_especialidad INT, @fecha DATETIME)
AS
	SELECT TOP 5 p.nombre Nombre, p.apellido Apellido, p.matricula 'Matrícula', ELIMINAR_CAR.horas_prof(p.matricula, @id_especialidad, @fecha) Horas
	FROM ELIMINAR_CAR.Profesional p
	ORDER BY Horas desc
GO

CREATE PROCEDURE ELIMINAR_CAR.afiliados_con_mas_bonos (@fecha DATETIME)
AS
	SELECT TOP 5 id_afiliado, count(id_afiliado_comprador) bonos_comprados, (case familiares_a_cargo when 0 then 'No pertenece a grupo familiar' else 'Pertenece a grupo familiar' end) pertenece_a_grupo
	FROM ELIMINAR_CAR.Afiliado A JOIN ELIMINAR_CAR.Compra_Bonos CB ON (A.id_afiliado=CB.id_afiliado_comprador)
	WHERE MONTH(@fecha) = MONTH(fecha_compra) and YEAR(@fecha)=YEAR(fecha_compra)
	GROUP BY id_afiliado, (case familiares_a_cargo when 0 then 'No pertenece a grupo familiar' else 'Pertenece a grupo familiar' end)
	ORDER BY count(id_afiliado_comprador) desc, id_afiliado
GO

CREATE PROCEDURE ELIMINAR_CAR.especialidades_con_mas_bonos (@fecha DATETIME)
AS
	SELECT TOP 5 T.id_especialidad, E.desc_especialidad, count(T.id_especialidad) bonos_utilizados
	FROM ELIMINAR_CAR.Consulta C JOIN ELIMINAR_CAR.Turno T ON (C.id_turno=T.id_turno) JOIN ELIMINAR_CAR.Especialidad E ON (T.id_especialidad=E.id_especialidad)
	WHERE id_bono IS NOT NULL and MONTH(@fecha) = MONTH(fecha_consulta) and YEAR(@fecha)=YEAR(fecha_consulta)
	GROUP BY T.id_especialidad, E.desc_especialidad
	ORDER BY count(T.id_especialidad) desc
GO