using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaMozg
{
     public class CategoryQuestionsService
    {

        public List<CategoryQuestion> CategoryQuestions  { get; set; }
        public CategoryQuestionsService() 
        {
        CategoryQuestions= new List<CategoryQuestion>();
        }

        public List<CategoryQuestion> AddCategoryQuestions(int id, string name)
        {
            CategoryQuestion categoryQuestions = new CategoryQuestion();
            categoryQuestions.Id = id;
            categoryQuestions.Name = name;
            CategoryQuestions.Add(categoryQuestions);
            return CategoryQuestions;
        }
        public List<CategoryQuestion> GetCategoryQuestions()
        {
            return CategoryQuestions;
        }
    }
}
