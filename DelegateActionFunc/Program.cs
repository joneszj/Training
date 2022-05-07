using System;
using System.Collections.Generic;
using System.Linq;

namespace DelegateActionFunc
{
    class Program
    {
        delegate bool GetVerbs(string s);

        static void Main(string[] args)
        {
            // What is a delegate? a delegate is a type-safe function pointer... Which doesn't mean much to us at this point.
            // It may be easier to understand delegates as interfaces for methods
            // If you are familiar with callbacks, you can view deleages as typed callbacks
            // Delegates allout methods to be passed as parameters

            // Funcs and Actions are also delegates
            // The only difference is that Actions do not have a return type

            // Why would we need one? I like to use delagates when was want to provide clarity to a complex method that is passed as a parameter
            // If you have a construct that you would like to provide a callback for that you don't want to hardcode but is type safe.
            // Dom events are analogous here. When the user clicks a button, fire an event with a callback (delegate) but that callback can
            // be of any method. Delegates provide identical architecture and infrastructure for this, but are type safe

            // using LinQ, we are using delegates extensively. Any method that accepts another method as an argument is a delegate
            // .Where(e => e.isActive) is .Where({delegate})
            // .Where does not know, or implement an overload for every possible type that may be passed to it, that is determined by the caller
            // by using a delegate, LinQ encapsulates the 'filtering' of the Where and allows the caller to fill in the details using a delegate

            // https://blog.ploeh.dk/2009/05/28/DelegatesAreAnonymousInterfaces/
            // https://www.pluralsight.com/guides/how-why-to-use-delegates-csharp
            // https://buildplease.com/pages/why-delegates/
            // https://stackoverflow.com/questions/6688775/when-is-useful-to-use-delegate-type-in-a-web-application

            // https://docs.microsoft.com/en-us/previous-versions/visualstudio/visual-studio-2010/ms173173(v=vs.100)?redirectedfrom=MSDN

            /*
             https://softwareengineering.stackexchange.com/questions/114138/delegate-vs-interfaces-any-more-clarifications-available
             This way of doing things is extremely beneficial under the right circumstances. 
             Think about it - why depend on an interface when all you really care about is having an implementation passed to you?
             */

            Console.WriteLine("Hello World!");
        }
    }
}
