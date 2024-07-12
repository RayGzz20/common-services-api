using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppCommonServices.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuzonSugerencia",
                columns: table => new
                {
                    BuzonSugerenciaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identificador de la sugerencia"),
                    UsuarioId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Identificador del usuario"),
                    Comentarios = table.Column<string>(type: "nvarchar(850)", maxLength: 850, nullable: false, comment: "Texto de la sugerencia"),
                    CREATED_AT = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Auditoria. Fecha en la que se creo el registro."),
                    CREATED_BY = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Auditoria. Usuario que creo el registro."),
                    UPDATED_AT = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "Auditoria. Fecha en la que se modifico el registro."),
                    UPDATED_BY = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Auditoria. Usuario que modifico el registro.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuzonSugerencia", x => x.BuzonSugerenciaId);
                },
                comment: "Tabla donde estan las sugerencias del usuario de la app móvil de Oxxo Gas.");

            migrationBuilder.CreateTable(
                name: "CatSeccionPreguntaFrecuente",
                columns: table => new
                {
                    SeccionPreguntaFrecuenteID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identificador unico de la seccion de preguntas frecuentes"),
                    Titulo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Titulo de la seccion de preguntas frecuentes"),
                    UrlImagen = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, comment: "Url donde esta localizado la imágen de la seccion"),
                    Posicion = table.Column<int>(type: "int", nullable: false, comment: "Numero de la posicion para ordenamiento en la que se mostrara la seccion de preguntas frecuentes. Valores debe ser mayor que 0 y es requerido."),
                    Activa = table.Column<bool>(type: "bit", nullable: false, comment: "Indica si la seccion de preguntas frecuentes esta habilitado o no para su visibilidad. Valores 0=No Activa, 1=Activa y es requerida."),
                    CREATED_AT = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Auditoria. Fecha en la que se creo el registro."),
                    CREATED_BY = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Auditoria. Usuario que creo el registro."),
                    UPDATED_AT = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "Auditoria. Fecha en la que se modifico el registro."),
                    UPDATED_BY = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Auditoria. Usuario que modifico el registro.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatSeccionPreguntaFrecuente", x => x.SeccionPreguntaFrecuenteID);
                },
                comment: "Tabla donde estan las secciones de preguntas y respuestas. Tabla principal del dominio de Preguntas Frecuentes.");

            migrationBuilder.CreateTable(
                name: "CatPreguntaFrecuente",
                columns: table => new
                {
                    PreguntaFrecuenteID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identificador unico de la pregunta frecuente"),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Texto de la pregunta"),
                    Posicion = table.Column<int>(type: "int", nullable: false, comment: "Numero de la posicion para ordenamiento en la que se mostrara las preguntas. Valores debe ser mayor que 0 y es requerido."),
                    Activa = table.Column<bool>(type: "bit", nullable: false, comment: "Indica si la pregunta esta habilitado o no para su visibilidad. Valores 0=No Activa, 1=Activa y es requerida."),
                    SeccionPreguntaFrecuenteID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identificador de la seccion de preguntas frecuentes a la que pertence la pregunta. Es llave foranea y es requerida."),
                    CREATED_AT = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Auditoria. Fecha en la que se creo el registro."),
                    CREATED_BY = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Auditoria. Usuario que creo el registro."),
                    UPDATED_AT = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "Auditoria. Fecha en la que se modifico el registro."),
                    UPDATED_BY = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Auditoria. Usuario que modifico el registro.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatPreguntaFrecuente", x => x.PreguntaFrecuenteID);
                    table.ForeignKey(
                        name: "FK_CatPreguntaFrecuente_CatSeccionPreguntaFrecuente_SeccionPreguntaFrecuenteID",
                        column: x => x.SeccionPreguntaFrecuenteID,
                        principalTable: "CatSeccionPreguntaFrecuente",
                        principalColumn: "SeccionPreguntaFrecuenteID",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Tabla donde estan las pregutas de la seccion de preguntas y respuestas.");

            migrationBuilder.CreateTable(
                name: "CatPreguntaFrecuenteRespuesta",
                columns: table => new
                {
                    PreguntaFrecuenteRespuestaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identificador unico de la respuesta de la pregunta frecuente"),
                    Descripcion = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, comment: "Texto de la respuesta"),
                    Posicion = table.Column<int>(type: "int", nullable: false, comment: "Numero de la posicion para ordenamiento en la que se mostrara las respuestas. Valores debe ser mayor que 0 y es requerido."),
                    Activa = table.Column<bool>(type: "bit", nullable: false, comment: "Indica si la respuesta esta habilitado o no para su visibilidad. Valores 0=No Activa, 1=Activa y es requerida."),
                    PreguntaFrecuenteID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identificador de la pregunta a la que pertence la respuesta. Es llave foranea y es requerida."),
                    CREATED_AT = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Auditoria. Fecha en la que se creo el registro."),
                    CREATED_BY = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Auditoria. Usuario que creo el registro."),
                    UPDATED_AT = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "Auditoria. Fecha en la que se modifico el registro."),
                    UPDATED_BY = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Auditoria. Usuario que modifico el registro.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatPreguntaFrecuenteRespuesta", x => x.PreguntaFrecuenteRespuestaID);
                    table.ForeignKey(
                        name: "FK_CatPreguntaFrecuenteRespuesta_CatPreguntaFrecuente_PreguntaFrecuenteID",
                        column: x => x.PreguntaFrecuenteID,
                        principalTable: "CatPreguntaFrecuente",
                        principalColumn: "PreguntaFrecuenteID",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Tabla donde estan las respuestas a las preguntas de la seccion de preguntas y respuestas.");

            migrationBuilder.CreateIndex(
                name: "IX_CatPreguntaFrecuente_SeccionPreguntaFrecuenteID",
                table: "CatPreguntaFrecuente",
                column: "SeccionPreguntaFrecuenteID");

            migrationBuilder.CreateIndex(
                name: "IX_CatPreguntaFrecuenteRespuesta_PreguntaFrecuenteID",
                table: "CatPreguntaFrecuenteRespuesta",
                column: "PreguntaFrecuenteID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuzonSugerencia");

            migrationBuilder.DropTable(
                name: "CatPreguntaFrecuenteRespuesta");

            migrationBuilder.DropTable(
                name: "CatPreguntaFrecuente");

            migrationBuilder.DropTable(
                name: "CatSeccionPreguntaFrecuente");
        }
    }
}
