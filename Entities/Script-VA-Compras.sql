CREATE TABLE Requerimiento (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Fecha DATE,
    Llaves TEXT,
    Nota TEXT,
	Estado TEXT,
	Historia TEXT, --Aqui se detalla la historia => Evento/Fecha/Usuario
	IdUsuario INT NOT NULL,
	IdSEctor INT NOT NULL,
    CONSTRAINT FK_Requerimiento_Sector FOREIGN KEY (IdSector) REFERENCES Sector(Id),
    CONSTRAINT FK_Requerimiento_Usuario FOREIGN KEY (IdUsuario) REFERENCES Usuario(Id)
);
CREATE TABLE DetalleRequerimiento (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    IdRequerimiento INT,
    IdInsumo INT,
    Cantidad INT,
    Precio DECIMAL(10, 2),
    CONSTRAINT FK_DetalleRequerimiento_Requerimiento FOREIGN KEY (IdRequerimiento) REFERENCES Requerimiento(Id),
    CONSTRAINT FK_DetalleRequerimiento_Insumo FOREIGN KEY (IdInsumo) REFERENCES Insumo(Id)
);
CREATE TABLE OrdenPedido (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Fecha DATE,
    Llaves TEXT,
    Nota TEXT,
    IdRequerimiento INT,
    FormaLegal NVARCHAR(255),
	Historia TEXT, --Aqui se detalla la historia => Evento/Fecha/Usuario
	IdUsuario INT NOT NULL,
	IdSEctor INT NOT NULL,
	CONSTRAINT FK_Requerimiento_Sector FOREIGN KEY (IdRequerimiento) REFERENCES Requerimiento(Id),
    CONSTRAINT FK_OrdenPedido_Sector FOREIGN KEY (IdSector) REFERENCES Sector(Id),
    CONSTRAINT FK_OrdenPedido_Usuario FOREIGN KEY (IdUsuario) REFERENCES Usuario(Id)
);
CREATE TABLE DetalleOrdenPedido (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    IdOrdenPedido INT,
    IdInsumo INT,
    Cantidad INT,
    Precio DECIMAL(10, 2),
    CONSTRAINT FK_DetalleOrdenPedido_OrdenPedido FOREIGN KEY (IdOrdenPedido) REFERENCES OrdenPedido(Id),
    CONSTRAINT FK_DetalleOrdenPedido_Insumo FOREIGN KEY (IdInsumo) REFERENCES Insumo(Id)
);
CREATE TABLE OrdenCompra (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Fecha DATE,
    Llaves TEXT,
    Nota TEXT,
    IdOrdenPedido INT,
	Historia TEXT, --Aqui se detalla la historia => Evento/Fecha/Usuario
	IdUsuario INT NOT NULL,
	IdSEctor INT NOT NULL,
    CONSTRAINT FK_OrdenCompra_Sector FOREIGN KEY (IdSector) REFERENCES Sector(Id),
    CONSTRAINT FK_OrdenCompra_Usuario FOREIGN KEY (IdUsuario) REFERENCES Usuario(Id)
);
CREATE TABLE DetalleOrdenCompra (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    IdOrdenCompra INT,
    IdInsumo INT,
    Cantidad INT,
    Precio DECIMAL(10, 2),
    CONSTRAINT FK_DetalleOrdenCompra_OrdenCompra FOREIGN KEY (IdOrdenCompra) REFERENCES OrdenCompra(Id),
    CONSTRAINT FK_DetalleOrdenCompra_Insumo FOREIGN KEY (IdInsumo) REFERENCES Insumo(Id)
);

CREATE TABLE Insumos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(255),
    Activo BIT,
    Nota NVARCHAR(MAX),
    Fecha DATETIME,
    IdUsuario INT NOT NULL,
	IdSEctor INT NOT NULL,
    CONSTRAINT FK_Insumos_Sector FOREIGN KEY (IdSector) REFERENCES Sector(Id),
    CONSTRAINT FK_Insumos_Usuario FOREIGN KEY (IdUsuario) REFERENCES Usuario(Id)
);
CREATE TABLE Sector (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(255),
    Activo BIT,
    Nota NVARCHAR(MAX),
    Fecha DATETIME,
    IdUsuario INT NOT NULL,
    CONSTRAINT FK_Sector_Usuario FOREIGN KEY (IdUsuario) REFERENCES Usuario(Id)
);
CREATE TABLE Proveedor (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(255),
    NombreContacto NVARCHAR(255),
    Direccion NVARCHAR(255),
    Ciudad NVARCHAR(255),
    ProvinciaEstado NVARCHAR(255),
    CodigoPostal NVARCHAR(20),
    Pais NVARCHAR(100),
    Telefono NVARCHAR(20),
    CorreoElectronico NVARCHAR(255),
    SitioWeb NVARCHAR(255),
    TipoProveedor NVARCHAR(100),
    CategoriaProductosServicios NVARCHAR(255),
    Notas NVARCHAR(MAX),
    Fecha DATETIME,
	Llaves TEXT,
    Activo BIT,
    IdUsuario INT NOT NULL,
	IdSEctor INT NOT NULL,
    CONSTRAINT FK_Proveedor_Sector FOREIGN KEY (IdSector) REFERENCES Sector(Id),
    CONSTRAINT FK_Proveedor_Usuario FOREIGN KEY (IdUsuario) REFERENCES Usuario(Id)
);
CREATE TABLE Surtido (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    IdInsumo INT,
    Entidad NVARCHAR(100),
    Nota NVARCHAR(MAX),
    Fecha DATETIME,
	Llaves TEXT,
    Activo BIT,
    IdUsuario INT NOT NULL,
	IdSEctor INT NOT NULL,
    CONSTRAINT FK_Surtido_Sector FOREIGN KEY (IdSector) REFERENCES Sector(Id),
    CONSTRAINT FK_Surtido_Usuario FOREIGN KEY (IdUsuario) REFERENCES Usuario(Id),
	CONSTRAINT FK_Surtido_Insumo FOREIGN KEY (IdInsumo) REFERENCES Insumo(Id)
);
CREATE TABLE Colecciones (
    Id INT IDENTITY(1,1) PRIMARY KEY,
	Nombre NVARCHAR(100),
	Versionado NVARCHAR(100),
	Coleccion NVARCHAR(100),
	Activo BIT,
    IdUsuario INT NOT NULL,
	IdSEctor INT NOT NULL,
    CONSTRAINT FK_Colecciones_Sector FOREIGN KEY (IdSector) REFERENCES Sector(Id),
    CONSTRAINT FK_Colecciones_Usuario FOREIGN KEY (IdUsuario) REFERENCES Usuario(Id)
);