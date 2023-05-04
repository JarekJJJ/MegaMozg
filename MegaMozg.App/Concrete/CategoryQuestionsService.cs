using MegaMozg.App.Common;
using MegaMozg.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaMozg.App.Concrete
{
     public class CategoryQuestionsService :BaseService<CategoryQuestion>
    {
        public CategoryQuestionsService()
        {
            Initialize();
        }
        private void Initialize()
        {
            AddItem(new CategoryQuestion(1, "Techika"));
            AddItem(new CategoryQuestion(2, "Historia"));
            AddItem(new CategoryQuestion(3, "Geografia"));
            AddItem(new CategoryQuestion(4, "Biologia"));
        }
    }
}
