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
    internal class CashDonation : Donation
    {
        public string connectionString;
        SqlCommand cmd = null;
        public DateTime donationDate { get; set; }

        public CashDonation()
        {
            connectionString = DbConnUtil.getConnectionString();
            cmd = new SqlCommand();
            Date = DateTime.Now;
        }

        public string CashType { get; set; }

        public override string RecordDonation()
        {
            string response = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                cmd.CommandText = "insert into Donations  (DonorName, DonationType, DonationAmount, DonationDate) OUTPUT INSERTED.DonationID values(@name, @type, @cash, @date)";
                cmd.Parameters.AddWithValue("@name", DonorName);
                string donationType = "Cash";
                cmd.Parameters.AddWithValue("@type", donationType);
                cmd.Parameters.AddWithValue("@cash", CashType);
                cmd.Parameters.AddWithValue("@date", Date);

                cmd.Connection = conn;
                conn.Open();
                try
                {
                    object NewId = cmd.ExecuteScalar();
                    if (NewId != null)
                    {
                        response = "\nThank you for donating the Cash : " + CashType;
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
            }
            return response;
        }
    }
}
