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
    public partial class InsertPerson : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn_SavePerson_Click(object sender, EventArgs e)
        {
            Person p = new Person();
            p.FirstName = tb_FirstName.Text;
            p.LastName = tb_LastName.Text;
            p.Address = tb_Address.Text;
            PersonsDAL.InsertPerson(p);

            Response.Redirect(UrlConstants.PHONEBOOK);
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect(UrlConstants.PHONEBOOK);
        }
    }
}