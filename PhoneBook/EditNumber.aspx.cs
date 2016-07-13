using Phonebook.DAL;
using Phonebook.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Phonebook
{
    public partial class EditNumber : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // if not posting back to get number by Parameter from address bar
                PhoneNumber pn = PhoneNumbersDAL.GetNumber(Convert.ToInt32(Request.QueryString["id"]));
                tb_PhoneNumber.Text = pn.PNumber;
            }
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            PhoneNumber pn = PhoneNumbersDAL.GetNumber(Convert.ToInt32(Request.QueryString["id"]));
            pn.PNumber = tb_PhoneNumber.Text;
            PhoneNumbersDAL.UpdateNumber(pn);
            RedirectBack(pn.PersonID);
        }

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            PhoneNumber pn = PhoneNumbersDAL.GetNumber(Convert.ToInt32(Request.QueryString["id"]));
            RedirectBack(pn.PersonID);
        }

        private  void RedirectBack(int personID)
        {
            string redirect = UrlConstants.PHONENUMBER + "?id={0}";
            Response.Redirect(string.Format(redirect, personID));
        }
    }
}