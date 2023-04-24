using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace MegaMozg
{
    public class GameService
    {
        public static void StartGame(int playerId, PlayerService player, CategoryQuestionsService category, QuestionService question, AnswerService answer)
        {
            int wynik = 0;
            Random random = new Random();
            int[] numberQuestions = new int[5];
            List<Question> randomQuestions = new List<Question>();
            int z = 0;
            bool noRepeatNumber = true;
            var actualPlayer = player.GetPlayer(playerId);
            Console.WriteLine($"Witaj {actualPlayer.Name} "); ;
            var questions = question.GetQuestions();

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
                var answers = answer.GetAnswers(element.Id);
                nquestion = 0;
                foreach (var elementAnswers in answers)
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
                    wynik = wynik + 20;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Zła odpowiedź !");
                    Console.WriteLine("Naciśnij dowolny klawisz żeby kontynuować.");
                    Console.ReadKey();
                }

            }
            Console.WriteLine($"Zdobyłeś {wynik} punktów ! Gratulacje !");
            Console.WriteLine("Naciśnij dowolny klawisz żeby przejść do głównego Menu.");
            Console.ReadKey();
        }
    }
}
