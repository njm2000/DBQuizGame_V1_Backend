namespace _01_DBQuizGame_Persistence.Entity
{
    public class QuestionType
    {
        public int IdQuestionType { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public int TotalOption { get; set; }

        public int IdObjectState { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }


        #region For Relationship

        public ObjectState ObjectState1 { get; set; }

        public virtual ICollection<Question> Questions1 { get; set; }

        #endregion
    }
}
