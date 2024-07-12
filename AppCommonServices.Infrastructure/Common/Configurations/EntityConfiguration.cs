using AppCommonServices.Domain.Common;
using AppCommonServices.Domain.Common.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppCommonServices.Infrastructure.Common.Configurations
{
    /// <summary>
    ///  This is a base configuration class for entities which inherit from BaseEntity class.
    ///  In a class inherit from this, ensure calling "base.Configure(builder)" to apply Id field and index configurations.
    /// </summary>
    /// <typeparam name="TEntity">Must inherit from Domain.Common.AuditableEntity</typeparam>
    public abstract class EntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : Entity
    {
        /// <summary>
        /// Apply:
        ///    Required Field Id:
        ///        - ColumnName "Id".
        ///        - HasKey
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            Configure(builder, "Id", "");
        }

        /// <summary>
        /// Apply:
        ///    Required Field Id:
        ///        - ColumnName columnNameForKey.
        ///        - ColumnComment columnCommentForKey. If columnCommentForKey is "", not apply comment
        ///        - HasKey
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="columnNameForKey"></param>
        /// <param name="columnCommentForKey"></param>
        protected void Configure(EntityTypeBuilder<TEntity> builder, string columnNameForKey, string columnCommentForKey)
        {
            builder.Property(f => f.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => Id.Create(value)
                )
                .HasColumnName(columnNameForKey);

            if (columnCommentForKey.Length > 0)
                builder.Property(f => f.Id).HasComment(columnCommentForKey);

            builder.HasKey(f => f.Id);
        }
    }
}
