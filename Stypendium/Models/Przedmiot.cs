using System.ComponentModel.DataAnnotations;

namespace Stypendium.Models
{
    public class Przedmiot
    {
        [Key]
        public string NazwaPrzedmiotu { set; get; }
        public double Ocena { set; get; }

        public Przedmiot(string nazwaPrzedmiotu, double ocena)
        {
            NazwaPrzedmiotu = nazwaPrzedmiotu;
            Ocena = ocena;
        }

        public Przedmiot()
        {
        }
    }
}