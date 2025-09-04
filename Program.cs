using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite; // Dodaj t� dyrektyw� using, je�li nie masz jej w projekcie

var builder = WebApplication.CreateBuilder(args);

// Upewnij si�, �e masz zainstalowany pakiet NuGet: Microsoft.EntityFrameworkCore.Sqlite
builder.Services.AddDbContext<GalleryDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddRazorPages();

var app = builder.Build();

app.UseStaticFiles();
app.MapRazorPages();
app.Run();


