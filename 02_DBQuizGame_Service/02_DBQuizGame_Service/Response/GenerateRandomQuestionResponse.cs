using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_DBQuizGame_Service.Response
{
    public class GenerateRandomQuestionResponse
    {
        public List<DTO.Question> Questions { get; set; }
        public List<DTO.Option> Options { get; set; }
        public List<DTO.Certificate> MissingCertificateList { get; set; }
        public bool IsGenerationSuccess { get; set; }
        public bool IsCallSuccess { get; set; }
        public string ErrorMessage { get; set; }
    }
}
