using _01_DBQuizGame_Persistence.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace _01_DBQuizGame_Persistence.EntityConfiguration
{
    public class QuizCertificateConfiguration : IEntityTypeConfiguration<QuizCertificate>
    {
        public void Configure(EntityTypeBuilder<QuizCertificate> builder)
        {
            #region Table Override

            ///Define primary key
            builder.HasKey(k => k.IdQuizCertificate);

            #endregion


            #region Property Configuration

            ///Set auto generate value for primary key
            builder.Property(p => p.IdQuizCertificate)
                .HasDefaultValueSql("NEWID()");

            #endregion


            #region Relationship

            ///Configure the relationship

            builder.HasOne(r => r.ObjectState1)
                .WithMany(r => r.QuizCertificates1)
                .HasForeignKey(k => k.IdObjectState)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(r => r.Quiz1)
                .WithMany(r => r.QuizCertificates1)
                .HasForeignKey(k => k.IdQuiz)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(r => r.Certificate1)
                .WithMany(r => r.QuizCertificates1)
                .HasForeignKey(k => k.IdCertificate)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion

        }
    }
}
