#region Exploring unary operators
using System.Security.Principal;

int a = 3;
int b = a++;
WriteLine($"a is {a}, b is {b}"); // b is 3 because a is assigned to b before the increment which is known as post-increment

int c = 3;
int d = ++c;
WriteLine($"c is {c}, d is {d}"); // d is 4 because c is incremented before the assignment which is known as pre-increment
#endregion

#region Exploring binary operators
int e = 11;
int f = 3;
WriteLine("");
WriteLine($"e is {e}, f is {f}");
WriteLine($"e + f = {e + f}");
WriteLine($"e - f = {e - f}");
WriteLine($"e * f = {e * f}");
WriteLine($"e / f = {e / f}");
WriteLine($"e % f = {e % f}"); // modulus operator gives the remainder

WriteLine("");
double g = 11.0;
WriteLine($"g is {g:N1}, f is {f}");
WriteLine($"g / f = {g / f}"); // results in a double
#endregion

#region Assignment operators
int r = 6;
r += 3; // equivalent to r = r + 3
r -= 3; // equivalent to r = r - 3
r *= 3; // equivalent to r = r * 3
r /= 3; // equivalent to r = r / 3
r %= 3; // equivalent to r = r % 3
#endregion

#region Null-coalescing operator
string? authorName = GetAuthorName(); // Nullable variable (?): For example, "Mark" or null
int maxLength = authorName?.Length ?? 30; //  Null-conditional operator (.?) and Null-coalescing operator (??): if authorName is null, use 30 as default length
authorName ??= "unknown"; // Null-coalescing assignment operator (??=): if authorName is null, assign "unknown"
#endregion

#region Exploring logical operators
Table table = new();
bool p = true;
bool q = false;
table.AddColumn(new TableColumn("AND (&)"));
table.AddColumn(new TableColumn("p"));
table.AddColumn(new TableColumn("q"));
table.AddRow("p", $"{p & p}", $"{p & q}");
table.AddRow("q", $"{q & p}", $"{q & q}");
AnsiConsole.Write(table);

Table table2 = new();
table2.AddColumn(new TableColumn("OR (|)"));
table2.AddColumn(new TableColumn("p"));
table2.AddColumn(new TableColumn("q"));
table2.AddRow("p", $"{p | p}", $"{p | q}");
table2.AddRow("q", $"{q | p}", $"{q | q}");
AnsiConsole.Write(table2);

Table table3 = new();
table3.AddColumn(new TableColumn("XOR (^)"));
table3.AddColumn(new TableColumn("p"));
table3.AddColumn(new TableColumn("q"));
table3.AddRow("p", $"{p ^ p}", $"{p ^ q}");
table3.AddRow("q", $"{q ^ p}", $"{q ^ q}");
AnsiConsole.Write(table3);
#endregion

#region Exploring conditional logical operators also known as short-circuiting operators
WriteLine();
WriteLine($"p & DoStuff() = {p & DoStuff()}"); // Both p and DoStuff() are evaluated
WriteLine($"q & DoStuff() = {q & DoStuff()}"); // Both q and DoStuff() are evaluated

WriteLine();
WriteLine($"p & DoStuff() = {p && DoStuff()}");
WriteLine($"q & DoStuff() = {q && DoStuff()}"); // DoStuff() is not evaluated because q is false, this is known as short-circuiting
// Be careful when using && and || operators as they may skip method calls that have side effects
// use & and | operators if you want to ensure all expressions are evaluated'
#endregion

#region Exploring bitwise and binary shift operators
int x = 10;
int y = 6;

Table table4 = new();
table4.AddColumn(new TableColumn("Expression"));
table4.AddColumn(new TableColumn("Decimal"));
table4.AddColumn(new TableColumn("Binary"));
table4.AddRow("x", $"{x}", $"{x:B8}");
table4.AddRow("y", $"{y}", $"{y:B8}");
table4.AddRow("x & y", $"{x & y}", $"{(x & y):B8}");
table4.AddRow("x | y", $"{x | y}", $"{(x | y):B8}");
table4.AddRow("x ^ y", $"{x ^ y}", $"{(x ^ y):B8}");
table4.AddRow("x << 3", $"{x << 3}", $"{(x << 3):B8}");
table4.AddRow("x * 8", $"{x * 8}", $"{(x * 8):B8}");
table4.AddRow("y >> 1", $"{y >> 1}", $"{(y >> 1):B8}");
AnsiConsole.Write(table4);
// Note: x << 3 is equivalent to x * 2^3 (8) and y >> 1 is equivalent to y / 2^1 (2)
// Left shift (<<) fills with 0s from the right, Right shift (>>) fills with 0s from the left for positive numbers and with 1s for negative numbers
// bit-shift operators are faster than traditional operations like multiplication and division
#endregion

#region Miscellaneous operators
int age = 50;
WriteLine($"The {nameof(age)} variable uses {sizeof(int)} bytes of memory.");

// How many operators are in the following statement?
char firstDigit = age.ToString()[0];
// There are 4 operators: =, ., (), and []
// The assignment operator (=) assigns the value on the right to the variable on the left
// The member access operator (.) accesses the ToString() method of the age variable
// The invocation operator (()) calls the ToString() method
// The index operator ([]) accesses the first character of the string returned by ToString()
#endregion


string GetAuthorName()
{
    return "Mark";
}

static bool DoStuff()
{
    WriteLine("I am doing some stuff.");
    return true;
}
