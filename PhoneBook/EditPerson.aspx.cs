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
    public partial class EditPerson : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Person p = PersonsDAL.GetPerson(Convert.ToInt32(Request.QueryString["id"]));
                tb_firstName.Text = p.FirstName;
                tb_lastName.Text = p.LastName;
                tb_Address.Text = p.Address;
            }
        }

        protected void btn_Update_Click(object sender, EventArgs e)
        {
            Person p = new Person();
            p.FirstName = tb_firstName.Text;
            p.LastName = tb_lastName.Text;
            p.PersonID = Convert.ToInt32(Request.QueryString["id"]);
            p.Address = tb_Address.Text;
            PersonsDAL.UpdatePerson(p);

            Response.Redirect(UrlConstants.PHONEBOOK);
        }

        protected void btn_BackToPhoneBook_Click(object sender, EventArgs e)
        {
            Response.Redirect(UrlConstants.PHONEBOOK);
        }
    }
}