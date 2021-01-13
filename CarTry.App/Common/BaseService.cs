using System;
using CarTry.App.Abstract;
using System.Collections.Generic;
using CarTry.Domain.Common;
using System.Linq;

namespace CarTry.App.Common
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        public List<T> Items { get; set ; }

        public BaseService()
        {
            Items = new List<T>();
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

        public virtual void RemoveItem(T item)
        {
            Items.Remove(item);
        }

        public int UpdateItem(T item)
        {
            var entity = Items.FirstOrDefault(p => p.Id == item.Id);
            if(entity != null)
            {
                entity = item;
            }
            return entity.Id;

        }

        public int GetLastId()
        {
            int lastId;
            if (Items.Any())
            {
                lastId = Items.OrderBy(p => p.Id).LastOrDefault().Id;
            }
            else
            {
                lastId = 0;
            }
            return lastId;
        }

        public virtual T GetItemById(int id)
        {
            var itemById = Items.FirstOrDefault(p => p.Id == id);
            return itemById;
        }




    }
}


