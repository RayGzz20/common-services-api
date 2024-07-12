using AppCommonServices.Domain.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppCommonServices.Infrastructure.Common.Configurations
{
    /// <summary>
    ///  This is a base configuration class for entities which inherit from AuditableEntity class.
    ///  In a class inherit from this, ensure calling "base.Configure(builder)" to apply fields and index configurations for this base class.
    /// </summary>
    /// <typeparam name="TEntity">Must inherit from Domain.Common.AuditableEntity</typeparam>
    public abstract class AuditableEntityConfiguration<TEntity> :
        EntityConfiguration<TEntity>, IEntityTypeConfiguration<TEntity>
        where TEntity : AuditableEntity
    {
        /// <summary>
        /// Apply:
        ///    Required Field Id:
        ///        - ColumnName "Id".
        ///        - HasKey
        ///    Required Field CreatedOn:  
        ///        - ColumnName "CREATED_AT".
        ///    Required Field CreatedBy:   
        ///        - ColumnName "CREATED_BY".
        ///        - Max Length 50.
        ///    Field UpdatedOn:   
        ///        - ColumnName "UPDATED_AT".
        ///    Field UpdatedBy:   
        ///        - ColumnName "UPDATED_BY".
        ///        - Max Length 50.
        /// </summary>
        /// <param name="builder"></param>
        public virtual new void Configure(EntityTypeBuilder<TEntity> builder)
        {
            ConfigureAudit(builder);
            base.Configure(builder);
        }

        /// <summary>
        /// Apply:
        ///    Required Field Id:
        ///        - ColumnName columnNameForKey.
        ///        - ColumnComment columnCommentForKey. If columnCommentForKey is "", not apply comment
        ///        - HasKey
        ///    Required Field CreatedOn:  
        ///        - ColumnName "CREATED_AT".
        ///    Required Field CreatedBy:   
        ///        - ColumnName "CREATED_BY".
        ///        - Max Length 50.
        ///    Field UpdatedOn:   
        ///        - ColumnName "UPDATED_AT".
        ///    Field UpdatedBy:   
        ///        - ColumnName "UPDATED_BY".
        ///        - Max Length 50.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="columnNameForKey"></param>
        /// <param name="columnCommentForKey"></param>
        protected new void Configure(EntityTypeBuilder<TEntity> builder, string columnNameForKey, string columnCommentForKey)
        {
            ConfigureAudit(builder);
            base.Configure(builder, columnNameForKey, columnCommentForKey);
        }

        private void ConfigureAudit(EntityTypeBuilder<TEntity> builder)
        {
            builder.OwnsOne(f => f.Audit, auditBuilder =>
            {
                auditBuilder.Property(f => f.CreatedOn)
                   .HasColumnName("CREATED_AT")
                   .HasComment("Auditoria. Fecha en la que se creo el registro.")
                   .IsRequired(true);

                auditBuilder.Property(f => f.UpdatedOn)
                    .HasColumnName("UPDATED_AT")
                    .HasComment("Auditoria. Fecha en la que se modifico el registro.")
                    .IsRequired(false);

                auditBuilder.Property(f => f.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(50)
                    .HasComment("Auditoria. Usuario que creo el registro.")
                    .IsRequired(true);

                auditBuilder.Property(f => f.UpdatedBy)
                    .HasColumnName("UPDATED_BY")
                    .HasMaxLength(50)
                    .HasComment("Auditoria. Usuario que modifico el registro.")
                    .IsRequired(false);
            });
        }
    }
}
