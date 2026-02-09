using Dumpify;
using Packt.Shared;
using Spectre.Console.Rendering;
using Fruit = (string Name, int Number);
using UnnamedParameters = (string, int);

ConfigureConsole();
Person bob = new();
WriteLine(bob.ToString());

bob.Name = "Bob Smith";
bob.Born = new DateTimeOffset(
    year: 1965,
    month: 12,
    day: 22,
    hour: 16,
    minute: 28,
    second: 0,
    offset: TimeSpan.FromHours(-5) //US Eastern Standard Time
);
WriteLine(format: "{0} was born on {1:D}.", arg0: bob.Name, arg1: bob.Born);

Person alice = new() { Name = "Alice Jones", Born = new(1998, 3, 7, 16, 28, 0, TimeSpan.Zero) };

WriteLine(format: "{0} was born on {1:d}.", arg0: alice.Name, arg1: alice.Born);

bob.FavoriteAncientWonder = WondersOfTheAncientWorld.StatueOfZeusAtOlympia;
WriteLine(
    format: "{0}'s favorite wonder is {1}. Its integer is {2}.",
    arg0: bob.Name,
    arg1: bob.FavoriteAncientWonder,
    arg2: (int)bob.FavoriteAncientWonder
);

// bob.BucketList =
//     WondersOfTheAncientWorld.HangingGardensOfBabylon
//     | WondersOfTheAncientWorld.MausoleumAtHalicarnassus;
bob.BucketList = (WondersOfTheAncientWorld)18; // similar to above from the byte 0b_0001_0010
WriteLine($"{bob.Name}'s bucket list is {bob.BucketList}.");
WriteLine(
    bob.BucketList.HasFlag(WondersOfTheAncientWorld.StatueOfZeusAtOlympia)
        ? $"{bob.Name} have already visited the {WondersOfTheAncientWorld.StatueOfZeusAtOlympia}."
        : $"{bob.Name} have not yet visited the {WondersOfTheAncientWorld.StatueOfZeusAtOlympia}."
);

Person alfred = new Person();
alfred.Name = "Alfred";
bob.Children.Add(alfred);
bob.Children.Add(new Person { Name = "Bella" });
bob.Children.Add(new() { Name = "Zoe" });
WriteLine($"{bob.Name} has {bob.Children.Count} children:");
foreach (Person child in bob.Children)
{
    WriteLine($"> {child.Name}");
}

BankAccount.InterestRate = 0.012M; // 1.2%
BankAccount jonesAccount = new();
jonesAccount.AccountName = "Jones Checking Account";
jonesAccount.Balance = 2400; // $2,400
WriteLine(
    format: "{0} earned {1:C} interest.",
    arg0: jonesAccount.AccountName,
    arg1: jonesAccount.Balance * BankAccount.InterestRate
);

BankAccount gerrierAccount = new();
gerrierAccount.AccountName = "Gerrier Checking Account";
gerrierAccount.Balance = 98; // $98
WriteLine(
    format: "{0} earned {1:C} interest.",
    arg0: gerrierAccount.AccountName,
    arg1: gerrierAccount.Balance * BankAccount.InterestRate
);

WriteLine($"{bob.Name} is a {Person.Species}.");
WriteLine($"{bob.Name} was born on {bob.HomePlanet}.");
WriteLine($"{alice.Name} was born on {alice.HomePlanet}.");

bob.Dump(label: "Default output");
bob.Dump(
    label: "Include fields and non-public members",
    members: new MembersConfig { IncludeFields = true, IncludeNonPublicMembers = false }
);

/*
// Intantiate a book using object initializer syntax
Book book = new()
{
    Isbn = "978-1803237800",
    Title = "C#14 and .NET 10 - Modern Cross-Platform Development Fundamentals",
};
*/
Book book = new(
    isbn: "978-1803237800",
    title: "C#14 and .NET 10 - Modern Cross-Platform Development Fundamentals"
)
{
    Author = "Mark J. Price",
    PageCount = 821,
};
WriteLine(
    "{0}: {1} written by {2} has {3:N0} pages.",
    book.Isbn,
    book.Title,
    book.Author,
    book.PageCount
);

Person blankPerson = new();
WriteLine(
    format: "{0} of {1} was created at {2:hh:mm:ss} on {2:dddd}.",
    arg0: blankPerson.Name,
    arg1: blankPerson.HomePlanet,
    arg2: blankPerson.Instantiated
);

Person gunny = new(initialName: "Gunny", homePlanet: "Mars");
WriteLine(
    format: "{0} of {1} was created at {2:hh:mm:ss} on {2:dddd}.",
    arg0: gunny.Name,
    arg1: gunny.HomePlanet,
    arg2: gunny.Instantiated
);

bob.WriteToConsole();
WriteLine(bob.GetOrigin());

WriteLine(bob.SayHello());
WriteLine(bob.SayHello("Emily"));

WriteLine(bob.OptionalParameters(3));
WriteLine(bob.OptionalParameters(3, "Jump!", 98.5));

// Naming parameter values when calling methods
WriteLine(bob.OptionalParameters(number: 52.7, command: "Hide!", count: 3));

// Skipping parameters
WriteLine(bob.OptionalParameters(3, "Poke!", active: false));

int a = 10;
int b = 20;
int c = 30;
int d = 40;
WriteLine($"Before: a={a}, b={b}, c={c}, d={d}");
bob.PassingParameters(a, b, ref c, out d);
WriteLine($"After: a={a}, b={b}, c={c}, d={d}");

int e = 50;
int f = 60;
int g = 70;
WriteLine($"Before: e={e}, f={f}, g={g}, h doesn't exist yet!");
bob.PassingParameters(e, f, ref g, out int h);
WriteLine($"After: e={e}, f={f}, g={g}, h={h}");

// params keyword allows a method to accept a variable number of arguments, it must be the last parameter in the method definition
bob.ParamsParameter("Sum using commas", 3, 6, 1, 2);
bob.ParamsParameter("Sum using collection expression", [3, 6, 1, 2]);
bob.ParamsParameter("Sum using explicit array", new int[] { 3, 6, 1, 2 });
bob.ParamsParameter("Sum (empty)");

// using tuples for multiple return values instead of defining a class
(string, int) fruit = bob.GetFruit();
UnnamedParameters fruit2 = bob.GetFruit();
WriteLine($"{fruit.Item1}, {fruit.Item2} there are.");
WriteLine($"{fruit2.Item1}, {fruit2.Item2} there are 2.");

// without an alias tuple
//var fruitNamed = bob.GetNamedFruit(); // we use var to shorten the syntax: (string Name, int Number) fruitNamed = bob.GetNamedFruit();
Fruit fruitNamed = bob.GetNamedFruit(); // Aliasing tuples ^ look at the top of the file
WriteLine($"There are {fruitNamed.Number} {fruitNamed.Name}.");

// tuple name inference
var thing1 = ("Neville", 4);
WriteLine($"{thing1.Item1} has {thing1.Item2} children.");
var thing2 = (bob.Name, bob.Children.Count);
WriteLine($"{thing2.Name} has {thing2.Count} children.");

// deconstructing tuples
(string name, int number) namedFields = bob.GetNamedFruit();
WriteLine($"{namedFields.name}, {namedFields.number}");
(string name, int number) = bob.GetNamedFruit(); // or namedFields
WriteLine($"{name}, {number}");

(string fruitName, int fruitNumber) = bob.GetFruit();
WriteLine($"Deconstructed tuple: {fruitName}, {fruitNumber}");

var (name1, dob1) = bob;
WriteLine($"Deconstructed person: {name1}, {dob1}");
var (name2, dob2, fav2) = bob;
WriteLine($"Deconstructed person: {name2}, {dob2}, {fav2}");

// local function test
int number5 = 5;
try
{
    WriteLine($"{number5}! is {Person.Factorial(number5)}");
}
catch (Exception ex)
{
    WriteLine($"{ex.GetType()} says: {ex.Message} number was {number5}");
}

// using properties
Person sam = new() { Name = "Sam", Born = new(1969, 6, 25, 0, 0, 0, TimeSpan.Zero) };
WriteLine(sam.Origin);
WriteLine(sam.Greeting);
WriteLine(sam.Age);
sam.FavoriteIceCream = "Chocolate Fudge";
WriteLine($"Sam's favorite ice-cream flavor is {sam.FavoriteIceCream}.");
string color = "Orange";
try
{
    sam.FavoritePrimaryColor = color;
    WriteLine($"Sam's favorite primary color is {sam.FavoritePrimaryColor}");
}
catch (Exception ex)
{
    WriteLine(
        "Tried to set {0} to '{1}': {2}",
        nameof(sam.FavoritePrimaryColor),
        color,
        ex.Message
    );
}

//bob.FavoriteAncientWonder =
//    WondersOfTheAncientWorld.StatueOfZeusAtOlympia | WondersOfTheAncientWorld.GreatPyramidOfGiza;
WondersOfTheAncientWorld favWonder = (WondersOfTheAncientWorld)22;
try
{
    bob.FavoriteAncientWonder = favWonder;
    WriteLine("Bob's favorite ancient wonder: {0}", bob.FavoriteAncientWonder);
}
catch (Exception ex)
{
    WriteLine(
        "Tried to set {0} to {1}: {2}",
        nameof(bob.FavoriteAncientWonder),
        favWonder,
        ex.Message
    );
}

//var test12 = ReadLine();

sam.Children.Add(new() { Name = "Charlie", Born = new(2010, 3, 18, 0, 0, 0, TimeSpan.Zero) });
sam.Children.Add(new() { Name = "Ella", Born = new(2020, 12, 24, 0, 0, 0, TimeSpan.Zero) });

// Get using Children list
WriteLine($"Sam's first child is {sam.Children[0].Name}");
WriteLine($"Sam's second child is {sam.Children[1].Name}");

// Get using the indexer
WriteLine($"Sam's first child is {sam[0].Name}");
WriteLine($"Sam's second child is {sam[1].Name}");

// Get using the string indexer
WriteLine($"Sam's child named Ella is {sam["Ella"].Age} years old");

// Pattern match flight passengers
Passenger[] passengers =
{
    new FirstClassPassenger { AirMiles = 1_419, Name = "Suman" },
    new FirstClassPassenger { AirMiles = 16_562, Name = "Lucy" },
    new BusinessClassPassenger { Name = "Janice" },
    new CoachClassPassenger { CarryOnKG = 25.7, Name = "Dave" },
    new CoachClassPassenger { CarryOnKG = 0, Name = "Amit" },
};
foreach (Passenger passenger in passengers)
{
    decimal flightCost = passenger switch
    {
        /* C# 8 syntax
        FirstClassPassenger p when p.AirMiles > 35_000 => 1_500M,
        FirstClassPassenger p when p.AirMiles > 15_000 => 1_750M,
        FirstClassPassenger _ => 2_000M,
        */
        // C# 9 or later syntax
        // FirstClassPassenger p => p.AirMiles switch
        // {
        //     > 35_000 => 1_500M,
        //     > 15_000 => 1_750M,
        //     _ => 2_000M,
        // },
        // Relational pattern with property pattern
        FirstClassPassenger { AirMiles: > 35_000 } => 1500M,
        FirstClassPassenger { AirMiles: > 15_000 } => 1750M,
        FirstClassPassenger => 2000M,
        BusinessClassPassenger _ => 1_000M,
        CoachClassPassenger p when p.CarryOnKG < 10.0 => 500M,
        CoachClassPassenger _ => 650M,
        _ => 800M,
    };
    WriteLine($"Flight costs {flightCost:C} for {passenger}");
}

// Using init keyword in a property, can only be initialize and never be changed afterwards also known as an Immutable object,
// even if intialization is empty, use required keyword to force it to be set
ImmutablePerson jeff = new() { FirstName = "Jeff", LastName = "Winger" };

//jeff.FirstName = "Geoff";

// C# 9, using record keyword on a type
ImmutableVehicle car = new()
{
    Brand = "Mazda MX-5 RF",
    Color = "Soul Red Crystal Metallic",
    Wheels = 4,
};

// mutated copy aka non-destructive mutation
ImmutableVehicle repaintedCar = car with
{
    Color = "Polymetal Gray Metallic",
};
WriteLine($"Original car color was {car.Color}");
WriteLine($"New car color is {repaintedCar.Color}"); // You can release the memory for the car variable and repaintedCar would still fully exist

// Comparing class vs record equality, two records with the same property values are considered equal aka value-based equality
// whereas with class, it is only equal when their memory addresses are equal, meaning they are literally the same object
AnimalClass ac1 = new() { Name = "Rex" };
AnimalClass ac2 = new() { Name = "Rex" };
WriteLine($"ac1 == ac2: {ac1 == ac2}");
AnimalRecord ar1 = new() { Name = "Rex" };
AnimalRecord ar2 = new() { Name = "Rex" };
WriteLine($"ar1 == ar2: {ar1 == ar2}");

// Equality of other types
// Two value type variables
int number1 = 3;
int number2 = 3;
WriteLine($"number1: {number1}, number2: {number2}");
WriteLine($"number1 == number2: {number1 == number2}");

// Two reference type instances
Person p1 = new() { Name = "Kevin" };
Person p2 = new() { Name = "Kevin" };

// This is literally pointing to the same object on the heap,
// this is an exception to string type since the equality operators have been overriden to make them behave as if they were value types
Person p3 = p1;

WriteLine($"p1 == p2: {p1 == p2}");
WriteLine($"p1 == p3: {p1 == p3}"); // so it is True
WriteLine($"p1.Name == p2.Name: {p1.Name == p2.Name}"); // We can also do this for our classes by overriding the equality operator or just use a record class instead

// Using positional record
ImmutableAnimal oscar = new("Oscar", "Labrador");
var (who, what) = oscar;
WriteLine($"{who} is a {what}");

// Primary constructor
Headset vp = new("Apple", "Vision Pro");
WriteLine($"{vp.ProductName} is made by {vp.Manufacturer}");
Headset holo = new();
WriteLine($"{holo.ProductName} is made by {holo.Manufacturer}"); // using the default
Headset mq = new() { Manufacturer = "Meta", ProductName = "Quest3" };
WriteLine($"{mq.ProductName} is made by {mq.Manufacturer}");

// Car fiat = new() { Wheels = 4, IsEV = true };
// fiat.Start();