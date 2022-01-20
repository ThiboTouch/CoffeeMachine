using CoffeeMachine.Entities;
using CoffeeMachine.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static CoffeeMachine.Entities.Abstract.IDrink;

namespace CoffeeMachine.Tests
{
    [TestClass]
    public class FactoryTests
    {
        [TestMethod]
        public void CreateDrinkForCoffeeReturnsCoffeeObject()
        {
            //Arrange
            DrinkFactory factory = new DrinkFactory(DrinkName.Coffee);

            uint noOfBeans = 2;
            uint noOfMilk = 0;
            bool allowSugar = false;

            //Act
            var factoryObject = factory.CreateDrink();

            //Assert
            Assert.IsNotNull(factoryObject);

            Assert.AreEqual(noOfBeans, factoryObject.BeanCount);
            Assert.AreEqual(noOfMilk, factoryObject.MilkCount);
            Assert.AreEqual(allowSugar, factoryObject.AllowSugar);

            Assert.IsInstanceOfType(factoryObject, typeof(Coffee));
        }

        [TestMethod]
        public void CreateDrinkForCuppaccinoReturnsCuppaccinoObject()
        {
            //Arrange
            DrinkFactory factory = new DrinkFactory(DrinkName.Cuppaccino);

            uint noOfBeans = 5;
            uint noOfMilk = 3;
            bool allowSugar = true;

            //Act
            var factoryObject = factory.CreateDrink();

            //Assert
            Assert.IsNotNull(factoryObject);

            Assert.AreEqual(noOfBeans, factoryObject.BeanCount);
            Assert.AreEqual(noOfMilk, factoryObject.MilkCount);
            Assert.AreEqual(allowSugar, factoryObject.AllowSugar);

            Assert.IsInstanceOfType(factoryObject, typeof(Cuppaccino));
        }

        [TestMethod]
        public void CreateDrinkForLatteReturnsLatteObject()
        {
            //Arrange
            DrinkFactory factory = new DrinkFactory(DrinkName.Latte);

            uint noOfBeans = 3;
            uint noOfMilk = 2;
            bool allowSugar = false;

            //Act
            var factoryObject = factory.CreateDrink();

            //Assert
            Assert.IsNotNull(factoryObject);

            Assert.AreEqual(noOfBeans, factoryObject.BeanCount);
            Assert.AreEqual(noOfMilk, factoryObject.MilkCount);
            Assert.AreEqual(allowSugar, factoryObject.AllowSugar);

            Assert.IsInstanceOfType(factoryObject, typeof(Latte));
        }

        [TestMethod]
        public void CreateDrinkForDefaultReturnsCoffeeObject()
        {
            //Arrange
            DrinkFactory factory = new DrinkFactory();

            //Act
            var factoryObject = factory.CreateDrink();

            //Assert
            Assert.IsNotNull(factoryObject);
            Assert.IsInstanceOfType(factoryObject, typeof(Coffee));
        }
    }
}