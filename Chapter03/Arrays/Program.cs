using System.Reflection.Metadata;

string[] names; // this can reference any size array of strings
names = new string[4]; // allocates memory for four strings
names[0] = "Kate";
names[1] = "Jack";
names[2] = "Rebecca";
names[3] = "Tom";
string[] names2 = { "Kate", "Jack", "Rebecca", "Tom" }; // alternate syntax for array initialization

for (int i = 0; i < names2.Length; i++)
{
    WriteLine($"{names2[i]} is at position {i}");
}

string[,] grid =
{
    { "Alpha", "Beta", "Gamma", "Delta" },
    { "Anne", "Ben", "Charlie", "Doug" },
    { "Aardvark", "Bear", "Cat", "Dog" },
};
WriteLine($"1st dimension lower bound: {grid.GetLowerBound(0)}");
WriteLine($"1st dimension upper bound: {grid.GetUpperBound(0)}");
WriteLine($"2nd dimension lower bound: {grid.GetLowerBound(1)}");
WriteLine($"2nd dimension upper bound: {grid.GetUpperBound(1)}");
for (int row = 0; row <= grid.GetUpperBound(0); row++) // rows
{
    for (int col = 0; col <= grid.GetUpperBound(1); col++) // columns
    {
        WriteLine($"Row {row} Column {col} = {grid[row, col]}");
    }
}

// for (int row = 0; row < grid.GetLength(0); row++) // rows
// {
//     for (int col = 0; col < grid.GetLength(1); col++) // columns
//     {
//         WriteLine($"Row {row} Column {col} = {grid[row, col]}");
//     }
// }

#region Working with jagged arrays
// C# 11
string[][] jagged =
{
    new[] { "Alpha", "Beta", "Gamma" },
    new[] { "Anne", "Ben", "Charlie", "Doug" },
    new[] { "Aardvark", "Bear" },
};

// C# 12
string[][] jagged2 =
[
    ["Alpha", "Beta", "Gamma"],
    ["Anne", "Ben", "Charlie", "Doug"],
    ["Aardvark", "Bear"],
];

WriteLine("Upper bound of the array of arrays is: {0}", jagged.GetUpperBound(0));
for (int array = 0; array <= jagged.GetUpperBound(0); array++)
{
    WriteLine(
        "Upper bound of array {0} is: {1}",
        arg0: array,
        arg1: jagged[array].GetUpperBound(0)
    );
}
for (int row = 0; row <= jagged.GetUpperBound(0); row++)
{
    for (int col = 0; col <= jagged[row].GetUpperBound(0); col++)
    {
        WriteLine($"Row {row} Column {col} = {jagged[row][col]}");
    }
}
#endregion

#region Cash change exercise using greedy algorithm, iterating from largest to smallest bill ensures least number of bills
// Create a method that takes in a cash amount and returns the change with the least number of bills
Dictionary<int, int> Change(int amount, int[] denominations)
{
    if (amount < 0)
    {
        throw new ArgumentException("Amount must be non-negative");
    }
    if (denominations == null)
    {
        throw new ArgumentNullException(
            nameof(denominations),
            "Denominations array cannot be null"
        );
    }

    Dictionary<int, int> count = new Dictionary<int, int>();

    // business logic to calculate the change with the least number of bills
    foreach (int denom in denominations)
    {
        count[denom] = amount / denom; // bill count
        amount = amount % denom; // remainder
    }

    return count;
}

// parameters: amount in cents, denominations in cents
var changes = Change(134230, new int[] { 10000, 5000, 2000, 1000, 500, 100, 25, 10, 5, 1 });
foreach (var change in changes)
{
    WriteLine($"{change.Key / 100.0:C}, Count: {change.Value}");
}
#endregion

#region List pattern matching with arrays
int[] sequentialNumbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
int[] oneTwoNumbers = { 1, 2 };
int[] oneTwoTenNumbers = { 1, 2, 10 };
int[] primeNumbers = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 };
int[] fibonacciNumbers = { 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89 };
int[] emptyNumbers = { };
int[] threeNumbers = { 9, 7, 5 };
int[] sixNumbers = { 6, 7, 5, 4, 2, 10 };
WriteLine($"{nameof(sequentialNumbers)}: {CheckSwitch(sequentialNumbers)}");
WriteLine($"{nameof(oneTwoNumbers)}: {CheckSwitch(oneTwoNumbers)}");
WriteLine($"{nameof(oneTwoTenNumbers)}: {CheckSwitch(oneTwoTenNumbers)}");
WriteLine($"{nameof(primeNumbers)}: {CheckSwitch(primeNumbers)}");
WriteLine($"{nameof(fibonacciNumbers)}: {CheckSwitch(fibonacciNumbers)}");
WriteLine($"{nameof(emptyNumbers)}: {CheckSwitch(emptyNumbers)}");
WriteLine($"{nameof(threeNumbers)}: {CheckSwitch(threeNumbers)}");
WriteLine($"{nameof(sixNumbers)}: {CheckSwitch(sixNumbers)}");

static string CheckSwitch(int[] values) =>
    values switch
    {
        [] => "Empty array",
        [1, 2, _, 10] => "Contains 1, 2, any single number, and 10",
        [1, 2, .., 10] => "Contains 1, 2, any range of numbers, and 10",
        [1, 2] => "One then two",
        [int item1, int item2, int item3] => $"Contains {item1}, then {item2}, then {item3}",
        [0, _] => "Starts with 0, then one other number",
        [0, ..] => "Starts with 0, then any range of numbers",
        [2, .. int[] others] => $"Starts with 2, then {others.Length} more numbers",
        [..] => "Any items in any order",
    };
#endregion
