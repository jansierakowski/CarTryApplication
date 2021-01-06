using CarTry.App.Common;
using CarTry.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarTry.App.Concrete
{
    public class MenuActionService : BaseService<MenuAction>
    {
        private List<MenuAction> menuActions;

        public MenuActionService()
        {
            Initialize();
        }

        //public void AddNewAction(int id, string name, string menuName)
        //{
        //    MenuAction menuAction = new MenuAction { Id = id, Name = name, MenuName = menuName };
        //    menuActions.Add(menuAction);
        //}

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

            AddItem(new MenuAction(1, "Opel", "AddNewItemMenu"));
            AddItem(new MenuAction(2, "Volkswagen", "AddNewItemMenu"));
            AddItem(new MenuAction(3, "Toyota", "AddNewItemMenu"));

            }
    }
}
