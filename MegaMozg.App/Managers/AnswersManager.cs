using MegaMozg.App.Abstract;
using MegaMozg.App.Concrete;
using MegaMozg.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaMozg.App.Managers
{
    public  class AnswersManager
    {
       // private readonly CategoryQuestionsService _categoryService;
        private IService<Answer> _answerService;
        public AnswersManager(IService<Answer> answerService)
        {
            _answerService = answerService;           
        }
        public void AddUserAnswer(int questionId)
        //Metoda nie sprawdza czy jest jakakolwiek dobra odpowiedź , trzeba zaimplementować tymczasową listę odpowiedzi
        //sprawdzić jej poprawność i dopiero dodać do właściwej List<Answer> -  poprzez addrange(); - Do zrobienia !!! 
        {
            bool answerSecurity = false;
            int numberAnswers = 1;
            int answerId;
            string answerDescription;
            Console.Clear();
            do
            {
                var lastId = _answerService.GetLastId();
                Console.Write($"Podaj odpowiedź {numberAnswers}: ");
                answerDescription = Console.ReadLine();
                Console.Write("Czy odpowiedź jest prawidłowa ? (1-Tak, 2-Nie) : ");
                int answerYesOrNo;
                Int32.TryParse(Console.ReadLine(), out answerYesOrNo);
                if (answerYesOrNo == 1 && answerSecurity == false)
                {
                    answerSecurity = true;
                    numberAnswers++;
                    Answer answer = new Answer(lastId+1,questionId, answerDescription,true);
                   _answerService.AddItem(answer);
                }
                else if (answerYesOrNo == 2)
                {
                    numberAnswers++;
                    Answer answer = new Answer(lastId + 1, questionId, answerDescription, false);
                    _answerService.AddItem(answer);
                    //AddItem(new Answer(answerId, answerDescription, false, questionId));
                }
                else
                {
                    Console.WriteLine("Podałeś już prawidłową odpowiedź! Prawidłowa odpowiedź może być tylko jedna!");
                }
            } while (numberAnswers < 5);
        }

    }
}
