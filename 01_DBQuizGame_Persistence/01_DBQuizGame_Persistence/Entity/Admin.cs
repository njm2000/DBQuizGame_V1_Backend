namespace _01_DBQuizGame_Persistence.Entity
{
    public class Admin
    {
        public Guid IdAdmin { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public int IdObjectState { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }


        #region For Relationship

        public ObjectState ObjectState1 { get; set; }

        #endregion
    }
}
