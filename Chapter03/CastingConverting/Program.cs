using System.Buffers.Text;
using System.Globalization;
using static System.Convert;

int a = 10;
double b = a; // implicit conversion from int to double
WriteLine($"a is {a}, b is {b}");

double c = 9.8;
int d = (int)c; // error: cannot implicitly convert double to int as it may lose data / unsafe
WriteLine($"c is {c}, d is {d}"); // d loses the fractional part .8

long e = 10;
int f = (int)e;
WriteLine($"e is {e:N0}, f is {f:N0}");
e = 5_000_000_000;
f = (int)e;
WriteLine($"e is {e:N0}, f is {f:N0}");

Table table = new();
table.AddColumn(new TableColumn("Decimal"));
table.AddColumn(new TableColumn("Binary"));
table.AddRow($"{int.MaxValue}", Convert.ToString(int.MaxValue, toBase: 2).PadLeft(32, '0'));

// signed numbers can be negative or positive so the leftmost bit is reserved for the sign (0 = positive, 1 = negative)
for (int i = 8; i >= -8; i--)
{
    table.AddRow($"{i}", Convert.ToString(i, toBase: 2).PadLeft(32, '0'));
}
table.AddRow($"{int.MinValue}", Convert.ToString(int.MinValue, toBase: 2).PadLeft(32, '0'));

long r = 43657622826;
int s = (int)r; // data loss will incur on conversion from long to int
table.AddRow($"{r}", Convert.ToString(r, toBase: 2).PadLeft(64, '0'));
table.AddRow($"{s}", Convert.ToString(s, toBase: 2).PadLeft(64, '0')); // the binary is truncated to fit into 32 bits, you see that '1010' was lost on the 33rd to 35th bits
AnsiConsole.Write(table);

#region Converting using System.Convert class
double g = 9.8;
int h = ToInt32(g); // converting rounds to nearest integer instead of cutting off the fractional part, casting cuts off the fractional part
WriteLine($"g is {g}, h is {h}");

double[,] doubles =
{
    { 9.49, 9.5, 9.51 },
    { 10.49, 10.5, 10.51 },
    { 11.49, 11.5, 11.51 },
    { 12.49, 12.5, 12.51 },
    { -12.49, -12.5, -12.51 },
    { -11.49, -11.5, -11.51 },
    { -10.49, -10.5, -10.51 },
    { -9.49, -9.5, -9.51 },
};

Table table2 = new();
table2.AddColumn(new TableColumn("double"));
table2.AddColumn(new TableColumn("ToInt32"));
table2.AddColumn(new TableColumn("double"));
table2.AddColumn(new TableColumn("ToInt32"));
table2.AddColumn(new TableColumn("double"));
table2.AddColumn(new TableColumn("ToInt32"));
for (int i = 0; i < 8; i++)
{
    for (int j = 0; j < 3; j++)
    {
        table2.AddRow(
            $"{doubles[i, j]}",
            $"{ToInt32(doubles[i, j])}",
            $"{doubles[i, ++j]}",
            $"{ToInt32(doubles[i, j])}",
            $"{doubles[i, ++j]}",
            $"{ToInt32(doubles[i, j])}"
        );
    }
}
AnsiConsole.Write(table2);

foreach (double n in doubles)
{
    WriteLine(
        format: "Math.Round({0}, MidpointRounding.AwayFromZero) is {1}",
        arg0: n,
        arg1: Math.Round(value: n, digits: 0, mode: MidpointRounding.AwayFromZero)
    );
}

// rounding documentation: https://learn.microsoft.com/en-us/dotnet/api/system.math.round
// make sure to check for different programming languages as they may behave differently
#endregion

#region Converting from any type to string
int number = 12;
WriteLine(number.ToString());
bool boolean = true;
WriteLine(boolean.ToString());
DateTime now = DateTime.Now;
WriteLine(now.ToString());
object me = new();
WriteLine(me.ToString());
WriteLine(me); // same as above, ToString() is called implicitly, avoids boxing operation (good for unity performance)
#endregion

#region Converting from a binary object to a string
byte[] binaryObject = new byte[128];
Random.Shared.NextBytes(binaryObject);
WriteLine("Binary object as bytes:");
for (int index = 0; index < binaryObject.Length; index++)
{
    Write($"{binaryObject[index]:X2} ");
}
WriteLine();
string encoded = Convert.ToBase64String(binaryObject);
WriteLine($"Binary object as Base64: {encoded}");

ReadOnlySpan<byte> bytes = binaryObject;
string encoded2 = Base64Url.EncodeToString(bytes);
WriteLine($"Binary object as Base64Url: {encoded2}");
#endregion

#region Parsing from strings to numbers or dates and times
CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
int friends = int.Parse("27");
DateTime birthday = DateTime.Parse("4 June 1980");
WriteLine($"I have {friends} friends to invite to my party.");
WriteLine($"My birthday is {birthday}");
WriteLine($"My birthday is {birthday:D}"); // long date pattern

//int count = int.Parse("abc");
Write("How many eggs are there? ");
string? input = ReadLine();
if (int.TryParse(input, out int count))
{
    WriteLine($"There are {count} eggs.");
}
else
{
    WriteLine("I could not parse the input.");
}

int number2 = int.Parse("123");
bool success = int.TryParse("123", out int number3);
bool success2 = Uri.TryCreate(
    "https://localhost:5000/api/customers",
    UriKind.Absolute,
    out Uri serviceUrl
);
#endregion
