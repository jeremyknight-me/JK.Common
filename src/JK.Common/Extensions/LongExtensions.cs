namespace JK.Common.Extensions;

public static class LongExtensions
{
    extension(long number)
    {
        /// <summary>
        /// Determines whether the specified number is even.
        /// </summary>
        /// <returns><c>true</c> if the number is even; otherwise, <c>false</c>.</returns>
        public bool IsEven => number % 2 == 0;

        /// <summary>
        /// Determines whether the specified number is odd.
        /// </summary>
        /// <returns><c>true</c> if the number is odd; otherwise, <c>false</c>.</returns>
        public bool IsOdd => !number.IsEven;

        /// <summary>
        /// Determines whether the specified number is a prime number.
        /// </summary>
        /// <returns><c>true</c> if the number is prime; otherwise, <c>false</c>.</returns>
        public bool IsPrime()
        {
            switch (number)
            {
                case var n when n < 0:
                    throw new ArgumentOutOfRangeException(nameof(number), "Number must be non-negative.");
                case 0:
                    return false;
                case 1:
                    return false;
                case 2:
                    return true;
                case var n when n.IsEven:
                    return false;
            }

            // Iterates through all odd numbers from 3 up to the calculated boundary to check if the number
            // is divisible by any of them. If a divisor is found, the number is not prime.
            var boundary = Convert.ToInt64(Math.Floor(Math.Sqrt(number)));
            for (long i = 3; i <= boundary; i += 2)
            {
                // Checks if the current divisor divides the number evenly. If so, the number is not prime.
                if (number % i == 0)
                {
                    return false;
                }
            }

            // Returns true if no divisors were found, indicating the number is prime.
            return true;
        }
    }
}
