/** while and do...while statements
int x = 0;
while (x < 10)
{
    WriteLine(x);
    x++;
}

string? actualPassword = "Pa$$w0rd";
string? password;
int attempts = 0;
bool passwordPassed;
do
{
    Write("Enter your password: ");
    password = ReadLine();
    attempts++;
    passwordPassed = password == actualPassword;
    if (!passwordPassed)
    {
        WriteLine("Incorrect password. Try again.");
    }
} while (!passwordPassed && attempts < 3);
WriteLine(passwordPassed ? "Access granted." : "Access denied. Too many failed attempts.");
**/

#region for loop statement
for (int y = 1; y <= 10; y++)
{
    WriteLine(y);
}

for (int y = 0; y <= 10; y += 3)
{
    WriteLine(y);
}
#endregion

#region foreach statement
List<string> names = ["Adam", "Eve", "Charlie"];
foreach (string name in names)
{
    WriteLine($"{name} has {name.Length} characters.");
}
#endregion
