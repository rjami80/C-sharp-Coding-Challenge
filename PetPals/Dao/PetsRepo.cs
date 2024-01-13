using PetPals.Entities;
using PetPals.Exceptions;
using PetPals.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Dao
{
    internal class PetsRepo : IPetsRepo
    {
        public string connectionString;
        SqlCommand cmd = null;

        public PetsRepo()
        {
            connectionString = DbConnUtil.getConnectionString();
            cmd = new SqlCommand();
        }
 
        public void AddPet(string petName, int petAge, string petBreed, string petType)
        {
            try
            {
                if (petAge > 0)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        cmd.CommandText = "insert into Pets(Name, age, Breed, Type, AvailableForAdoption) values(@name, @age, @breed, @type, @avbl)";
                        cmd.Parameters.AddWithValue("@name", petName);
                        cmd.Parameters.AddWithValue("@age", petAge);
                        cmd.Parameters.AddWithValue("@breed", petBreed);
                        cmd.Parameters.AddWithValue("@type", petType);
                        bool avlb = true;
                        cmd.Parameters.AddWithValue("@avbl", avlb);
                        cmd.Connection = conn;
                        conn.Open();
                        try
                        {
                            int addPetStatus = cmd.ExecuteNonQuery();
                            if (addPetStatus > 0)
                            {
                                Console.WriteLine("Pet data added successfully");
                            }
                            else
                            {
                                Console.WriteLine("Something went wrong");
                            }
                        }
                        catch(Exception ex) 
                        {
                            Console.WriteLine();
                            Console.WriteLine(ex.Message);
                            Console.ReadLine();
                        }
                    }
                }
                else
                {
                    throw new InvalidPetAgeException("Pet age has to be a postivive number");
                }
            }
            catch(InvalidPetAgeException ey)
            {
                Console.WriteLine();
                Console.WriteLine(ey.Message);
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine(ex.Message);
                Console.ReadLine();            }
        }
        public void RemovePet(int petID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    cmd.CommandText = "delete from Pets where PetID=@petid";
                    cmd.Parameters.AddWithValue("@petid", petID);
                    cmd.Connection = conn;
                    conn.Open();
                    try
                    {
                        int removePetStatus = cmd.ExecuteNonQuery();
                        if (removePetStatus > 0)
                            Console.WriteLine("Removed pet data successfully");
                        else
                        {
                            throw new PetNotFoundException("It seems like the petID you entered is invalid");
                        }
                    }
                    catch (Exception ez)
                    {
                        Console.WriteLine();
                        Console.WriteLine(ez.Message);
                        Console.ReadLine();
                    }
                }
            }
            catch (PetNotFoundException ey)
            {
                Console.WriteLine();
                Console.WriteLine(ey.Message);
                Console.ReadLine();
            }
            catch (Exception ex) 
            {
                Console.WriteLine();
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
        public List<Pet> ShowAvailablePets()
        {
            List<Pet> availablePets = new List<Pet>();
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                cmd.CommandText = "select * from Pets where AvailableForAdoption=1";
                cmd.Connection = conn;
                conn.Open();
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Pet pet = new Pet();
                        pet.name = (string)reader["Name"];
                        pet.age = (int)reader["age"];
                        pet.type = (string)reader["Type"];
                        pet.breed = (string)reader["Breed"];
                        availablePets.Add(pet);
                    }
                }
                catch (Exception ex) 
                {
                    Console.WriteLine();
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                }
            }

            return availablePets;
        }
        
    }
}
