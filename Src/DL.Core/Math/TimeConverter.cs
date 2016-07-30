namespace DL.Core.Math
{
    /// <summary>
    /// Class which contains time conversion logic.
    /// </summary>
    public static class TimeConverter
    {
        /// <summary>
        /// Converts hours to minutes.
        /// </summary>
        /// <param name="hours">Number of hours to convert.</param>
        /// <returns>Number of minutes in the given number of hours.</returns>
        public static int ConvertHoursToMinutes(int hours)
        {
            checked
            {
                return hours * 60;    
            }
        }

        /// <summary>
        /// Converts minutes to seconds.
        /// </summary>
        /// <param name="minutes">Number of minutes to convert.</param>
        /// <returns>Number of seconds in the given number of minutes.</returns>
        public static int ConvertMinutesToSeconds(int minutes)
        {
            checked
            {
                return minutes * 60;    
            }
        }

        /// <summary>
        /// Converts seconds to milliseconds.
        /// </summary>
        /// <param name="seconds">Number of seconds to convert.</param>
        /// <returns>Number of milliseconds in the given number of seconds.</returns>
        public static int ConvertSecondsToMilliseconds(int seconds)
        {
            checked
            {
                return seconds * 1000;    
            }
        }

        /// <summary>
        /// Converts hours to milliseconds.
        /// </summary>
        /// <param name="hours">Number of hours to convert.</param>
        /// <returns>Number of milliseconds in the given number of hours.</returns>
        public static int ConvertHoursToMilliseconds(int hours)
        {
            int minutes = ConvertHoursToMinutes(hours);
            return ConvertMinutesToMilliseconds(minutes);
        }

        /// <summary>
        /// Converts minutes to milliseconds.
        /// </summary>
        /// <param name="minutes">Number of minutes to convert.</param>
        /// <returns>Number of milliseconds in the given number of minutes.</returns>
        public static int ConvertMinutesToMilliseconds(int minutes)
        {
            int seconds = ConvertMinutesToSeconds(minutes);
            return ConvertSecondsToMilliseconds(seconds);
        }
    }
}
