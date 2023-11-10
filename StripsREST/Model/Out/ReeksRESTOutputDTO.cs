using StripsBL.DTOs;

namespace StripsREST.Model.Out;

public class ReeksRESTOutputDTO
{
     public string Url { get; set; }
     public string Naam { get; set; }
    public int Aantal { get; set; }
    public List<StripDTO> Strips { get; set; }

    public ReeksRESTOutputDTO(string url, string naam, int aantal, List<StripDTO> strips)
    {
        Url = url;
        Naam = naam;
        Aantal = aantal;
        Strips = strips;
    }
}