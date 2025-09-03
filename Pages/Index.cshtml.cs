using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

public class IndexModel : PageModel
{
    private readonly GalleryDbContext _context;
    public List<Photo> Photos { get; set; }

    public IndexModel(GalleryDbContext context)
    {
        _context = context;
    }

    public async Task OnGetAsync()
    {
        Photos = await _context.Photos.ToListAsync();
    }
}