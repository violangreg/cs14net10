public abstract class Shape
{
    protected double height;
    protected double width;
    public virtual double Height 
    { 
        get => height; 
        set
        {
            height = value;
        }
    }
    public virtual double Width 
    { 
        get => width;
        set => width = value;
    }
    public abstract double Area { get; }
}