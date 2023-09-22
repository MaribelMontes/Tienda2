namespace Practice2.Models;

public class Album
{
    public int id { get; set; }
    public string? name{ get; set; }
    public string? image_url { get; set; }
    public int? cantanteid { get; set; }
    public Cantante? Cantante { get; set; }
 
}

