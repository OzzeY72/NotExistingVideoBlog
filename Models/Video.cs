namespace NotExistingVideoBlog.Models
{
    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string Preview { get; set; }
        public string URL { get; set; }
        public int? AuthorId { get; set; }
        public Author? Author { get; set; }
    }
}
