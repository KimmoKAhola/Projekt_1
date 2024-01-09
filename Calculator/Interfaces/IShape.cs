namespace Calculator.Interfaces
{
    public interface IShape
    {
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public decimal CalculateArea(decimal width, decimal height);
        public decimal CalculateCircumference(decimal width, decimal height);
    }
}
