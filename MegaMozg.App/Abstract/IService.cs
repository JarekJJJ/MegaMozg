using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaMozg.App.Abstract
{
    public interface IService<T>
    {

        // Dodać dodawanie kategorii w późniejszym czasie
        List<T> Items { get; set; }
        List<T> GetAllItems();
        T GetItem(int id);
        int AddItem(T item);
        int GetLastId();


    }
}
