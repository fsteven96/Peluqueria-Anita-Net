CREATE PROCEDURE sp_ValidarUsuario
    @Usuario NVARCHAR(50),
    @PasswordU NVARCHAR(200)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        Id,
        Usuario,
        NombreCompleto,
        Cargo
    FROM Usuarios
    WHERE Usuario = @Usuario AND PasswordU = @PasswordU;
END;
GO



CREATE PROCEDURE sp_AgregarCliente
    @Nombre NVARCHAR(100),
    @Telefono NVARCHAR(20) = NULL
AS
BEGIN
    INSERT INTO Clientes (Nombre, Telefono)
    VALUES (@Nombre, @Telefono);
END;
GO


CREATE PROCEDURE sp_ObtenerCitasActivas
AS
BEGIN
    SELECT
        c.Id,
        c.ClienteId,
        cl.Nombre ,
        c.FechaHora,
        c.Estado
    FROM Citas c
    INNER JOIN Clientes cl ON c.ClienteId = cl.Id
    
    ORDER BY c.FechaHora DESC;
END;
GO


CREATE PROCEDURE AgregarCita
    @ClienteId INT,
    @FechaHora DATETIME,
    @Estado NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Citas (ClienteId, FechaHora, Estado)
    VALUES (@ClienteId, @FechaHora, @Estado);

   
END;
GO


CREATE PROCEDURE sp_ObtenerAtenciones
AS
BEGIN
    SELECT 
        a.Id ,
        a.CitaId,
        c.FechaHora ,
        cl.Nombre ,
        a.Descripcion,
        a.FechaAtencion
    FROM Atenciones a
    INNER JOIN Citas c ON a.CitaId = c.Id
    INNER JOIN Clientes cl ON c.ClienteId = cl.Id
    ORDER BY a.FechaAtencion DESC;
END;
GO

CREATE PROCEDURE sp_GuardarAtencion
    @CitaId INT,
    @Descripcion NVARCHAR(200)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        -- Insertar la atención
        INSERT INTO Atenciones (CitaId, Descripcion)
        VALUES (@CitaId, @Descripcion);

        -- Actualizar el estado de la cita a 'Culminada'
        UPDATE Citas
        SET Estado = 'Culminada'
        WHERE Id = @CitaId;

        COMMIT;
    END TRY
    BEGIN CATCH
        ROLLBACK;
        THROW;
    END CATCH
END;
GO