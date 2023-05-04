using MegaMozg.App.Common;
using MegaMozg.App.Concrete;
using MegaMozg.Domain.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MegaMozg.App.Concrete
{
    public class AnswerService : BaseService<Answer>
    {
        public AnswerService()
        {
            if (!File.Exists(@"answer.txt"))
            {
                Initialize();
                WriteJsonDB();
            }else
            {
                ReadJsonDB();
            }           
        }
        public void WriteJsonDB()
        {
            using StreamWriter streamWriter = new StreamWriter(@"answer.txt");
            using JsonWriter jsonWriter = new JsonTextWriter(streamWriter);
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(jsonWriter, Items);
        }
        public void ReadJsonDB()
        {          
            string jsonDb = File.ReadAllText(@"answer.txt");
            var answers = JsonConvert.DeserializeObject<List<Answer>>(jsonDb);
            //Items.Clear();
            Items.AddRange(answers);
        }
        private void Initialize()
        {
            AddItem(new Answer(1, 1, "104", true));
            AddItem(new Answer(2, 1, "110", false));
            AddItem(new Answer(3, 1, "101", false));
            AddItem(new Answer(4, 1, "112", false));

            AddItem(new Answer(5, 2, "130kW", false));
            AddItem(new Answer(6, 2, "75.86kW", false));
            AddItem(new Answer(7, 2, "95.61kW", true));
            AddItem(new Answer(8, 2, "165.32kW", false));

            AddItem(new Answer(9, 3, "Bolesław Chrobry", false));
            AddItem(new Answer(10, 3, "Zygmunt I Stary", false));
            AddItem(new Answer(11, 3, "Władysław Jagiełło", true));
            AddItem(new Answer(12, 3, "Jan III Sobieski", false));

            AddItem(new Answer(13, 4, "14", false));
            AddItem(new Answer(14, 4, "18", false));
            AddItem(new Answer(15, 4, "22", false));
            AddItem(new Answer(16, 4, "16", true));

            AddItem(new Answer(17, 5, "7 par", true));
            AddItem(new Answer(18, 5, "47 par", false));
            AddItem(new Answer(19, 5, "50 par", false));
            AddItem(new Answer(20, 5, "67 par", false));
        }
    }
}
