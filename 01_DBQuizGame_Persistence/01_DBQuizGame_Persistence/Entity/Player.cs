using Microsoft.EntityFrameworkCore;

namespace _01_DBQuizGame_Persistence.Entity
{
    public class Player
    {
        public Guid IdPlayer { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public long MatricsNo { get; set; }

        public string Password { get; set; }

        public long TotalPoints { get; set; }

        public int IdObjectState { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }


        #region For Relationship

        public ObjectState ObjectState1 { get; set; }

        public virtual ICollection<PlayerCertificate> PlayerCertificates1 { get; set; }

        public virtual ICollection<PlayerQuiz> PlayerQuizzes1 { get; set; }


        #endregion

    }
}
