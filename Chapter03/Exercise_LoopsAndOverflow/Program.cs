int max = 500;
byte i = 0;
try
{
    checked
    {
        for (i = 0; i < max; i++)
        {
            WriteLine(i);
        }
    }
}
catch (OverflowException)
{
    WriteLine("The code overflowed but I caught the exception.");
    int j = i;
    for (j++; j < max; j++)
    {
        WriteLine(j);
    }
}
catch (Exception ex)
{
    WriteLine($"Unexpected exception: {ex.Message}");
}
// byte is an 8-bit unsigned integer that can hold values from 0 to 255,
// it will never reach max because byte overflows at 255 so when it hits 255 it wraps around to 0 again.
