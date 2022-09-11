using BloodBank.DataLayer;
using BloodBank.Entities;
using System;

namespace BloodBank.UI
{
    public partial class Signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SignUpWarningText.Text = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            UserDAO userDAO = new UserDAO();
            if (userDAO.isUserNameAvailable(userName.Text))
            {
                SignUpWarningText.Text = "UserName is Already Taken";
            }
            else
            {
                User usr = new User();
                usr.UserName = userName.Text;
                usr.Password = password.Text;
                usr.FirstName = firstName.Text;
                usr.LastName = lastName.Text;
                usr.Age = age.Text;
                usr.ContactNumber = contactNumber.Text;
                usr.Weight = weight.Text;
                usr.Email = email.Text;
                if (male.Checked) usr.Gender = "male";
                if (female.Checked) usr.Gender = "female";
                usr.BloodGroup = BloodGroupDropDown.Text;
                usr.Role = "User";
                userDAO.AddUser(usr);

                Response.Redirect("login.aspx");
            }
        }
    }
}