using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_DBQuizGame_Service.Response
{
    public class ValidatePlayerLoginResponse
    {
        public DTO.Player Player { get; set; }
        public bool IsLoginValid { get; set; }
        public bool IsCallSuccess { get; set; }
        public string ErrorMessage { get; set; }
    }
}
