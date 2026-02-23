using System.ComponentModel.DataAnnotations;

namespace Packt.Shared;

public class Student
{
    public int StudentId { get; set; }
    public string? FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string? LastName { get; set; }

    [EmailAddress]
    public string? Email { get; set; }
    public ICollection<Course>? Courses { get; set; }
}
