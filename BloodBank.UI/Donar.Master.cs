using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BloodBank.UI
{
    public partial class Donar : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userrole"] is null || !Session["userrole"].ToString().Equals("User"))
            {
                Session.Abandon();
                Response.Redirect("../login.aspx");
            }
        }

        protected void DonarLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("../login.aspx");
        }
    }
}