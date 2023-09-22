
namespace Practice2.Models;

public class Ciudad
{
    public int? id { get; set; }
    public string? Name { get; set; }
    
    public string? Description { get; set; }
   
    public string? Image_url { get; set; }

    public List<Comment> Comments { get; set; }
    public Ciudad()
    {
        Comments = new List<Comment>();
    }
}
