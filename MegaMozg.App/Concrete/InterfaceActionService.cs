using MegaMozg.App.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MegaMozg.Domain.Entity;

namespace MegaMozg.App.Concrete
{
    public class InterfaceActionService : BaseService<InterfaceAction>
    {
        public InterfaceActionService() 
        {
        Initialize();
        }
        
       
        public List<InterfaceAction> GetInterfaceActionsByName(string interfaceName) 
        {
            List<InterfaceAction> result = new List<InterfaceAction>();
            foreach (var element in Items) 
            {
                if (element.InterfaceName == interfaceName) 
                {
                    result.Add(element);
                }
            }
            return result;
        }
        private void Initialize()
        {
            AddItem(new InterfaceAction(1, "Nowa gra", "Main"));
            AddItem(new InterfaceAction(2, "Dodaj własne pytanie", "Main"));
            AddItem(new InterfaceAction(3, "Tablica wyników", "Main"));
            AddItem(new InterfaceAction(4, "Wyjście", "Main"));
        }
    }
}
