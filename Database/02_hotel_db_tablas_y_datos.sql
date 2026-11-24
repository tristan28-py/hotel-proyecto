-- ============================================================================
-- Script 02: Tablas, restricciones, índices y datos iniciales de hotel_db
-- Compatible con SQL Server local (USE hotel_db) y Azure SQL Database.
-- Nota para Azure SQL: ejecutar conectado directamente a la BD hotel_db
-- (omitir o comentar la línea USE hotel_db si el entorno no la permite).
-- ============================================================================

-- ============================================================================
-- 1. CREACIÓN DE TABLAS
-- ============================================================================

IF OBJECT_ID(N'dbo.Usuarios', N'U') IS NOT NULL DROP TABLE dbo.Usuarios;
IF OBJECT_ID(N'dbo.DetallePedidos', N'U') IS NOT NULL DROP TABLE dbo.DetallePedidos;
IF OBJECT_ID(N'dbo.PedidosRestaurante', N'U') IS NOT NULL DROP TABLE dbo.PedidosRestaurante;
IF OBJECT_ID(N'dbo.Platillos', N'U') IS NOT NULL DROP TABLE dbo.Platillos;
IF OBJECT_ID(N'dbo.CategoriasPlatillo', N'U') IS NOT NULL DROP TABLE dbo.CategoriasPlatillo;
IF OBJECT_ID(N'dbo.Pagos', N'U') IS NOT NULL DROP TABLE dbo.Pagos;
IF OBJECT_ID(N'dbo.Reservaciones', N'U') IS NOT NULL DROP TABLE dbo.Reservaciones;
IF OBJECT_ID(N'dbo.Habitaciones', N'U') IS NOT NULL DROP TABLE dbo.Habitaciones;
IF OBJECT_ID(N'dbo.TiposHabitacion', N'U') IS NOT NULL DROP TABLE dbo.TiposHabitacion;
IF OBJECT_ID(N'dbo.Clientes', N'U') IS NOT NULL DROP TABLE dbo.Clientes;
GO

CREATE TABLE dbo.Clientes (
    Id                  INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Clientes PRIMARY KEY,
    TipoDocumento       NVARCHAR(20)  NOT NULL,
    NumeroDocumento     NVARCHAR(30)  NOT NULL,
    Nombres             NVARCHAR(100) NOT NULL,
    Apellidos           NVARCHAR(100) NOT NULL,
    Nacionalidad        NVARCHAR(60)  NOT NULL CONSTRAINT DF_Clientes_Nacionalidad DEFAULT (N'Costarricense'),
    Email               NVARCHAR(150) NOT NULL,
    Telefono            NVARCHAR(30)  NOT NULL,
    TelefonoEmergencia  NVARCHAR(30)  NULL,
    Direccion           NVARCHAR(250) NULL,
    FechaNacimiento     DATE          NULL,
    Preferencias        NVARCHAR(250) NULL,
    EsClienteFrecuente  BIT           NOT NULL CONSTRAINT DF_Clientes_Frecuente DEFAULT (0),
    FechaRegistro       DATETIME2     NOT NULL CONSTRAINT DF_Clientes_FechaRegistro DEFAULT (SYSUTCDATETIME()),
    CONSTRAINT CK_Clientes_TipoDocumento CHECK (TipoDocumento IN (N'DNI', N'Pasaporte', N'Cedula')),
    CONSTRAINT UQ_Clientes_Documento UNIQUE (TipoDocumento, NumeroDocumento),
    CONSTRAINT UQ_Clientes_Email UNIQUE (Email)
);
GO

CREATE TABLE dbo.TiposHabitacion (
    Id                  INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_TiposHabitacion PRIMARY KEY,
    Nombre              NVARCHAR(80)  NOT NULL,
    Descripcion         NVARCHAR(300) NULL,
    CapacidadAdultos    INT           NOT NULL,
    CapacidadNinos      INT           NOT NULL CONSTRAINT DF_TiposHabitacion_Ninos DEFAULT (0),
    PrecioBasePorNoche  DECIMAL(10,2) NOT NULL,
    CONSTRAINT UQ_TiposHabitacion_Nombre UNIQUE (Nombre),
    CONSTRAINT CK_TiposHabitacion_Adultos CHECK (CapacidadAdultos > 0),
    CONSTRAINT CK_TiposHabitacion_Ninos CHECK (CapacidadNinos >= 0),
    CONSTRAINT CK_TiposHabitacion_Precio CHECK (PrecioBasePorNoche > 0)
);
GO

CREATE TABLE dbo.Habitaciones (
    Id                      INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Habitaciones PRIMARY KEY,
    Numero                  NVARCHAR(10)  NOT NULL,
    Piso                    INT           NOT NULL,
    TipoHabitacionId        INT           NOT NULL,
    EstadoOperativo         NVARCHAR(30)  NOT NULL CONSTRAINT DF_Habitaciones_Estado DEFAULT (N'Disponible'),
    TieneJacuzzi            BIT           NOT NULL CONSTRAINT DF_Habitaciones_Jacuzzi DEFAULT (0),
    TieneVistaMar           BIT           NOT NULL CONSTRAINT DF_Habitaciones_VistaMar DEFAULT (0),
    TieneWifi6              BIT           NOT NULL CONSTRAINT DF_Habitaciones_Wifi6 DEFAULT (1),
    TieneFrigobar           BIT           NOT NULL CONSTRAINT DF_Habitaciones_Frigobar DEFAULT (0),
    AmenidadesAdicionales   NVARCHAR(250) NULL,
    Activa                  BIT           NOT NULL CONSTRAINT DF_Habitaciones_Activa DEFAULT (1),
    CONSTRAINT UQ_Habitaciones_Numero UNIQUE (Numero),
    CONSTRAINT FK_Habitaciones_TiposHabitacion FOREIGN KEY (TipoHabitacionId) REFERENCES dbo.TiposHabitacion(Id),
    CONSTRAINT CK_Habitaciones_Piso CHECK (Piso >= 1),
    CONSTRAINT CK_Habitaciones_Estado CHECK (EstadoOperativo IN (N'Disponible', N'Reservada', N'Ocupada', N'EnLimpieza', N'EnMantenimiento', N'Bloqueada'))
);
GO

CREATE TABLE dbo.Reservaciones (
    Id                      INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Reservaciones PRIMARY KEY,
    Codigo                  NVARCHAR(30)  NOT NULL,
    ClienteId               INT           NOT NULL,
    HabitacionId            INT           NOT NULL,
    FechaInicio             DATE          NOT NULL,
    FechaFin                DATE          NOT NULL,
    HoraLlegadaPactada      TIME          NULL,
    Estado                  NVARCHAR(30)  NOT NULL CONSTRAINT DF_Reservaciones_Estado DEFAULT (N'PendientePago'),
    CantidadHuespedes       INT           NOT NULL,
    SubtotalHospedaje       DECIMAL(10,2) NOT NULL CONSTRAINT DF_Reservaciones_Subtotal DEFAULT (0),
    RecargoTemporada        DECIMAL(10,2) NOT NULL CONSTRAINT DF_Reservaciones_RecargoTemp DEFAULT (0),
    RecargoPersonasExtra    DECIMAL(10,2) NOT NULL CONSTRAINT DF_Reservaciones_RecargoExtra DEFAULT (0),
    DescuentoCliente        DECIMAL(10,2) NOT NULL CONSTRAINT DF_Reservaciones_Descuento DEFAULT (0),
    Impuestos               DECIMAL(10,2) NOT NULL CONSTRAINT DF_Reservaciones_Impuestos DEFAULT (0),
    AjustesCheckOut         DECIMAL(10,2) NOT NULL CONSTRAINT DF_Reservaciones_Ajustes DEFAULT (0),
    CostoTotal              DECIMAL(10,2) NOT NULL,
    MontoAnticipoRequerido  DECIMAL(10,2) NOT NULL CONSTRAINT DF_Reservaciones_Anticipo DEFAULT (0),
    FechaCheckInReal        DATETIME2     NULL,
    FechaCheckOutReal       DATETIME2     NULL,
    Acompanantes            NVARCHAR(500) NULL,
    LlavesAsignadas         NVARCHAR(100) NULL,
    Observaciones           NVARCHAR(500) NULL,
    FechaCreacion           DATETIME2     NOT NULL CONSTRAINT DF_Reservaciones_FechaCreacion DEFAULT (SYSUTCDATETIME()),
    RowVersion              ROWVERSION    NOT NULL,
    CONSTRAINT UQ_Reservaciones_Codigo UNIQUE (Codigo),
    CONSTRAINT FK_Reservaciones_Clientes FOREIGN KEY (ClienteId) REFERENCES dbo.Clientes(Id),
    CONSTRAINT FK_Reservaciones_Habitaciones FOREIGN KEY (HabitacionId) REFERENCES dbo.Habitaciones(Id),
    CONSTRAINT CK_Reservaciones_Fechas CHECK (FechaInicio < FechaFin),
    CONSTRAINT CK_Reservaciones_Huespedes CHECK (CantidadHuespedes > 0),
    CONSTRAINT CK_Reservaciones_Estado CHECK (Estado IN (N'PendientePago', N'Confirmada', N'EnCurso', N'Completada', N'Cancelada')),
    CONSTRAINT CK_Reservaciones_CostoTotal CHECK (CostoTotal >= 0)
);
GO

CREATE NONCLUSTERED INDEX IX_Reservaciones_Habitacion_Fechas
    ON dbo.Reservaciones (HabitacionId, Estado, FechaInicio, FechaFin);
GO

CREATE TABLE dbo.Pagos (
    Id                      INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Pagos PRIMARY KEY,
    ReservacionId           INT           NOT NULL,
    Monto                   DECIMAL(10,2) NOT NULL,
    MetodoPago              NVARCHAR(40)  NOT NULL,
    FechaPago               DATETIME2     NOT NULL CONSTRAINT DF_Pagos_FechaPago DEFAULT (SYSUTCDATETIME()),
    ReferenciaTransaccion   NVARCHAR(100) NULL,
    TipoComprobante         NVARCHAR(20)  NOT NULL CONSTRAINT DF_Pagos_TipoComp DEFAULT (N'Recibo'),
    NumeroComprobante       NVARCHAR(40)  NULL,
    Notas                   NVARCHAR(250) NULL,
    CONSTRAINT FK_Pagos_Reservaciones FOREIGN KEY (ReservacionId) REFERENCES dbo.Reservaciones(Id),
    CONSTRAINT CK_Pagos_Monto CHECK (Monto > 0),
    CONSTRAINT CK_Pagos_MetodoPago CHECK (MetodoPago IN (N'Efectivo', N'TarjetaCredito', N'TarjetaDebito', N'TransferenciaBancaria')),
    CONSTRAINT CK_Pagos_TipoComprobante CHECK (TipoComprobante IN (N'Recibo', N'Factura'))
);
GO

CREATE TABLE dbo.CategoriasPlatillo (
    Id          INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_CategoriasPlatillo PRIMARY KEY,
    Nombre      NVARCHAR(80)  NOT NULL,
    Descripcion NVARCHAR(250) NULL,
    Activo      BIT           NOT NULL CONSTRAINT DF_CategoriasPlatillo_Activo DEFAULT (1),
    CONSTRAINT UQ_CategoriasPlatillo_Nombre UNIQUE (Nombre)
);
GO

CREATE TABLE dbo.Platillos (
    Id                        INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Platillos PRIMARY KEY,
    CategoriaId               INT           NOT NULL,
    Nombre                    NVARCHAR(120) NOT NULL,
    Descripcion               NVARCHAR(350) NULL,
    Precio                    DECIMAL(10,2) NOT NULL,
    TiempoPreparacionMinutos  INT           NOT NULL,
    Disponible                BIT           NOT NULL CONSTRAINT DF_Platillos_Disponible DEFAULT (1),
    Activo                    BIT           NOT NULL CONSTRAINT DF_Platillos_Activo DEFAULT (1),
    ImagenUrl                 NVARCHAR(300) NULL,
    CONSTRAINT FK_Platillos_CategoriasPlatillo FOREIGN KEY (CategoriaId) REFERENCES dbo.CategoriasPlatillo(Id),
    CONSTRAINT CK_Platillos_Precio CHECK (Precio > 0),
    CONSTRAINT CK_Platillos_Tiempo CHECK (TiempoPreparacionMinutos > 0)
);
GO

CREATE TABLE dbo.PedidosRestaurante (
    Id                      INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_PedidosRestaurante PRIMARY KEY,
    ReservacionId           INT           NOT NULL,
    FechaPedido             DATETIME2     NOT NULL CONSTRAINT DF_PedidosRestaurante_Fecha DEFAULT (SYSUTCDATETIME()),
    FechaHoraDeseada        DATETIME2     NOT NULL CONSTRAINT DF_PedidosRestaurante_FechaDeseada DEFAULT (SYSUTCDATETIME()),
    EstadoPedido            NVARCHAR(30)  NOT NULL CONSTRAINT DF_PedidosRestaurante_Estado DEFAULT (N'Recibido'),
    Subtotal                DECIMAL(10,2) NOT NULL CONSTRAINT DF_PedidosRestaurante_Subtotal DEFAULT (0),
    RecargoServicio         DECIMAL(10,2) NOT NULL CONSTRAINT DF_PedidosRestaurante_Recargo DEFAULT (0),
    Total                   DECIMAL(10,2) NOT NULL,
    EsRoomService           BIT           NOT NULL CONSTRAINT DF_PedidosRestaurante_RoomService DEFAULT (1),
    NumeroMesa              NVARCHAR(20)  NULL,
    InstruccionesEspeciales NVARCHAR(500) NULL,
    CONSTRAINT FK_PedidosRestaurante_Reservaciones FOREIGN KEY (ReservacionId) REFERENCES dbo.Reservaciones(Id),
    CONSTRAINT CK_PedidosRestaurante_Estado CHECK (EstadoPedido IN (N'Recibido', N'EnCocina', N'EnCamino', N'Entregado', N'Cancelado')),
    CONSTRAINT CK_PedidosRestaurante_Total CHECK (Total >= 0)
);
GO

CREATE TABLE dbo.DetallePedidos (
    Id              INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_DetallePedidos PRIMARY KEY,
    PedidoId        INT           NOT NULL,
    PlatilloId      INT           NOT NULL,
    Cantidad        INT           NOT NULL,
    PrecioUnitario  DECIMAL(10,2) NOT NULL,
    Subtotal        DECIMAL(10,2) NOT NULL,
    CONSTRAINT FK_DetallePedidos_Pedidos FOREIGN KEY (PedidoId) REFERENCES dbo.PedidosRestaurante(Id),
    CONSTRAINT FK_DetallePedidos_Platillos FOREIGN KEY (PlatilloId) REFERENCES dbo.Platillos(Id),
    CONSTRAINT CK_DetallePedidos_Cantidad CHECK (Cantidad > 0),
    CONSTRAINT CK_DetallePedidos_Precio CHECK (PrecioUnitario > 0),
    CONSTRAINT CK_DetallePedidos_Subtotal CHECK (Subtotal >= 0)
);
GO

CREATE TABLE dbo.Usuarios (
    Id              INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Usuarios PRIMARY KEY,
    Username        NVARCHAR(50)  NOT NULL,
    PasswordHash    NVARCHAR(256) NOT NULL,
    NombreCompleto  NVARCHAR(120) NOT NULL,
    Rol             NVARCHAR(30)  NOT NULL,
    ClienteId       INT           NULL,
    Activo          BIT           NOT NULL CONSTRAINT DF_Usuarios_Activo DEFAULT (1),
    FechaCreacion   DATETIME2     NOT NULL CONSTRAINT DF_Usuarios_FechaCreacion DEFAULT (SYSUTCDATETIME()),
    CONSTRAINT UQ_Usuarios_Username UNIQUE (Username),
    CONSTRAINT FK_Usuarios_Clientes FOREIGN KEY (ClienteId) REFERENCES dbo.Clientes(Id),
    CONSTRAINT CK_Usuarios_Rol CHECK (Rol IN (N'Administrador', N'Recepcionista', N'Cliente'))
);
GO

-- ============================================================================
-- 2. DATOS INICIALES (SEED)
-- ============================================================================

INSERT INTO dbo.TiposHabitacion (Nombre, Descripcion, CapacidadAdultos, CapacidadNinos, PrecioBasePorNoche)
VALUES
    (N'Simple',            N'Habitación individual confortable con cama queen y escritorio de trabajo.', 1, 1, 85.00),
    (N'Doble Estándar',    N'Habitación amplia con dos camas matrimoniales ideal para parejas o amigos.', 2, 2, 130.00),
    (N'Suite Ejecutiva',   N'Suite con sala de estar privada, vista panorámica y amenidades ejecutivas.', 2, 2, 210.00),
    (N'Suite Presidencial',N'Suite de lujo en piso superior con jacuzzi, terraza y servicio VIP.', 4, 2, 390.00),
    (N'Familiar',          N'Habitación interconectada diseñada para grupos familiares.', 4, 3, 240.00);
GO

INSERT INTO dbo.Habitaciones (Numero, Piso, TipoHabitacionId, EstadoOperativo, TieneJacuzzi, TieneVistaMar, TieneWifi6, TieneFrigobar, AmenidadesAdicionales, Activa)
VALUES
    (N'101', 1, 1, N'Disponible',      0, 0, 1, 0, N'Smart TV 50", Caja fuerte', 1),
    (N'102', 1, 1, N'Ocupada',         0, 0, 1, 0, N'Smart TV 50", Escritorio ergonómico', 1),
    (N'103', 1, 2, N'Disponible',      0, 0, 1, 1, N'Balcón jardín, Cafetera', 1),
    (N'104', 1, 2, N'EnLimpieza',      0, 0, 1, 1, N'Balcón jardín, Smart TV', 1),
    (N'201', 2, 2, N'Reservada',       0, 1, 1, 1, N'Vista parcial al mar, Cafetera', 1),
    (N'202', 2, 3, N'Ocupada',         1, 1, 1, 1, N'Sala privada, Máquina Espresso', 1),
    (N'203', 2, 3, N'Disponible',      1, 1, 1, 1, N'Sala privada, Terraza', 1),
    (N'204', 2, 5, N'Disponible',      0, 0, 1, 1, N'Dos baños, Litera infantil', 1),
    (N'301', 3, 3, N'EnMantenimiento', 1, 1, 1, 1, N'Piso alto, Vista total al mar', 1),
    (N'302', 3, 5, N'Disponible',      0, 1, 1, 1, N'Terraza familiar, Cocineta', 1),
    (N'303', 3, 4, N'Disponible',      1, 1, 1, 1, N'Jacuzzi privado, Comedor, Butler 24h', 1),
    (N'304', 3, 4, N'Reservada',       1, 1, 1, 1, N'Jacuzzi terraza, Bar privado', 1);
GO

INSERT INTO dbo.Clientes (TipoDocumento, NumeroDocumento, Nombres, Apellidos, Nacionalidad, Email, Telefono, TelefonoEmergencia, Direccion, FechaNacimiento, Preferencias, EsClienteFrecuente)
VALUES
    (N'Cedula',    N'1-1456-0789', N'Carlos Eduardo', N'Solís Guevara',  N'Costarricense', N'carlos.solis@correo.com',    N'+506 8888-1122', N'+506 8888-0001', N'San José, Escazú',        '1992-04-18', N'Piso alto, almohada firme', 1),
    (N'DNI',       N'45891234',    N'Valeria',        N'Mendoza Ríos',   N'Peruana',       N'valeria.mendoza@correo.com', N'+51 999-445-210', N'+51 999-111-222', N'Lima, Miraflores',        '1989-09-25', N'Vista al mar, sin lactosa', 1),
    (N'Pasaporte', N'US99881122',  N'Michael',        N'Anderson',       N'Estadounidense',N'm.anderson@correo.com',      N'+1 305-555-0199', N'+1 305-555-0100', N'Miami, FL',               '1985-12-03', N'Cama King, check-in tarde', 0),
    (N'Cedula',    N'2-0712-0345', N'Sofía',          N'Ramírez Vargas', N'Costarricense', N'sofia.ramirez@correo.com',   N'+506 7011-3344', N'+506 7011-0000', N'Alajuela, Centro',        '1996-06-11', N'Habitación silenciosa', 0),
    (N'DNI',       N'31987456',    N'Mateo',          N'Fernández Cruz', N'Mexicana',      N'mateo.fernandez@correo.com', N'+52 55-4433-2211', N'+52 55-0011-2233', N'Ciudad de México',        '1991-02-14', N'Cerca del ascensor', 0);
GO

-- Reservaciones iniciales usando fechas relativas a hoy para que siempre haya datos vigentes en demo
DECLARE @Hoy DATE = CAST(GETUTCDATE() AS DATE);

INSERT INTO dbo.Reservaciones (
    Codigo, ClienteId, HabitacionId, FechaInicio, FechaFin, HoraLlegadaPactada,
    Estado, CantidadHuespedes, SubtotalHospedaje, RecargoTemporada, RecargoPersonasExtra,
    DescuentoCliente, Impuestos, AjustesCheckOut, CostoTotal, MontoAnticipoRequerido,
    FechaCheckInReal, FechaCheckOutReal, Acompanantes, LlavesAsignadas, Observaciones
)
VALUES
    (N'RES-2026-0001', 1, 2, DATEADD(DAY, -1, @Hoy), DATEADD(DAY, 2, @Hoy), '14:00:00',
     N'EnCurso', 1, 255.00, 0.00, 0.00, 25.50, 36.72, 0.00, 266.22, 79.87,
     DATEADD(HOUR, -20, SYSUTCDATETIME()), NULL, N'Titular únicamente', N'LLAVE-102A', N'Huésped frecuente en estadía activa.'),

    (N'RES-2026-0002', 2, 6, DATEADD(DAY, -2, @Hoy), DATEADD(DAY, 1, @Hoy), '15:00:00',
     N'EnCurso', 2, 630.00, 63.00, 0.00, 63.00, 100.80, 0.00, 730.80, 219.24,
     DATEADD(HOUR, -42, SYSUTCDATETIME()), NULL, N'Laura Mendoza', N'LLAVE-202A, LLAVE-202B', N'Solicitó vista al mar y desayuno temprano.'),

    (N'RES-2026-0003', 3, 5, DATEADD(DAY, 1, @Hoy), DATEADD(DAY, 4, @Hoy), '16:00:00',
     N'Confirmada', 2, 390.00, 0.00, 0.00, 0.00, 62.40, 0.00, 452.40, 135.72,
     NULL, NULL, N'Sarah Anderson', NULL, N'Anticipo del 30% cancelado vía tarjeta.'),

    (N'RES-2026-0004', 4, 12, DATEADD(DAY, 3, @Hoy), DATEADD(DAY, 6, @Hoy), '15:00:00',
     N'PendientePago', 3, 1170.00, 117.00, 0.00, 0.00, 205.92, 0.00, 1492.92, 447.88,
     NULL, NULL, N'Familia Ramírez', NULL, N'Pendiente de pago de seña para confirmar.'),

    (N'RES-2026-0005', 5, 4, DATEADD(DAY, -5, @Hoy), DATEADD(DAY, -1, @Hoy), '14:00:00',
     N'Completada', 2, 520.00, 52.00, 0.00, 0.00, 91.52, 0.00, 663.52, 199.06,
     DATEADD(DAY, -5, SYSUTCDATETIME()), DATEADD(DAY, -1, SYSUTCDATETIME()), N'Ana Cruz', N'Devueltas', N'Check-out completado sin novedades.');
GO

INSERT INTO dbo.Pagos (ReservacionId, Monto, MetodoPago, ReferenciaTransaccion, TipoComprobante, NumeroComprobante, Notas)
VALUES
    (1, 150.00, N'TarjetaCredito',      N'VISA-884120', N'Recibo',  N'REC-0001', N'Abono inicial check-in'),
    (2, 300.00, N'TransferenciaBancaria', N'TRF-992011', N'Recibo',  N'REC-0002', N'Anticipo de reserva confirmado'),
    (3, 140.00, N'TarjetaDebito',       N'DEB-552190', N'Recibo',  N'REC-0003', N'Seña mínima requerida'),
    (5, 663.52, N'TarjetaCredito',      N'MC-774100',  N'Factura', N'FAC-0001', N'Liquidación total check-out');
GO

INSERT INTO dbo.CategoriasPlatillo (Nombre, Descripcion, Activo)
VALUES
    (N'Entradas',       N'Aperitivos fríos y calientes para abrir el apetito.', 1),
    (N'Platos Fuertes', N'Cortes, pescados, pastas y especialidades del chef.', 1),
    (N'Guarniciones',   N'Acompañamientos frescos y horneados.', 1),
    (N'Postres',        N'Repostería artesanal y postres de la casa.', 1),
    (N'Bebidas',        N'Jugos naturales, cafés, tés y coctelería sin alcohol.', 1),
    (N'Vinos',          N'Selección de vinos tintos, blancos y espumosos.', 1);
GO

INSERT INTO dbo.Platillos (CategoriaId, Nombre, Descripcion, Precio, TiempoPreparacionMinutos, Disponible, Activo, ImagenUrl)
VALUES
    (1, N'Ceviche de Corvina Caribeño', N'Corvina fresca marinada en limón mandarino con aguacate y chips de plátano.', 14.50, 12, 1, 1, NULL),
    (1, N'Bruschettas Caprese',         N'Pan artesanal tostado con tomate cherry, mozzarella fresca y reducción balsámica.', 11.00, 10, 1, 1, NULL),
    (2, N'Salmón a la Parrilla',        N'Filete de salmón sellado con salsa de maracuyá y vegetales salteados.', 28.00, 22, 1, 1, NULL),
    (2, N'Lomo Fino en Salsa de Vino',  N'Medallón de res 250g con reducción de vino tinto y puré trufado.', 34.00, 25, 1, 1, NULL),
    (2, N'Risotto de Hongos Silvestres',N'Arroz arborio cremoso con mezcla de setas y queso parmesano añejo.', 22.50, 20, 1, 1, NULL),
    (3, N'Papas Rústicas al Romero',    N'Papas horneadas con aceite de oliva, ajo confitado y romero.', 6.50, 12, 1, 1, NULL),
    (3, N'Ensalada César Clásica',      N'Lechuga romana, aderezo de la casa, crutones y lascas de parmesano.', 8.50, 8, 1, 1, NULL),
    (4, N'Volcán de Chocolate 70%',     N'Bizcocho tibio relleno de ganache oscuro con helado de vainilla.', 10.50, 15, 1, 1, NULL),
    (4, N'Cheesecake de Maracuyá',      N'Base crocante de galleta con crema suave y coulis tropical.', 9.50, 5, 1, 1, NULL),
    (5, N'Limonada con Hierbabuena',    N'Refrescante mezcla natural recién preparada.', 4.75, 5, 1, 1, NULL),
    (5, N'Espresso Doble Gourmet',      N'Café de altura 100% arábica recién molido.', 4.00, 4, 1, 1, NULL),
    (6, N'Copa Cabernet Sauvignon',     N'Reserva especial del valle con notas a frutos rojos y roble.', 13.00, 3, 1, 1, NULL);
GO

INSERT INTO dbo.PedidosRestaurante (ReservacionId, FechaPedido, FechaHoraDeseada, EstadoPedido, Subtotal, RecargoServicio, Total, EsRoomService, NumeroMesa, InstruccionesEspeciales)
VALUES
    (1, DATEADD(HOUR, -3, SYSUTCDATETIME()), DATEADD(HOUR, -2, SYSUTCDATETIME()), N'Entregado', 34.25, 3.43, 37.68, 1, NULL, N'Sin cebolla en el ceviche, por favor.'),
    (2, DATEADD(MINUTE, -25, SYSUTCDATETIME()), SYSUTCDATETIME(), N'EnCocina', 44.50, 0.00, 44.50, 0, N'M-04', N'Término medio para el lomo.');
GO

INSERT INTO dbo.DetallePedidos (PedidoId, PlatilloId, Cantidad, PrecioUnitario, Subtotal)
VALUES
    (1, 1, 1, 14.50, 14.50),
    (1, 2, 1, 11.00, 11.00),
    (1, 10, 1, 4.75, 4.75),
    (1, 11, 1, 4.00, 4.00),
    (2, 4, 1, 34.00, 34.00),
    (2, 8, 1, 10.50, 10.50);
GO

INSERT INTO dbo.Usuarios (Username, PasswordHash, NombreCompleto, Rol, ClienteId, Activo)
VALUES
    (N'admin',     N'573A9E4FF687BC0104427E921407309A2DBE2FF5563A360056F0B8D45CBCE3C1', N'Administrador General',       N'Administrador', NULL, 1),
    (N'recepcion', N'7AC5423D4100DE2899C28BF5EF129ACAAB94E13723830FE557F7226168988E4B', N'Laura Vargas (Recepcion)',    N'Recepcionista', NULL, 1),
    (N'cliente',   N'A71552734870E0F3C071BE17B24513969D03A8714D235B3C41FAEF726C043DF2', N'Carlos Eduardo Solis Guevara',N'Cliente',       1,    1);
GO
