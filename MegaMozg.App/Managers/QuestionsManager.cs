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
    public class QuestionsManager
    {
        private readonly CategoryQuestionsService _categoryService;
        private  IService<Question> _questionService;
        public QuestionsManager(CategoryQuestionsService categoryService, IService<Question> questionService) 
        {
        _categoryService= categoryService;
        _questionService= questionService;
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
            //int.TryParse(selectedCategory, out selectedCategory); 
            Console.Write("Napisz pytanie :");
            userQuestion = Console.ReadLine();
            var lastId = _questionService.GetLastId();
            //if (selectedCategory != null) {
                Question question = new Question(lastId+1, catId,userQuestion );
                _questionService.AddItem(question);
           // }
           return question.Id;
        }
    }
}
