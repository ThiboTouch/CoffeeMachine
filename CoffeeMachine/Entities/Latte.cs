using CoffeeMachine.Entities.Abstract;
using static CoffeeMachine.Entities.Abstract.IDrink;

namespace CoffeeMachine.Entities
{
    public class Latte : IDrink
    {
        private uint _milkCount = 2;
        public bool AllowSugar => false;

        public uint MilkCount { 
            get { return _milkCount; } 
            
            set
            {
                if (value != _milkCount)
                    _milkCount = 2;
            } 
        }

        public uint BeanCount => 3;

        public uint SugarCount { get; set; }

        public string Name => DrinkName.Latte.ToString();
    }
}
