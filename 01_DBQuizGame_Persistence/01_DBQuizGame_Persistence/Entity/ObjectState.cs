namespace _01_DBQuizGame_Persistence.Entity
{
    public class ObjectState
    {
        public int IdObjectState { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }


        #region For Relationship
        public virtual ICollection<Admin> Admins1 { get; set; }

        public virtual ICollection<Player> Players1 { get; set; }

        public virtual ICollection<Certificate> Certificates1 { get; set; }

        public virtual ICollection<PlayerCertificate> PlayerCertificates1 { get; set; }

        public virtual ICollection<Quiz> Quizzes1 { get; set; }

        public virtual ICollection<PlayerQuiz> PlayerQuizzes1 { get; set; }

        public virtual ICollection<QuizCertificate> QuizCertificates1 { get; set; }

        public virtual ICollection<Question> Questions1 { get; set; }

        public virtual ICollection<QuestionType> QuestionTypes1 { get; set; }

        public virtual ICollection<Option> Options1 { get; set; }

        #endregion

    }
}
