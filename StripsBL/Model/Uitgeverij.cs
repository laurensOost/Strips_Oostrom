using System;
using System.Collections.Generic;

namespace StripsBL.Model
{
    public class Uitgeverij
    {
        public Uitgeverij(string naam)
        {
            Naam = naam;
        }
        public Uitgeverij(int iD, string naam)
        {
            ID = iD;
            Naam = naam;
        }
        public int ID { get; set; }
        public string Naam { get; set; }        
    }
}