using _01_DBQuizGame_Persistence.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _01_DBQuizGame_Persistence.EntityConfiguration
{
    public class ObjectStateConfiguration : IEntityTypeConfiguration<ObjectState>
    {
        public void Configure(EntityTypeBuilder<ObjectState> builder)
        {
            #region Table Override

            ///Define primary key
            builder.HasKey(k => k.IdObjectState);

            ///Define unique constraint
            builder.HasIndex(k => k.Name).IsUnique();

            #endregion

            #region Property Configuration

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Description)
                .HasMaxLength(250);

            #endregion

            #region Relationship

            ///Configure the relationship


            #endregion


        }
    }
}
