using MegaMozg.App.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MegaMozg.App.Common;
using MegaMozg.Domain.Entity;

namespace MegaMozg.App.Concrete
{
    public class QuestionService :BaseService<Question>
    {     
        public ConsoleKeyInfo AddQuestionsView(List<CategoryQuestion> categoryQuestions)
        {
            
            
            Console.Clear();
            for (int i = 0; i < categoryQuestions.Count; i++)
            {
                Console.WriteLine($"{categoryQuestions[i].Id}. {categoryQuestions[i].Name}");
            }
            Console.WriteLine($"Wybierz kategorię pytania jakie chcesz dodać (1-{categoryQuestions.Count}: ");
            var wyborKategorii = Console.ReadKey();

            return wyborKategorii;

        }
        public int AddUserQuestion(char categoryType)
        {
            int categoryId;
            string userQuestion;
            int questionId;
            Int32.TryParse(categoryType.ToString(), out categoryId);
            
           // Question question = new Question();
           // question.CategoryId = categoryId;
            questionId = Items.Count + 1;
            Console.Write("Napisz pytanie :");
            userQuestion = Console.ReadLine();
            AddItem(new Question(questionId, userQuestion, categoryId));
            
            return questionId;

            
        }
        private void Initialize()
        { 

        }

    }
}
