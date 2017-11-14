using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Stypendium.Models
{
    public class Person
    {
        
        private int id;
        private string name;

        

        public string Name
        {
            get => name;
            set => name = value;
        }
        
        public int Id
        {
            get => id;
            set => id = value;
        }
    }
}