using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_DBQuizGame_Service.DTO
{
    public class QuizCertificate
    {
        public Guid IdQuizCertificate { get; set; }

        public Guid IdQuiz { get; set; }

        public Guid IdCertificate { get; set; }

        public int IdObjectState { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
