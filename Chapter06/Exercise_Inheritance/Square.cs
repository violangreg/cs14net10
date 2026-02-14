public class Square : Rectangle
{
    public override double Height
    {
        set 
        {
            height = value;
            width = value;
        }
    }
    public override double Width
    {
        set
        {
            height = value;
            width = value;
        }
    }

    public Square() { }
    public Square(double side) : base(height: side, width: side) { }
}