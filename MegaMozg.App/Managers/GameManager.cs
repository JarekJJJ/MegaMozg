using MegaMozg.App.Abstract;
using MegaMozg.App.Concrete;
using MegaMozg.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace MegaMozg.App.Managers
{
    public class GameManager
    {
        private IService<Player> _playerService;
        private IService<Question> _question;
        private IService<Answer> _answer;
        private IService<Game> _gameService;
      //  private QuestionService _questionService = new QuestionService();
        public GameManager(IService<Player> player, IService<Question> question, IService<Answer> answer, IService<Game> gameService)
        {
            _playerService = player;
            _question = question;
            _answer = answer;
            _gameService = gameService;
        }
        public void StartGame(int playerId, QuestionService questionService, AnswerService answerService)
        {
            int score = 0;
            var actualPlayer = _playerService.GetItem(playerId);
            Console.WriteLine($"Witaj {actualPlayer.Name} "); ;
            var randomQuestions = questionService.GetRandomQuestion();
            randomQuestions.ForEach(x =>
            {               
                Console.WriteLine(x.Description);
                Console.WriteLine(" ");
                var answerQuestion = answerService.GetAnswersToRandomQuestion(x.Id);
                int nquestion = 1;
                answerQuestion.ForEach(a =>
                {
                    Console.Write($"{nquestion}: {a.Description}    ");
                    if (nquestion % 2 == 0)
                    {
                        Console.WriteLine();
                    }
                    if (nquestion < 4)
                    {
                        nquestion++;
                    }
                });
                int userChoice;
                Console.WriteLine(" ");
                Console.Write("Wybierz odpowiedź (1-4) i naciśnij ENTER: ");
                Int32.TryParse(Console.ReadLine(), out (userChoice));
                userChoice = userChoice - 1;
                if (answerQuestion[userChoice].IsCorrect)
                {
                    Console.WriteLine();
                    Console.WriteLine("Dobra odpowiedź !");
                    Console.WriteLine("Naciśnij dowolny klawisz żeby kontynuować.");
                    Console.ReadKey();
                    score = score + 20;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Zła odpowiedź !");
                    Console.WriteLine("Naciśnij dowolny klawisz żeby kontynuować.");
                    Console.ReadKey();
                }
                Console.Clear();
            });
            Console.WriteLine($"Zdobyłeś {score} punktów ! Gratulacje !");
            Console.WriteLine("Naciśnij dowolny klawisz żeby przejść do głównego Menu.");
            Console.ReadKey();
            int gameId;
            gameId = _gameService.GetNewId();
            Game game = new Game(gameId, score, playerId, actualPlayer.Name);
            _gameService.AddItem(game);
        }
    }
}
