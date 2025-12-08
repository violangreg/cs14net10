WriteLine($"There are {args.Length} arguments.");
foreach (string arg in args)
{
    WriteLine(arg);
}

if (args.Length < 3)
{
    WriteLine("Please provide at least 3 arguments when running the program.");
    WriteLine("dotnet run red yellow 50");
    return;
}

ForegroundColor = (ConsoleColor)
    Enum.Parse(enumType: typeof(ConsoleColor), value: args[0], ignoreCase: true);
BackgroundColor = (ConsoleColor)
    Enum.Parse(enumType: typeof(ConsoleColor), value: args[1], ignoreCase: true);
CursorSize = int.Parse(args[2]);

#region Conditional Compilation -- only compile certain code based on build configuration or target framework

#if DEBUG
WriteLine("Press any key to reset console colors...");
#elif RELEASE
WriteLine("Press any key to exit...");
#else
WriteLine("Press any key to continue...");
#endif

#if NET10_0_ANDROID
// Compile statements that only work on Android.
#elif NET10_0_IOS
// Compile statements that only work on iOS.
#else
// Compile statements that work everywhere else.
#endif

#endregion
