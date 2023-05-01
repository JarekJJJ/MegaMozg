using MegaMozg.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaMozg.Domain.Entity
{
    public class Game : BaseEntity
    {
        public int Score { get; set; }
        public int PlayerId { get; set; }
        public Game(int id, int score, int playerId)
        {
            Score = score;
            Id = id;
            PlayerId = playerId;
        }
    }
}
