using CostControl.Domain.ValueObjects.Common;
using CostControl.Identity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CostControl.Identity.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            //builder.HasKey(u => u.Id);

            builder.Property(u => u.Birthdate)
                .IsRequired();

            //builder.HasMany(u => u.UserRoles)
            //    .WithOne(ur => ur.User)
            //    .HasForeignKey(ur => ur.UserId)
            //    .IsRequired()
            //    .OnDelete(DeleteBehavior.Restrict);

            builder.Property(n => n.FirstName)
                    .IsRequired()
                    .HasMaxLength(100)
            .HasColumnName("FirstName");

            builder.Property(n => n.LastName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("LastName");

            builder.Property(d => d.DocumentId)
                .IsRequired()
                .HasColumnName("DocumentId")
                .HasMaxLength(50);
        }
    }
}
