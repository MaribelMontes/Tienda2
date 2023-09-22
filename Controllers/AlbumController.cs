using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Practice2.Models;

namespace Practice2.Controllers;

public class AlbumController : Controller
{
private AppDbContext _context;
public AlbumController(AppDbContext context)
{
    _context = context;
}

public async Task<IActionResult> Save (Album model)
{
    if (ModelState.IsValid)
    {
        
        _context.Albums.Add(model);
        await _context.SaveChangesAsync();
        return Redirect("/Cantante/Details/ " + model.cantanteid);
    }
        return Redirect("/Cantante/Index");
    
}



}