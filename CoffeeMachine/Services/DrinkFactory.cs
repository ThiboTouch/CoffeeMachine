using CoffeeMachine.Entities;
using CoffeeMachine.Entities.Abstract;
using static CoffeeMachine.Entities.Abstract.IDrink;

namespace CoffeeMachine.Services
{
    public class DrinkFactory
    {
        private DrinkName _drinkName;

        public DrinkFactory(DrinkName drink = DrinkName.Coffee)
        {
            _drinkName = drink;
        }

        public IDrink CreateDrink()
        {
            switch (_drinkName)
            {
                case DrinkName.Cuppaccino:
                    var cuppaccino = new Cuppaccino();
                    return cuppaccino;
                case DrinkName.Coffee:
                    var coffee = new Coffee();
                    return coffee;
                case DrinkName.Latte:
                    var latte = new Latte();
                    return latte;
                default: return new Coffee();
            }
        }
    }
}
