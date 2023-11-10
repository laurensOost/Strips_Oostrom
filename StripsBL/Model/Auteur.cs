using System;
using System.Collections.Generic;
using System.Text;

namespace StripsBL.Model
{
    public class Auteur
    {
        public Auteur(string naam)
        {
            Naam = naam;
        }
        public Auteur(int iD, string naam)
        {
            ID = iD;
            Naam = naam;
        }
        public int ID { get; set; }
        public string Naam { get; set; }
    }
}
