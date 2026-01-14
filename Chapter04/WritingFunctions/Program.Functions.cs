using System.Globalization;
using Microsoft.VisualBasic;

/// <summary>
/// Collection of demonstration helper methods used by the sample console application.
/// </summary>
/// <remarks>
/// This <see cref="Program"/> partial class provides small, focused examples that show how to:
/// <list type="bullet">
/// <item><description>Write formatted console output (e.g., <see cref="TimesTable"/>)</description></item>
/// <item><description>Manipulate culture and encoding for deterministic formatting (see <see cref="ConfigureConsole(string,bool)"/>)</description></item>
/// <item><description>Implement simple algorithms and edge-case handling (see <see cref="Factorial(int)"/>)</description></item>
/// </list>
/// These methods are designed for learning and demonstration; they are not intended as production-grade utilities.
/// </remarks>
partial class Program
{
    /// <summary>
    /// Writes a multiplication table for <paramref name="number"/> to the console.
    /// </summary>
    /// <param name="number">The multiplicand used to generate rows in the times table.</param>
    /// <param name="size">The number of rows to generate; defaults to 12 to match common times tables used in examples.</param>
    /// <remarks>
    /// Use this method to demonstrate simple formatting and loop constructs. The method intentionally writes directly
    /// to the console for pedagogical clarity rather than returning a data structure.
    /// </remarks>
    static void TimesTable(byte number, byte size = 12)
    {
        WriteLine($"This is the {number} times table with {size} rows:");
        WriteLine();
        for (int row = 1; row <= size; row++)
        {
            WriteLine($"{row} x {number} = {row * number}");
        }
        WriteLine();
    }

    /// <summary>
    /// Calculates the tax amount for <paramref name="amount"/> using a simplified lookup by region code.
    /// </summary>
    /// <param name="amount">The monetary amount to tax. Not modified by this method.</param>
    /// <param name="twoLetterRegionCode">
    /// A two-letter region code (case-insensitive) such as <c>"CA"</c> or <c>"OR"</c>. The lookup uses <see cref="string.ToUpper"/> so either case is acceptable.
    /// </param>
    /// <returns>The tax amount as a <see cref="decimal"/> (i.e., <c>amount * rate</c>), not the tax rate itself.</returns>
    /// <remarks>
    /// This implementation uses a small, hard-coded set of example region-to-rate mappings for demonstration purposes.
    /// It is not intended to represent real tax law and should not be used for financial calculations in production.
    /// A default fallback rate of 6% is applied when the region code is not recognized.
    /// </remarks>
    static decimal CalculateTax(decimal amount, string twoLetterRegionCode)
    {
        decimal rate = twoLetterRegionCode.ToUpper() switch
        {
            "CH" => 0.077M, // Switzerland
            "DK" or "NO" => 0.25M, // Denmark or Norway
            "GB" or "UK" or "FR" => 0.20M, // United Kingdom, Great Britain, France
            "HU" => 0.27M, // Hungary
            "OR" or "AK" or "MT" => 0.0M, // Oregon, Alaska, Montana
            "ND" or "WI" or "ME" or "VA" => 0.05M, // North Dakota, Wisconsin, Maine, Virginia
            "CA" => 0.0825M, // California
            _ => 0.06M, // Most other states
        };

        return amount * rate;
    }

    /// <summary>
    /// Configures console output encoding and optionally sets the thread culture.
    /// </summary>
    /// <param name="culture">A culture name such as <c>"en-US"</c>. Only used if <paramref name="useComputerCulture"/> is <see langword="false"/>.</param>
    /// <param name="useComputerCulture">If <see langword="true"/>, the method preserves the machine's current culture; otherwise it applies <paramref name="culture"/>.</param>
    /// <remarks>
    /// Ensuring a known <see cref="CultureInfo.CurrentCulture"/> and <c>UTF-8</c> <see cref="System.Console.OutputEncoding"/>
    /// makes sample output deterministic (for example, number and date formatting) across different machines and locales.
    /// </remarks>
    static void ConfigureConsole(string culture = "en-US", bool useComputerCulture = false)
    {
        OutputEncoding = System.Text.Encoding.UTF8;
        if (!useComputerCulture)
        {
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo(culture);
        }
        WriteLine($"CurrentCulture: {CultureInfo.CurrentCulture.DisplayName}");
    }

    /// <summary>
    /// Converts a positive integer to its English ordinal representation (for example, <c>1</c> -> <c>1st</c>).
    /// </summary>
    /// <param name="number">The cardinal number to convert. The method accepts <see cref="uint"/> so it supports large positive values.</param>
    /// <returns>A string containing the number formatted with no decimal places and an English ordinal suffix (for example, <c>{number:N0}th</c>).</returns>
    /// <remarks>
    /// The implementation follows the English-language ordinal rules, where numbers ending in 11, 12, or 13 always use <c>"th"</c>.
    /// The formatted number uses <c>"N0"</c> to include thousands separators for readability.
    /// This method is intended for display purposes in examples and assumes English ordinal rules.
    /// </remarks>
    static string CardinalToOrdinal(uint number)
    {
        uint lastTwoDigits = number % 100;
        return number switch
        {
            _ when lastTwoDigits == 11 || lastTwoDigits == 12 || lastTwoDigits == 13 =>
                $"{number:N0}th",
            _ when number % 10 == 1 => $"{number:N0}st",
            _ when number % 10 == 2 => $"{number:N0}nd",
            _ when number % 10 == 3 => $"{number:N0}rd",
            _ => $"{number:N0}th",
        };
    }

    /// <summary>
    /// Alternate implementation of <see cref="CardinalToOrdinal(uint)"/> using a <c>switch</c>-based flow to demonstrate control structures.
    /// </summary>
    /// <param name="number">The cardinal number to convert to an ordinal string.</param>
    /// <returns>The ordinal representation of <paramref name="number"/>.</returns>
    /// <remarks>
    /// This version exists to compare different approaches to the same problem: clarity and explicit control flow versus pattern-based <c>switch</c> expressions.
    /// </remarks>
    static string CardinalToOrdinal2(uint number)
    {
        uint lastTwoDigits = number % 100;
        switch (lastTwoDigits)
        {
            case 11:
            case 12:
            case 13:
                return $"{number:N0}th";
            default:
                uint lastDigit = number % 10;
                string suffix = lastDigit switch
                {
                    1 => "st",
                    2 => "nd",
                    3 => "rd",
                    _ => "th",
                };
                return $"{number:N0}{suffix}";
        }
    }

    /// <summary>
    /// Demonstration driver that writes the ordinals for 1 through 1500 to the console.
    /// </summary>
    /// <remarks>
    /// Used in examples to show the correctness and formatting of <see cref="CardinalToOrdinal(uint)"/>.
    /// This method intentionally produces a large amount of output and is not optimized for production use.
    /// </remarks>
    static void RunCardinalToOrdinal()
    {
        for (uint number = 1; number <= 1500; number++)
        {
            Write($"{CardinalToOrdinal(number)} ");
        }
    }

    /// <summary>
    /// Computes the factorial of a non-negative integer using recursion.
    /// </summary>
    /// <param name="number">A non-negative integer whose factorial to compute.</param>
    /// <returns>The factorial as an <see cref="int"/>.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="number"/> is negative because factorial is undefined for negative integers.</exception>
    /// <exception cref="OverflowException">May be thrown when the result exceeds the range of a 32-bit signed integer; the computation uses <c>checked</c> arithmetic to demonstrate overflow behavior.</exception>
    /// <remarks>
    /// This implementation uses recursion to make the algorithm clear for teaching purposes. For production code and large inputs,
    /// an iterative approach with arbitrary-precision arithmetic (for example, <see cref="System.Numerics.BigInteger"/>) is recommended.
    /// </remarks>
    static int Factorial(int number)
    {
        if (number < 0)
        {
            throw new ArgumentOutOfRangeException(
                message: $"The factorial function is defined for non-negative integers only. Input: {number}.",
                paramName: nameof(number)
            );
        }
        else if (number == 0)
        {
            return 1;
        }
        else
        {
            checked
            {
                return number * Factorial(number - 1);
            }
        }
    }

    /// <summary>
    /// Demonstration driver that exercises <see cref="Factorial(int)"/> across a range of inputs and shows error conditions.
    /// </summary>
    /// <remarks>
    /// Iterates values from -2 to 15 to demonstrate normal results, argument validation, and overflow handling; output is written to the console.
    /// </remarks>
    static void RunFactorial()
    {
        for (int i = -2; i <= 15; i++)
        {
            try
            {
                WriteLine($"{i}! = {Factorial(i):N0}");
            }
            catch (OverflowException)
            {
                WriteLine($"{i}! is too big for a 32-bit integer.");
            }
            catch (Exception ex)
            {
                WriteLine($"{i}! throws {ex.GetType()}: {ex.Message}");
            }
        }
    }

    static int FibImperative(uint term)
    {
        if (term == 0)
        {
            throw new ArgumentOutOfRangeException();
        }
        else if (term == 1)
        {
            return 0;
        }
        else if (term == 2)
        {
            return 1;
        }
        else
        {
            return FibImperative(term - 1) + FibImperative(term - 2);
        }
    }

    static void RunFibImperative()
    {
        for (uint i = 1; i <= 30; i++)
        {
            WriteLine(
                "The {0} term of the Fibonacci sequence is {1:N0}",
                arg0: CardinalToOrdinal(i),
                arg1: FibImperative(term: i)
            );
        }
    }

    static int FibFunctional(uint term) =>
        term switch
        {
            0 => throw new ArgumentOutOfRangeException(),
            1 => 0,
            2 => 1,
            _ => FibFunctional(term - 1) + FibFunctional(term - 2),
        };

    static void RunFibFunctional()
    {
        for (uint i = 1; i <= 30; i++)
        {
            WriteLine(
                "The {0} term of the Fibonacci sequence is {1:N0}",
                arg0: CardinalToOrdinal(i),
                arg1: FibFunctional(term: i)
            );
        }
    }
}
