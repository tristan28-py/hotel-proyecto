-- ============================================================================
-- Script 01: Creación de base de datos local en SQL Server Express / Developer
-- Nota: En Azure SQL Database, la base de datos se crea desde el Portal Azure
-- y luego se ejecuta directamente el script 02_hotel_db_tablas_y_datos.sql.
-- ============================================================================

IF DB_ID(N'hotel_db') IS NULL
BEGIN
    CREATE DATABASE [hotel_db];
END
GO
