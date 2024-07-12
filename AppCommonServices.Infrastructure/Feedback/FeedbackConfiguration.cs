using AppCommonServices.Domain.Feedback.ValueObjects;
using AppCommonServices.Infrastructure.Common.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using E = AppCommonServices.Domain.Feedback.Entities;

namespace AppCommonServices.Infrastructure.Feedback
{
    public class FeedbackConfiguration : 
        AuditableEntityConfiguration<E.Feedback>, 
        IEntityTypeConfiguration<E.Feedback>
    {
        public override void Configure(EntityTypeBuilder<E.Feedback> builder)
        {
            ConfigureTable(builder);
            Configure(builder, "BuzonSugerenciaId", "Identificador de la sugerencia");
        }

        private void ConfigureTable(EntityTypeBuilder<E.Feedback> builder)
        {
            builder.ToTable("BuzonSugerencia",
                 t => t.HasComment("Tabla donde estan las sugerencias del usuario de la app móvil de Oxxo Gas."));

            builder.Property(f => f.UserId)
                .HasConversion(
                    UserId => UserId!.Value,
                    value => UserId.Create(value)!
                )
                .HasMaxLength(50)
                .HasColumnName("UsuarioId")
                .HasComment("Identificador del usuario")
                .IsRequired(true);

            builder.Property(f => f.Comments)
                .HasConversion(
                    com => com!.Value,
                    value => Comments.Create(value)!
                )
                .HasMaxLength(850)
                .HasColumnName("Comentarios")
                .HasComment("Texto de la sugerencia")
                .IsRequired(true);

        }
    }
}
