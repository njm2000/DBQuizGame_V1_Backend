namespace _01_DBQuizGame_Persistence.Entity
{
    public class Quiz
    {
        public Guid IdQuiz { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public int TotalQuestion { get; set; }

        public int MaxScore { get; set; }

        public int ExpectedCompletionTime { get; set; }

        public int IdObjectState { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }


        #region For Relationship

        public ObjectState ObjectState1 { get; set; }

        public virtual ICollection<PlayerQuiz> PlayerQuizzes1 { get; set; }

        public virtual ICollection<QuizCertificate> QuizCertificates1 { get; set; }

        public virtual ICollection<Question> Questions1 { get; set; }


        #endregion
    }
}
