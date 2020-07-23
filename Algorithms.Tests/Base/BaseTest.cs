using Algorithms.Extensions;

namespace Algorithms.Tests.Base
{
    public class BaseTest
    {
        protected string Stringify(int key) => key.ToString();

        protected int[] GetBalancedArray(int count)
        {
            var balancedValues = new int[count];

            for (int i = 0; i < count; i++)
            {
                balancedValues[i] = i;
            }

            balancedValues.Shuffle();
            return balancedValues;
        }
    }
}
