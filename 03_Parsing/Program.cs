﻿using System;

namespace _03_Parsing
{
    class Program
    {
        static void Main(string[] args)
        {
            // Pasring is simply a means of extracting a value of a non-string type, from a string

            #region Parse
            var parseAsInt = int.Parse("12345");
            // ^ parseAsInt will be an int of 12345
            var parseAsBool = bool.Parse("true");
            // ^ parseAsInt will be a bool of true
            var parseAsFloat = float.Parse("132.14");
            // ^ parseAsInt will be a float of 132.14
            var parseAsChar = char.Parse("T");

            // If a normal parse fails to parse, it will throw an exception
            // var thisWillThrow = int.Parse("ABKDFJH#$#2NF4325464"); <- this is obviously not an int, and Parse will throw trying to parse the string as an int
            // This is why we have, and generally use, TryParse
            #endregion

            #region TryParse
            // TryParse will do 2 things:
            // 1 return a bool if the parse was successful
            // 2 out a variable if the parse was successful
            // It requires 2 arguments:
            // 1 the string to parse
            // 2 the out variable that will have the parsed value
            var tryParseAsInt = int.TryParse("12345", out var parsedInt);
            if (tryParseAsInt)
            {
                // if tryParseAsInt is true, we know that parsedInt will have our parsed value
                Console.WriteLine(parsedInt * 2);
            }
            var tryParseAsBool = int.TryParse("true", out var parsedBool);
            if (tryParseAsBool)
            {
                // if tryParseAsInt is true, we know that parsedInt will have our parsed value
                Console.WriteLine($"parsedBool is {parsedBool}");
            }
            // TryParse can even reassign an existing variable, instead of creating a new variable
            // You just need to drop the 'var' keyword
            var tryParseAsFloat = float.TryParse("132.14", out parseAsFloat);
            if (tryParseAsFloat)
            {
                // if tryParseAsInt is true, we know that parseAsFloat will have our parsed value
                Console.WriteLine($"parseAsFloat is {parseAsFloat + 100}");
            }
            // Since TryParse returns a string, we can simplify our if condition a bit
            if (char.TryParse("T", out var letter))
            {
                // We know that letter will be the char 'T'
            }

            // Manual parsing hasn't been super common for me. Most frameworks will deserialize incoming strings into the type they belong to
            // However, for Console applicaitons, all we has is the user input string or char, so parsing happens more frequently
            #endregion
        }
    }
}
