using AppCommonServices.Domain.Common.ValueObjects;
using AppCommonServices.Domain.Faq.Entities;
using AppCommonServices.Domain.Faq.ValueObjects;
using AppCommonServices.Infrastructure.Common.Configurations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppCommonServices.Infrastructure.Faq
{
    public class QuestionConfiguration: AuditableEntityConfiguration<Question>,
        IEntityTypeConfiguration<Question>
    {
        public override void Configure(EntityTypeBuilder<Question> builder)
        {
            ConfigureQuestionTable(builder);
            base.Configure(builder, "PreguntaFrecuenteID", "Identificador unico de la pregunta frecuente");
        }

        private void ConfigureQuestionTable(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable("CatPreguntaFrecuente",
                    t => t.HasComment("Tabla donde estan las pregutas de la seccion de preguntas y respuestas."));

            builder.Property(q => q.Description)
                .HasConversion(
                    name => name!.Value, value => QuestionName.Create(value)!)
                .HasMaxLength(500)
                .HasColumnName("Descripcion")
                .HasComment("Texto de la pregunta")
                .IsRequired(true);

            builder.Property(q => q.Position)
                .HasConversion(pos => pos!.Value, value => Position.Create(value)!)
                .HasColumnName("Posicion")
                .HasComment("Numero de la posicion para ordenamiento en la que se mostrara las preguntas. Valores debe ser mayor que 0 y es requerido.")
                .IsRequired(true);

            builder.Property(q => q.IsActive)
                .HasColumnName("Activa")
                .HasComment("Indica si la pregunta esta habilitado o no para su visibilidad. Valores 0=No Activa, 1=Activa y es requerida.")
                .IsRequired(true);

            builder.Property(q => q.FaqId)
                .HasConversion(
                    id => id!.Value,
                    value => Id.Create(value))
                .HasColumnName("SeccionPreguntaFrecuenteID")
                .HasComment("Identificador de la seccion de preguntas frecuentes a la que pertence la pregunta. Es llave foranea y es requerida.")
                .IsRequired(true);

            builder.HasMany(p => p.Answers).WithOne().HasForeignKey(p => p.QuestionId);
        }

    }
}
