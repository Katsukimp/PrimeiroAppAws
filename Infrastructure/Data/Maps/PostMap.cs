using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrimeiroAppAws.Domain.Entities;

namespace PrimeiroAppAws.Infrastructure.Data.Maps
{
    public class PostMap : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CreatedAt);

            builder.Property(x => x.Active);

            builder.Property(x => x.Description);
        }
    }
}
