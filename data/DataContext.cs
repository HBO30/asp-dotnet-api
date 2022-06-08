using Microsoft.EntityFrameworkCore;
namespace SuperHerosSchool.data
{
    public class DataContext : DbContext
    {
         public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
    }
}