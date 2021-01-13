using CarTry.App.Common;
using CarTry.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarTry.App.Concrete
{
    public class ItemService : BaseService<Item>
    {
        public List<Item> GetCarBrandByType(string carBrand)
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

        public List<Item> ShowAllGivenCars()
        {
            List<Item> showAllCars = new List<Item>();
            foreach (var item in Items)
            {
                showAllCars.Add(item);
            }
            return showAllCars;
        }

        public bool IsUserInputCorrect(string v)
        {
            if (string.IsNullOrWhiteSpace(v))
            {
                return true;
            }
            else
                return false;
        }

        public bool IsUserInputCorrect(System.ConsoleKeyInfo keyGiven, int countedMenuOptions)
        {
            if (Int32.TryParse(keyGiven.KeyChar.ToString(), out int keyGivenInt))
            {
                for (int i = 1; i < countedMenuOptions+1; i++)
                {
                    if (keyGivenInt == i)
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            { return true; }
        }

        public string FindBrand(string brand)
        {
            var itemById = Items.FirstOrDefault(p => p.CarBrand == brand);
            return itemById.CarBrand;
        }

    }
}
