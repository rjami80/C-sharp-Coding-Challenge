using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using PetPals.Dao;
using PetPals.Entities;
using PetPals.Exceptions;
using System.Linq.Expressions;

namespace PetPals
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("--------Welcome to PetPals--------");
                    Console.WriteLine("\n-------------HomePage-------------\n");
                    Console.WriteLine("\n----HomePage of the Petpals----\n");
                    Console.WriteLine("\nHere are your choices:\n");
                    Console.WriteLine("\nSelect Any Choice Below:\n");
                    Console.WriteLine("\n1. Donation Details\n");
                    Console.WriteLine("\n2. Pets Management\n");
                    Console.WriteLine("\n3. Adoption Event\n");
                    Console.WriteLine("\n4. Exit Code\n");
                    Console.Write("\nPlease enter your choice: ");
                    string mainChoice = Console.ReadLine();
                    switch (mainChoice)
                    {
                        case "1":
                            try
                            {
                                Console.Clear();
                                Console.WriteLine("\nMake a donation\n");
                                Console.WriteLine("\nYou can make a donation in following ways:\n");
                                Console.WriteLine("\n1. Cash donation\n");
                                Console.WriteLine("\n2. Item donation\n");
                                Console.Write("\nSelect the type of donation you would like to make: ");
                                string donationChoice = Console.ReadLine();
                                switch (donationChoice)
                                {
                                    case "1":
                                        try
                                        {
                                            Console.Clear();
                                            CashDonation cashDonation = new CashDonation();
                                            Console.Write("\n Enter your name: ");
                                            cashDonation.DonorName = Console.ReadLine();
                                            Console.Write("\nEnter the amount of cash you want to donate: ");
                                            cashDonation.CashType = Console.ReadLine();
                                            string res0 = cashDonation.RecordDonation();
                                            if (res0 != null)
                                            {
                                                Console.WriteLine(res0);
                                                Console.Write("\nReturning to previous menu...");
                                                Thread.Sleep(2000);
                                            }
                                            break;
                                        }
                                        catch (InsufficientFundsException e)
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine(e.Message);
                                            Console.ReadLine();
                                        }
                                        Console.WriteLine("\nPress Any key to go back to HomeScreen\n");
                                        Console.ReadLine();
                                        break;
                                    case "2":
                                        try
                                        {
                                            Console.Clear();
                                            ItemDonation itemDonation = new ItemDonation();
                                            Console.Write("\nEnter your name: ");
                                            itemDonation.DonorName = Console.ReadLine();
                                            Console.Write("\nEnter the amount of cash you want to donate: ");
                                            itemDonation.ItemType = Console.ReadLine();

                                            string res = itemDonation.RecordDonation();
                                            if (res != null)
                                            {
                                                Console.WriteLine(res);
                                                Console.Write("\nReturning to previous menu...");
                                                Thread.Sleep(2000);
                                            }
                                            break;
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine(e.Message);
                                            Console.ReadLine();
                                        }
                                        Console.WriteLine("\nPress Any key to go back to HomeScreen\n");
                                        Console.ReadLine();
                                        break;
                                    default:
                                        Console.WriteLine("\nPlease enter a valid choice\n");
                                        Console.ReadLine();
                                        break;
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine();
                                Console.WriteLine(e.Message);
                                Console.ReadLine();
                            }
                            break;
                        case "2":
                            try
                            {
                                Console.Clear();
                                Console.WriteLine("\nWelcome to Pet management Homepage\n");
                                Console.WriteLine("\nTo view the available pets for adoption, Click 1\n");
                                Console.WriteLine("\nTo add a pet data to our system, Click 2\n");
                                Console.WriteLine("\nTo remove a pet data from our system, Click 3\n");
                                Console.Write("\nEnter your choice: ");
                                string petChoice = Console.ReadLine();
                                switch (petChoice)
                                {
                                    case "1":
                                        Console.Clear();
                                        Console.WriteLine("\nHere are all the pets that are currently available for adoption:\n ");
                                        IPetsRepo showPets = new PetsRepo();
                                            List<Pet> pets = showPets.ShowAvailablePets();
                                            foreach (var v in pets)
                                            {
                                                Console.WriteLine(v + "\n");
                                            }
                                        Console.WriteLine("\nPress Any key to go back to HomeScreen\n");
                                        Console.ReadLine();
                                        break;
                                    case "2":
                                        try
                                        {
                                            Console.Clear();
                                            Console.WriteLine("\nTo add details of a pet in our system, please provide following info:\n");
                                            Console.Write("\nName: ");
                                            string petname = Console.ReadLine();
                                            Console.Write("\nAge: ");
                                            int age = int.Parse(Console.ReadLine());
                                            Console.Write("\nType(Eg: Cat, Dog, etc.): ");
                                            string type = Console.ReadLine();
                                            Console.WriteLine("Breed");
                                            string breed = Console.ReadLine();
                                            IPetsRepo addPet = new PetsRepo();
                                            addPet.AddPet(petname, age, breed, type);
                                        }
                                        catch (InvalidPetAgeException e)
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine(e.Message);
                                            Console.ReadLine();
                                        }
                                        Console.WriteLine("\nPress Any key to go back to HomeScreen\n");
                                        Console.ReadLine();
                                        break;
                                    case "3":
                                        try
                                        {
                                            Console.Clear();
                                            Console.Write("\nTo remove data of a specific pet from our system, please enter the ID of the pet: ");
                                            int removePetId = int.Parse(Console.ReadLine());
                                            IPetsRepo removePet = new PetsRepo();
                                            removePet.RemovePet(removePetId);
                                        }
                                        catch (PetNotFoundException e)
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine(e.Message);
                                            Console.ReadLine();
                                        }
                                        Console.WriteLine("\nPress Any key to go back to HomeScreen\n");
                                        Console.ReadLine();
                                        break;
                                    default:
                                        Console.WriteLine("\nPlease enter a valid choice\n");
                                        Console.ReadLine();
                                        break;
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine();
                                Console.WriteLine(e.Message);
                                Console.ReadLine();
                            }
                            break;
                        case "3":
                            try
                            {
                                Console.Clear();
                                Console.WriteLine("\t\t\tWelcome to Adoption event!");
                                Console.WriteLine("\n 1. Host a new event");
                                Console.WriteLine("\n 2. View all Events");
                                Console.WriteLine("\n 3. Register Participant for an event");
                                Console.WriteLine("\n 4. View all participants");
                                Console.WriteLine("\n 5. Adopt a pet");
                                Console.Write("\nEnter your choice: ");
                                string eventChoice = Console.ReadLine();
                                switch (eventChoice)
                                {
                                    case "1":
                                        try
                                        {
                                            Console.Clear();
                                            AdoptionEvent adoptionEvent = new AdoptionEvent();
                                            Console.WriteLine("\t\t\tEvent Registration");
                                            Console.WriteLine("\nEnter Event Name: ");
                                            adoptionEvent.EventName = Console.ReadLine();
                                            Console.WriteLine("\nEnter Event Location: ");
                                            adoptionEvent.Location = Console.ReadLine();
                                            Console.WriteLine("\nEnter the date of hosting the event (dd-MM-yyyy): ");
                                            if (DateTime.TryParseExact(Console.ReadLine(), "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime parsedDate))
                                            {
                                                adoptionEvent.EventDate = parsedDate;
                                                Console.WriteLine();
                                                string hostRes = adoptionEvent.HostEvent();

                                                if (hostRes != null)
                                                {
                                                    Console.WriteLine(hostRes);
                                                    Console.Write("\nReturning to previous menu...");
                                                    Thread.Sleep(2000);
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine();
                                                Console.WriteLine("Invalid date format.");
                                                Console.Write("\nReturning to previous menu...");
                                                Thread.Sleep(2000);
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine(ex.Message);
                                            Console.Write("\nReturning to previous menu...");
                                            Thread.Sleep(2000);
                                        }
                                        break;

                                    case "2":
                                        try
                                        {
                                            Console.Clear();
                                            Console.WriteLine("\t\tHere is a list of all pets that are currently available for adoption:\n");
                                            AdoptionEvent AllEvents = new AdoptionEvent();
                                            List<AdoptionEvent> events = AllEvents.ShowAllEvents();
                                            foreach (AdoptionEvent ae in events)
                                            {
                                                Console.WriteLine(ae);
                                            }
                                            Console.Write("\n\n\n\nPress any key to return to previous menu...");
                                            Console.ReadLine();
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine(ex.Message);
                                            Console.Write("\nReturning to previous menu...");
                                            Thread.Sleep(2000);
                                        }
                                        break;

                                    case "3":
                                        try
                                        {
                                            Console.Clear();
                                            Console.WriteLine("\t\t\tParticipant Registration for an event\n");
                                            Participants participant = new Participants();
                                            Console.WriteLine("\nEnter Participant Name: ");
                                            participant.ParticipantName = Console.ReadLine();
                                            Console.WriteLine("\nEnter Participant Type: ");
                                            participant.ParticipantType = Console.ReadLine();
                                            Console.WriteLine("\nEnter the Event ID you want to participate in: ");
                                            participant.EventId = int.Parse(Console.ReadLine());
                                            AdoptionEvent RegisterParticipent = new AdoptionEvent();

                                            Console.WriteLine();
                                            string participantRes0 = RegisterParticipent.RegisterParticipant(participant);

                                            if (participantRes0 != null)
                                            {
                                                Console.WriteLine(participantRes0);
                                                Console.Write("\nReturning to previous menu...");
                                                Thread.Sleep(2000);
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine(ex.Message);
                                            Console.Write("\nReturning to previous menu...");
                                            Thread.Sleep(2000);
                                        }
                                        break;

                                    case "4":
                                        try
                                        {
                                            Console.Clear();
                                            Console.WriteLine("\t\tHere is a list of all participants:\n");
                                            AdoptionEvent listParticipants = new AdoptionEvent();
                                            List<Participants> participants = listParticipants.GetAllParticipants();
                                            foreach (Participants p in participants)
                                            {
                                                Console.WriteLine(p);
                                            }
                                            Console.Write("\n\n\n\nPress any key to return to previous menu...");
                                            Console.ReadLine();
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine(ex.Message);
                                            Console.Write("\nReturning to previous menu...");
                                            Thread.Sleep(2000);
                                        }
                                        break;

                                    case "5":
                                        try
                                        {
                                            Console.Clear();
                                            AdoptionEvent adoption = new AdoptionEvent();
                                            Console.WriteLine("\t\t\tAdoption Page");
                                            Console.WriteLine("\nEnter the id of the pet you want to adopt: ");
                                            int petId = int.Parse(Console.ReadLine());
                                            Console.WriteLine("\nEnter User id: ");
                                            int userId = int.Parse(Console.ReadLine());
                                            Console.WriteLine();
                                            string adoptRes0 = adoption.Adopt(petId, userId);

                                            if (adoptRes0 != null)
                                            {
                                                Console.WriteLine(adoptRes0);
                                                Console.Write("\nReturning to previous menu...");
                                                Thread.Sleep(2000);
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine(ex.Message);
                                            Console.Write("\nReturning to previous menu...");
                                            Thread.Sleep(2000);
                                        }
                                        break;
                                    default:
                                        Console.Write("\nPlease enter a valid choice");
                                        Console.ReadLine();
                                        break;
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;
                        case "4":
                            Console.Write("Exiting...");
                            Thread.Sleep(1000);
                            Console.WriteLine();
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("\nPlease enter a valid choice\n");
                            Console.ReadLine();
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine();
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
            }
        }
    }
}
