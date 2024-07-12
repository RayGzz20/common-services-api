using AppCommonServices.Domain.Faq.ValueObjects;
using AppCommonServices.Infrastructure.Common.Configurations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EntitiesFaq = AppCommonServices.Domain.Faq.Entities.Faq;

namespace AppCommonServices.Infrastructure.Faq
{
    public class FaqConfiguration : AuditableEntityConfiguration<EntitiesFaq>,
        IEntityTypeConfiguration<EntitiesFaq>
    {
        public override void Configure(EntityTypeBuilder<EntitiesFaq> builder)
        {
            ConfigureFaqTable(builder);
            base.Configure(builder, "SeccionPreguntaFrecuenteID", "Identificador unico de la seccion de preguntas frecuentes");
        }

        private void ConfigureFaqTable(EntityTypeBuilder<EntitiesFaq> builder)
        {
            builder.ToTable("CatSeccionPreguntaFrecuente", 
                t => t.HasComment("Tabla donde estan las secciones de preguntas y respuestas. Tabla principal del dominio de Preguntas Frecuentes."));

            builder.Property(f => f.Name)
                .HasConversion(
                    name => name!.Value, value => FaqName.Create(value)!)
                .HasMaxLength(50)
                .HasColumnName("Titulo")
                .HasComment("Titulo de la seccion de preguntas frecuentes")
                .IsRequired(true);

            builder.Property(f => f.UrlImage)
                .HasConversion(urlimg => urlimg!.Value, value => UrlImage.Create(value)!)
                .HasMaxLength(255)
                .HasColumnName("UrlImagen")
                .HasComment("Url donde esta localizado la imágen de la seccion")
                .IsRequired(true);

            builder.Property(f => f.Position)
                .HasConversion(
                    pos => pos!.Value, value => FaqPosition.Create(value)!)
                .HasColumnName("Posicion")
                .HasComment("Numero de la posicion para ordenamiento en la que se mostrara la seccion de preguntas frecuentes. Valores debe ser mayor que 0 y es requerido.")
                .IsRequired(true);

            builder.Property(f => f.IsActive)
               .HasColumnName("Activa")
               .HasComment("Indica si la seccion de preguntas frecuentes esta habilitado o no para su visibilidad. Valores 0=No Activa, 1=Activa y es requerida.")
               .IsRequired(true);

            builder.HasMany(p => p.Questions).WithOne().HasForeignKey(p => p.FaqId);
        }

    }
}
