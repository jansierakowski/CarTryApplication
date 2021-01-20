using CarTry.App.Common;
using CarTry.Domain.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CarTry.App.Concrete
{
    public class MenuActionService : BaseService<MenuAction>
    {
        public MenuActionService()
        {
            Initialize();
        }

        public List<MenuAction> GetMenuActionsByName(string menuName)
        {
            List<MenuAction> result = new List<MenuAction>();
            foreach (var menuAction in Items)
            {
                if (menuAction.MenuName == menuName)
                {
                    result.Add(menuAction);
                }
            }
            return result;
        }


        private void Initialize()
        {
            AddItem(new MenuAction(1, "Add the car that you can lend to test&try", "Main"));
            AddItem(new MenuAction(2, "Delete a car test&try announcement", "Main"));
            AddItem(new MenuAction(3, "Search a car to test&try", "Main"));
            AddItem(new MenuAction(4, "Search a model by car brand to test&try", "Main"));
            AddItem(new MenuAction(5, "Show all cars to test&try", "Main"));
            AddItem(new MenuAction(6, "Show all cars in given city", "Main"));


            var dataService = new DataService();
            var carManufacturersList = dataService.LoadJsonData("CarManufacturers.json");
            foreach (var brand in carManufacturersList.Select((Value, Index) => new { Value, Index }))
            {
                AddItem(new MenuAction(brand.Index + 1, brand.Value, "AddNewItemMenu"));
            }
        }
    }
}
