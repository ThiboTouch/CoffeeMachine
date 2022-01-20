namespace CoffeeMachine.Entities.Abstract
{
    public interface IDrink
    {
        public bool AllowSugar { get;}
        public uint MilkCount { get; set; }
        public uint BeanCount { get; }
        public uint SugarCount { get; set; }
        public string Name { get; }

        public enum DrinkName
        {
            Coffee = 1,
            Cuppaccino = 2,
            Latte = 3
        }
    }
}
