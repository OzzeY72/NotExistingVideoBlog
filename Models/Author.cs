namespace NotExistingVideoBlog.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? AvatarUrl { get; set; }
        public ICollection<Video>? Videos { get; set; }
    }
}
