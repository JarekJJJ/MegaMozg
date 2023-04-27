using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaMozg
{
    internal class InterfaceActionService
    {
        private List<InterfaceAction> interfaceActions = new List<InterfaceAction>();
        public void AddNewAction(int id, string name, string interfaceName)
        {
            InterfaceAction interfaceAction = new InterfaceAction() { Id = id, Name = name, InterfaceName = interfaceName };
            interfaceActions.Add(interfaceAction);
        }
        public List<InterfaceAction> GetInterfaceActionsByName(string interfaceName) 
        {
            List<InterfaceAction> result = new List<InterfaceAction>();
            foreach (var element in interfaceActions) 
            {
                if (element.InterfaceName == interfaceName) 
                {
                    result.Add(element);
                }
            }
            return result;
        }
    }
}
