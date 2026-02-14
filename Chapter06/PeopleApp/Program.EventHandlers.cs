using Packt.Shared;

partial class Program
{
    private static void Harry_Shout(object? sender, EventArgs e)
    {
        // if no sender then do nothing
        if (sender is null)
            return;

        // if sender is not a Person then do nothing, otherwise assign sender to Person p
        if (sender is not Person p)
            return;

        WriteLine($"{p.Name} is this angry: {p.AngerLevel}!");
    }

    private static void Harry_Shout_2(object? sender, EventArgs e)
    {
        WriteLine("Stop it!");
    }

    private static void Dog_Speak(object? sender, EventArgs e)
    {
        if (sender is null)
            return;

        if (sender is not Animal)
            return;

        WriteLine("The dog says: Ruff!");
    }
}
