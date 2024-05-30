namespace _01_DBQuizGame_Persistence.Entity
{
    public class QuizCertificate
    {
        public Guid IdQuizCertificate { get; set; }

        public Guid IdQuiz { get; set; }

        public Guid IdCertificate { get; set; }

        public int IdObjectState { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }


        #region For Relationship

        public ObjectState ObjectState1 { get; set; }

        public Quiz Quiz1 { get; set; }

        public Certificate Certificate1 { get; set; }


        #endregion
    }


}
