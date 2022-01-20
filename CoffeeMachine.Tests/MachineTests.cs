using CoffeeMachine.Entities;
using CoffeeMachine.Entities.Abstract;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoffeeMachine.Tests
{
    [TestClass]
    public class MachineTests
    {
        [TestMethod]
        public void MakeMilkReturnsTrueOnDrinkRequest()
        {
            //Arrange
            IDrink cuppaccino = new Cuppaccino();
            Machine machine = new Machine();
            var message = string.Empty;

            //Act
            var success = machine.MakeDrink(cuppaccino, out message);

            //Assert
            Assert.IsTrue(success);
            Assert.AreEqual("Your drink is ready, thanks for your support.", message);
        }

        [TestMethod]
        public void MakeMilkReturnsFalseOnLimitedBeanOrMilkCapacity()
        {
            //Arrange
            IDrink cuppaccino = new Cuppaccino();
            Machine machine = new Machine();
            var message = string.Empty;

            bool success = true;

            //Act
            while (success)
            {
                success = machine.MakeDrink(cuppaccino, out message);
            }

            //Assert
            Assert.IsFalse(success);
            Assert.AreEqual("Sorry, the capacity for milk or beans in the machine is insufficient.", message);
        }

        [TestMethod]
        public void MakeMilkHasWarningOnBeanDecreasedCapacity()
        {
            //Arrange 
            IDrink cuppaccino = new Cuppaccino();
            Machine machine = new Machine();
            var message = string.Empty;

            string beanCapacityWarning = "The bean capacity on the machine has reached";

            bool success = true;

            //Act
            while (success)
            {
                success = machine.MakeDrink(cuppaccino, out message);
                if (message.Contains(beanCapacityWarning))
                    break;
            }

            //Assert
            Assert.IsTrue(success);
            Assert.IsTrue(message.Contains(beanCapacityWarning));
        }
    }
}
