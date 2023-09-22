using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Practice2.Models;

namespace Practice2.Controllers;

public class CommentController : Controller
{
private AppDbContext _context;
public CommentController(AppDbContext context)
{
    _context = context;
}

public async Task<IActionResult> Save (Comment model)
{
    if (ModelState.IsValid)
    {
        model.date = DateTime.Now.Date.ToShortDateString();
        _context.Comments.Add(model);
        await _context.SaveChangesAsync();
        return Redirect("/Ciudad/Details/ " + model.ciudadid);
    }
        return Redirect("/Ciudad/Index");
    
}



}