using CarTry.App.Abstract;
using CarTry.App.Concrete;
using CarTry.App.Manager;
using CarTry.Domain.Entity;
using System;

namespace CarTryApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuActionService actionService = new MenuActionService();
            ItemManger itemManger = new ItemManger(actionService);

            Console.WriteLine("Welcome in first car test&try community");
            Console.WriteLine("Select what you want to do:");

            while (true)
            {
                var mainMenu = actionService.GetMenuActionsByName("Main");
                for (int i = 0; i < mainMenu.Count; i++)
                {
                    Console.WriteLine($"{mainMenu[i].Id}. {mainMenu[i].Name}");
                }
                var operation = Console.ReadKey();

                Console.WriteLine();

                switch (operation.KeyChar)
                {
                    case '1':
                        var newId = itemManger.AddNewItem();
                        break;
                    case '2':
                        var removeId = itemManger.RemoveItem();
                        Console.WriteLine();
                        break;
                    case '3':
                        var detailId = itemManger.ItemDetail();
                        Console.WriteLine();
                        break;
                    case '4':
                        var brandToShow = itemManger.CarBrandsByType();
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine("Action you entered does not exist");
                        break;
                }
            }
        }


    }
}
