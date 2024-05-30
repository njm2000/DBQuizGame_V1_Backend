using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_DBQuizGame_Service.Response
{
    public class ViewQuizResponse
    {
        public List<DTO.Quiz> Quizzes { get; set; }
        public List<DTO.PlayerQuiz> PlayerQuizRecords { get; set; }
        public bool IsCallSuccess { get; set; }
        public string ErrorMessage { get; set; }

    }
}
