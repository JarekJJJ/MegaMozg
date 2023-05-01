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
        public QuestionService()
        {
            Initialize();
        }
        private void Initialize() 
        {
            AddItem(new Question(1, 1, "Ile klawiszy ma standardowa klawiatura komputerowa ?"));
            AddItem(new Question(2, 1, "130 koni mechanicznych ile to kiloWatów"));
            AddItem(new Question(3, 2, "Który król najdłużej rządził w Polsce(48 lat i 3 miesiące)?"));
            AddItem(new Question(4, 3, "Ile w Polsce jest województw ?"));
            AddItem(new Question(5, 4, "Stonoga (Oniscoidea) ile ma nóg ?"));
        }

    }
}
