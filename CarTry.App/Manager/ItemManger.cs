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

        public void AddNewItem()
        {
            var addNewItemMenu = _actionService.GetMenuActionsByName("AddNewItemMenu");
            for (int i = 0; i < addNewItemMenu.Count; i++)
            {
                Console.WriteLine($"{addNewItemMenu[i].Id}. {addNewItemMenu[i].Name}");
            }
            var operation = Console.ReadKey();
            if (_itemService.IsUserInputCorrect(operation, addNewItemMenu.Count))
            {
                int carBrandChoosed;
                Int32.TryParse(operation.KeyChar.ToString(), out carBrandChoosed);
                string carBrandChosed = addNewItemMenu[carBrandChoosed - 1].Name;
                Console.WriteLine();

                Console.WriteLine("Please enter your car model");
                var carModel = Console.ReadLine();
                if (_itemService.IsUserInputCorrect(carModel))
                {
                    var lastId = _itemService.GetLastId();
                    Item item = new Item(lastId + 1, carModel, carBrandChosed);
                    _itemService.AddItem(item);
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Given incorrect values");

                }
            }
            else
            {
                Console.WriteLine("Given incorrect values");

            }
        }



        public void RemoveItem()
        {
            Console.WriteLine("Enter id you want to delete: ");
            var itemId = Console.ReadLine();
            Int32.TryParse(itemId.ToString(), out int id);
            var item = _itemService.GetItemById(id);
            if (item == null)
            {
                Console.WriteLine("There is no such id");
            }
            else
            {
                _itemService.RemoveItem(item);
            }
        }


        public void ItemDetail()
        {
            Console.WriteLine("Enter id you want to show: ");
            var itemId = Console.ReadLine();
            Int32.TryParse(itemId.ToString(), out int id);
            var productToShow = _itemService.GetItemById(id);
            if (productToShow == null)
            {
                Console.WriteLine("There is no such id");
            }
            else
            {
                Console.WriteLine($"Car id: {productToShow.Id} ");
                Console.WriteLine($"Car brand: {productToShow.CarBrand} ");
                Console.WriteLine($"Car model: {productToShow.CarModel} ");
                Console.WriteLine();
            }
        }

        public void CarBrandsByType()
        {
            Console.WriteLine("Enter car brand you want to show: ");
            var carBrand = Console.ReadLine();
            var toShow = _itemService.GetCarBrandByType(carBrand);
            if (toShow.Count == 0)
            {
                Console.WriteLine("There are no cars of this brand");
            }
            else
            {
                Console.WriteLine(toShow.ToStringTable(new[] { "Id", "Car Brand", "Car Model" }, a => a.Id, a => a.CarBrand, a => a.CarModel));
            }
        }


        public Item GetItemById(int id)
        {
            var item = _itemService.GetItemById(id);
            return item;
        }

        public void RemoveItemById(int id)
        {
            var item = GetItemById(id);
            _itemService.RemoveItem(item);
        }



    }
}
