using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaMozg
{
    public class QuestionService
    {
        public List<Question> Questions { get; set; }
        
        

         public QuestionService() 
        {
            Questions = new List<Question>();
        }
        


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
        public int AddNewQuestion(char categoryType)
        {
            int categoryId;
            string userQuestion;
            Int32.TryParse(categoryType.ToString(), out categoryId);
            Question question = new Question();
            question.CategoryId = categoryId;
            question.Id = Questions.Count + 1;
            Console.Write("Napisz pytanie :");
            userQuestion = Console.ReadLine();
            question.Description = userQuestion;
            Questions.Add(question);
            return question.Id;

            
        }
        public void AddBaseQuestions (int questionId,int categoryId,string descriptionQuestion)
        {
            Question question = new Question();
            question.Id= questionId;
            question.CategoryId = categoryId;
            question.Description = descriptionQuestion;
            Questions.Add(question);

        }
        public List<Question> GetQuestions()
        {
           return Questions;
        }
    }
}
