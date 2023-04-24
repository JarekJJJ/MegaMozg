using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaMozg
{
    public class PlayerService
    {
        public List<Player> Players { get; set; }
        public PlayerService()
        {
            Players = new List<Player>();
        }
        public int AddPlayer()
        {
            Console.Clear();
            Console.Write("Podaj nick: ");
            string name = Console.ReadLine();
            Console.WriteLine();
            Player player = new Player();
            player.Id = Players.Count + 1;
            player.Name = name;
            Players.Add(player);
            return player.Id;
        }
        public Player GetPlayer(int playerId)
        {
            Player player = new Player();
            foreach (Player p in Players)
            {
                if (playerId == p.Id)
                {
                    player = p;
                }
            }
            return player;
        }
    }
}
