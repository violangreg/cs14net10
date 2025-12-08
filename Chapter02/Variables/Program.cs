using System.Drawing;
using System.Dynamic;
using System.Xml;

#region Boolean type - only true or false
bool isCSharpFun = true;
bool isFishTasty = false;
#endregion

#region Object type
// The object type can hold any data type, it is the base type for all data types in C#
object height = 1.88; // in meters
object name = "Amir";
System.Console.WriteLine($"{name} is {height} meters tall.");

//int length1 = name.Length; // gives compiler error: 'object' does not contain a definition for 'Length'
int length2 = ((string)name).Length; // cast to string first
System.Console.WriteLine($"{name} has {length2} characters.");
#endregion

#region Dynamic type
dynamic something;
something = new[] { 1, 2, 3 };

//something = 12;
//something = "A string instead";
System.Console.WriteLine($"The length of something is {something.Length}"); // resolved at runtime, no compile-time checking, may cause runtime errors if the member does not exist
System.Console.WriteLine($"Something is a {something.GetType()}");

// A limitation of dynamic is that IDEs cannot provide IntelliSense or compile-time type checking for dynamic types, which can lead to runtime errors if the expected members do not exist on the actual object assigned to the dynamic variable.
// Instead the CLR checks for the member at runtime and throws an exception if it is missing.
// Dynamic types are useful when dealing with data from external sources or interoperating with other non-.NET systems like JSON, XML, or COM objects where the structure may not be known at compile time or other language class libraries like F#, Python, JavaScript.

#region ExpandoObject
dynamic person = new ExpandoObject();
person.Name = "Alice";
person.LastName = "Smith";
person.Age = 30;
System.Console.WriteLine($"{person.Name} {person.LastName} is {person.Age} years old.");
var dictionary = (IDictionary<string, object>)person;
foreach (var item in dictionary)
{
    System.Console.WriteLine($"{item.Key} = {item.Value}");
}
// you can find more info: https://learn.microsoft.com/en-us/dotnet/fundamentals/runtime-libraries/system-dynamic-expandoobject
#endregion

#endregion

#region Declaring local variables
// local variables declared inside a method exist only within the method scope. Once the method execution is complete, the local variables are destroyed and their memory is released by the garbage collector.
// Note: Value types are released immediately when they go out of scope, while reference types are eligible for garbage collection when there are no more references to them.
var myName = "Bob"; // implicitly typed local variable, type inferred by the compiler as string

// myName = 42; // gives compiler error: cannot implicitly convert type 'int' to 'string'

#region Specifying the type of a local variable
string myCity = "New York"; // explicitly typed local variable
int myAge = 25; // explicitly typed local variable
double myHeight = 5.9; // explicitly typed local variable
char myInitial = 'B'; // explicitly typed local variable
bool isStudent = false; // explicitly typed local variable
decimal myBalance = 1234.56M; // explicitly typed local variable
#endregion

#region Inferring the type of a local variable
var myCountry = "USA"; // implicitly typed local variable, type inferred by the compiler as string
var myZipCode = 10001; // implicitly typed local variable, type inferred by the compiler as int
var myGPA = 3.75; // implicitly typed local variable, type inferred by the compiler as double
var myGrade = 'A'; // implicitly typed local variable, type inferred by the compiler as char
var isEmployed = true; // implicitly typed local variable, type inferred by the compiler as bool
var mySalary = 55000.50M; // implicitly typed local variable, type inferred by the compiler as decimal

// int variables inferred with a suffix
// L - long, U - unsigned, UL - unsigned long, F - float, M - decimal, D - double
var bigNumber = 12345678901234L; // long
var unsignedNumber = 1234567890U; // unsigned int
var bigUnsignedNumber = 12345678901234567890UL; // unsigned long
var floatNumber = 3.14F; // float
var decimalNumber = 19.99M; // decimal
var doubleNumber = 2.71828D; // double

// A literal number with decimal point is inferred as double by default otherwise you need to use the M suffix for Decimal and F suffix for Float
var defaultDouble = 1.618; // double

// Double " infers as string
var doubleQuoteString = "She said, \"Hello!\"";

// Char ' infers as char
var singleQuoteChar = 'A';

// True or false infers as bool
var isAvailable = true; // bool
#endregion

#region Value and reference types
// Value types store data directly in their own memory space. Examples: int, double, bool, char, struct, enum -- held on the stack (memory allocated at compile time)
// Reference types store a reference (memory address) to the actual data. Examples: string, array, class, interface, delegate -- held on the heap (dynamically allocated memory at runtime)
short age; // allocates 2 bytes on the stack to store a System.Int16 value
long population; // allocates 8 bytes on the stack to store a System.Int64 value
DateTime birthdate; // allocates 8 bytes on the stack to store a System.DateTime value
Point location; // allocates 8 bytes on the stack to store a System.Drawing.Point struct value
Person bob; // allocates 4 or 8 bytes (depending on 32-bit or 64-bit system) on the stack to store a reference to a Person object on the heap

age = 45; // initializes this variable to 45 using a literal value
population = 8_000_000_000; // initializes this variable to 8 billion using a literal value
birthdate = new(1995, 2, 23);
location = new(10, 20);
bob = new(); // Allocates memory on the heap for a new Person object. Any state will have default values. bob is no longer null
bob = new("Bob", "Smith", 45); // creates a new Person object on the heap and assigns its reference in the stack to the bob variable

// Old syntax with explicit type:
bob = new Person();
bob = new Person("Bob", "Smith", 45);

// C# 9 or later - target-typed new to instantiate objects without repeating the type name
XmlDocument xmlDoc = new();

// Getting and setting the default values for types
Console.WriteLine($"Default value of int: {default(int)}");
System.Console.WriteLine($"default(bool): {default(bool)}");
System.Console.WriteLine($"default(DateTime): {default(DateTime)}");
System.Console.WriteLine($"default(string): {default(string) ?? "<NULL>"}");

#endregion


#endregion

var xml1 = new XmlDocument(); // Works with C# 3 and later
XmlDocument xml2 = new XmlDocument(); // Works with all C# versions
var file1 = File.CreateText("test1.txt"); // Bad use of var because we cannot tell the type without hovering over the var
StreamWriter file2 = File.CreateText("test2.txt"); // Better to explicitly state the type for readability

// var is converted to the specific type at compile time, so there is no runtime overhead compared to explicitly typed variables.
// var is different from dynamic, which is resolved at runtime and can lead to runtime errors if the expected members do not exist on the actual object assigned to the dynamic variable.

class Person
{
    public string FirstName;
    public string LastName;
    public int Age;

    public Person() // default constructor
    {
        FirstName = "John";
        LastName = "Doe";
        Age = 30;
    }

    public Person(string firstName, string lastName, int age) // parameterized constructor
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }
}
