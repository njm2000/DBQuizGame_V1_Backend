using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_DBQuizGame_Service.DTO
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
    }
}
