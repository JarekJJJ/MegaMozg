using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaMozg
{
    public class AnswerService
    {
        public List<Answer> Answers { get; set; }

        public AnswerService()
        {
            Answers = new List<Answer>();
        }
        public void AddBaseAnswer(int questionId, string description, bool isCorrect)
        {
            Answer answer = new Answer();
            answer.Id = Answers.Count + 1;
            answer.QuestionId = questionId;
            answer.Description = description;
            answer.IsCorrect = isCorrect;
            Answers.Add(answer);
        }
        public List<Answer> GetAnswers(int questionId)
        {
            List<Answer> answers = new List<Answer>();
            foreach (var element in Answers)
            {
                if (element.QuestionId == questionId)
                {
                    answers.Add(element);
                }
            }
            return answers;
        }

        public void AddNewAnswer(int questionId)
        //Metoda nie sprawdza czy jest jakakolwiek dobra odpowiedź , trzeba zaimplementować tymczasową listę odpowiedzi
        //sprawdzić jej poprawność i dopiero dodać do właściwej List<Answer> -  poprzez addrange(); - Do zrobienia !!! 
        {
            bool answerSecurity = false;
            int numberAnswers = 1;
            Console.Clear();
            do
            {
                Answer answer = new Answer();
                answer.QuestionId = questionId;
                answer.Id = Answers.Count + 1;
                Console.Write($"Podaj odpowiedź {numberAnswers}: ");
                answer.Description = Console.ReadLine();
                Console.Write("Czy odpowiedź jest prawidłowa ? (1-Tak, 2-Nie) : ");
                int answerYesOrNo;
                Int32.TryParse(Console.ReadLine(), out answerYesOrNo);
                if (answerYesOrNo == 1 && answerSecurity == false)
                {
                    answer.IsCorrect = true;
                    answerSecurity = true;
                    numberAnswers++;
                    Answers.Add(answer);
                }
                else if (answerYesOrNo == 2)
                {
                    answer.IsCorrect = false;
                    numberAnswers++;
                    Answers.Add(answer);
                }
                else
                {
                    Console.WriteLine("Podałeś już prawidłową odpowiedź! Prawidłowa odpowiedź może być tylko jedna!");
                }
            } while (numberAnswers < 5);
        }
    }
}
