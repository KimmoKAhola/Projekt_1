namespace Database.Interfaces
{
    public interface ICalculation
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateLastUpdated { get; set; }
    }
}