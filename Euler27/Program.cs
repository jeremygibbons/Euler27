using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler27
{
    class Program
    {
        static SortedSet<int> primes;
        static SortedSet<int> not_primes;

        static int maxA;
        static int maxB;
        static int maxNumPrimes;

        static void Main(string[] args)
        {
            primes = new SortedSet<int>();
            not_primes = new SortedSet<int>();

            primes.Add(2);
            primes.Add(3);
            primes.Add(5);
            primes.Add(7);
            not_primes.Add(9);

            maxNumPrimes = 0;

            foreach(int a in Enumerable.Range(0, 1000))
            {
                foreach(int b in Enumerable.Range(0, 1000))
                {
                    TestQuadratic(a, b);
                    TestQuadratic(-a, b);
                    TestQuadratic(a, -b);
                    TestQuadratic(-a, -b);

                }
            }

            Console.WriteLine(maxNumPrimes);
            Console.WriteLine(maxA * maxB);
            Console.ReadLine();
        }

        private static void TestQuadratic(int a, int b)
        {
            int n = GetMaxIndexOfConsecutivePrimes(a, b);
            if (n > maxNumPrimes)
            {
                maxA = a;
                maxB = b;
                maxNumPrimes = n;
            }
        }

        static int GetMaxIndexOfConsecutivePrimes(int a, int b)
        {
            int n = 0;
            while (IsPrime(n * n + a * n + b))
                n++;

            return n;
        }

        static bool IsPrime(int n)
        {
            if (n < 0)
                return false;

            if (n == 2)
                return true;

            if (n < 2 || n % 2 == 0)
                return false;

            if (not_primes.Contains(n))
                return false;

            if (primes.Contains(n))
                return true;

            for (int i = 3; i <= (int)Math.Sqrt(n); i += 2)
            {
                if (n % i == 0)
                {
                    not_primes.Add(n);
                    return false;
                }
            }
            primes.Add(n);
            return true;
        }
    }
}
