namespace Database.Interfaces
{
    public interface IDatabaseEntity
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateLastUpdated { get; set; }
    }
}