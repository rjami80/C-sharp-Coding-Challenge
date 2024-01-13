using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Entities
{
    internal class Cat:Pet
    {
        public string catColour {  get; set; }
        public Cat()
        {

        }
        public Cat(string name, int age, string breed, string catColour) : base(name, age, breed)
        {
            this.catColour = catColour;
        }
    }
}
