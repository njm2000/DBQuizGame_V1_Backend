using _01_DBQuizGame_Persistence.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace _01_DBQuizGame_Persistence.EntityConfiguration
{
    public class PlayerQuizConfiguration : IEntityTypeConfiguration<PlayerQuiz>
    {
        public void Configure(EntityTypeBuilder<PlayerQuiz> builder)
        {
            #region Table Override

            ///Define primary key
            builder.HasKey(k => k.IdPlayerQuiz);

            #endregion


            #region Property Configuration

            ///Set auto generate value for primary key
            builder.Property(p => p.IdPlayerQuiz)
                .HasDefaultValueSql("NEWID()");

            builder.Property(p => p.TotalScore)
                .IsRequired();

            builder.Property(p => p.TimeTaken)
                .IsRequired();

            builder.Property(p => p.PointsAcquired)
                .IsRequired();

            #endregion


            #region Relationship

            ///Configure the relationship

            builder.HasOne(r => r.ObjectState1)
                .WithMany(r => r.PlayerQuizzes1)
                .HasForeignKey(k => k.IdObjectState)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(r => r.Player1)
                .WithMany(r => r.PlayerQuizzes1)
                .HasForeignKey(k => k.IdPlayer)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(r => r.Quiz1)
                .WithMany(r => r.PlayerQuizzes1)
                .HasForeignKey(k => k.IdQuiz)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion

        }
    }
}
