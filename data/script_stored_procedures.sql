CREATE PROCEDURE ELIMINAR_CAR.verificar_login( @usuario varchar(20),@contrasenia BINARY(32))
AS  
IF (SELECT contrasenia FROM ELIMINAR_CAR.Usuario WHERE id_usuario=@usuario) = @contrasenia
    RETURN 1  
ELSE  
    RETURN 0;  
GO  

declare @password  VARCHAR(20) SET @password='w23e' 
declare @enc BiNARY(32) SET @enc=HashBytes('SHA2_256',@password)
declare @resultado INT
EXECUTE @resultado = ELIMINAR_CAR.verificar_login 'admin',@enc
PRINT @resultado
SELECT id_usuario,contrasenia,intentos_fallidos,habilitado FROM ELIMINAR_CAR.Usuario WHERE id_usuario = 'admin' 

