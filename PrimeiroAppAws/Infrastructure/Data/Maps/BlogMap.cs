using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrimeiroAppAws.Domain.Entities;

namespace PrimeiroAppAws.Infrastructure.Data.Maps
{
    public class BlogMap : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CreatedAt);

            builder.Property(x => x.Active);

            builder.Property(x => x.Description);

            builder.HasMany(x => x.Posts).WithOne();
        }
    }
}
