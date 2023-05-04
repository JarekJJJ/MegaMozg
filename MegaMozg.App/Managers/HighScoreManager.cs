using MegaMozg.App.Abstract;
using MegaMozg.App.Concrete;
using MegaMozg.Domain.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaMozg.App.Managers
{
    public class HighScoreManager
    {
        private IService<Game> _gameService;
        private IService<Player> _playerService;
        public HighScoreManager(IService<Game> gameService, IService<Player> playerService)
        {
            _gameService = gameService;
            _playerService = playerService;
        }
        public void GetHighScore()
        {
            int i = 1;
            Console.Clear();
            Console.WriteLine("TOP 10 Graczy");           
            _gameService.Items.OrderByDescending(x => x.Score).Take(10).ToList().ForEach(game =>
            {                
                Console.WriteLine($"{i}     Gra numer:{game.Id}    Gracz:{game.PlayerName}     Wynik: {game.Score}");
                i++;
            });
            Console.ReadLine();
        }
    }
}
