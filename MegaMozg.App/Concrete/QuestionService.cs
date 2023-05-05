using MegaMozg.App.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MegaMozg.App.Common;
using MegaMozg.Domain.Entity;
using Newtonsoft.Json;

namespace MegaMozg.App.Concrete
{
    public class QuestionService : BaseService<Question>
    {
        public QuestionService()
        {
            if (!File.Exists(@"question.txt"))
            {
                Initialize();
                WriteJsonDB();
            }
            else
            {
                ReadJsonDB();
            }
        }
        public List<Question> GetRandomQuestion()
        {
            var randomQuestions = Items.OrderBy(x => Guid.NewGuid()).Take(5).ToList();
            return randomQuestions;
        }
        public void WriteJsonDB()
        {
            using StreamWriter streamWriter = new StreamWriter(@"question.txt");
            using JsonWriter jsonWriter = new JsonTextWriter(streamWriter);
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(jsonWriter, Items);
        }
        public void ReadJsonDB()
        {
            string jsonDb = File.ReadAllText(@"question.txt");
            var questions = JsonConvert.DeserializeObject<List<Question>>(jsonDb);
            Items.Clear();
            Items.AddRange(questions);
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
