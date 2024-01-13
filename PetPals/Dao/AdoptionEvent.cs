using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using PetPals.Entities;
using PetPals.Util;

namespace PetPals.Dao
{
    internal class AdoptionEvent
    {
        public string connectionString;
        SqlCommand cmd = null;
        public AdoptionEvent()
        {
            connectionString = DbConnUtil.getConnectionString();
            cmd = new SqlCommand();
        }
        public int EventID { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string Location { get; set; }
        public List<AdoptionEvent> ShowAllEvents()
        {
            List<AdoptionEvent> allEvents = new List<AdoptionEvent>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                cmd.CommandText = "select * from AdoptionEvents";
                cmd.Connection = conn;
                conn.Open();
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        AdoptionEvent adoptionEvent = new AdoptionEvent();
                        adoptionEvent.EventID = (int)reader["EventID"];
                        adoptionEvent.EventName = (string)reader["EventName"];
                        adoptionEvent.EventDate = (DateTime)reader["EventDate"];
                        adoptionEvent.Location = (string)reader["Location"];
                        allEvents.Add(adoptionEvent);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                }
            }

            return allEvents;
        }

        public string RegisterParticipant(Participants participant)
        {
            string response = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    cmd.CommandText = "insert into Participants OUTPUT INSERTED.EventID values (@name, @type, @id)";
                    cmd.Parameters.AddWithValue("@name", participant.ParticipantName);
                    cmd.Parameters.AddWithValue("@type", participant.ParticipantType);
                    cmd.Parameters.AddWithValue("@id", participant.EventId);

                    cmd.Connection = conn;
                    conn.Open();
                    object newId = cmd.ExecuteScalar();

                    if (newId != null)
                    {
                        response = "Thank you for registering to the event. Your ID : " + newId;
                    }
                    else
                    {
                        response = "Something went wrong";
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
                Console.Write("\nReturning to previous menu...");
                Thread.Sleep(2000);
            }
            return response;
        }

        public string Adopt(int petId, int userId)
        {
            string response = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    cmd.CommandText = "update Pets set AvailableForAdoption=0 where PetID=@petid";
                    cmd.Parameters.AddWithValue("@petid", petId);
                    cmd.Connection = conn;
                    conn.Open();
                    int petUpdate = cmd.ExecuteNonQuery();
                    cmd.CommandText = "insert into Adoption values(@petid, @userid);";
                    cmd.Parameters.AddWithValue("@userid", userId);
                    int userUpdate = cmd.ExecuteNonQuery();
                    if (userUpdate > 0 && petUpdate > 0)
                    {
                        response = "Congratulations! You have successfully adopted a pet!";
                    }
                    else
                        response = "Invalid Pet Adoption";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine(ex.Message);
                Console.Write("\nReturning to previous menu...");
                Thread.Sleep(2000);
            }
            return response;
        }
        public string HostEvent()
        {
            string response = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    cmd.CommandText = "insert into AdoptionEvents OUTPUT INSERTED.EventID values (@name, @date, @location)";
                    cmd.Parameters.AddWithValue("@name", EventName);
                    cmd.Parameters.AddWithValue("@date", EventDate);
                    cmd.Parameters.AddWithValue("@location", Location);

                    cmd.Connection = conn;
                    conn.Open();
                    object newId = cmd.ExecuteScalar();

                    if (newId != null)
                    {
                        response = "Event Registered Successfully. ID : " + newId;
                    }
                    else
                    {
                        response = "Something went wrong";
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
                Console.Write("\nReturning to previous menu...");
                Thread.Sleep(2000);
            }
            return response;
        }

        public List<Participants> GetAllParticipants()
        {
            List<Participants> participants1 = new List<Participants>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                cmd.CommandText = "select * from Participants";
                cmd.Connection = conn;
                conn.Open();
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Participants participants = new Participants();
                        participants.ParticipantID = (int)reader["ParticipantID"];
                        participants.ParticipantName = (string)reader["ParticipantName"];
                        participants.ParticipantType = (string)reader["ParticipantType"];
                        participants.EventId = (int)reader["EventID"];
                        participants1.Add(participants);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                    Console.WriteLine(ex.Message);
                    Console.Write("\nReturning to previous menu...");
                    Thread.Sleep(2000);
                }
            }
            return participants1;
        }
        public override string ToString()
        {
            return $"Event ID : {EventID}\n Name: {EventName}\n Date: {EventDate}\n Location: {Location}\n\n";
        }
    }
}