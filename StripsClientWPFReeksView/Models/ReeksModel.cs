using System.Collections.Generic;

namespace StripsClientWPFReeksView.Models;

public class ReeksModel
{
    public string Naam { get; set; }
    public int Aantal { get; set; }
    public List<StripModel> Strips { get; set; }
}