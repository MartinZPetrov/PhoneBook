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
    /// Phone Numbers Data Access Layer
    /// </summary>
    public class PhoneNumbersDAL
    {
        public static List<PhoneNumber> GetNumbersByPersonID(int personID)
        {
            // create empty list which we'll populate width phone numbers
            List<PhoneNumber> pnList = new List<PhoneNumber>();

            // use ConfigurationManager class to read connection string from Web.config file
            string CS = ConfigurationManager.ConnectionStrings["PhonebookConnectionString"].ConnectionString;

            // create new SQLConnection object
            using (SqlConnection con = new SqlConnection(CS))
            {
                //Create new SqlCommand object and add parameter
                SqlCommand cmd = new SqlCommand("Select * from PhoneNumbers where PersonID=@PersonID", con);
                cmd.Parameters.Add(new SqlParameter("@PersonID", personID));
                con.Open();

                // Create new SqlDataReader object
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        PhoneNumber pn = new PhoneNumber();
                        pn.PhoneID = Convert.ToInt32(rdr["PhoneID"]);
                        pn.PNumber = rdr["PhoneNumber"].ToString();
                        pn.PersonID = Convert.ToInt32(rdr["PersonID"]);
                        // populate list
                        pnList.Add(pn);
                    }
                }
            }
            return pnList;
        }

        /// <summary>
        /// Retrieve phone
        /// </summary>
        /// <param name="numberID"></param>
        /// <returns></returns>
        public static PhoneNumber GetNumber(int numberID)
        {
            string CS = ConfigurationManager.ConnectionStrings["PhonebookConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Select * from PhoneNumbers where PhoneID=@PhoneID", con);
                cmd.Parameters.Add(new SqlParameter("@PhoneID", numberID));
                con.Open();

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    rdr.Read();
                    PhoneNumber pn = new PhoneNumber();
                    pn.PhoneID = Convert.ToInt32(rdr["PhoneID"]);
                    pn.PNumber = rdr["PhoneNumber"].ToString();
                    pn.PersonID = Convert.ToInt32(rdr["PersonID"]);
                    return pn;
                }
            }
        }
        /// <summary>
        /// Update phone
        /// </summary>
        /// <param name="pn"></param>
        public static void UpdateNumber(PhoneNumber pn)
        {
            string CS = ConfigurationManager.ConnectionStrings["PhonebookConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Update PhoneNumbers set PhoneNumber=@PhoneNumber where PhoneID=@PhoneID", con);
                cmd.Parameters.Add(new SqlParameter("@PhoneID", pn.PhoneID));
                cmd.Parameters.Add(new SqlParameter("@PhoneNumber", pn.PNumber));
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Delete by ID
        /// </summary>
        /// <param name="numberID"></param>
        public static void DeleteNumber(int numberID)
        {
            string CS = ConfigurationManager.ConnectionStrings["PhonebookConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Delete from PhoneNumbers where PhoneID=@PhoneID", con);
                cmd.Parameters.Add(new SqlParameter("@PhoneID", numberID));
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        
        /// <summary>
        /// Insert PhoneNumber
        /// </summary>
        /// <param name="pn"></param>
        public static void InsertNumber(PhoneNumber pn)
        {
            string CS = ConfigurationManager.ConnectionStrings["PhonebookConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Insert into PhoneNumbers (PhoneNumber,PersonID)" + 
                "values (@PhoneNumber, @PersonID)", con);
                cmd.Parameters.Add(new SqlParameter("@PhoneNumber",pn.PNumber));
                cmd.Parameters.Add(new SqlParameter("@PersonID",pn.PersonID));
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}