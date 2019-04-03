using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ContactsMvcApp.Models
{
    public class ContactsDao
    {
        public List<Contact> GetAllContacts()
        {
            List<Contact> list = new List<Contact>();
            string connectionString ="Data Source=KHUSHI\\SQLEXPRESS;Initial Catalog=Training;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string queryString = "select * from Contacts";
                using (SqlCommand command = new SqlCommand(queryString, conn))
                {
                    try
                    {

                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Contact c = new Contact();

                            c.ContactID = reader.GetInt32(0);
                            c.FirstName = reader.GetString(1);
                            c.LastName = reader.GetString(2);


                            list.Add(c);
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                return list;
            }
        }
    }
}