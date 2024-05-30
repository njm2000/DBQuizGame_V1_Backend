namespace _01_DBQuizGame_Persistence.Entity
{
    public class Option
    {
        public Guid IdOption { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public bool? IsCorrect { get; set; }

        public string? CorrectSlot { get; set; }

        public string? CorrectSlotGroup { get; set; }

        public int IdObjectState { get; set; }

        public Guid IdQuestion { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }


        #region For Relationship

        public ObjectState ObjectState1 { get; set; }

        public Question Question1 { get; set; }

        #endregion
    }
}
