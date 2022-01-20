using CoffeeMachine.Entities.Abstract;
using CoffeeMachine.Services;
using static CoffeeMachine.Entities.Abstract.IDrink;

namespace CoffeeMachine
{
    internal class Program
    {
        private static string? _value;
        private static string? Value
        {
            get => _value;
            set
            {
                _value = value;
                if (_value == "off")
                {
                    Environment.Exit(0);
                }
            }
        }

        static void Main(string[] args)
        {
            var machine = new Machine();

            printMenuGreeting();

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Value = Console.ReadLine();

            while (true)
            {
                int.TryParse(Value, out int choice);

                var drinkName = (DrinkName)choice == 0 ? DrinkName.Coffee : (DrinkName)choice;

                var drink = new DrinkFactory(drinkName).CreateDrink();

                if (drinkName == DrinkName.Coffee)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine();
                    Console.WriteLine($"Would you like milk with your {drink.Name} (type y for yes, n for no)?");
                    Console.WriteLine();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Value = Console.ReadLine();
                    if (char.TryParse(Value, out char milk))
                        if (milk == 'y')
                            drink.MilkCount = 1;
                        else
                            drink.MilkCount = 0;
                }

                if (drink.AllowSugar)
                {
                    uint sugarCount;

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine();
                    Console.WriteLine($"How much sugar would you like for your {drink.Name}?");
                    Console.WriteLine();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Value = Console.ReadLine();

                    if (uint.TryParse(Value, out sugarCount))
                        drink.SugarCount = sugarCount;
                }

                string message;
                var success = machine.MakeDrink(drink, out message);

                if (success)
                    Console.ForegroundColor = ConsoleColor.Blue;
                else
                    Console.ForegroundColor = ConsoleColor.Red;

                printMachineOutput(message, drink, machine);

                printMenuGreeting();

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Value = Console.ReadLine();
            }
        }

        static void printMenuGreeting()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Hi, what drink would you like today? (type \"off\" to exit program)");
            Console.WriteLine("Choose between our three products:");
            Console.WriteLine("1. Coffee    2. Cuppaccino   3. Latte (type option number)");
        }

        static void printMachineOutput(string message, IDrink drink, Machine machine)
        {
            Console.WriteLine();
            Console.WriteLine(message);

            Console.WriteLine();
            Console.WriteLine(
                $"------------{drink.Name}-------------\n" +
                $"Milk - {drink.MilkCount}\n" +
                $"Beans - {drink.BeanCount}\n" +
                $"Sugar - {drink.SugarCount}\n" +
                $"------------{drink.Name}-------------\n");

            Console.WriteLine("------------Machine Status--------------\n");
            Console.WriteLine(
                $"Beans left: {machine.BeanCount}\n" +
                $"Milk left: {machine.MilkCount}");
            Console.WriteLine();
            Console.WriteLine("------------Machine Status--------------\n");

            Console.WriteLine();
        }
    }
}