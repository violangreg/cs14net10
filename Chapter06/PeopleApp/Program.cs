using Dumpify;
using Packt.Shared;

Person harry = new()
{
    Name = "Harry",
    Born = new DateTimeOffset(
        year: 2001,
        month: 3,
        day: 25,
        hour: 0,
        minute: 0,
        second: 0,
        offset: TimeSpan.Zero
    ),
};
harry.WriteToConsole();

Person lamech = new() { Name = "Lamech" };
Person adah = new() { Name = "Adah" };
Person zillah = new() { Name = "Zillah" };

// Call the instance method
lamech.Marry(adah);

// Call the static method
//Person.Marry(lamech, zillah);
if (lamech + zillah)
{
    WriteLine($"{lamech.Name} is now married to {zillah.Name}.");
}

lamech.OutputSpouses();
adah.OutputSpouses();
zillah.OutputSpouses();

// Call the instance method to make a baby
Person baby1 = lamech.ProcreateWith(adah);
baby1.Name = "Jabal";
WriteLine($"{baby1.Name} was born on {baby1.Born}.");

// Call the static method to make a baby
Person baby2 = Person.Procreate(zillah, lamech);
baby2.Name = "Tubalcain";

Person baby3 = lamech * adah;
baby3.Name = "Jubal";
Person baby4 = zillah * lamech;
baby4.Name = "Naamah";

adah.WriteChildrenToConsole();
zillah.WriteChildrenToConsole();
lamech.WriteChildrenToConsole();

for (int i = 0; i < lamech.Children.Count; i++)
{
    WriteLine(
        format: "{0}'s child #{1} is named \"{2}\".",
        arg0: lamech.Name,
        arg1: i,
        arg2: lamech.Children[i].Name
    );
}

//lamech.Dump();

// non-generic types
System.Collections.Hashtable lookupObject = new();
lookupObject.Add(key: 1, value: "Alpha");
lookupObject.Add(key: 2, value: "Beta");
lookupObject.Add(key: 3, value: "Gamma");
lookupObject.Add(key: harry, value: "Delta");

int key = 2;
WriteLine(format: "Key {0} has value \"{1}\".", arg0: harry, arg1: lookupObject[harry]);

// generic types
Dictionary<int, string> lookupIntString = new();
lookupIntString.Add(key: 1, value: "Alpha");
lookupIntString.Add(key: 2, value: "Beta");
lookupIntString.Add(key: 3, value: "Gamma");
lookupIntString.Add(key: 4, value: "Delta");

key = 3;
WriteLine(format: "Key {0} has value \"{1}\".", arg0: key, arg1: lookupIntString[key]);

// Assign the method to the Shout event delegate
harry.Shout += Harry_Shout;
harry.Shout += Harry_Shout_2;
harry.Poke();
harry.Poke();
harry.Poke();
harry.Poke();

Person?[] people =
{
    null,
    new() { Name = "Simon" },
    new() { Name = "Jenny" },
    new() { Name = "Adam" },
    new() { Name = null },
    new() { Name = "Richard" },
};

OutputPeopleNames(people, "Initial list of people:");
Array.Sort(people);
OutputPeopleNames(people, "After sorting people by name:");

DisplacementVector dv1 = new(3, 5);
DisplacementVector dv2 = new(-2, 7);
DisplacementVector dv3 = dv1 + dv2;
WriteLine($"({dv1.X}, {dv1.Y}) + ({dv2.X}, {dv2.Y}) = ({dv3.X}, {dv3.Y})");

DisplacementVector dv4 = new();
WriteLine($"({dv4.X}, {dv4.Y})");

DisplacementVector dv5 = new(3, 5);
WriteLine($"dv1.Equals(dv5): {dv1.Equals(dv5)})");
WriteLine($"dv1 == dv5: {dv1 == dv5})");

Employee john = new()
{
    Name = "John Jones",
    Born = new(year: 1990, month: 7, day: 28, hour: 0, minute: 0, second: 0, offset: TimeSpan.Zero),
};
john.WriteToConsole();
john.EmployeeCode = "JJ001";
john.HiredDate = new(year: 2014, month: 11, day: 23);
WriteLine($"{john.Name} was hired on {john.HiredDate:yyyy-MM-dd}.");
WriteLine(john.ToString());

Employee aliceInEmployee = new() { Name = "Alice", EmployeeCode = "AA123" };
Person aliceInPerson = aliceInEmployee; // upcast Employee to Person
aliceInEmployee.WriteToConsole();
aliceInPerson.WriteToConsole();
WriteLine(aliceInEmployee.ToString());
WriteLine(aliceInPerson.ToString());

// Can have runtime error if you try to cast to the wrong type
Employee explicitAlice = (Employee)aliceInPerson;

if (aliceInPerson is Employee)
{
    WriteLine($"{nameof(aliceInPerson)} is an Employee");
    // Safely cast
    Employee safeAlice = (Employee)aliceInPerson;
}

// declaration pattern
if (aliceInPerson is Employee safeAlice2)
{
    WriteLine($"{nameof(aliceInPerson)} is an Employee");
    safeAlice2.WriteToConsole();
}

if (aliceInPerson is not Employee)
{
    WriteLine($"{nameof(aliceInPerson)} is not an Employee");
}

// Using the as operator to safely cast
Employee? aliceAsEmployee = aliceInPerson as Employee;
if (aliceAsEmployee is not null)
{
    WriteLine($"{nameof(aliceInPerson)} is an Employee");
    aliceAsEmployee.WriteToConsole();
}

try
{
    john.TimeTravel(when: new(1999, 12, 31));
    john.TimeTravel(when: new(1950, 12, 25));
}
catch (PersonException ex)
{
    WriteLine($"Time travel failed: {ex.Message}");
}

string email1 = "pamela@test.com";
string email2 = "ian&test.com";
WriteLine(format: "{0} is a valid email address: {1}", arg0: email1, arg1: email1.IsValidEmail());
WriteLine(format: "{0} is a valid email address: {1}", arg0: email2, arg1: email2.IsValidEmail());

WriteLine($"{john.Name}'s birthday is {john.Born:yyyy-MM-dd}");
john.GetOlder().ChangeName("Jonathan");
WriteLine($"{john.Name}'s birthday is {john.Born:yyyy-MM-dd}");

Person greg = new Person()
    .SetName("Greg")
    .SetBirthDate(
        new(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, offset: TimeSpan.Zero)
    );

greg.WriteToConsole();


// extension methods are used to add methods to existing types without modifying the original type, and they can be used with method chaining to create fluent interfaces.
// you can also use it to extend static types
var height = greg.SetHeight(185).IsTall();
WriteLine($"{greg.Name} is tall: {greg.IsTall()}");
var s = "asdasd@asd".IsValidEmail();
WriteLine(s);

Animal dog = new();
dog.Speak += Dog_Speak;
dog.MakeSound();
