namespace DATAGOV_API_INTRO_8.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // Ensure this property has a default value
        public string Comment { get; set; } = string.Empty; // Ensure this property has a default value
        public int Rating { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
