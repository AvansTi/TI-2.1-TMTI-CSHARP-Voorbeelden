using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    public class Calculate
    {

        public int lastNumber = 0;
        public int Fibonacci(int n) {
            if (n >= 47)
                throw new
                    OverflowException("Fibonacci with interger datatype is limited to n <= 47");

            if (n < 0)
                throw new ArgumentException("N >= 0");

            int a = 0;
            int b = 1;
            // In N steps compute Fibonacci sequence iteratively.
            for (int i = 0; i < n; i++) {
                int temp = a;
                a = b;
                b = temp + b;
            }

            lastNumber = a;
            return a;

        }
    }
    class Program
    {
        static void Main(string[] args)
        {

        }


        
    }
}
