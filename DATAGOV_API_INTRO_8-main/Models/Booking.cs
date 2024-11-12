namespace DATAGOV_API_INTRO_8.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string? Destination { get; set; }
        public DateTime Date { get; set; }
        public int Travelers { get; set; }
        public string? Status { get; set; }
    }
}
