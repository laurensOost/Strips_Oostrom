using System;
using System.Collections.Generic;

namespace StripsBL.Model
{
    public class Reeks
    {
        public Reeks(string naam)
        {
            Naam = naam;
        }
        public Reeks(int iD, string naam)
        {
            ID = iD;
            Naam = naam;
        }
        public int ID { get; set; }
        public string Naam { get; set; }
        public List<Strip> Strips { get; set; } = new List<Strip>();
    }
}