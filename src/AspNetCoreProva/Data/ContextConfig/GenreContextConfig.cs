using Application.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ContextConfig
{
    class GenreContextConfig : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(genre => genre.Id);

            builder.Property(x => x.Description)
                .HasMaxLength(1000);

            builder.HasMany(x => x.Movies)
                .WithOne(x => x.Genre)
                .HasForeignKey(x => x.GenreId);
        }
    }
}
