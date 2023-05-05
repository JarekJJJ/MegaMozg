using MegaMozg.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaMozg.Domain.Entity
{
    public class Player : BaseEntity
    {
        public string Name { get; set; }
        public Player(int id, string name)
        {
            Id= id;
            Name= name;
        }
    }

}
