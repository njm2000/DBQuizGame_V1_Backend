using _01_DBQuizGame_Persistence.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_DBQuizGame_Service.Response
{
    public class ViewPlayerCertificateResponse
    {
        public List<DTO.PlayerCertificate> PlayerCertificates { get; set; }
        public List<DTO.Certificate> Certificates { get; set; }
        public bool IsCallSuccess { get; set; }
        public string ErrorMessage { get; set; }

    }
}
