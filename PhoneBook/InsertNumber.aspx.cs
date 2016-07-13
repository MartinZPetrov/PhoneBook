using Phonebook.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Phonebook
{
    public partial class InsertNumber : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            PhoneNumber pn = new PhoneNumber();
            pn.PNumber = tb_PhoneNmb.Text;
            pn.PersonID = Convert.ToInt32(Request.QueryString["id"]);
            DAL.PhoneNumbersDAL.InsertNumber(pn);
            string redirect = UrlConstants.PHONENUMBER + "?id={0}";
            Response.Redirect(string.Format(redirect, pn.PersonID));
        }
    }
}