using Microsoft.EntityFrameworkCore;

namespace Packt.Shared;

public class Academy : DbContext
{
    public DbSet<Student>? Students { get; set; }
    public DbSet<Course>? Courses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string path = Path.Combine(Environment.CurrentDirectory, "AcademyMigration.db");
        string connection = $"Filename={path}";
        WriteLine($"Connection: {connection}");
        optionsBuilder.UseSqlite(connection);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<Student>().Property(s => s.LastName).HasMaxLength(30).IsRequired();

        // Student alice = new()
        // {
        //     StudentId = 1,
        //     FirstName = "Alice",
        //     LastName = "Jones",
        // };

        // Student bob = new()
        // {
        //     StudentId = 2,
        //     FirstName = "Bob",
        //     LastName = "Smith",
        // };

        // Student cecilia = new()
        // {
        //     StudentId = 3,
        //     FirstName = "Cecilia",
        //     LastName = "Ramirez",
        // };

        // Course csharp = new() { CourseId = 1, Title = "C# 11 and .NET 7" };
        // Course webdev = new() { CourseId = 2, Title = "Web Development" };
        // Course python = new() { CourseId = 3, Title = "Python for Beginners" };

        // modelBuilder.Entity<Student>().HasData(alice, bob, cecilia);
        // modelBuilder.Entity<Course>().HasData(csharp, webdev, python);

        // modelBuilder
        //     .Entity<Course>()
        //     .HasMany(c => c.Students)
        //     .WithMany(s => s.Courses)
        //     .UsingEntity(e =>
        //         e.HasData(
        //             // All students signed up for C#, the types below are anonymous types for the intermediate table in many-to-many relationship
        //             // The convention is NavigationPropertyNamePropertyName
        //             new { CoursesCourseId = 1, StudentsStudentId = 1 },
        //             new { CoursesCourseId = 1, StudentsStudentId = 2 },
        //             new { CoursesCourseId = 1, StudentsStudentId = 3 },
        //             // Only bob signed up for web dev
        //             new { CoursesCourseId = 2, StudentsStudentId = 2 },
        //             // Only cecilia signed up for python
        //             new { CoursesCourseId = 3, StudentsStudentId = 3 }
        //         )
        //     );
    }
}
