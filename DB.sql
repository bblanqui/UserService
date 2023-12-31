USE [master]
GO
/****** Object:  Database [digital_bank]    Script Date: 20/08/2023 10:35:25 ******/
/****** copia ******/
CREATE DATABASE [digital_bank]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'digital_bank', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\digital_bank.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'digital_bank_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\digital_bank_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [digital_bank] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [digital_bank].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [digital_bank] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [digital_bank] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [digital_bank] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [digital_bank] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [digital_bank] SET ARITHABORT OFF 
GO
ALTER DATABASE [digital_bank] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [digital_bank] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [digital_bank] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [digital_bank] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [digital_bank] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [digital_bank] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [digital_bank] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [digital_bank] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [digital_bank] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [digital_bank] SET  DISABLE_BROKER 
GO
ALTER DATABASE [digital_bank] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [digital_bank] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [digital_bank] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [digital_bank] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [digital_bank] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [digital_bank] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [digital_bank] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [digital_bank] SET RECOVERY FULL 
GO
ALTER DATABASE [digital_bank] SET  MULTI_USER 
GO
ALTER DATABASE [digital_bank] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [digital_bank] SET DB_CHAINING OFF 
GO
ALTER DATABASE [digital_bank] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [digital_bank] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [digital_bank] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [digital_bank] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'digital_bank', N'ON'
GO
ALTER DATABASE [digital_bank] SET QUERY_STORE = ON
GO
ALTER DATABASE [digital_bank] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [digital_bank]
GO
/****** Object:  Table [dbo].[user_bank]    Script Date: 20/08/2023 10:35:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user_bank](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NULL,
	[birthdate] [datetime] NULL,
	[gender] [varchar](1) NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[sp_crud_user]    Script Date: 20/08/2023 10:35:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_crud_user]
-- Recibe los parámetros:
-- @operation: tipo de operación a realizar (C, R, U, D) 
-- @id: id del usuario (para operaciones puntuales)
-- @name: nombre del usuario (para busqueda o creación) 
-- @birthdate: fecha de nacimiento
-- @gender: género

    @operation VARCHAR(10),
    @id INT = NULL,
    @name NVARCHAR(100) = NULL,
    @birthdate DATE = NULL,
    @gender CHAR(1) = NULL

AS
BEGIN

IF @operation = 'C' -- Crear nuevo registro
BEGIN
  -- Inserta nuevo usuario con valores recibidos
  INSERT INTO user_bank (name, birthdate, gender)
    VALUES (@name, @birthdate, @gender)
END

IF @operation = 'U' -- Actualizar registro existente
BEGIN
  -- Actualiza usuario con id indicado
  UPDATE user_bank 
  SET name = @name, birthdate = @birthdate, gender = @gender
  WHERE user_id = @id
END

IF @operation = 'R' -- Leer todos los registros
BEGIN
  -- Obtiene todos los usuarios
  SELECT * FROM [dbo].[user_bank] 
END

IF @operation = 'D' -- Eliminar registro
BEGIN
  -- Elimina el usuario con el id indicado
  DELETE FROM user_bank
  WHERE user_id = @id
END

IF @operation = 'S' -- Buscar usuarios por nombre
BEGIN
  -- Busca usuarios cuyo nombre contenga @name 
  -- y devuelve los primeros 4 resultados
  SELECT TOP(4)* FROM user_bank WHERE name LIKE +'%'+@name+'%' 
END

IF @operation = 'SID' -- Leer registro por ID
BEGIN
  -- Obtiene el usuario con el id indicado
  SELECT * FROM user_bank
  WHERE user_id = @id
END
END
GO
USE [master]
GO
ALTER DATABASE [digital_bank] SET  READ_WRITE 
GO
