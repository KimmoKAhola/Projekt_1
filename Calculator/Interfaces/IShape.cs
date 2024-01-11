namespace Calculator.Interfaces
{
    public interface IShape
    {
        public double Width { get; set; } //Are these two needed?
        public double Height { get; set; }

        public string Name { get; set; }
        public (double area, double circumference) Calculate(double width, double height);
    }
}
