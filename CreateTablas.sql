CREATE DATABASE PeluqueriaAnita;
GO

USE PeluqueriaAnita;
GO

-- Tabla Clientes
CREATE TABLE Clientes (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Telefono NVARCHAR(20) NULL
);
GO

-- Tabla Citas
CREATE TABLE Citas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ClienteId INT NOT NULL,
    FechaHora DATETIME NOT NULL,
    Estado NVARCHAR(20) NOT NULL, -- Ej: 'Agendada', 'Atendida'

    CONSTRAINT FK_Citas_Clientes FOREIGN KEY (ClienteId)
        REFERENCES Clientes(Id)
        ON DELETE CASCADE
);
GO

-- Tabla Atenciones (Para cuando una cita se convierte en atención)
CREATE TABLE Atenciones (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    CitaId INT NOT NULL,
    Descripcion NVARCHAR(200) NOT NULL, 
    FechaAtencion DATETIME NOT NULL DEFAULT GETDATE(),

    CONSTRAINT FK_Atenciones_Citas FOREIGN KEY (CitaId)
        REFERENCES Citas(Id)
        ON DELETE CASCADE
);
GO

-- Tabla Usuarios (Para el inicio de sesión)
CREATE TABLE Usuarios (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Usuario NVARCHAR(50) NOT NULL UNIQUE,
    PasswordU NVARCHAR(200) NOT NULL, -- Guarda el hash de la contraseña
    NombreCompleto NVARCHAR(100) NOT NULL,
	Cargo NVARCHAR(50)
);
GO



