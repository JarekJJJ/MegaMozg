using MegaMozg.App.Abstract;
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
        //IService<CategoryQuestion> _categoryQuestions; - do zrobienia w przyszłości
        public GameManager(IService<Player> player, IService<Question> question, IService<Answer> answer, IService<Game> gameService) 
        {
            _playerService= player;
            _question= question;
            _answer= answer;
            _gameService= gameService;

        }
        public Game StartGame(int playerId)
        {
            int score = 0;
            Random random = new Random();
            int[] numberQuestions = new int[5];
            List<Question> randomQuestions = new List<Question>();
            int z = 0;
            bool noRepeatNumber = true;
            var actualPlayer = _playerService.GetItem(playerId);
            Console.WriteLine($"Witaj {actualPlayer.Name} "); ;
            var questions = _question.GetAllItems();

            while (z < 5)
            {

                int testNumber;
                noRepeatNumber = true;

                testNumber = random.Next(questions.Count + 1);
                for (int i = 0; i < 5; i++)
                {
                    if (numberQuestions[i] == testNumber)
                    {
                        noRepeatNumber = false;
                    }
                }
                if (noRepeatNumber)
                {
                    numberQuestions[z] = testNumber;
                    //Console.WriteLine($"{numberQuestions[z]}, ");
                    z++;
                }
            }
            foreach (var element in questions)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (element.Id == numberQuestions[i])
                    {
                        randomQuestions.Add(element);
                    }
                }
            }
            int nquestion = 0;
            foreach (var element in randomQuestions)
            {
                Console.Clear();
                int userChoice;
                Answer[] answerChoice = new Answer[4];
                Console.WriteLine(element.Description);
                Console.WriteLine();
                var allAnswers = _answer.GetAllItems();
                List<Answer> answerList = new List<Answer>();
                foreach (var answer in allAnswers)
                {
                    if(element.Id == answer.QuestionId) 
                    {
                        answerList.Add(answer);
                    }
                }
                nquestion = 0;
                foreach (var elementAnswers in answerList)
                {

                    Console.Write($"{nquestion}: {elementAnswers.Description}    ");
                    if (nquestion % 2 != 0)
                    {
                        Console.WriteLine();
                    }
                    answerChoice[nquestion] = elementAnswers;
                    if (nquestion < 3)
                    {
                        nquestion++;
                    }
                }
                Console.Write("Wybierz odpowiedź (0-3) i naciśnij ENTER: ");
                Int32.TryParse(Console.ReadLine(), out userChoice);

                if (answerChoice[userChoice].IsCorrect)
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

            }
            Console.WriteLine($"Zdobyłeś {score} punktów ! Gratulacje !");
            Console.WriteLine("Naciśnij dowolny klawisz żeby przejść do głównego Menu.");
            Console.ReadKey();
            int gameId;
            gameId =  _gameService.GetLastId();
            Game game = new Game(gameId+1, score, playerId);
            _gameService.AddItem(game);
            return game;
        }
    }
}
