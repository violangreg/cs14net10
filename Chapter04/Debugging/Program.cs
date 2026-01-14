double a = 4.5;
double b = 2.5;
double answer = Add(a, b);
for (int i = 0; i < 5; i++)
{
    WriteLine($"{a} + {b} = {answer}");
}
WriteLine("Press Enter to exit...");
ReadLine(); // Wait for user to press Enter

// Deliberate bug for testing/learning debugging
double Add(double a, double b) => a + b;
