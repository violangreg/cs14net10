#region Selection statements
using SelectionStatements;

bool expression1 = true;
bool expression2 = true;
bool expression3 = false;
if (expression1)
{
    // Executes if expression1 is true
}
else if (expression2)
{
    // Executes if expression1 is false and expression2 is true
}
else if (expression3)
{
    // Executes if expression1 and expression2 are false
    // And expression3 is true
}
else
{
    // Executes if all expressions are false
}

// Each if statement's Boolean expression is independent of the others and, unlike switch statements, does not need to reference a single value

string password = "ninja";
if (password.Length < 8)
{
    WriteLine("Your password is too short. Use at least 8 characters.");
}
else
{
    WriteLine("Your password is strong.");
}

// if, else while and for can use either a single statement without braces or one with more statements enclosed in braces, also known as embedded statement.
// A block or compound statement is one kind of embedded statement that uses braces to group multiple statements together.
// It is safer to always use braces even for single statements to avoid errors or serious bugs so always use braces {}
// Don't do this:
if (password.Length < 8)
    WriteLine("Your password is too short. Use at least 8 characters.");
else
    WriteLine("Your password is strong.");
#endregion

#region Early return or guard clause style if statements
// Traditional if statement style using else
string GetStatus(int score)
{
    if (score >= 50)
    {
        return "Pass";
    }
    else
    {
        return "Fail";
    }
}

// Early return or guard clause style if statement
string GetStatus2(int score)
{
    if (score < 50)
    {
        return "Fail";
    }
    return "Pass";
}
// The benefits of early return style if statements include reduced nesting, improved readability, and allows short-circuiting for edge cases /invalid cases early in the method
// this style is clean code practices advocated by Robert C. Martin, and known by C# codebases community and widely adopted in ASP.NET Core framework. An example is:
// IActionResult ProcessOrder(Order order)
// {
//     if (order == null)
//     {
//         return BadRequest("Order cannot be null.");
//     }
//     if (!order.IsValid())
//     {
//         return UnprocessableEntity("Order is invalid.");
//     }
//     // Process the order
//     _orderService.Save(order);
//     return Ok();
// }
// Notice there is no else statements, the method returns early for each invalid cases, allowing the main logic to stay flat and readable.
// If you notice there is an else statement, consider refactoring to early return or guard clause style if statements.
#endregion

#region Pattern matching with the if statement
object o = "3";
int j = 4;
if (o is int i)
{
    WriteLine($"{i} x {j} = {i * j}");
}
else
{
    WriteLine("o is not an integer so it cannot multiply!");
}

#endregion

#region Branching with switch statements
int number = Random.Shared.Next(minValue: 1, maxValue: 7);
WriteLine($"My random number is {number}");
switch (number)
{
    case 1:
        WriteLine("One");
        break; // jumps to the end of switch
    case 2:
        WriteLine("Two");
        goto case 1; // Example of goto statement in switch
    case 3: // multiple case section
    case 4:
        WriteLine("Three or Four");
        goto case 1;
    case 5:
        goto A_label;
    default:
        WriteLine("Default");
        break;
}
WriteLine("After end of switch");
A_label:
WriteLine($"After A_label");
#endregion

var animals = new Animal?[]
{
    new Cat
    {
        Name = "Karen",
        Born = new(year: 2022, month: 8, day: 23),
        Legs = 4,
        isDomestic = true,
    },
    null,
    new Cat { Name = "Mufasa", Born = new(year: 1994, month: 6, day: 12) },
    new Spider
    {
        Name = "Sid Vicioua",
        Born = DateTime.Today,
        isPoisonous = true,
    },
    new Spider { Name = "Captain Furry", Born = DateTime.Today },
};

foreach (Animal? animal in animals)
{
    string message;
    switch (animal)
    {
        case Cat { Legs: 4 } fourLeggedCat: // similar to Cat fourLeggedCat when fourLeggedCat.Legs == 4
            message = $"The cat named {fourLeggedCat.Name} has four legs.";
            break;
        case Cat wildCat when wildCat.isDomestic == false:
            message = $"The non-domestic cat is named {wildCat.Name}.";
            break;
        case Cat cat:
            message = $"The cat is named {cat.Name}.";
            break;
        default:
            message = $"{animal.Name} is a {animal.GetType().Name}";
            break;
        case Spider s when s.isPoisonous:
            message = $"{s.Name} is a poisonous spider. Run!";
            break;
        case null:
            message = "Animal is null.";
            break;
    }
    WriteLine($"switch statement: {message}");
}

#region Simplifying switch statements with switch expressions
foreach (Animal? animal in animals)
{
    string message = animal switch
    {
        Cat { Legs: 4 } fourLeggedCat => $"The cat named {fourLeggedCat.Name} has four legs.",
        Cat wildCat when wildCat.isDomestic == false =>
            $"The non-domestic cat is named {wildCat.Name}.",
        Cat cat => $"The cat is named {cat.Name}.",
        Spider s when s.isPoisonous => $"{s.Name} is a poisonous spider. Run!",
        null => "Animal is null.",
        _ => $"{animal.Name} is a {animal.GetType().Name}",
    };
    WriteLine($"switch expression: {message}");
}

#endregion
