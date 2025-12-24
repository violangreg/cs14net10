Write("Enter a number between 0 and 255: ");
string number1 = ReadLine()!;
Write("Enter another number between 0 and 255: ");
string number2 = ReadLine()!;

try
{
    byte byte1 = byte.Parse(number1);
    byte byte2 = byte.Parse(number2);
    WriteLine($"{number1} divided by {number2} is {byte1 / byte2}");
}
catch (FormatException)
{
    WriteLine("The format of one of the numbers is invalid.");
}
catch (OverflowException)
{
    WriteLine("One of the numbers is outside the range of a byte (0-255).");
}
catch (DivideByZeroException)
{
    WriteLine("Cannot divide by zero.");
}
catch (Exception ex)
{
    WriteLine($"An error occurred with type {ex.GetType().Name}: {ex.Message}");
}
