using System;

namespace DL.Common.Math
{
    public class MathHelper
    {
        public bool IsPrime(long number)
        {
            long boundary = Convert.ToInt64(System.Math.Floor(System.Math.Sqrt(number)));

            if (number == 1) return false;
            if (number == 2) return true;

            for (long i = 2; i <= boundary; ++i)
            {
                if (number % i == 0) return false;
            }

            return true;
        }
    }
}
