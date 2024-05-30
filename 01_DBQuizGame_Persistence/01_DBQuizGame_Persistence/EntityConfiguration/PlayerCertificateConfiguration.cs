using _01_DBQuizGame_Persistence.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace _01_DBQuizGame_Persistence.EntityConfiguration
{
    public class PlayerCertificateConfiguration : IEntityTypeConfiguration<PlayerCertificate>
    {
        public void Configure(EntityTypeBuilder<PlayerCertificate> builder)
        {
            #region Table Override

            ///Define primary key
            builder.HasKey(k => k.IdPlayerCertificate);

            #endregion


            #region Property Configuration

            ///Set auto generate value for primary key
            builder.Property(p => p.IdPlayerCertificate)
                .HasDefaultValueSql("NEWID()");

            builder.Property(p => p.TotalAttempt)
                .IsRequired();

            builder.Property(p => p.TimeTaken)
                .IsRequired();

            builder.Property(p => p.PointsAcquired)
                .IsRequired();

            #endregion


            #region Relationship

            ///Configure the relationship

            builder.HasOne(r => r.ObjectState1)
                .WithMany(r => r.PlayerCertificates1)
                .HasForeignKey(k => k.IdObjectState)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(r => r.Player1)
                .WithMany(r => r.PlayerCertificates1)
                .HasForeignKey(k => k.IdPlayer)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(r => r.Certificate1)
                .WithMany(r => r.PlayerCertificates1)
                .HasForeignKey(k => k.IdCertificate)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion

        }
    }
}
