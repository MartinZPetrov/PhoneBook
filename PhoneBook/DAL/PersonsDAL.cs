using Phonebook.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Phonebook.DAL
{
    /// <summary>
    ///  Person Data Access Layer
    /// </summary>
    public class PersonsDAL
    {
        //method that returns list of persons
        public static List<Person> GetPersons(string orderField = null, bool asc = false)
        {
            // create empty list which we'll populate width persons
            List<Person> persons = new List<Person>();

            // use ConfigurationManager class to read connection string from Web.config file
            string CS = ConfigurationManager.ConnectionStrings["PhonebookConnectionString"].ConnectionString;

            // create new SQLConnection Object
            using (SqlConnection con = new SqlConnection(CS))   
            {
                //Create new SqlCommand object.
                SqlCommand cmd = null;
                if (!string.IsNullOrEmpty(orderField))
                {
                    cmd = new SqlCommand("Select * from Persons ORDER BY " + orderField + (asc ? " ASC" : " DESC"), con);
                }
                else
                {
                    cmd = new SqlCommand("Select * from Persons", con);
                }
                con.Open();

                // Create new SqlDataReader object by invoking ExecuteReader method.
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    // as long as there are more records to read Read == true
                    while (rdr.Read())
                    {
                        Person p = new Person();
                        p.PersonID = Convert.ToInt32(rdr["PersonID"]);
                        p.FirstName = rdr["FirstName"].ToString();
                        p.LastName = rdr["LastName"].ToString();
                        p.Address = rdr["Address"].ToString();

                        // populate list
                        persons.Add(p);
                    }
                }
            }
            return persons;
        }

        //method that returns list of persons
        //by search criteria
        public static List<Person> GetPersonsSearch(string searchText)
        {
            // create empty list which we'll populate width persons
            List<Person> persons = new List<Person>();

            // use ConfigurationManager class to read connection string from Web.config file
            string CS = ConfigurationManager.ConnectionStrings["PhonebookConnectionString"].ConnectionString;

            // create new SQLConnection Object
            using (SqlConnection con = new SqlConnection(CS))
            {
                //Create new SqlCommand object.
                //Full outer joins is used in order to retrieve all records
                //which match the search criteria
                string query = @"SELECT DISTINCT Persons.*
                                FROM Persons
                                FULL OUTER JOIN PhoneNumbers on PhoneNumbers.PersonID = Persons.PersonID
                                WHERE FirstName LIKE '%" + searchText + "%' or LastName LIKE '%" + searchText + "%' OR Address LIKE '%" 
                                                         + searchText + "%' or PhoneNumber LIKE '%" + searchText + "%'";

                SqlCommand cmd = new SqlCommand(query, con);
                
                con.Open();

                // Create new SqlDataReader object by invoking ExecuteReader method.
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    // as long as there are more records to read Read == true
                    while (rdr.Read())
                    {
                        Person p = new Person();
                        p.PersonID = Convert.ToInt32(rdr["PersonID"]);
                        p.FirstName = rdr["FirstName"].ToString();
                        p.LastName = rdr["LastName"].ToString();
                        p.Address = rdr["Address"].ToString();
                        // populate list
                        persons.Add(p);
                    }
                }
            }
            return persons;
        }

        // I'll give you person Id you return me persons data
        public static Person GetPerson(int pID)
        {
            string CS = ConfigurationManager.ConnectionStrings["PhonebookConnectionString"].ConnectionString;
            
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Select * from Persons where PersonID=@PersonID", con);
                cmd.Parameters.Add(new SqlParameter("@PersonID", pID));
                con.Open();

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    rdr.Read();
                    Person p = new Person();
                    p.PersonID = Convert.ToInt32(rdr["PersonID"]);
                    p.FirstName = rdr["FirstName"].ToString();
                    p.LastName = rdr["LastName"].ToString();
                    p.Address = rdr["Address"].ToString();

                    return p;
                }
            }
        }

        //Update person method
        public static void UpdatePerson (Person p)
        {
            string CS = ConfigurationManager.ConnectionStrings["PhonebookConnectionString"].ConnectionString;
            
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Update Persons set FirstName=@FirstName, LastName=@LastName, Address=@Address where PersonID=@PersonID", con);
                cmd.Parameters.Add(new SqlParameter("@PersonID", p.PersonID));
                cmd.Parameters.Add(new SqlParameter("@FirstName", p.FirstName));
                cmd.Parameters.Add(new SqlParameter("@LastName", p.LastName));
                cmd.Parameters.Add(new SqlParameter("@Address", p.Address));
                con.Open();
                cmd.ExecuteNonQuery();
            }

        }

        // Insert person method
        public static void InsertPerson(Person p)
        {
            string CS = ConfigurationManager.ConnectionStrings["PhonebookConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Insert into Persons (FirstName, LastName, Address) values (@FirstName, @LastName, @Address)",con);
                cmd.Parameters.Add(new SqlParameter("@FirstName", p.FirstName));
                cmd.Parameters.Add(new SqlParameter("@LastName", p.LastName));
                cmd.Parameters.Add(new SqlParameter("@Address", p.Address));
                
                con.Open();
                var n = cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Delete person BY param
        /// </summary>
        /// <param name="pID"></param>
        public static void DeletePerson(int pID)
        {
            string CS = ConfigurationManager.ConnectionStrings["PhonebookConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Delete from Persons where PersonID=@PersonID", con);
                cmd.Parameters.Add(new SqlParameter("@PersonID", pID));
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}