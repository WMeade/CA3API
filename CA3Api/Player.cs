using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CA3Api
{
    public class Player
    {
        [Key]
        public int user_id { get; set; }

        public string user_name { get; set; }

        public int kills { get; set; }

        public int deaths { get; set; }
        
        public int assists { get; set; }

        public int leaderboard_pos { get; set; }

        public int max_kills { get; set; }

        public int wins { get; set; }

        public int losses { get; set; }

        public int highest_killstreak { get; set; }

        public bool Premium { get; set; }
    }
}
