using System.ComponentModel.DataAnnotations.Schema;
namespace Practice2.Models;

public class Movie
{
    public int? id { get; set; }
    public string? title { get; set; }
    public string? year { get; set; }
    public string? director { get; set; }
    public string? genre { get; set; }
    public string? rating { get; set; }
    public string? description { get; set; }
     public string? poster{ get; set; }
   [NotMapped]
    public string? image_url { get; set; }
     
}