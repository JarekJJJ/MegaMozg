using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaMozg
{
    public class Question
    {
        public int Id { get; set; }
        public string Description { get; set; }
       // public byte Difficulty { get; set; } - do implementacji w późniejszym czasie
        public int CategoryId { get; set; }

       
    }
}
