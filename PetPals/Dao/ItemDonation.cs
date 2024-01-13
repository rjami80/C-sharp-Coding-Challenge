using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetPals.Entities;
using PetPals.Util;

namespace PetPals.Dao
{
    internal class ItemDonation : Donation
    {
        public string connectionString;
        SqlCommand cmd = null;

        public ItemDonation()
        {
            connectionString = DbConnUtil.getConnectionString();
            cmd = new SqlCommand();
            Date = DateTime.Now;
        }
        public string ItemType { get; set; }


        public override string RecordDonation()
        {
            
                string response = null;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    cmd.CommandText = "insert into Donations  (DonorName, DonationType, DonationItem, DonationDate) OUTPUT INSERTED.DonationID values(@name, @type, @item, @date)";
                    cmd.Parameters.AddWithValue("@name", DonorName);
                    string donationType = "Item";
                    cmd.Parameters.AddWithValue("@type", donationType);
                    cmd.Parameters.AddWithValue("@item", ItemType);
                    cmd.Parameters.AddWithValue("@date", Date);

                    cmd.Connection = conn;
                    conn.Open();
                try
                {
                    object NewId = cmd.ExecuteScalar();
                    if (NewId != null)
                    {
                        response = "\nThank you for donating the Item : " + ItemType;
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                }
                return response;
                }

        }
    }
}
