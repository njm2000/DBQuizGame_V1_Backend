using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_DBQuizGame_Service.DTO
{
    public class Question
    {
        public Guid IdQuestion { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public string Difficulty { get; set; }

        public Guid IdQuiz { get; set; }

        public int IdQuestionType { get; set; }

        public int IdObjectState { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
