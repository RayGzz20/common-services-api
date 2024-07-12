using AppCommonServices.Domain.Common.ValueObjects;
using AppCommonServices.Domain.Faq.Entities;
using AppCommonServices.Domain.Faq.ValueObjects;
using AppCommonServices.Infrastructure.Common.Configurations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppCommonServices.Infrastructure.Faq
{
    public class AnswerConfiguration : AuditableEntityConfiguration<Answer>,
        IEntityTypeConfiguration<Answer>
    {
        public override void Configure(EntityTypeBuilder<Answer> builder)
        {
            ConfigureQuestionTable(builder);
            base.Configure(builder, "PreguntaFrecuenteRespuestaID", "Identificador unico de la respuesta de la pregunta frecuente");
        }

        private void ConfigureQuestionTable(EntityTypeBuilder<Answer> builder)
        {
            builder.ToTable("CatPreguntaFrecuenteRespuesta",
                t => t.HasComment("Tabla donde estan las respuestas a las preguntas de la seccion de preguntas y respuestas."));

            builder.Property(a => a.Description)
                .HasConversion(
                    name => name!.Value, value => AnswerName.Create(value)!)
                .HasMaxLength(1000)
                .HasColumnName("Descripcion")
                .HasComment("Texto de la respuesta")
                .IsRequired(true);

            builder.Property(a => a.Position)
                .HasConversion(pos => pos!.Value, value => Position.Create(value)!)
                .HasColumnName("Posicion")
                .HasComment("Numero de la posicion para ordenamiento en la que se mostrara las respuestas. Valores debe ser mayor que 0 y es requerido.")
                .IsRequired(true);

            builder.Property(a => a.IsActive)
            .HasColumnName("Activa")
            .HasComment("Indica si la respuesta esta habilitado o no para su visibilidad. Valores 0=No Activa, 1=Activa y es requerida.")
            .IsRequired(true);

            builder.Property(q => q.QuestionId)
                .HasConversion(
                    id => id!.Value,
                    value => Id.Create(value))
                .HasColumnName("PreguntaFrecuenteID")
                .HasComment("Identificador de la pregunta a la que pertence la respuesta. Es llave foranea y es requerida.")
                .IsRequired(true);
        }
    }
}
