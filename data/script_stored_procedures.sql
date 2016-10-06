CREATE PROCEDURE ELIMINAR_CAR.matricula_por_usuario(@usuario varchar(20),@matricula BIGINT OUTPUT)
AS  
SELECT TOP 1 @matricula=matricula FROM ELIMINAR_CAR.Profesional p JOIN ELIMINAR_CAR.Usuario u on (p.usuario = u.id_usuario) WHERE id_usuario=@usuario
GO  
