using CoffeeMachine.Entities.Abstract;
using static CoffeeMachine.Entities.Abstract.IDrink;

namespace CoffeeMachine.Entities
{
    public class Cuppaccino : IDrink
    {
        private uint _milkCount = 3;

        public bool AllowSugar => true;

        public uint MilkCount
        {
            get
            {
                return _milkCount;
            }
            set
            {
                if (value != _milkCount)
                    _milkCount = 3;
            }
        }

        public uint BeanCount => 5;

        public uint SugarCount { get; set; }

        public string Name => DrinkName.Cuppaccino.ToString();
    }
}
