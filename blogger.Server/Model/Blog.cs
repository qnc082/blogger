namespace blogger.Server.Model
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        // Foreign Key relationships
        public int AuthorId { get; set; }  // The actual author of the blog
        public User Author { get; set; }

        public int CreatedBy { get; set; }  // User who created the blog
        public User Creator { get; set; }

        public int UpdatedBy { get; set; }  // User who updated the blog
        public User Updater { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation Properties
        public ICollection<Comment> Comments { get; set; }
    }

}
