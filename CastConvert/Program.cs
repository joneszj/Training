using System;

namespace CastConvert
{
    class Program
    {
        static void Main(string[] args)
        {
            // Where parsing attempts to extract a value and type from a string, cast and convert are similar, but don't require a string
            // So, parsing is really used against strings
            // https://exceptionnotfound.net/csharp-in-simple-terms-3-casting-conversion-parsing-is-as-and-typeof/
            // https://stackoverflow.com/a/15395832/3700826

            #region Cast
            // Casting will attempt to force one type into another
            // Usually best when you know what both types are
            // typeA = (castType)typeB
            // In my experience, I usually only ever cast enum values to ints, but casting works for other types as well

            int myNumber = 10;
            var myFloat = (float)myNumber;
            Console.WriteLine($"myFloat: {myFloat}");

            // Warning, casting can loose precision
            // from link above
            decimal myMoney = 5.87M;
            int intMoney = (int)myMoney; //Value is now 5; the .87 was lost
            Console.WriteLine($"intMoney: {intMoney}");

            // Ex of casting an enum
            var myEnumValue = (int)DaysofWeek.Saturday;
            Console.WriteLine(myEnumValue);
            #endregion

            #region Convert
            // Conversions are performed on the static Convert class
            // Convert is a bit more expensive than cast, but both have their nuances (see the link above)
            var convertedInt = Convert.ToInt32("123");
            var convertedBool = Convert.ToBoolean(1);
            // One cannot convert an enum value to an int, it basically provides conversion for base data types
            #endregion

            #region Practice
            // TODO: ideas to reinforce cast/convert functionality
            #endregion
        }
    }

    enum DaysofWeek
    {
        Sunday = 0,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday
    }
}
