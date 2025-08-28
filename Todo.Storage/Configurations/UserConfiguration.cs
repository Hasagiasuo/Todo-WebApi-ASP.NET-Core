using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Domain.Models;

namespace Todo.Storage.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
  public void Configure(EntityTypeBuilder<User> builder)
  {
    builder.HasKey(x => x.Id);
    builder
      .Property(x => x.Token)
      .IsRequired();
    builder
      .Property(x => x.Username)
      .IsRequired();
    builder
      .HasMany(x => x.Items) 
      .WithOne(x => x.User)
      .HasForeignKey(x => x.UserId);
  }
}