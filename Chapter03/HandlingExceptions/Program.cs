using HandlingExceptions;

#region Handling exceptions with try-catch, exception type has a certain order, build compiler will let you know
WriteLine("Before parsing");
Write("What is your age? ");
string? input = ReadLine();
try
{
    uint age = uint.Parse(input!);
    WriteLine($"You are {age} years old.");
}
catch (OverflowException)
{
    WriteLine("Your age is a valid number format but it is either too big or too small.");
}
catch (FormatException)
{
    WriteLine("The age you entered is not a valid number format.");
}
catch (Exception ex)
{
    WriteLine($"{ex.GetType()} says: {ex.Message}");
}
WriteLine("After parsing");
#endregion

#region Using exception filters to provide more specific error messages
Write("Enter an amount: ");
string amount = ReadLine()!;
if (string.IsNullOrEmpty(amount))
    return;
try
{
    decimal amountValue = decimal.Parse(amount);
    WriteLine($"Amount formatted as currency: {amountValue:C}");
}
catch (FormatException) when (amount.Contains('$')) // exception filter
{
    WriteLine("Amounts cannot use the dollar sign!");
}
catch (FormatException)
{
    WriteLine("Amount must only contain digits!");
}
#endregion

#region checked statement to catch arithmetic overflow exceptions instead of letting it happen silently
// checked
// {
//     int x = int.MaxValue - 1;
//     WriteLine($"Initial value: {x}");
//     x++;
//     WriteLine($"After incrementing: {x}");
//     x++;
//     WriteLine($"After incrementing: {x}");
//     x++;
//     WriteLine($"After incrementing: {x}");
// }

try
{
    checked // will cause an exception when overflow occurs at runtime, so we can catch it
    {
        int x = int.MaxValue - 1;
        WriteLine($"Initial value: {x}");
        x++;
        WriteLine($"After incrementing: {x}");
        x++;
        WriteLine($"After incrementing: {x}");
        x++;
        WriteLine($"After incrementing: {x}");
    }
}
catch (OverflowException)
{
    WriteLine("The code overflowed but I caught the exception.");
}

#endregion

#region unchecked statement to disable arithmetic overflow exceptions
unchecked
{
    int y = int.MaxValue + 1; // this will have compile time error because it will overflow but with unchecked it will compile
    WriteLine($"Initial value: {y}");
    y--;
    WriteLine($"After decrementing: {y}");
    y--;
    WriteLine($"After decrementing: {y}");
    y--;
    WriteLine($"After decrementing: {y}");
}

#endregion

#region Using the Result Type pattern: Creating a ParseAge method that returns a Result<T> type instead of using exceptions for control flow
Write("Enter your age: ");
string userInput = ReadLine()!;
var result = ParseAge(userInput);

if (result.IsSuccess)
{
    WriteLine($"Valid age: {result.Value}");
}
else
{
    WriteLine($"Error: {result.ErrorMessage}");
}

Result<int> ParseAge(string input)
{
    if (string.IsNullOrWhiteSpace(input))
        return Result<int>.Failure("Age cannot be empty.");

    if (!int.TryParse(input, out int age))
        return Result<int>.Failure("Age must be a valid number.");

    if (age < 0 || age > 130)
        return Result<int>.Failure("Age must be between 0 and 130.");

    return Result<int>.Success(age);
}
#endregion
