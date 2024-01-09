namespace Calculator.Interfaces
{
    public interface IShape
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public double CalculateArea(double width, double height);
        public double CalculateCircumference(double width, double height);
    }
}
