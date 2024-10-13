namespace blogger.Server.Model
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string CommentText { get; set; }

        // Foreign Key relationships
        public int BlogId { get; set; }
        public Blog Blog { get; set; }

        public int CommenterId { get; set; }  // User who posted the comment
        public User Commenter { get; set; }

        public int CreatedBy { get; set; }  // User who created the comment
        public User Creator { get; set; }

        public int UpdatedBy { get; set; }  // User who updated the comment
        public User Updater { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

}
