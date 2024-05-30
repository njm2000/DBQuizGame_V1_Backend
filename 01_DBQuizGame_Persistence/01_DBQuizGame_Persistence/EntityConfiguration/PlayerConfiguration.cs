using _01_DBQuizGame_Persistence.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _01_DBQuizGame_Persistence.EntityConfiguration
{
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            #region Table Override

            ///Define primary key
            builder.HasKey(k => k.IdPlayer);

            ///Define unique constraint
            builder.HasIndex(k => k.Name).IsUnique();

            #endregion


            #region Property Configuration

            ///Set auto generate value for primary key
            builder.Property(p => p.IdPlayer)
                .HasDefaultValueSql("NEWID()");

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Description)
                .HasMaxLength(250);

            builder.Property(p => p.MatricsNo)
                .IsRequired();

            builder.Property(p => p.Password)
               .HasMaxLength(50);

            builder.Property(p => p.TotalPoints)
                .IsRequired();

            #endregion


            #region Relationship

            ///Configure the relationship

            builder.HasOne(r => r.ObjectState1)
                .WithMany(r => r.Players1)
                .HasForeignKey(k => k.IdObjectState)
                .OnDelete(DeleteBehavior.NoAction);

            #endregion

        }
    }
}
