USE [FinanzasPersonales]
GO
/****** Object:  Table [dbo].[Ahorros]    Script Date: 16/01/2025 10:37:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ahorros](
	[IdAhorro] [int] IDENTITY(1,1) NOT NULL,
	[Mes] [nvarchar](50) NOT NULL,
	[Diversion] [decimal](18, 2) NOT NULL,
	[Inversion] [decimal](18, 2) NOT NULL,
	[Intocables] [decimal](18, 2) NOT NULL,
	[IngresoId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdAhorro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gastos]    Script Date: 16/01/2025 10:37:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gastos](
	[IdGasto] [int] IDENTITY(1,1) NOT NULL,
	[Mes] [nvarchar](50) NOT NULL,
	[Descripcion] [nvarchar](255) NOT NULL,
	[Valor] [decimal](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdGasto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ingresos]    Script Date: 16/01/2025 10:37:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ingresos](
	[IdIngreso] [int] IDENTITY(1,1) NOT NULL,
	[Mes] [nvarchar](50) NOT NULL,
	[CantidadChaquetas] [int] NOT NULL,
	[ValorUnitario] [decimal](18, 2) NOT NULL,
	[Total] [decimal](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdIngreso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 16/01/2025 10:37:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NULL,
	[Cedula] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Cedula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Ahorros]  WITH CHECK ADD  CONSTRAINT [FK_Ahorros_Ingresos] FOREIGN KEY([IngresoId])
REFERENCES [dbo].[Ingresos] ([IdIngreso])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Ahorros] CHECK CONSTRAINT [FK_Ahorros_Ingresos]
GO
ALTER TABLE [dbo].[Ahorros]  WITH CHECK ADD  CONSTRAINT [FK_IngresoId] FOREIGN KEY([IngresoId])
REFERENCES [dbo].[Ingresos] ([IdIngreso])
GO
ALTER TABLE [dbo].[Ahorros] CHECK CONSTRAINT [FK_IngresoId]
GO
/****** Object:  StoredProcedure [dbo].[ActualizarIngreso]    Script Date: 16/01/2025 10:37:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Daniel Bambague>
-- Create date: <13/01/2025>
-- Description:	<Procedimiento almacenado para actualizar un ingreso>
-- =============================================
-- Procedimiento almacenado para actualizar un ingreso
CREATE PROCEDURE [dbo].[ActualizarIngreso]
    @IdIngreso INT,
    @Mes NVARCHAR(50),
    @CantidadChaquetas INT,
    @ValorUnitario DECIMAL(18, 2)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Total DECIMAL(18, 2);
    SET @Total = @CantidadChaquetas * @ValorUnitario;

    UPDATE Ingresos
    SET Mes = @Mes,
        CantidadChaquetas = @CantidadChaquetas,
        ValorUnitario = @ValorUnitario,
        Total = @Total
    WHERE IdIngreso = @IdIngreso;

    PRINT 'Ingreso actualizado correctamente.';
END;

GO
/****** Object:  StoredProcedure [dbo].[AgregarGasto]    Script Date: 16/01/2025 10:37:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Daniel Bambague>
-- Create date: <14/01/2025>
-- Description:	<Procedimiento para agregar gastos>
-- =============================================
CREATE PROCEDURE [dbo].[AgregarGasto]
    @Mes NVARCHAR(50),
    @Descripcion NVARCHAR(255),
    @Valor DECIMAL(18, 2)
AS
BEGIN
    INSERT INTO Gastos (Mes, Descripcion, Valor)
    VALUES (@Mes, @Descripcion, @Valor);
END;
GO
/****** Object:  StoredProcedure [dbo].[AgregarIngreso]    Script Date: 16/01/2025 10:37:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Daniel Bambague>
-- Create date: <12/01/2025>
-- Description:	<procedimiento para carlcular los ahorros cuando se ingrese una tupla en la tabla ingresos>
-- =============================================
-- Procedimiento almacenado para agregar un ingreso y distribuir ahorros
CREATE PROCEDURE [dbo].[AgregarIngreso] 
    @Mes NVARCHAR(50),
    @CantidadChaquetas INT,
    @ValorUnitario DECIMAL(18, 2)
AS
BEGIN
    SET NOCOUNT ON;

    -- Calcular el total del ingreso
    DECLARE @Total DECIMAL(18, 2);
    SET @Total = @CantidadChaquetas * @ValorUnitario;

    -- Insertar el ingreso en la tabla Ingresos
    INSERT INTO Ingresos (Mes, CantidadChaquetas, ValorUnitario, Total)
    VALUES (@Mes, @CantidadChaquetas, @ValorUnitario, @Total);

    -- Calcular los ahorros
    DECLARE @Diversion DECIMAL(18, 2) = @Total * 0.10;
    DECLARE @Inversion DECIMAL(18, 2) = @Total * 0.10;
    DECLARE @Intocables DECIMAL(18, 2) = @Total * 0.20;
	DECLARE @IngresoId INT = SCOPE_IDENTITY();

	

    -- Insertar los ahorros en la tabla Ahorros
    INSERT INTO Ahorros (Mes, Diversion, Inversion, Intocables, IngresoId)
    VALUES (@Mes, @Diversion, @Inversion, @Intocables, @IngresoId );
	-- Obtiene el ID del último ingreso insertado (con una subconsulta que busca el último ingreso por el mes)
	
	
   
   
    SET @IngresoId = (SELECT TOP 1 IdIngreso FROM Ingresos WHERE Mes = @Mes ORDER BY IdIngreso DESC);

    -- Actualiza la tabla Ahorros con el ID del ingreso en la columna IngresoId
    

    -- Ajustar el total disponible después del ahorro (opcional, si deseas llevar un control externo)
    PRINT 'Ingreso registrado y ahorros distribuidos correctamente.';
END;
GO
/****** Object:  StoredProcedure [dbo].[EliminarGasto]    Script Date: 16/01/2025 10:37:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Daniel Bambague>
-- Create date: <14/01/2025>
-- Description:	<Eliminar gasto>
-- =============================================
CREATE PROCEDURE [dbo].[EliminarGasto]
    @IdGasto INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM Gastos
    WHERE IdGasto = @IdGasto;
END;
GO
/****** Object:  StoredProcedure [dbo].[EliminarIngreso]    Script Date: 16/01/2025 10:37:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Daniel Bambague>
-- Create date: <13/01/2025>
-- Description:	<Procedimiento almacenado para eliminar un ingreso>
-- =============================================
-- Procedimiento almacenado para eliminar un ingreso
CREATE   PROCEDURE [dbo].[EliminarIngreso]
    @IdIngreso INT
AS
BEGIN
    -- Eliminar los ahorros asociados al ingreso
    DELETE FROM Ahorros
    WHERE IngresoId = @IdIngreso;

    -- Eliminar el ingreso
    DELETE FROM Ingresos
    WHERE IdIngreso = @IdIngreso;
END;
GO
/****** Object:  StoredProcedure [dbo].[ObtenerResumenMensual]    Script Date: 16/01/2025 10:37:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Daniel Bambague>
-- Create date: <12/1/2025>
-- Description:	<Procedimiento almacenado para calcular el saldo por mes>
-- =============================================
-- Procedimiento almacenado para calcular el saldo por mes
CREATE PROCEDURE [dbo].[ObtenerResumenMensual]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        i.Mes,
        SUM(i.Total) AS TotalIngresos,
        ISNULL(g.TotalGastos, 0) AS TotalGastos,
        (SUM(i.Total) - ISNULL(g.TotalGastos, 0) - ISNULL(a.TotalAhorros, 0)) AS SaldoRestante
    FROM 
        Ingresos i
    LEFT JOIN (
            SELECT Mes, SUM(Valor) AS TotalGastos
            FROM Gastos
            GROUP BY Mes
        ) g ON i.Mes = g.Mes
    LEFT JOIN (
            SELECT Mes, SUM(Diversion + Inversion + Intocables) AS TotalAhorros
            FROM Ahorros
            GROUP BY Mes
        ) a ON i.Mes = a.Mes
    GROUP BY 
        i.Mes, g.TotalGastos, a.TotalAhorros;
END;

GO
