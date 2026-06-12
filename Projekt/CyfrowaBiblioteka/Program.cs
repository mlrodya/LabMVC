using Microsoft.EntityFrameworkCore;
using CyfrowaBiblioteka.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BibliotekaContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("BibliotekaConnection")));

builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<BibliotekaContext>();
    db.Database.Migrate();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Ksiazki}/{action=Index}/{id?}");

app.Run();