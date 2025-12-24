// FizzBuzz: Write a program that prints the numbers from 1 to max. But for multiples of three print "Fizz" instead of the number and for the multiples of five print "Buzz". For numbers which are multiples of both three and five print "FizzBuzz".
int max = 321;
for (int i = 1; i <= max; i++)
{
    if (i % 3 == 0 && i % 5 == 0)
    {
        Write("FizzBuzz");
    }
    else if (i % 5 == 0)
    {
        Write("Buzz");
    }
    else if (i % 3 == 0)
    {
        Write("Fizz");
    }
    else
    {
        Write(i);
    }

    // put a comma and space after every number except max
    if (i < max)
        Write(", ");
    // new line after every 20 numbers
    if (i % 20 == 0)
        WriteLine();
}
