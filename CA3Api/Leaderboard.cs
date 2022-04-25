using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CA3Api
{
    public class Leaderboard
    {
        [Key]
        public int id { get; set; }
        public int size { get; set; }
        public int player_pos { get; set; }
        public int kd_ratio { get; set; }
        public int wins { get; set; }
        public int player_id { get; set; }
    }
}
