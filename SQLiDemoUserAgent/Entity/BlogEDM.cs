namespace SQLiDemoUserAgent.Entity
{
    using System.Data.Entity;

    public partial class BlogEDM : DbContext
    {
        public BlogEDM()
            : base("name=BlogEDM")
        {
        }

        public virtual DbSet<BlogPost> BlogPosts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogPost>()
                .Property(e => e.Message)
                .IsUnicode(false);
        }
    }
}
