using CarTry.App.Common;
using CarTry.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarTry.App.Concrete
{
    public class ItemService : BaseService<Item>
    {
        public  List<Item> GetCarBrandByType(string carBrand)
        {
            List<Item> toShow = new List<Item>();
            foreach (var item in Items)
            {
                if (item.CarBrand == carBrand)
                {
                    toShow.Add(item);
                }
            }
            return toShow;
        }

    }
}
