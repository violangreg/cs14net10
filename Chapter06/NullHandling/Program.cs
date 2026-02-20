using Packt.Shared;

int thisCannotBeNull = 4;

//thisCannotBeNull = null; // compile-time error: CS0037: Cannot convert null to 'int' because it is a non-nullable value type
WriteLine(thisCannotBeNull);
int? thisCouldBeNull = null; // nullable int can be null
WriteLine(thisCouldBeNull);
WriteLine(thisCouldBeNull.GetValueOrDefault());
thisCouldBeNull = 7;
WriteLine(thisCouldBeNull);
WriteLine(thisCouldBeNull.GetValueOrDefault());

Nullable<int> thisCouldAlsoBeNull = null; // same as int?
thisCouldAlsoBeNull = 9;
WriteLine(thisCouldAlsoBeNull);

Address address = new(city: "London")
{
    Building = null,
    Street = null!,
    Region = "UK",
};

WriteLine(address.Building?.Length);
if (address.Street is not null)
{
    WriteLine(address.Street.Length);
}
