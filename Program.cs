using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite; // Dodaj tê dyrektywê using, jeœli nie masz jej w projekcie

var builder = WebApplication.CreateBuilder(args);

// Upewnij siê, ¿e masz zainstalowany pakiet NuGet: Microsoft.EntityFrameworkCore.Sqlite
builder.Services.AddDbContext<GalleryDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddRazorPages();

var app = builder.Build();

app.UseStaticFiles();
app.MapRazorPages();
app.Run();


