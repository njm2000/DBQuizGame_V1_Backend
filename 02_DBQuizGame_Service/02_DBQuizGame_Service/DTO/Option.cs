using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_DBQuizGame_Service.DTO
{
    public class Option
    {
        public Guid IdOption { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public bool? IsCorrect { get; set; }

        public string? CorrectSlot { get; set; }

        public string? CorrectSlotGroup { get; set; }

        public int IdObjectState { get; set; }

        public Guid IdQuestion { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
