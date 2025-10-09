using System.ComponentModel.DataAnnotations;

namespace FlixSan.Models
{
    public class MovieDetails
    {
        public int Id { get; set; }
        public string MovieName { get; set; }
        public string MovieDescription { get; set; }
        [Range(1, 5)]
        public int Rating { get; set; }
        public string MovieCategory { get; set; }

    }
}
