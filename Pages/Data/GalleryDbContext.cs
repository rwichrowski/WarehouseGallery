using Microsoft.EntityFrameworkCore;

public class GalleryDbContext : DbContext
{
    public GalleryDbContext(DbContextOptions<GalleryDbContext> options) : base(options) { }

    public DbSet<Photo> Photos { get; set; }
}