
namespace Practice2.Models;

public class Cantante
{
    public int? id { get; set; }
    public string? Name { get; set; }
    
    public string? Genre { get; set; }
    
    public string? Description { get; set; }
   
    public string? Image_url { get; set; }
    
     public Cantante()
     {
        Album = new List<Album>();

     }
     public List<Album> Album { get; set; }
}