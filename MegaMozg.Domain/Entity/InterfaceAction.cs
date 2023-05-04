using MegaMozg.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaMozg.Domain.Entity
{
    public class InterfaceAction : BaseEntity
    {
        public string Name { get; set; }
        public string InterfaceName { get; set; }
        public InterfaceAction(int id,string name,  string interfaceName) 
        {
            Id= id;
            Name= name;
            InterfaceName= interfaceName;
        }
    }
}
