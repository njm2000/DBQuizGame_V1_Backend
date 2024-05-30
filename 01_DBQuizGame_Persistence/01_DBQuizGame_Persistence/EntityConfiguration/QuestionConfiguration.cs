using _01_DBQuizGame_Persistence.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace _01_DBQuizGame_Persistence.EntityConfiguration
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            #region Table Override

            ///Define primary key
            builder.HasKey(k => k.IdQuestion);

            ///Define unique constraint
            builder.HasIndex(k => k.Name).IsUnique();

            #endregion


            #region Property Configuration

            ///Set auto generate value for primary key
            builder.Property(p => p.IdQuestion)
                .HasDefaultValueSql("NEWID()");

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Difficulty)
                .IsRequired()
                .HasMaxLength(50);

            #endregion


            #region Relationship

            ///Configure the relationship

            builder.HasOne(r => r.ObjectState1)
                .WithMany(r => r.Questions1)
                .HasForeignKey(k => k.IdObjectState)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(r => r.Quiz1)
                .WithMany(r => r.Questions1)
                .HasForeignKey(k => k.IdQuiz)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(r => r.QuestionType1)
                .WithMany(r => r.Questions1)
                .HasForeignKey(k => k.IdQuestionType)
                .OnDelete(DeleteBehavior.NoAction);

            #endregion

        }
    }
}
