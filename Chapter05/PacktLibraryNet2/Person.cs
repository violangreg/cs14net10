namespace Packt.Shared;

public partial class Person : object
{
    #region Fields: Data or state for this person.
    public string? Name; // ? means it can be null
    public DateTimeOffset Born;
    // This has been moved to PersonAutoGen.cs as a property.
    //public WondersOfTheAncientWorld FavoriteAncientWonder;
    public WondersOfTheAncientWorld BucketList;
    public List<Person> Children = new();

    // A constant field, meaning a value of a field that will never be changed and is shared among the class type for all instances of this object
    // const are set on compile time and if its been changed in the future, all assemblies need to be rebuilt to reflect the new value
    public const string Species = "Homo Sapiens";

    // A readonly field, similar to a constant field but it can be calculated or loaded during run-time and is a live reference
    // thereby it will correctly reflect the new value
    // so Read-only fields: Values that can be set at runtime.
    public readonly string HomePlanet = "Earth";
    private readonly string? Secret = "12345";
    public readonly DateTime Instantiated;

    #region Constructors: called when using new to instantiate a type
    public Person()
    {
        Name = "Unknown";
        Instantiated = DateTime.Now;
    }

    public Person(string initialName, string homePlanet)
    {
        Name = initialName;
        HomePlanet = homePlanet;
        Instantiated = DateTime.Now;
    }
    #endregion Constructors

    #region Deconstructors
    public void Deconstruct(out string? name, out DateTimeOffset dob)
    {
        name = Name;
        dob = Born;
    }

    public void Deconstruct(
        out string? name,
        out DateTimeOffset dob,
        out WondersOfTheAncientWorld fav
    )
    {
        name = Name;
        dob = Born;
        fav = FavoriteAncientWonder;
    }
    #endregion Deconstructors

    #region Methods: Actions the type can perform.
    public void WriteToConsole()
    {
        WriteLine($"{Name} was born on a {Born:dddd}");
    }

    public string GetOrigin()
    {
        return $"{Name} was born on {HomePlanet}";
    }

    public string SayHello()
    {
        return $"{Name} says 'Hello!'";
    }

    public string SayHello(string name)
    {
        return $"{Name} says 'Hello, {name}!'";
    }

    public string OptionalParameters(
        int count,
        string command = "Run!",
        double number = 0.0,
        bool active = true
    )
    {
        return string.Format(
            format: "command is {0}, number is {1}, active is {2}",
            arg0: command,
            arg1: number,
            arg2: active
        );
    }

    // Passing parameters by value, by reference but read-only using in, by reference using ref, and as output parameters using out
    public void PassingParameters(int w, in int x, ref int y, out int z)
    {
        // out parameters cannot have a default value and must be assigned in the method
        z = 100;

        // Increment each parameter except the read-only x
        w++;
        //x++; // this would cause a compile error
        y++;
        z++;
        WriteLine($"Inside method: w={w}, x={x}, y={y}, z={z}");
    }

    // Using the params keyword to specify a method parameter that takes a variable number of arguments
    public void ParamsParameter(string text, params int[] numbers)
    {
        int total = 0;
        foreach (int number in numbers)
        {
            total += number;
        }
        WriteLine($"{text}: {total}");
    }

    // defining a method that returns a tuple with default names of Item1 and Item2
    public (string, int) GetFruit()
    {
        return ("Apples", 5);
    }

    public (string Name, int Number) GetNamedFruit()
    {
        return (Name: "Apples", Number: 5);
    }

    // local functions
    public static int Factorial(int number)
    {
        if (number < 0)
        {
            throw new ArgumentException($"{nameof(number)} cannot be less than zero.");
        }

        return localFactorial(number);

        int localFactorial(int localNumber) // local function
        {
            if (localNumber == 0)
                return 1;
            return localNumber * localFactorial(localNumber - 1);
        }
    }
    #endregion Methods
    #endregion
}
