#region Storing numeric data
// Computers store numbers in binary format (0s and 1s). There are 128-bit, 64-bit, 32-bit, 16-bit, and 8-bit numbers. 128-bit is precised, largest (space/size) and slowest performance wise than its latter equivalent like 64-bit and lower.
// Numbers are data that we want to perform an arithmatic calculation on, for example, multiply, divide, add, subtract, etc.
// A phone number is not a number for calculation, it is a sequence of characters so it is a string: (562)-350-9485
// Consider if you want it as positive or negative, whole number or decimal, precision vs space vs speed
uint naturalNumber = 23; // 32-bit unsigned integer, whole numbers only, no negative values
int integerNumber = -23; // 32-bit signed integer, whole numbers including negative values
float floatingPointNumber = 2.5F; // 32-bit floating point, for decimal numbers, less precision, f suffix required - makes it a float literal, less space, faster
double doublePrecisionNumber = 2.5; // 64-bit floating point, for decimal numbers, more precision, moderate space, faster
decimal preciseDecimalNumber = 2.5M; // 128-bit precise decimal point, for decimal numbers, highest precision ideal for financial calculations, m suffix required - makes it a decimal literal, more space, slower

// You can store as cents to avoid floating point precision issues in financial calculations, this is how decimal type works internally, 0.1 is stored as 1, moving the decimal point one place to the right, 19.99 is stored as 1999, moving the decimal point two places to the right
// Integer approach: store cents
ulong priceCents = 1999; // $19.99
ulong qty = 3;
ulong totalCents = priceCents * qty; // exact integer arithmetic
Console.WriteLine($"Total: ${totalCents / 100}.{totalCents % 100:D2}"); // formatting comes after expression: D2 means pad with leading zero to 2 digits so 5 becomes 05, 45 stays 45, 0 is 00

byte byteNumber = 255; // 8-bit unsigned integer, whole numbers only, no negative values, range: 0 to 255
sbyte sbyteNumber = -128; // 8-bit signed integer, whole numbers including negative values, range: -128 to 127
short shortNumber = -32000; // 16-bit signed integer, whole numbers including negative values, smaller range: -32,768 to 32,767
ushort ushortNumber = 65000; // 16-bit unsigned integer, whole numbers only, no negative values, range: 0 to 65,535
int intNumber = 2_000_000_000; // 32-bit signed integer, use underscores for readability equates to 2000000000, the range for int is: -2,147,483,648 to 2,147,483,647
uint uintNumber = 4_000_000_000; // 32-bit unsigned integer, larger positive whole numbers only, the range for uint is: 0 to 4,294,967,295
long bigNumber = 1_000_000; // 64-bit signed integer, use underscores for readability equates to 1 million or 1000000, the range for long is: -9,223,372,036,854,775,807 to 9,223,372,036,854,775,807
ulong veryBigUnsignedNumber = 1_000_000_000_000; // 64-bit unsigned integer, larger positive whole numbers only, unsigned has more space for bigger positive numbers, the range for ulong is: 0 to 18,446,744,073,709,551,615
BigInteger veryBigNumber = BigInteger.Parse("1234567890123456789012345678901234567890"); // biggest of the biggest arbitrary-precision integer
#region Using binary with 0b and hexadecimals with 0x notations
int decimalNumber = 42; // decimal literal for 42
int binaryNumber = 0b_0010_1010; // binary literal for 42
int hexNumber = 0x_2A; // hexadecimal literal for 42
WriteLine($"Binary {binaryNumber} equals Hexadecimal {hexNumber}");
WriteLine($"{decimalNumber == binaryNumber}");
WriteLine($"{decimalNumber == hexNumber}");
WriteLine($"{decimalNumber:N0}");
WriteLine($"{binaryNumber:N0}");
WriteLine($"{hexNumber:N0}");
WriteLine($"{decimalNumber:X}");
WriteLine($"{binaryNumber:X}");
WriteLine($"{hexNumber:X}");
WriteLine($"{decimalNumber:B}");
WriteLine($"{binaryNumber:B}");
WriteLine($"{hexNumber:C}");
// Can find all the formats available at https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings
#endregion

#region Precision issues with floating point numbers -- decimal alternative for financial calculations but slower and more memory usage
// TL;DR: Never use double or float for == comparisons because of precision issues in binary representation of decimal fractions. Use decimal type for financial/accuracy calculations to avoid precision errors.
// Use double only for scientific calculations with big numbers, less accurate, or performance needed or using less than < or greater than > comparisons. More info: https://github.com/markjprice/cs14net10/blob/main/docs/ch02-decimal-vs-double.md

// Storing real numbers uses Institute of Electrical and Electronics Engineers (IEEE) 754 standard for floating-point arithmetic
// 12.75 in decimal is 00001100.1100 in binary
// But computers store floating/double point numbers in scientific notation (also called normalized form) to save space
// 12.75 in binary scientific notation is 1.10011 x 2^3
// The first bit is the sign bit (0 for positive, 1 for negative), the next 8 bits are the exponent (with a bias of 127 for single precision), and the remaining 23 bits are the significand (also called mantissa)
// So 12.75 in 32-bit floating point representation is: 0 10010000 10011001100110011001101
// This representation can lead to precision issues because some decimal fractions cannot be represented exactly in binary.
// For example, 0. 1 in decimal is a repeating binary fraction: 0.00011001100110011... (in binary).
// This can lead to small rounding errors in calculations. For example:
double a = 0.1;
double b = 0.2;
double c = a + b;
Console.WriteLine(c == 0.3); // Output: False due to precision error

// To mitigate this, use decimal type for financial calculations but will require more memory and be slower
decimal d = 0.1M;
decimal e = 0.2M;
decimal f = d + e;
Console.WriteLine(f == 0.3M); // Output: True
#endregion

#region Exploring number sizes
WriteLine(
    $"int uses {sizeof(int)} bytes and can store numbers in the range {int.MinValue:N0} to {int.MaxValue:N0}"
);
WriteLine(
    $"float uses {sizeof(float)} bytes and can store numbers in the range {float.MinValue:N0} to {float.MaxValue:N0}"
);
WriteLine(
    $"double uses {sizeof(double)} bytes and can store numbers in the range {double.MinValue:N0} to {double.MaxValue:N0}"
);
WriteLine(
    $"decimal uses {sizeof(decimal)} bytes and can store numbers in the range {decimal.MinValue:N0} to {decimal.MaxValue:N0}"
);

WriteLine($"Size of byte: {sizeof(byte)}");
WriteLine($"Size of sbyte: {sizeof(sbyte)}");
WriteLine($"Size of short: {sizeof(short)}");
WriteLine($"Size of ushort: {sizeof(ushort)}");
WriteLine($"Size of int: {sizeof(int)}");
WriteLine($"Size of uint: {sizeof(uint)}");
WriteLine($"Size of long: {sizeof(long)}");
WriteLine($"Size of ulong: {sizeof(ulong)}");
WriteLine($"Size of float: {sizeof(float)}");
WriteLine($"Size of double: {sizeof(double)}");
WriteLine($"Size of decimal: {sizeof(decimal)}");
WriteLine($"Size of BigInteger: {BigInteger.One.ToByteArray().Length} (varies)");
#endregion

#region Special real number values
double epsilon = double.Epsilon; // smallest positive Double value greater than zero denoted as 5e-324
Console.WriteLine($"Epsilon: {epsilon}");
Console.WriteLine($"Epsilon with 350 decimal places: {epsilon:N350}");
double positiveInfinity = double.PositiveInfinity;
double negativeInfinity = double.NegativeInfinity;
double.IsInfinity(positiveInfinity); // returns true
double.IsInfinity(negativeInfinity); // returns true
double notANumber = double.NaN; // represents an undefined or unrepresentable value, such as the result of 0.0/0.0
double.IsNaN(notANumber); // returns true
Console.WriteLine($"Positive Infinity: {positiveInfinity}");
Console.WriteLine($"Negative Infinity: {negativeInfinity}");
Console.WriteLine($"Not a Number (NaN): {notANumber}");
System.Console.WriteLine($"{0.0 / 0.0}"); // outputs NaN
System.Console.WriteLine($"{1.0 / 0.0}"); // outputs Infinity
System.Console.WriteLine($"{-1.0 / 0.0}"); // outputs -Infinity
System.Console.WriteLine($"{0.0 / 1.0}"); // outputs 0
System.Console.WriteLine($"{0.0 / -1.0}"); // outputs -0
#endregion

unsafe
{
    System.Console.WriteLine(
        $"Half uses {sizeof(Half)} bytes and can store numbers in the range {Half.MinValue:N0} to {Half.MaxValue:N0}"
    );
    System.Console.WriteLine(
        $"Int128 uses {sizeof(Int128)} bytes and can store numbers in the range {Int128.MinValue:N0} to {Int128.MaxValue:N0}"
    );
    System.Console.WriteLine(
        $"Int64 uses {sizeof(Int64)} bytes and can store numbers in the range {Int64.MinValue:N0} to {Int64.MaxValue:N0}"
    );
    System.Console.WriteLine(
        $"long uses {sizeof(long)} bytes and can store numbers in the range {long.MinValue:N0} to {long.MaxValue:N0}"
    ); // int64 is long, they are the same
}

#endregion
