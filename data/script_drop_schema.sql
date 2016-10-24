USE [GD2C2016]
GO

DROP PROCEDURE ELIMINAR_CAR.cancelaciones_afiliado;
DROP PROCEDURE ELIMINAR_CAR.cancelaciones_totales;
DROP PROCEDURE ELIMINAR_CAR.cancelaciones_profesional;
DROP PROCEDURE ELIMINAR_CAR.comprar_bono;
DROP PROCEDURE ELIMINAR_CAR.profesionales_mas_consultados;
DROP PROCEDURE ELIMINAR_CAR.cancelarTurnoProfesional;
DROP PROCEDURE ELIMINAR_CAR.cancelarTurnoAfiliado; 
DROP PROCEDURE ELIMINAR_CAR.turnosCancelablesAfiliado;
DROP PROCEDURE ELIMINAR_CAR.registrarConsulta;
DROP PROCEDURE ELIMINAR_CAR.turnosParaDiagnosticar;
DROP PROCEDURE ELIMINAR_CAR.registrarLlegada;
DROP PROCEDURE ELIMINAR_CAR.bonosDisponibles;
DROP PROCEDURE ELIMINAR_CAR.turnosFuturosPorProfesionalYEspecialidad;
DROP PROCEDURE ELIMINAR_CAR.turnosDelDiaPorProfesional;
DROP PROCEDURE ELIMINAR_CAR.insertarNuevoTurno;
DROP PROCEDURE ELIMINAR_CAR.matricula_por_usuario;
DROP PROCEDURE ELIMINAR_CAR.afiliado_por_usuario;
DROP PROCEDURE ELIMINAR_CAR.proximoIdTurno;
DROP PROCEDURE ELIMINAR_CAR.Migrar_Bonos;
DROP PROCEDURE ELIMINAR_CAR.insertarAfiliadoRaiz;
DROP PROCEDURE ELIMINAR_CAR.ProfesionalesConMasHoras;
DROP PROCEDURE ELIMINAR_CAR.insertarConyuge;
DROP PROCEDURE ELIMINAR_CAR.insertarDependiente;
DROP PROCEDURE ELIMINAR_CAR.modificarAfiliado;
DROP PROCEDURE ELIMINAR_CAR.eliminarAfiliadoRaiz;
DROP PROCEDURE ELIMINAR_CAR.eliminarAfiliadoNoRaiz;
DROP FUNCTION ELIMINAR_CAR.proximoIdAfiliado;
DROP FUNCTION ELIMINAR_CAR.SumarHoras;
DROP TABLE ELIMINAR_CAR.Funcionalidades_por_rol;
DROP TABLE ELIMINAR_CAR.Roles_por_usuarios;
DROP TABLE ELIMINAR_CAR.Especialidad_por_profesional;
DROP TABLE ELIMINAR_CAR.Cambio_de_plan;
DROP TABLE ELIMINAR_CAR.Agenda_Diaria;
DROP TABLE ELIMINAR_CAR.Consulta;
DROP TABLE ELIMINAR_CAR.Cancelacion_Afiliado;
DROP TABLE ELIMINAR_CAR.Cancelacion_Profesional;
DROP TABLE ELIMINAR_CAR.Turno;
DROP TABLE ELIMINAR_CAR.Bono;
DROP TABLE ELIMINAR_CAR.Compra_Bonos;
DROP TABLE ELIMINAR_CAR.Rango_Atencion;
DROP TABLE ELIMINAR_CAR.Rol;
DROP TABLE ELIMINAR_CAR.Funcionalidad;
DROP TABLE ELIMINAR_CAR.Afiliado;
DROP TABLE ELIMINAR_CAR.Familia;
DROP TABLE ELIMINAR_CAR.Profesional;
DROP TABLE ELIMINAR_CAR.Especialidad;
DROP TABLE ELIMINAR_CAR.Tipo_Especialidad;
DROP TABLE ELIMINAR_CAR.Planes;
DROP TABLE ELIMINAR_CAR.Usuario;
DROP SCHEMA ELIMINAR_CAR;