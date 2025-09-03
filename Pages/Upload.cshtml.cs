using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class UploadModel : PageModel
{
    private readonly GalleryDbContext _context;
    private readonly IWebHostEnvironment _env;

    [BindProperty]
    public IFormFile PhotoFile { get; set; }
    [BindProperty]
    public string Description { get; set; }

    public UploadModel(GalleryDbContext context, IWebHostEnvironment env)
    {
        _context = context;
        _env = env;
    }

    public void OnGet() { }

    public async Task<IActionResult> OnPostAsync()
    {
        if (PhotoFile != null)
        {
            var fileName = Path.GetFileName(PhotoFile.FileName);
            var uploadPath = Path.Combine(_env.WebRootPath, "uploads");
            Directory.CreateDirectory(uploadPath);
            var filePath = Path.Combine(uploadPath, fileName);

            using (var stream = System.IO.File.Create(filePath))
            {
                await PhotoFile.CopyToAsync(stream);
            }

            var photo = new Photo { FileName = fileName, Description = Description };
            _context.Photos.Add(photo);
            await _context.SaveChangesAsync();
        }
        return RedirectToPage("Index");
    }
}