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
    class MoveContextConfig : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Title)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Director)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Gross)
                .HasPrecision(15, 2);

            builder.Property(p => p.ImagePath)
                .HasMaxLength(1000);
        }
    }
}
