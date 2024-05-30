using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_DBQuizGame_Service.Request
{
    public class SavePlayerQuizRequest
    {
        public Guid IdPlayer { get; set; }
        public string QuizName { get; set; }
        public int TotalScore { get; set; }
        public int TimeTaken { get; set; }
        public int PointsAcquired { get; set; }
    }
}
