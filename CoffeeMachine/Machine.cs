using CoffeeMachine.Entities.Abstract;
using System.Text;

namespace CoffeeMachine
{
    public class Machine
    {
        private uint _milkCount = 20;
        private uint _beanCount = 25;
        private const uint _beanCountWarning = 5;
        public uint MilkCount => _milkCount;
        public uint BeanCount => _beanCount;

        public bool MakeDrink(IDrink drink, out string message) 
        {
            if (MilkCount < drink.MilkCount || BeanCount < drink.BeanCount)
            {
                message = "Sorry, the capacity for milk or beans in the machine is insufficient.";
                return false;
            }
            
            _milkCount -= drink.MilkCount;
            _beanCount -= drink.BeanCount;

            var buildMessage = new StringBuilder();
            if(_beanCount <= _beanCountWarning)
            {
               buildMessage.Append($"The bean capacity on the machine has reached {_beanCountWarning} or lower.\n");
            }

            message = buildMessage.Append("Your drink is ready, thanks for your support.").ToString();
            return true;
        }
    }
}
