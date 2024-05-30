using _01_DBQuizGame_Persistence.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace _01_DBQuizGame_Persistence.Entity
{
    public class DBQuizGameContext : DbContext
    {
        private IConfiguration _config { get; set; }

        public DBQuizGameContext(IConfiguration config)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(_config.GetConnectionString("DatabaseConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ObjectStateConfiguration());
            modelBuilder.ApplyConfiguration(new AdminConfiguration());
            modelBuilder.ApplyConfiguration(new PlayerConfiguration());
            modelBuilder.ApplyConfiguration(new CertificateConfiguration());
            modelBuilder.ApplyConfiguration(new PlayerCertificateConfiguration());
            modelBuilder.ApplyConfiguration(new QuizConfiguration());
            modelBuilder.ApplyConfiguration(new PlayerQuizConfiguration());
            modelBuilder.ApplyConfiguration(new QuizCertificateConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OptionConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        #region DbSet
        public DbSet<ObjectState> ObjectStates { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<PlayerCertificate> PlayerCertificates { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<PlayerQuiz> PlayerQuizzes { get; set; }
        public DbSet<QuizCertificate> QuizCertificates { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionType> QuestionTypes { get; set; }
        public DbSet<Option> Options { get; set; }

        #endregion

    }
}
