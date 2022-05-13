using System;
using System.Collections.Generic;

namespace Interface
{
    class Program
    {
        static void Main(string[] args)
        {
            // An interface is not something that you instantiate. It is a contract, that when inherited, requires a class to implement/satisfy that contract.
            // In turn, if you have several related types but want to use them without creating separate implementations of a method or construct for each type,
            // you can instead pass the type that implements the interface, into a parameter that requires the interface.

            // Interfaces really shine when you want to use types that have similar behavior, but because they are distinct types, you can't use them interchangibly.
            // Interfaces provide a means to use them interchangibly

            // Interfaces drive the design principle: composition over inheritance

            #region Example
            // For example: we have a dog, and a robotDog class. 
            Dog dog = new();
            RobotDog robotDog = new();
            Human human = new();

            // Notice this list is of IMakeSound, not the concrete types the dog, robotDog and human are
            foreach (var item in new List<IMakeSound> { dog, robotDog, human })
            {
                // because both dog, human and robotDog implement the IMakeSound interface, we can treat them as the same type as defined by the interface
                // they each may have their own distinct implementation details, but the interface allows us to group them on shared features the classes must implement
                Console.WriteLine(item.MakeSound());
                // When we do this, we loose the non-inteface api for the type, but we can get that back if needed like so
                // But in most scenarios, you likely accept the interface because you only need to execute on the contract it provides
                switch (item)
                {
                    case Dog:
                        (item as Dog).RunAround();
                        break;
                    case RobotDog:
                        (item as RobotDog).PlayFetch();
                        break;
                    default:
                        (item as Human).GoToWork();
                        break;
                }

                /* 
                // same as an if statement
                if (item is Dog)
                {
                    (item as Dog).RunAround();
                }
                else if (item is RobotDog)
                {
                    (item as RobotDog).PlayFetch();
                }
                else
                {
                    (item as Human).GoToWork();
                }
                */
            }

            // Types may inherit multiple interfaces
            // Dog and Human inherit an IMetabolism interface, so they must implement its contract of have a void RegulateTemprature(bool isHot)
            // We can now group them on that interface as well
            List<IMetabolism> metabolisms = new() { new Dog(), new Human() };
            foreach (var metabolismThing in metabolisms)
            {
                metabolismThing.RegulateTemperature(true);
            }

            var you = new Human();
            var robotDogBob = new RobotDog();
            you.TogglePower(robotDogBob);
            you.TogglePower(robotDogBob);
            #endregion

            #region My Experiece with Interfaces
            // In web development, this usually interfaces are an OOP feature that is really helpful for unit testing. Instead of creating a instance of a dependency for a test, you
            // can mock that dependance with an interface, and use the mock instead.
            // So, if you have an http api service library, instead of making the actual library, you can instead mock its signature and immediatly provide data appropriate for your tests 
            #endregion

            // If we examine the Array class, we can see it implements IEnumerable, so anywhere an IEnumerable is required, we can use an array
            // Same with Lists, which implement IEnumerable and ICollection

            // Another value to this is the O in SOLID. Then open/close principal. Code should be open to extension, but closed to modification.
            // Besides are switch that demonstrates getting out contrete type from our itnerface, we did a lot of 'branching' without any if statements. Very powerful

            #region Interface vs Base Class Inheritance
            // A note on interface vs base class inheritance
            // unlike base class inheritance (which we will cover later) interfaces allow us to specify and isolate exactly the state/behavior needed by various types
            // and are able to group them as needed. base class inheritance forces derived classes to inherit state/behavior that may not make sense for the derived type
            // Example: Dog, Cat and Lion are all Animals, but not all are Pets (rocks can be pets)
            // Dog Cat and Lion are Animals, Dog Cat and Rock are Pets
            // Also, a derived class can only inherit one base class
            // The benefit of a base class would be state/behavior we know will be used on all derived classes as it will be shared and can be overided by each derived type
            // For example: a sql table very often will have a Id, and audit columns (CreatedBy, CreatedOn, ModifiedBy, ModifiedOn, IsActive), a base class works well there 
            #endregion
        }

        class Dog : IMakeSound, IMetabolism
        {
            public string Sound { get; set; } = "Woof!";
            public string MakeSound()
            {
                return Sound;
            }

            public void RegulateTemperature(bool isHot)
            {
                if (isHot)
                {
                    Console.WriteLine("Start panting...");
                }
            }

            public void RunAround()
            {
                Console.WriteLine("Dog is running around");
            }
        }

        class RobotDog : IMakeSound, ICanShutDown
        {
            public bool IsOn { get; set; }
            public string Sound { get; set; } = "Bark!";

            public string MakeSound()
            {
                return Sound;
            }
            public void PlayFetch()
            {
                Console.WriteLine("RobotDog is playing fetch");
            }

            public void TogglePower()
            {
                IsOn = !IsOn;
                switch (IsOn)
                {
                    case true:
                        Console.WriteLine("Robot Dog is on!");
                        break;
                    case false:
                        Console.WriteLine("Robot Dog is off!");
                        break;
                }
            }
        }

        class Human : IMakeSound, IMetabolism
        {
            public string Sound { get; set; } = "Hello!";
            public string MakeSound()
            {
                return $"{Sound} Happy {DateTime.Now.DayOfWeek}";
            }
            public void GoToWork()
            {
                Console.WriteLine("Human is going to work");
            }

            public void RegulateTemperature(bool isHot)
            {
                if (isHot)
                {
                    Console.WriteLine("Begin Sweating...");
                }
            }

            public void TogglePower(ICanShutDown canShutDown)
            {
                canShutDown.TogglePower();
            }
        }

        interface IMakeSound
        {
            string Sound { get; set; }
            string MakeSound();
        }

        interface IMetabolism
        {
            void RegulateTemperature(bool isHot);
        }

        interface ICanShutDown
        {
            public void TogglePower();
        }
    }
}
