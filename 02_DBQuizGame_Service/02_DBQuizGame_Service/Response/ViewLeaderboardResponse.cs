using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_DBQuizGame_Service.Response
{
    public class ViewLeaderboardResponse
    {
        public List<DTO.Player> SortedPlayerList { get; set; }
        public bool IsCallSuccess { get; set; }
        public string ErrorMessage { get; set; }

    }
}
