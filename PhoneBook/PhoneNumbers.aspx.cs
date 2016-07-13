using Phonebook.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Phonebook
{
    public partial class PhoneNumbers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gv_PhoneNumbers.DataSource = PhoneNumbersDAL.GetNumbersByPersonID(Convert.ToInt32(Request.QueryString["id"]));
                gv_PhoneNumbers.DataBind();
            }
        }

        protected void lbtn_Delete_Command(object sender, CommandEventArgs e)
        {
            PhoneNumbersDAL.DeleteNumber(Convert.ToInt32(e.CommandArgument));
            gv_PhoneNumbers.DataSource = PhoneNumbersDAL.GetNumbersByPersonID(Convert.ToInt32(Request.QueryString["id"]));
            gv_PhoneNumbers.DataBind();

        }

        protected void btn_InsertNumber_Click(object sender, EventArgs e)
        {
            string redirect = UrlConstants.INSERTNUMBER + "?id={0}";
            Response.Redirect(string.Format(redirect, Request.QueryString["id"]));
        }

        protected void btn_BackToPhoneBook_Click(object sender, EventArgs e)
        {
            Response.Redirect(UrlConstants.PHONEBOOK);
        }
    }
}