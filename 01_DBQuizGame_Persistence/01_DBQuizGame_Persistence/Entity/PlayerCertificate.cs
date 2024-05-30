namespace _01_DBQuizGame_Persistence.Entity
{
    public class PlayerCertificate
    {
        public Guid IdPlayerCertificate { get; set; }

        public int TotalAttempt { get; set; }

        public int TimeTaken { get; set; }

        public int PointsAcquired { get; set; }

        public Guid IdPlayer { get; set; }

        public Guid IdCertificate { get; set; }

        public int IdObjectState { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }


        #region For Relationship

        public ObjectState ObjectState1 { get; set; }

        public Player Player1 { get; set; }

        public Certificate Certificate1 { get; set; }


        #endregion
    }
}
