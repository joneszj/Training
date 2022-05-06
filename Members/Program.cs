using System;

namespace Members
{
    class Program
    {
        static void Main(string[] args)
        {
            // https://docs.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/program-building-blocks
            // A member is a general term refering to any thing that is on a class

            #region Static vs Instance
            // Members may be static or instanced
            // static members are called on the class, and any static state is shared among all instance of the class
            // non-static members are on instances of the class, and their state is isolated to the instance
            // non-static members have access to static members, but not the other way around  
            #endregion

            #region Common Members
            // fields - state on a class
                // fields may be marked 'readonly' meaning the value can only be set at declaration or in a constructor
            // properties - state on a class, is a getter setter wrapper of a field
                // auto-properties (most common form, also called properties) - state on a class, is a getter setter wrapper of a field, and the field is automatically hidden
                // properties can be made readonly, or write only by ommiting the setter or the getter respectively
                // properties are an example/implementation of the encapsulation OOP principle: https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/tutorials/oop
            // methods - execute code blocks
            // constructors - execute when a class object is instantiated, and for parameters to be supplied that are required for the object to function properly
            #endregion

            #region Accessibility
            // Members have accessibility values controlling where they can be accessed: https://docs.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/program-building-blocks#accessibility
            // By default, without any accessibility modifier, members are internal (only visible to the other entities/classes in the assembly)
            // Most access modifiers in my experience have been using public or private
            // public means there is no restriction, private means the member is only accessible to the class they are defined on 
            #endregion
        }

        class MyClass
        {
            // A default constructor (ctor + tab + tab)
            public MyClass()
            {

            }

            // A constructor with a required paremeter
            public MyClass(int fieldNumber)
            {
                // set this instances myField
                myReadOnlyField = fieldNumber;
            }

            // A field
            int myField;

            // A readonly field, value can only be set at declaration or in a constructor
            readonly int myReadOnlyField;

            // A full-property (or just property)
            private int myProperty;
            public int MyProperty { get => myProperty; set => myProperty = value; }
            
            // An auto-property (or just property) (prop + tab + tab)
            public int MyProperty2 { get; set; }

            // A method that has 0 parameters and returns nothing
            void DoSomething()
            {

            }

            // A method that has 2 int parameters and returns an int
            int Sum(int num1, int num2)
            {
                return num1 + num2;
            }

            int SumWithStatic(int num1, int num2)
            {
                // non-static members have access to static members
                return num1 + num2 + MyStaticProperty;
            }

            // A static property, its value is on the class, not instances
            static int MyStaticProperty { get; set; } = 10;

            // A static method that has 0 parameters and returns nothing
            // Static methods are useful when you want to perform an operation related to the class, but requires no instanced state
            static void StaticDoSomething()
            {
                // static methods cannot use any member on the class that is not static, but has access to static members
            }
        }
    }
}
