using MegaMozg.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaMozg.Domain.Entity
{
    public class Question : BaseEntity
    {
       
        public string Description { get; set; }
       // public byte Difficulty { get; set; } - do implementacji w późniejszym czasie
        public int CategoryId { get; set; }

        public Question(int id, string description, int categoryId)
        {
            Id= id;
            Description = description;
            CategoryId = categoryId;
        }
    }
}
