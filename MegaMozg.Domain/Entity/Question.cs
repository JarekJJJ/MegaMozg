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
        public int CategoryId { get; set; }
        public Question(int id, int categoryId,  string description )
        {
            Id= id;
            Description = description;
            CategoryId = categoryId;
        }
    }
}
