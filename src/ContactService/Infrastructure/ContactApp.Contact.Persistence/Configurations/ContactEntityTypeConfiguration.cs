using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApp.Contact.Persistence.Configurations;

public class ContactEntityTypeConfiguration : BaseEntityTypeConfiguration<Domain.Models.Contact>
{
    public override void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Domain.Models.Contact> builder)
    {
        builder.Property(t => t.PersonId)
            .IsRequired();

        builder.Property(t => t.InformationType)
            .HasConversion<string>()
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(t => t.Content)
            .HasMaxLength(50)
            .IsRequired();
    }
}
