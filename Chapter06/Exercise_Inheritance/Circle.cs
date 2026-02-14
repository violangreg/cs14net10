public class Circle : Square
{
    protected double radius;
    public double Radius
    {
        get => radius;
        set 
        {
            radius = value;
            Height = value * 2;
        }
    }
    public Circle() { }
    public Circle(double radius) : base(side: radius * 2)
    {
        this.radius = radius;
    }

    public override double Area
    {
        get
        {
            return Math.PI * Math.Pow(radius, 2);
        } 
    }
}