IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [BuzonSugerencia] (
    [BuzonSugerenciaId] uniqueidentifier NOT NULL,
    [UsuarioId] nvarchar(50) NOT NULL,
    [Comentarios] nvarchar(850) NOT NULL,
    [CREATED_AT] datetimeoffset NOT NULL,
    [CREATED_BY] nvarchar(50) NOT NULL,
    [UPDATED_AT] datetimeoffset NULL,
    [UPDATED_BY] nvarchar(50) NULL,
    CONSTRAINT [PK_BuzonSugerencia] PRIMARY KEY ([BuzonSugerenciaId])
);
DECLARE @defaultSchema AS sysname;
SET @defaultSchema = SCHEMA_NAME();
DECLARE @description AS sql_variant;
SET @description = N'Tabla donde estan las sugerencias del usuario de la app móvil de Oxxo Gas.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'BuzonSugerencia';
SET @description = N'Identificador de la sugerencia';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'BuzonSugerencia', 'COLUMN', N'BuzonSugerenciaId';
SET @description = N'Identificador del usuario';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'BuzonSugerencia', 'COLUMN', N'UsuarioId';
SET @description = N'Texto de la sugerencia';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'BuzonSugerencia', 'COLUMN', N'Comentarios';
SET @description = N'Auditoria. Fecha en la que se creo el registro.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'BuzonSugerencia', 'COLUMN', N'CREATED_AT';
SET @description = N'Auditoria. Usuario que creo el registro.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'BuzonSugerencia', 'COLUMN', N'CREATED_BY';
SET @description = N'Auditoria. Fecha en la que se modifico el registro.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'BuzonSugerencia', 'COLUMN', N'UPDATED_AT';
SET @description = N'Auditoria. Usuario que modifico el registro.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'BuzonSugerencia', 'COLUMN', N'UPDATED_BY';
GO

CREATE TABLE [CatSeccionPreguntaFrecuente] (
    [SeccionPreguntaFrecuenteID] uniqueidentifier NOT NULL,
    [Titulo] nvarchar(50) NOT NULL,
    [UrlImagen] nvarchar(255) NOT NULL,
    [Posicion] int NOT NULL,
    [Activa] bit NOT NULL,
    [CREATED_AT] datetimeoffset NOT NULL,
    [CREATED_BY] nvarchar(50) NOT NULL,
    [UPDATED_AT] datetimeoffset NULL,
    [UPDATED_BY] nvarchar(50) NULL,
    CONSTRAINT [PK_CatSeccionPreguntaFrecuente] PRIMARY KEY ([SeccionPreguntaFrecuenteID])
);
DECLARE @defaultSchema AS sysname;
SET @defaultSchema = SCHEMA_NAME();
DECLARE @description AS sql_variant;
SET @description = N'Tabla donde estan las secciones de preguntas y respuestas. Tabla principal del dominio de Preguntas Frecuentes.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CatSeccionPreguntaFrecuente';
SET @description = N'Identificador unico de la seccion de preguntas frecuentes';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CatSeccionPreguntaFrecuente', 'COLUMN', N'SeccionPreguntaFrecuenteID';
SET @description = N'Titulo de la seccion de preguntas frecuentes';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CatSeccionPreguntaFrecuente', 'COLUMN', N'Titulo';
SET @description = N'Url donde esta localizado la imágen de la seccion';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CatSeccionPreguntaFrecuente', 'COLUMN', N'UrlImagen';
SET @description = N'Numero de la posicion para ordenamiento en la que se mostrara la seccion de preguntas frecuentes. Valores debe ser mayor que 0 y es requerido.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CatSeccionPreguntaFrecuente', 'COLUMN', N'Posicion';
SET @description = N'Indica si la seccion de preguntas frecuentes esta habilitado o no para su visibilidad. Valores 0=No Activa, 1=Activa y es requerida.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CatSeccionPreguntaFrecuente', 'COLUMN', N'Activa';
SET @description = N'Auditoria. Fecha en la que se creo el registro.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CatSeccionPreguntaFrecuente', 'COLUMN', N'CREATED_AT';
SET @description = N'Auditoria. Usuario que creo el registro.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CatSeccionPreguntaFrecuente', 'COLUMN', N'CREATED_BY';
SET @description = N'Auditoria. Fecha en la que se modifico el registro.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CatSeccionPreguntaFrecuente', 'COLUMN', N'UPDATED_AT';
SET @description = N'Auditoria. Usuario que modifico el registro.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CatSeccionPreguntaFrecuente', 'COLUMN', N'UPDATED_BY';
GO

CREATE TABLE [CatPreguntaFrecuente] (
    [PreguntaFrecuenteID] uniqueidentifier NOT NULL,
    [Descripcion] nvarchar(500) NOT NULL,
    [Posicion] int NOT NULL,
    [Activa] bit NOT NULL,
    [SeccionPreguntaFrecuenteID] uniqueidentifier NOT NULL,
    [CREATED_AT] datetimeoffset NOT NULL,
    [CREATED_BY] nvarchar(50) NOT NULL,
    [UPDATED_AT] datetimeoffset NULL,
    [UPDATED_BY] nvarchar(50) NULL,
    CONSTRAINT [PK_CatPreguntaFrecuente] PRIMARY KEY ([PreguntaFrecuenteID]),
    CONSTRAINT [FK_CatPreguntaFrecuente_CatSeccionPreguntaFrecuente_SeccionPreguntaFrecuenteID] FOREIGN KEY ([SeccionPreguntaFrecuenteID]) REFERENCES [CatSeccionPreguntaFrecuente] ([SeccionPreguntaFrecuenteID]) ON DELETE CASCADE
);
DECLARE @defaultSchema AS sysname;
SET @defaultSchema = SCHEMA_NAME();
DECLARE @description AS sql_variant;
SET @description = N'Tabla donde estan las pregutas de la seccion de preguntas y respuestas.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CatPreguntaFrecuente';
SET @description = N'Identificador unico de la pregunta frecuente';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CatPreguntaFrecuente', 'COLUMN', N'PreguntaFrecuenteID';
SET @description = N'Texto de la pregunta';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CatPreguntaFrecuente', 'COLUMN', N'Descripcion';
SET @description = N'Numero de la posicion para ordenamiento en la que se mostrara las preguntas. Valores debe ser mayor que 0 y es requerido.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CatPreguntaFrecuente', 'COLUMN', N'Posicion';
SET @description = N'Indica si la pregunta esta habilitado o no para su visibilidad. Valores 0=No Activa, 1=Activa y es requerida.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CatPreguntaFrecuente', 'COLUMN', N'Activa';
SET @description = N'Identificador de la seccion de preguntas frecuentes a la que pertence la pregunta. Es llave foranea y es requerida.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CatPreguntaFrecuente', 'COLUMN', N'SeccionPreguntaFrecuenteID';
SET @description = N'Auditoria. Fecha en la que se creo el registro.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CatPreguntaFrecuente', 'COLUMN', N'CREATED_AT';
SET @description = N'Auditoria. Usuario que creo el registro.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CatPreguntaFrecuente', 'COLUMN', N'CREATED_BY';
SET @description = N'Auditoria. Fecha en la que se modifico el registro.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CatPreguntaFrecuente', 'COLUMN', N'UPDATED_AT';
SET @description = N'Auditoria. Usuario que modifico el registro.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CatPreguntaFrecuente', 'COLUMN', N'UPDATED_BY';
GO

CREATE TABLE [CatPreguntaFrecuenteRespuesta] (
    [PreguntaFrecuenteRespuestaID] uniqueidentifier NOT NULL,
    [Descripcion] nvarchar(1000) NOT NULL,
    [Posicion] int NOT NULL,
    [Activa] bit NOT NULL,
    [PreguntaFrecuenteID] uniqueidentifier NOT NULL,
    [CREATED_AT] datetimeoffset NOT NULL,
    [CREATED_BY] nvarchar(50) NOT NULL,
    [UPDATED_AT] datetimeoffset NULL,
    [UPDATED_BY] nvarchar(50) NULL,
    CONSTRAINT [PK_CatPreguntaFrecuenteRespuesta] PRIMARY KEY ([PreguntaFrecuenteRespuestaID]),
    CONSTRAINT [FK_CatPreguntaFrecuenteRespuesta_CatPreguntaFrecuente_PreguntaFrecuenteID] FOREIGN KEY ([PreguntaFrecuenteID]) REFERENCES [CatPreguntaFrecuente] ([PreguntaFrecuenteID]) ON DELETE CASCADE
);
DECLARE @defaultSchema AS sysname;
SET @defaultSchema = SCHEMA_NAME();
DECLARE @description AS sql_variant;
SET @description = N'Tabla donde estan las respuestas a las preguntas de la seccion de preguntas y respuestas.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CatPreguntaFrecuenteRespuesta';
SET @description = N'Identificador unico de la respuesta de la pregunta frecuente';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CatPreguntaFrecuenteRespuesta', 'COLUMN', N'PreguntaFrecuenteRespuestaID';
SET @description = N'Texto de la respuesta';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CatPreguntaFrecuenteRespuesta', 'COLUMN', N'Descripcion';
SET @description = N'Numero de la posicion para ordenamiento en la que se mostrara las respuestas. Valores debe ser mayor que 0 y es requerido.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CatPreguntaFrecuenteRespuesta', 'COLUMN', N'Posicion';
SET @description = N'Indica si la respuesta esta habilitado o no para su visibilidad. Valores 0=No Activa, 1=Activa y es requerida.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CatPreguntaFrecuenteRespuesta', 'COLUMN', N'Activa';
SET @description = N'Identificador de la pregunta a la que pertence la respuesta. Es llave foranea y es requerida.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CatPreguntaFrecuenteRespuesta', 'COLUMN', N'PreguntaFrecuenteID';
SET @description = N'Auditoria. Fecha en la que se creo el registro.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CatPreguntaFrecuenteRespuesta', 'COLUMN', N'CREATED_AT';
SET @description = N'Auditoria. Usuario que creo el registro.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CatPreguntaFrecuenteRespuesta', 'COLUMN', N'CREATED_BY';
SET @description = N'Auditoria. Fecha en la que se modifico el registro.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CatPreguntaFrecuenteRespuesta', 'COLUMN', N'UPDATED_AT';
SET @description = N'Auditoria. Usuario que modifico el registro.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CatPreguntaFrecuenteRespuesta', 'COLUMN', N'UPDATED_BY';
GO

CREATE INDEX [IX_CatPreguntaFrecuente_SeccionPreguntaFrecuenteID] ON [CatPreguntaFrecuente] ([SeccionPreguntaFrecuenteID]);
GO

CREATE INDEX [IX_CatPreguntaFrecuenteRespuesta_PreguntaFrecuenteID] ON [CatPreguntaFrecuenteRespuesta] ([PreguntaFrecuenteID]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240510001759_InitialMigration', N'8.0.3');
GO

COMMIT;
GO

