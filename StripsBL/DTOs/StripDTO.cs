using System.Text.Json.Serialization;

namespace StripsBL.DTOs;

public class StripDTO
{
    [JsonIgnore] 
    public int ID { get; set; }
    [JsonIgnore]
    public string Naam { get; set; }
    public string Nr { get; set; }
    public string Titel { get; set; }
    public string Url { get; set; }
    public StripDTO(int id, string naam, string nr, string titel, string url)
    {
        ID = id;
        Naam = naam;
        Nr = nr;
        Titel = titel;
        Url = url;
    }
}