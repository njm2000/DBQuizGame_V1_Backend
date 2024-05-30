using _01_DBQuizGame_Persistence.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace _01_DBQuizGame_Persistence.EntityConfiguration
{
    public class CertificateConfiguration : IEntityTypeConfiguration<Certificate>
    {
        public void Configure(EntityTypeBuilder<Certificate> builder)
        {
            #region Table Override

            ///Define primary key
            builder.HasKey(k => k.IdCertificate);

            ///Define unique constraint
            builder.HasIndex(k => k.Name).IsUnique();

            #endregion

            #region Property Configuration

            ///Set auto generate value for primary key
            builder.Property(p => p.IdCertificate)
                .HasDefaultValueSql("NEWID()");

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Description)
                .HasMaxLength(250);

            #endregion

            #region Relationship

            ///Configure the relationship
            builder.HasOne(r => r.ObjectState1)
                .WithMany(r => r.Certificates1)
                .HasForeignKey(k => k.IdObjectState)
                .OnDelete(DeleteBehavior.NoAction);

            #endregion


        }
    }
}
