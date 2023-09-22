namespace Practice2.Models;

public class Comment
{
    public int id { get; set; }
    public string? date{ get; set; }
    public string? text { get; set; }
    public int? ciudadid { get; set; }
    public Ciudad? ciudad{ get; set; }
   
}

