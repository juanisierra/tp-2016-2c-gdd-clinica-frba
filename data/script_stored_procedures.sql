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
