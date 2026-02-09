namespace Packt.Shared;

using System.Diagnostics.CodeAnalysis;

public class Book
{
    // Needs .NET 7 or later as well as C# 11 or later, use required keyword to make compiler require the fields when instantiating
    public required string? Isbn;
    public required string? Title;

    // works with any version of .NET
    public string? Author;
    public int PageCount;

    public Book() { }

    [SetsRequiredMembers]
    public Book(string? isbn, string? title)
    {
        Isbn = isbn;
        Title = title;
    }
}
