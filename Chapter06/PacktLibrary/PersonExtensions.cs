namespace Packt.Shared;

public static class PersonExtensions
{
    public static Person SetName(this Person p, string name)
    {
        p.Name = name;
        return p;
    }

    public static Person SetBirthDate(this Person p, DateTimeOffset birthDate)
    {
        p.Born = birthDate;
        return p;
    }

    extension(Person p)
    {
        public Person SetHeight(int height)
        {
            p.Height = height;
            return p;
        }

        public bool IsTall()
        {
            return p.Height.HasValue && p.Height.Value > 180;
        }
    }
}
