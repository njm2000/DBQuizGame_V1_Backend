using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_DBQuizGame_Service.Request
{
    public class ValidatePlayerLoginRequest
    {
        public string Name { get; set; }
        public long MatricsNo { get; set; }
    }
}
