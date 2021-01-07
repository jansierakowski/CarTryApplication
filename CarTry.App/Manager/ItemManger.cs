using CarTry.App.Concrete;
using CarTry.Domain.Entity;
using CarTryApplication.Helpers;
using System;
using System.Collections.Generic;

namespace CarTry.App.Manager
{
    public class ItemManager
    {
        private readonly MenuActionService _actionService;
        private ItemService _itemService;
        public ItemManager(MenuActionService actionService, ItemService itemService)
        {
            _itemService = itemService;
            _actionService = actionService;
        }
        public int AddNewItem()
        {
            var addNewItemMenu = _actionService.GetMenuActionsByName("AddNewItemMenu");
            for (int i = 0; i < addNewItemMenu.Count; i++)
            {
                Console.WriteLine($"{addNewItemMenu[i].Id}. {addNewItemMenu[i].Name}");
            }
            var operation = Console.ReadKey();
            int carBrandChoosed;
            Int32.TryParse(operation.KeyChar.ToString(), out carBrandChoosed);
            string carBrandChosed = addNewItemMenu[carBrandChoosed - 1].Name;

            Console.WriteLine("Please enter your car model");
            var carModel = Console.ReadLine();
            var lastId = _itemService.GetLastId();
            Item item = new Item(lastId + 1, carModel, carBrandChosed);
            _itemService.AddItem(item);
            Console.WriteLine();
            return item.Id;
        }

        public int RemoveItem()
        {
            Console.WriteLine("Enter id you want to delete: ");
            var itemId = Console.ReadLine();
            int id;
            Int32.TryParse(itemId.ToString(), out id);
            var item = _itemService.GetItemById(id);
            _itemService.RemoveItem(item);
            return id;
        }


        public int ItemDetail()
        {
            Console.WriteLine("Enter id you want to show: ");
            var itemId = Console.ReadLine();
            int id;
            Int32.TryParse(itemId.ToString(), out id);
            var productToShow = _itemService.GetItemById(id);

            Console.WriteLine($"Car id: {productToShow.Id} ");
            Console.WriteLine($"Car brand: {productToShow.CarBrand} ");
            Console.WriteLine($"Car model: {productToShow.CarModel} ");
            Console.WriteLine();
            return id;
        }

        public List<Item> CarBrandsByType()
        {
            Console.WriteLine("Enter car brand you want to show: ");
            var carBrand = Console.ReadLine();
            var toShow = _itemService.GetCarBrandByType(carBrand);
            Console.WriteLine(toShow.ToStringTable(new[] { "Id", "Car Brand", "Car Model" }, a => a.Id, a => a.CarBrand, a => a.CarModel));
            return toShow;
        }


        public Item GetItemById(int id)
        {
            var item = _itemService.GetItemById(id);
            return item;
        }



    }
}
