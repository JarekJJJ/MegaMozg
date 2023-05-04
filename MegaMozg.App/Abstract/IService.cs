using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaMozg.App.Abstract
{
    public interface IService<T>
    {
        List<T> Items { get; set; }
        List<T> GetAllItems();    
        List<T> GetAllItemsDescending();
        T GetItem(int id);
        int AddItem(T item);
        int GetLastId();
        int GetNewId();
    }
}
