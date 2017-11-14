using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Stypendium.Models
{
    public class Person
    {
        public int Id { set; get; }
        public string Name { set; get; }
        
        /*private int id;
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
        }*/
    }
}