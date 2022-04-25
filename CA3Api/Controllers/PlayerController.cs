using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CA3Api.Controllers
{
   
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly ILogger<PlayerController> _logger;

        public PlayerController(ILogger<PlayerController> logger)
        {
            _logger = logger;
        }

        [HttpGet("byId/{playerId}")]
        public Player GetPlayerById(int playerId)
        {
            using PlayerDbContext database = new();
            var result = database.Player.ToList();
            var player = result.FirstOrDefault(val => val.user_id == playerId);
            return player;
        }

        [HttpGet("byUsername/{username}")]
        public Player GetPlayerByUsername(string username)
        {
            using PlayerDbContext database = new();
            var result = database.Player.ToList();
            var player = result.FirstOrDefault(val => val.user_name == username);
            return player;
        }

        [HttpGet("Players/TopTen")]
        public IEnumerable<Player> GetTopTen()
        {
            using PlayerDbContext database = new();
            var result = database.Player.ToList();
            var player = result.FindAll(val => val.leaderboard_pos <= 10);
            return player;
        }


        [HttpGet("Players/TopHundred")]
        public IEnumerable<Player> GetTopHundred()
        {
            using PlayerDbContext database = new();
            var result = database.Player.ToList();
            var player = result.FindAll(val => val.leaderboard_pos <= 100);
            return player;
        }


        [HttpGet("Leaderboard/getLeaderboard")]
        public IEnumerable<Leaderboard> GetLeaderboard()
        {
            using PlayerDbContext database = new();
            var result = database.Leaderboard.ToList();
            return result;
        }


        [HttpGet("getKdById/{playerId}")]
        public int GetKdByPlayerById(int playerId)
        {
            using PlayerDbContext database = new();
            var result = database.Leaderboard.ToList();
            var kd = result.FirstOrDefault(val => val.player_id == playerId).kd_ratio;
            return kd;
        }

        [HttpGet("getKdByUsername/{username}")]
        public int GetKdByPlayerByUsername(string username)
        {
            using PlayerDbContext database = new();
            var result = database.Player.ToList();
            var id = result.FirstOrDefault(val => val.user_name == username).user_id;
            var resultTwo = database.Leaderboard.ToList();
            var kd = resultTwo.FirstOrDefault(val => val.player_id == id).kd_ratio;
            return kd;
        }
    }
}
