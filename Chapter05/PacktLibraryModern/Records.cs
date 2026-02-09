namespace Packt.Shared;

public class ImmutablePerson
{
    public required string? FirstName { get; init; }
    public string? LastName { get; init; }
}

public record ImmutableVehicle
{
    public int Wheels { get; init; }
    public string? Color { get; init; }
    public string? Brand { get; init; }
}

// Simpler syntax to define a record that auto-generates the properties, constructor and deconstructor aka positional records
public record ImmutableAnimal(string Name, string Species);
