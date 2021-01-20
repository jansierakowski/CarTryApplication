using CarTry.App.Concrete;
using CarTry.App.Manager;
using CarTry.Domain.Entity;
using FluentAssertions;
using Moq;
using System;
using Xunit;

namespace CarTry.Test
{
    public class ItemService_Tests
    {
        [Fact]
        public void GetItemById_ShouldReturnIdSameAsGivenItem()
        {
            //Arrange
            Item item = new Item(1, "Polo", "Volkswagen", DateTime.Now);
            var mock = new Mock<ItemService>();
            mock.Setup(s => s.GetItemById(1)).Returns(item);
            var manager = new ItemManager(new MenuActionService(), mock.Object);

            //Act
            var returnedItem = manager.GetItemById(item.Id);
            //Assert
            //Assert.Equal(item, returnedItem);
            returnedItem.Should().BeOfType(typeof(Item));
            returnedItem.Should().NotBeNull();
            returnedItem.Should().BeSameAs(item);
        }

        [Fact]
        public void RemoveItemById_RemoveItemByGivenId_ShouldRemoveItemByGivenId()
        {
            //Arrange
            Item item = new Item(1, "Polo", "VW", DateTime.Now);
            var mock = new Mock<ItemService>();
            mock.Setup(m => m.GetItemById(1)).Returns(item);
            mock.Setup(m => m.RemoveItem(It.IsAny<Item>()));
            var manager = new ItemManager(new MenuActionService(), mock.Object);
            //Act
            manager.RemoveItemById(item.Id);
            //Assert
            mock.Verify(m => m.RemoveItem(item));
        }


        [Fact]
        public void AddNewItem_ShouldAddItemAndReturnId()
        {
            //Arrange
            var itemService = new ItemService();
            Item item = new Item(1, "Polo", "Volkswagen", DateTime.Now);

            //Act
            var id = itemService.AddItem(item);
            var newItem = itemService.GetItemById(id);
            //Assert
            item.Id.Should().NotBe(null);
            newItem.Should().BeOfType(typeof(Item));
            item.Id.Should().Be(id);

            //Clear
            itemService.RemoveItem(item);
        }


        [Fact]
        public void UpdateItem_ShouldUpdateAndReturnUpdatedValue()
        {
            //Arrange
            var itemService = new ItemService();
            Item item1 = new Item(1, "Polo", "Volkswagen", DateTime.Now);
            Item item2 = new Item(2, "Up!", "Volkswagen", DateTime.Now);
            //Act
            itemService.AddItem(item1);
            itemService.AddItem(item2);
            var itemToUpdate = itemService.UpdateItem(item1);
            var itemUpdated = itemService.GetItemById(itemToUpdate);
            itemUpdated = item2;

            //Assert
            Assert.Equal(item2.CarModel, itemUpdated.CarModel);


            //Clear
            itemService.RemoveItem(item1);
            itemService.RemoveItem(item2);

        }

        [Fact]
        public void ShowAllGivenCars_ShouldShowAllItems()
        {
            //Arrange
            var itemService = new ItemService();
            Item item1 = new Item(1, "Polo", "Volkswagen", DateTime.Now);
            Item item2 = new Item(2, "Up!", "Volkswagen", DateTime.Now);
            Item item3 = new Item(3, "Golf", "Volkswagen", DateTime.Now);
            
            //Act
            itemService.AddItem(item1);
            itemService.AddItem(item2);
            itemService.AddItem(item3);
            var allCarsList = itemService.ShowAllGivenCars();

            //Assert
            allCarsList.Should().NotBeNull();
            Assert.Equal(3, allCarsList.Count);

            //Clear
            itemService.RemoveItem(item1);
            itemService.RemoveItem(item2);
            itemService.RemoveItem(item3);

        }

        [Fact]

        public void IsUserInputCorrect_ShouldCheckGivenNullOrWhiteSpace()
        {
            //Arrnage
            var itemService = new ItemService();
            string whitespace = " ";
            string nullValue = null;
            string corretInput = "SomeWord";
            //Act
            var checkIsThereWhiteSpace = itemService.IsUserInputCorrect(whitespace);
            var checkIsThereNullValue = itemService.IsUserInputCorrect(nullValue);
            var checkIsGivenValueCorrect = itemService.IsUserInputCorrect(corretInput);

            //Assert
            checkIsThereWhiteSpace.Should().BeTrue();
            checkIsThereNullValue.Should().BeTrue();
            checkIsGivenValueCorrect.Should().BeFalse();
        }

        [Fact]
        public void FindBrand_ShouldFoundBrand()
        {
            //Arrange
            var itemService = new ItemService();
            Item item1 = new Item(1, "Polo", "Volkswagen", DateTime.Now);
            Item item2 = new Item(2, "Astra", "Opel", DateTime.Now);
            Item item3 = new Item(3, "Yaris", "Toyota", DateTime.Now);
            //Act
            itemService.AddItem(item1);
            itemService.AddItem(item2);
            itemService.AddItem(item3);
            var givenCarBrand = itemService.FindBrand("Toyota");
            //Assert
            givenCarBrand.Should().NotBeNull();
            Assert.Equal("Toyota", givenCarBrand);
            //Clear
            itemService.RemoveItem(item1);
            itemService.RemoveItem(item2);
            itemService.RemoveItem(item3);
        }
    }
}
