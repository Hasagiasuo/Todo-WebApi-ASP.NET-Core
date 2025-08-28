using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Domain.Models;

namespace Todo.Storage.Configurations;

public class ItemConfiguration :  IEntityTypeConfiguration<Item>
{
  public void Configure(EntityTypeBuilder<Item> builder)
  {
    builder.HasKey(x => x.Id);
    builder
      .Property(x => x.Title)
      .HasMaxLength(200)
      .IsRequired();
    builder
      .Property(x => x.CompleteDate)
      .IsRequired();
    builder
      .Property(x => x.UserId)
      .IsRequired();
    builder
      .HasOne(x => x.User)
      .WithMany(i => i.Items)
      .HasForeignKey(x => x.UserId);
  }
}