namespace _01_DBQuizGame_Persistence.Entity
{
    public class PlayerQuiz
    {
        public Guid IdPlayerQuiz { get; set; }

        public int TotalScore { get; set; }

        public int TimeTaken { get; set; }

        public int PointsAcquired { get; set; }

        public Guid IdPlayer { get; set; }

        public Guid IdQuiz { get; set; }

        public int IdObjectState { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }


        #region For Relationship

        public ObjectState ObjectState1 { get; set; }

        public Player Player1 { get; set; }

        public Quiz Quiz1 { get; set; }


        #endregion
    }
}
