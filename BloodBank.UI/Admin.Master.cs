using System;

namespace BloodBank.UI
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userrole"] is null || !Session["userrole"].ToString().Equals("Admin"))
            {
                Session.Abandon();
                Response.Redirect("../login.aspx");
            }
        }

        protected void AdminLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("../login.aspx");
        }
    }
}