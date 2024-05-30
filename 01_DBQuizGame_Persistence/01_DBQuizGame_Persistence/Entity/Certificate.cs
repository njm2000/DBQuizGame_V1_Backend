namespace _01_DBQuizGame_Persistence.Entity
{
    public class Certificate
    {
        public Guid IdCertificate { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public int IdObjectState { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }


        #region For Relationship

        public ObjectState ObjectState1 { get; set; }

        public virtual ICollection<PlayerCertificate> PlayerCertificates1 { get; set; }

        public virtual ICollection<QuizCertificate> QuizCertificates1 { get; set; }


        #endregion
    }
}
