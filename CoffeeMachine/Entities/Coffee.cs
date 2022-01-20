using CoffeeMachine.Entities.Abstract;
using static CoffeeMachine.Entities.Abstract.IDrink;

namespace CoffeeMachine.Entities
{
    public class Coffee : IDrink
    {
        private uint _milkCount = 0;
        public bool AllowSugar => false;

        public uint MilkCount
        {
            get
            {
                return _milkCount;
            }
            set
            {
                if (value == 1 || value == 0)
                    _milkCount = value;
            }
        }

        public uint BeanCount => 2;

        public uint SugarCount { get; set; }

        public string Name => DrinkName.Coffee.ToString();
    }
}
