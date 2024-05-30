using _01_DBQuizGame_Persistence.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace _01_DBQuizGame_Persistence.EntityConfiguration
{
    public class QuizConfiguration : IEntityTypeConfiguration<Quiz>
    {
        public void Configure(EntityTypeBuilder<Quiz> builder)
        {
            #region Table Override

            ///Define primary key
            builder.HasKey(k => k.IdQuiz);

            ///Define unique constraint
            builder.HasIndex(k => k.Name).IsUnique();

            #endregion


            #region Property Configuration

            ///Set auto generate value for primary key
            builder.Property(p => p.IdQuiz)
                .HasDefaultValueSql("NEWID()");

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Description)
                .HasMaxLength(250);

            builder.Property(p => p.TotalQuestion)
                .IsRequired();

            builder.Property(p => p.MaxScore)
                .IsRequired();

            builder.Property(p => p.ExpectedCompletionTime)
                .IsRequired();

            #endregion


            #region Relationship

            ///Configure the relationship

            builder.HasOne(r => r.ObjectState1)
                .WithMany(r => r.Quizzes1)
                .HasForeignKey(k => k.IdObjectState)
                .OnDelete(DeleteBehavior.NoAction);

            #endregion

        }
    }
}
