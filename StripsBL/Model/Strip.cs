using System;
using System.Collections.Generic;
using System.Text;

namespace StripsBL.Model
{
    public class Strip
    {
        public Strip(int iD, string titel, int? nr)
        {
            ID = iD;
            Titel = titel;
            Nr = nr;
        }

        public Strip(string titel, int? nr, Reeks reeks, Uitgeverij uitgeverij, List<Auteur> auteurs)
        {
            Titel = titel;
            Nr = nr;
            Reeks = reeks;
            Uitgeverij = uitgeverij;
            Auteurs = auteurs;
        }

        public Strip(int iD, string titel, int? nr, Reeks reeks, Uitgeverij uitgeverij, List<Auteur> auteurs)
        {
            ID = iD;
            Titel = titel;
            Nr = nr;
            Reeks = reeks;
            Uitgeverij = uitgeverij;
            Auteurs = auteurs;
        }

        public int ID { get; set; }
        public string Titel { get; set; }
        public int? Nr { get; set; }
        public Reeks Reeks { get; set; }
        public Uitgeverij Uitgeverij { get; set; }
        public List<Auteur> Auteurs { get; set; } = new List<Auteur>();

        public override string ToString()
        {
            return $"{Titel},{Nr},{Reeks},{Uitgeverij}";
        }
    }
}
