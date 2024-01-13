using PetPals.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Dao
{
    internal interface IPetsRepo
    {
        //Methods for Pet class services
        void AddPet(string petName, int petAge, string petBreed, string petType);
        void RemovePet(int petID);
        List<Pet> ShowAvailablePets();

    }
}
