using Phonebook.DAL;
using Phonebook.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Phonebook
{
    public partial class Phonebook : System.Web.UI.Page
    {
        static int count ;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            //when you want to execute the code only the FIRST time the page is loaded
            if (!IsPostBack)
            {
                ViewState["count"] = 1;
                FillPersonList();
            }
        }

        private void FillPersonList()
        {
            // get the data from the server and bound them
            rptPhonebookTabel.DataSource = PersonsDAL.GetPersons();
            rptPhonebookTabel.DataBind();
        }

        protected void btn_InsertNewPerson_Click(object sender, EventArgs e)
        {
            // when we click the button we will be redirected to new location
            Response.Redirect(UrlConstants.INSERTPERSON);
        }

        protected void lbtn_Delete_Command(object sender, CommandEventArgs e)
        {
            PersonsDAL.DeletePerson(Convert.ToInt32(e.CommandArgument));
            FillPersonList();
        }

        protected void lnkreq_name_click(object sender, EventArgs e)
        {
            count = Convert.ToInt32(ViewState["count"].ToString());
            ViewState["count"] = count;
            loadRepeater("FirstName+LastName", count);
        }

        protected void lnkreq_id_click(object sender, EventArgs e)
        {
            count = Convert.ToInt32(ViewState["count"].ToString());
            ViewState["count"] = count;
            loadRepeater("PersonID", count);
        }

        protected void lnkreq_address_click(object sender, EventArgs e)
        {
            count = Convert.ToInt32(ViewState["count"].ToString());
            ViewState["count"] = count;
            loadRepeater("Address", count);
        }

        /// <summary>
        /// Sorting by field in Ascending or Descending order
        /// </summary>
        /// <param name="reqname"></param>
        /// <param name="count"></param>
        protected void loadRepeater(string reqname, int count)
        {
            if (count == 0)
            {
                rptPhonebookTabel.DataSource = PersonsDAL.GetPersons(reqname, true); // ASC order
                ViewState["count"] = 1;
            }
            else if (count == 1)
            {
                rptPhonebookTabel.DataSource = PersonsDAL.GetPersons(reqname, false); // DESC Order
                ViewState["count"] = 0;
            }
            rptPhonebookTabel.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            rptPhonebookTabel.DataSource = PersonsDAL.GetPersonsSearch(tb_SearchText.Text.Trim());
            rptPhonebookTabel.DataBind();
        }
    }
}