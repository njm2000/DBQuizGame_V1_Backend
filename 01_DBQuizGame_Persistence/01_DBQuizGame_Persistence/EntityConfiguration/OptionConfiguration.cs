using _01_DBQuizGame_Persistence.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace _01_DBQuizGame_Persistence.EntityConfiguration
{
    public class OptionConfiguration : IEntityTypeConfiguration<Option>
    {
        public void Configure(EntityTypeBuilder<Option> builder)
        {
            #region Table Override

            ///Define primary key
            builder.HasKey(k => k.IdOption);

            ///Define unique constraint
            builder.HasIndex(k => k.Name).IsUnique();

            #endregion


            #region Property Configuration

            ///Set auto generate value for primary key
            builder.Property(p => p.IdOption)
                .HasDefaultValueSql("NEWID()");

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.CorrectSlot)
                .HasMaxLength(50);

            builder.Property(p => p.CorrectSlotGroup)
                .HasMaxLength(50);

            #endregion


            #region Relationship

            ///Configure the relationship

            builder.HasOne(r => r.ObjectState1)
                .WithMany(r => r.Options1)
                .HasForeignKey(k => k.IdObjectState)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(r => r.Question1)
                .WithMany(r => r.Options1)
                .HasForeignKey(k => k.IdQuestion)
                .OnDelete(DeleteBehavior.NoAction);

            #endregion

        }
    }
}
