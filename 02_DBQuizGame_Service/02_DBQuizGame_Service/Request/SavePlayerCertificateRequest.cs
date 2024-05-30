using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_DBQuizGame_Service.Request
{
    public class SavePlayerCertificateRequest
    {
        public Guid IdPlayer { get; set; }
        public string CertificateName { get; set; }
        public int TotalAttempts { get; set; }
        public int TimeTaken { get; set; }
        public int PointsAcquired { get; set; }
    }
}
