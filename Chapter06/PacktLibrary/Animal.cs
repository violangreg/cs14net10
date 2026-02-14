namespace Packt.Shared;

public class Animal
{
    public event EventHandler? Speak;

    public void MakeSound()
    {
        Speak?.Invoke(this, EventArgs.Empty);
    }
}
