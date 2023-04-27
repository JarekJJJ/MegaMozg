using MegaMozg.App.Abstract;
using MegaMozg.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaMozg.App.Common
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {

        public List<T> Items { get; set; }
        public BaseService()
        {
            Items= new List<T>();
        }

      

        public int AddItem(T item)
        {
            Items.Add(item);
            return item.Id;
        }

        public List<T> GetAllItems()
        {
            return Items;
        }

        public T GetItem(int id)
        {
            var entity = Items.FirstOrDefault(x => x.Id == id);
           
                return entity;
           
        }
    }


}
