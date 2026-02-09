namespace Packt.Shared;

class Car
{
    int Wheels { get; set; }
    public bool IsEV { get; set; }

    internal void Start()
    {
        Console.WriteLine("Car started");
    }
}
