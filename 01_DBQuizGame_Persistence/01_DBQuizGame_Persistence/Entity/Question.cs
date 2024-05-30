namespace _01_DBQuizGame_Persistence.Entity
{
    public class Question
    {
        public Guid IdQuestion { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public string Difficulty { get; set; }

        public Guid IdQuiz { get; set; }

        public int IdQuestionType { get; set; }

        public int IdObjectState { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }


        #region For Relationship

        public ObjectState ObjectState1 { get; set; }

        public Quiz Quiz1 { get; set; }

        public QuestionType QuestionType1 { get; set; }

        public virtual ICollection<Option> Options1 { get; set; }


        #endregion

    }
}
