using System.Globalization;

CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
int numberOfApples = 12;
decimal pricePerApple = 0.35M;
WriteLine(
    format: "{0} apples cost {1:C}",
    arg0: numberOfApples,
    arg1: numberOfApples * pricePerApple
);
string formatted = string.Format(
    format: "{0} applesX cost {1:C}",
    arg0: numberOfApples,
    arg1: numberOfApples * pricePerApple
);
WriteLine(formatted);
WriteLine(format: formatted);

// 3 parameter values can use named arguments
WriteLine("{0} {1} lived in {2}.", arg0: "Bob", arg1: "Smith", arg2: "New York");

// 4+ parameter values cannot use named arguments
WriteLine("{0} {1} is {2} years old and lives in {3}.", "Alice", "Johnson", 30, "Los Angeles");

// Good practice is to skip the named arguments once you are familiar with the order of parameters

#region Formatting using interpolated strings
// C# 11 or later we can include line break in the middle of the expression but not in the string text
WriteLine($"{numberOfApples} apples cost {numberOfApples 
* pricePerApple:C}");

#endregion

#region Alignment in formatting / format strings
string applesText = "Apples";
string bananasText = "Bananas";
int apples = 1234;
int bananas = 56789;
WriteLine(format: "{0,-10} {1,6:N0}", arg0: "Item", arg1: "Quantity");
WriteLine(format: "{0,-10} {1,6:N0}", arg0: applesText, arg1: apples);
WriteLine(format: "{0,-10} {1,6:N0}", arg0: bananasText, arg1: bananas);
#endregion

WriteLine($"{123:0000.00}");

// for more formats: https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-numeric-format-strings and https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings

WriteLine("Enter your first name and PRESS ENTER:");
string? firstName = ReadLine(); // nullable string, we expect that string can be null, up to us to handle it
WriteLine("Enter your age and PRESS ENTER:");
string age = ReadLine()!; // using null-forgiving operator ! to suppress nullable warning, it is up to us ensure it is not null
WriteLine($"Hello {firstName}, you look good for {age}.");
