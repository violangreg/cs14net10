using Exercise_PrimeFactorsLib;

Console.WriteLine("Enter a number between 1 and 1000 to factor (or 'exit' to quit):");
var input = Console.ReadLine();
if (int.TryParse(input, out int number))
{
    Console.WriteLine(
        format: "Prime factors of {0} are: {1}",
        arg0: number,
        arg1: PrimeFactorsLib.PrimeFactors(number)
    );
}
