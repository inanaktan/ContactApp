using ContactApp.Contact.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContactApp.Contact.Persistence.Configurations;

public abstract class BaseEntityTypeConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.Property(t => t.Id)
               .ValueGeneratedOnAdd()
               .IsRequired();

        builder.Property(t => t.CreatedOn)
               .IsRequired();

        builder.Property(t => t.IsDeleted)
               .IsRequired();
    }
}
