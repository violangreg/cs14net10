using Dumpify;
using Packt.Shared;

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
