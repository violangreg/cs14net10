using System.Runtime.CompilerServices;

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

// Exercises
double variable = 10;
WriteLine(variable / 0); // this will not throw an exception because dividing a double by zero results in Infinity

/*
int x = 0;
int y = 0;
x = ++y; // pre-increment: y is incremented first, then assigned to x
x = y++; // post-increment: y is assigned to x first, then y is incremented

for (int i = 0; i < 10; i++)
{
    if (i == 5)
        continue; // skip the rest of the loop when i is 5
    if (i == 8)
        break; // exit the loop when i is 8
    if (i == 3)
        return; // exit the method when i is 3
}

for (int i = 0; i < 10; i++) // initialization (required); condition (required); increment (optional).
{
    WriteLine(i);
}

for (int i = 0; i < 10; )
{
    WriteLine(i);
}

// What is the difference between = and ==
// = is the assignment operator, used to assign a value to a variable
// == is the equality operator, used to compare two values for equality

for (; ; )
    ; // infinite loop because there is no condition to exit
*/
// the _ in a switch statement is the default case that matches anything not explicitly handled by other cases

// An object must implement Enumerable interface to use foreach statement

int x = 3;
int y = 2 + ++x;
WriteLine(y);

x = 3 << 2; // left shift operator, shifts bits to the left, equivalent to multiplying by 2^2 so 0011 becomes 1100 which is 12
WriteLine(x);
y = 10 >> 1; // right shift operator, shifts bits to the right, equivalent to dividing by 2^1 so 1010 becomes 0101 which is 5
WriteLine(y);
x = 10 & 8; // bitwise AND operator, compares each bit of two numbers and returns a new number with bits set to 1 only if both bits are 1, so 1010 & 1000 = 1000 which is 8
WriteLine(x);
y = 10 | 7; // bitwise OR operator, compares each bit of two numbers and returns a new number with bits set to 1 if either bit is 1, so 1010 | 0111 = 1111 which is 15
WriteLine(y);
