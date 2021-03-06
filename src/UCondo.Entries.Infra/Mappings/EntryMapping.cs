using UCondo.Entries.Domain.Entries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UCondo.Entries.Infra.Mappings
{
    public class EntryMapping : IEntityTypeConfiguration<Entry>
    {
        public void Configure(EntityTypeBuilder<Entry> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Code);

            builder.ToTable("Entries");
        }
    }
}