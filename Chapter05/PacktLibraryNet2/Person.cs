namespace Packt.Shared;

public class Person : object
{
    #region Fields: Data or state for this person.
    public string? Name; // ? means it can be null
    public DateTimeOffset Born;
    public WondersOfTheAncientWorld FavoriteAncientWonder;
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
    #endregion
}
