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
    public class UserQuestionManager
    {
        private IService<Answer> _answerService;
        private readonly CategoryQuestionsService _categoryService;
        private IService<Question> _questionService;
        QuestionService userQuestions = new QuestionService();
        AnswerService userAnswer = new AnswerService();
        public UserQuestionManager(CategoryQuestionsService categoryService, IService<Question> questionService, IService<Answer> answerService)
        {
            _categoryService = categoryService;
            _questionService = questionService;
            _answerService = answerService;
        }
        public int AddNewQuestions()
        {
            Console.Clear();
            string userQuestion;
            var categoryList = _categoryService.GetAllItems();
            for (int i = 0; i < _categoryService.Items.Count; i++)
            {
                Console.WriteLine($"{categoryList[i].Id}. {categoryList[i].Name}");
            }
            Console.WriteLine($"Wybierz kategorię pytania jakie chcesz dodać (1-{_categoryService.Items.Count}: ");
            var selectedCategory = Console.ReadKey();
            int catId;
            Int32.TryParse(selectedCategory.KeyChar.ToString(), out catId);
            Console.Write("Napisz pytanie :");
            userQuestion = Console.ReadLine();
            var lastId = _questionService.GetLastId();
            Question question = new Question(lastId + 1, catId, userQuestion);
            _questionService.AddItem(question);            
            return question.Id;
        }
        public void AddUserAnswer(int questionId)
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
                    Answer answer = new Answer(lastId + 1, questionId, answerDescription, true);
                    _answerService.AddItem(answer);
                }
                else if (answerYesOrNo == 2)
                {
                    numberAnswers++;
                    Answer answer = new Answer(lastId + 1, questionId, answerDescription, false);
                    _answerService.AddItem(answer);
                }
                else
                {
                    Console.WriteLine("Podałeś już prawidłową odpowiedź! Prawidłowa odpowiedź może być tylko jedna!");
                }
                Console.Clear();
                
            } while (numberAnswers < 5);
            userQuestions.Items.Clear();
            userAnswer.Items.Clear();
            userQuestions.Items.AddRange(_questionService.Items);
            userQuestions.WriteJsonDB();
            userAnswer.Items.AddRange(_answerService.Items);
            userAnswer.WriteJsonDB();
        }
    }
}
