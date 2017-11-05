using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Razredi.Zad6i7
{
    public class FactDigSum
    {
        public async static Task<int> FactorialDigitSum(int n)
        {
            Task<int> t = Task.Run(() => DigitSum(Factorial(n)));
            return await t;
        }

        private static int DigitSum(long n)
        {
            int sum = 0;

            while (n != 0)
            {
                sum += (int) (n % 10);
                n /= 10;
            }

            return sum;
        }

        public static long Factorial(int n)
        {
            if (n <= 1)
            {
                return 1;
            }
            else
            {
                return n * Factorial(n - 1);
            }
        }

        private async static Task LetsSayUserClickedAButtonOnGuiMethod()
        {
            var result = await GetTheMagicNumber();
            Console.WriteLine(result);
        }

        private async static Task<int> GetTheMagicNumber()
        {
            return await Task.Run(() => IKnowIGuyWhoKnowsAGuy());
        }

        private async static Task<int> IKnowIGuyWhoKnowsAGuy()
        {
            return await Task.Run(() => IKnowWhoKnowsThis(10)) + await Task.Run(() => IKnowWhoKnowsThis(5));
        }

        private async static Task<int> IKnowWhoKnowsThis(int n)
        {
            return await Task.Run(() => FactorialDigitSum(n));
        }

    }

}