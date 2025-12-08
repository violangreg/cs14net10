#region Implicit namespace usings/imports in .NET 10
// In .NET 10, implicit usings are enabled by default for new projects.
// You can find the imported namespaces in the auto-generated <project-name>.GlobalUsings.g.cs file. The extension g stands for generated.
// The file is located in the obj/Debug/net10.0 folder under your project directory.
// You can include or exclude namespaces by modifying the .csproj file of your project.
#endregion
#region Explicitly import/remove namespaces of Global Usings from the .csproj file
// We statically imported System.Console in the csproj file, so we can use WriteLine directly
WriteLine("This line uses static import of System.Console.");

// We aliased System.Environment as Env in the csproj file, so we can use Env to access Environment members
WriteLine($"Machine Name: {Env.MachineName}");
// You can disable implicit usings in the .csproj file by setting <ImplicitUsings>disable</ImplicitUsings>.
#endregion


#region Comments in C#
// VS Code shortcut: Ctrl+/
// This is a single-line comment.

/* VS Code shortcut: Alt+Shift+A
    This is a multi-line comment.
    It can span multiple lines.
 */
#endregion
#region Collapsible region for putting related code together, this is a region name or description

// This is a collapsible region.
// You can put related code here.

#endregion

#region Syntax
#region Reserved keywords as identifiers/variables
// C# reserved keywords cannot be used directly as identifiers/variable names.
// using reserved keywords as identifiers by prefixing them with @ -- avoid this !!
string @string = "This is a string variable named 'string'.";
int @int = 42;
Console.WriteLine(@string);
#endregion
#endregion

#region IDE features
#region Checking for syntax errors with problems tab
// Ctrl+Shift+M to open the problems tab
// Console.Writeline(@int)
Console.WriteLine(@int);
#endregion
#endregion

#region Methods -- methods are verb names, they perform actions
#region Method overloading
// Method overloading allows multiple methods with the same name but different parameters.
Console.WriteLine();
Console.WriteLine("Hello, World!");
Console.WriteLine("Temperature on {0:D} is {1}°C", DateTime.Today, 13.4);
#endregion
#endregion

#region Using reflection to get assembly information
System.Data.DataSet ds = new();
HttpClient client = new();

Assembly? assembly = Assembly.GetEntryAssembly();
if (assembly == null)
    return;
foreach (var name in assembly.GetReferencedAssemblies())
{
    Assembly a = Assembly.Load(name);
    int methodCount = 0;
    foreach (var type in a.DefinedTypes)
    {
        methodCount += type.GetMethods().Length;
    }
    WriteLine(
        "{0:N0} types with {1:N0} methods in {2} assembly",
        arg0: a.DefinedTypes.Count(),
        arg1: methodCount,
        arg2: name.Name
    );
}
#endregion

#region Types, variables, fields, and properties -- are noun names, they represent objects or data

#region Variables
// Two important factors of variables is their name camelCase (used for local variables and private fields) vs PascalCase,
// space (memory) they occupy and process speed (performance).
// The 64-bit types process faster on 64-bit systems, but occupy more memory space. 16-bit types occupy less memory space, but process slower on 64-bit systems.
// So you have to balance between memory space and performance when choosing variable types.
// Do you need more speed or less memory usage? Choose 64 for speed, 16 for memory space.
double doubleVar = 3.14159; // 64-bit floating point, good for scientific calculations, faster but less precise, occupies moderate memory, good balance between speed and precision, commonly used
decimal decimalVar = 3.14159M; // 128-bit precise decimal point, higher precision for financial calculations, but slower, occupies more memory, but provides better accuracy, commonly used in financial applications
double heightInMetres = 1.88;
WriteLine($"The variable {nameof(heightInMetres)} has the value {heightInMetres}.");

// Literal values
char letter = 'A'; // character literal
char digit = '7'; // character literal
string greeting = "Hello"; // string literal
string horizontalLine = new('-', count: 74); // string created with constructor
string emoji = char.ConvertFromUtf32(0x1F600); // string literal
char esc = '\e'; // escape character literal
#region Options for storing text data
// 4 ways: Literal values, verteim literal strings, raw string literals, and raw interpolated string literals

// Verbatim literal strings
string fullNameWithTabSeparator = "John\tDoe"; // with tab escape character
string backwardSlash = "This is a backslash: \\"; // with escape character
string filePathWithEscapeCharacters = "C:\\Users\\JohnDoe\\Documents\\file.txt"; // with escape characters
string filePathVerbatim = @"C:\Users\JohnDoe\Documents\file.txt"; // verbatim string literal
string multiLineVerbatim =
    @"This is a verbatim string literal.
It can span multiple lines."; // verbatim string literal spanning multiple lines

// Raw String Literals (C# 11 and later)
string rawStringLiteral = """
<person age="50">
    <firstName>John</firstName>
    <lastName>Doe</lastName>
</person>
""";

// Raw interpolated String Literals (C# 11 and later)
// the number of $ indicates the level of interpolation (replaced expression), two $$ for double braces {{}}, three $$$ for triple braces {{{}}}
var person = new
{
    FirstName = "John",
    LastName = "Doe",
    Age = 50,
};
string json = $$"""
{
    "firstName": "{{person.FirstName}}",
    "lastName": "{{person.LastName}}",
    "age": {{person.Age}},
    "calculation": "{{{1 + 2}}}"
}
""";
WriteLine(json);
#endregion

#endregion

// Note: in top-level statements, we must declare variables before we define the class
// top-level statements is without explicit Main method, namespace, or class Program
var Fido = new Animal(); // Variable -- Fido is a variable; it is a noun referring to a specific object. A variable is a named storage location that holds a value.
Fido.Speak();

class Animal // Type -- are nouns for categorizing objects
{
    // Field and Property are nouns that belong to Animal
    // Field -- field is a variable that is associated with a class or an object
    public string name;

    // Property -- property is a special kind of class member that provides a flexible mechanism to read, write, or compute the value of a private field
    public int Age { get; set; }

    public Animal()
    {
        this.name = "Fido";
        this.Age = 3;
    }

    // Method -- method is a verb Animal can do, a function that is associated with a class or an object
    public void Speak()
    {
        Console.WriteLine($"{name} says: Hello!");
    }
}


#endregion
