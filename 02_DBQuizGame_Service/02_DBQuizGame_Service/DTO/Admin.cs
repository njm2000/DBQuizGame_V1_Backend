using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_DBQuizGame_Service.DTO
{
    public class Admin
    {
        public Guid IdAdmin { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public int IdObjectState { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
