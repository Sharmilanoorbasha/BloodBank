using BloodBank.DataLayer;
using System;

namespace BloodBank.UI
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            UserDAO userDAO = new UserDAO();
            if (userDAO.isUserNameAvailable(TextBox1.Text))
            {
                var user = userDAO.GetUser(TextBox1.Text);
                Session["username"] = user.UserName;
                Session["userrole"] = user.Role;
                Session.Timeout = 60;

                if (TextBox2.Text.Equals(user.Password))
                {
                    Label1.Text = "";
                    if (user.Role.Equals("Admin"))
                        Response.Redirect("~/Dashboard/ListAllDonations.aspx");
                    Response.Redirect("~/DonarDashboard/ListAllDonationsForDonar.aspx");
                }
                else
                {
                    Label1.Text = "Incorrect UserName/Password";
                }
            }
            else
            {
                Label1.Text = "Incorrect UserName/Password";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("signup.aspx");
        }
    }
}