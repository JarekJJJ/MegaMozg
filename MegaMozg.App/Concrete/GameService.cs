using MegaMozg.App.Common;
using MegaMozg.Domain.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace MegaMozg.App.Concrete
{
    public class GameService : BaseService<Game>
    {
        public GameService()
        {
            if (!File.Exists(@"highscore.txt"))
            {
                WriteJsonDB();
            }
            else
            {
                ReadJsonDB();
            }
        }
        public void WriteJsonDB()
        {
            using StreamWriter streamWriter = new StreamWriter(@"highscore.txt");
            using JsonWriter jsonWriter = new JsonTextWriter(streamWriter);
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(jsonWriter, Items);
        }
        public void ReadJsonDB()
        {
            string jsonDb = File.ReadAllText(@"highscore.txt");
            var highScore = JsonConvert.DeserializeObject<List<Game>>(jsonDb);
            //Items.Clear();
            Items.AddRange(highScore);
        }
    }
}
