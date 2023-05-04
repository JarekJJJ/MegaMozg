using MegaMozg.App.Abstract;
using MegaMozg.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaMozg.App.Managers
{
    public class PlayerManager
    {
        private IService<Player> _playerService;
        public PlayerManager(IService<Player> playerService)
        {
            _playerService = playerService;
        }
        public int AddNewPlayer()
        {
            int playerId;
            Console.Clear();
            Console.Write("Podaj nick: ");
            string name = Console.ReadLine();
            Console.WriteLine();
            playerId = _playerService.GetLastId();
            Player player = new Player(playerId + 1, name);
            _playerService.AddItem(player);
            return playerId+1;
        }
    }
}
