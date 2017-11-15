using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stypendium.Models
{
    public class Kierunek
    {
        [Key]
        public int Id { set; get; }
        
        public int Semestr { get; set; }

        public Przedmiot Przedmiot { set; get; }



    }
}