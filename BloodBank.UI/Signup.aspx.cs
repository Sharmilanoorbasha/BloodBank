using BloodBank.DataLayer;
using BloodBank.Entities;
using System;
using System.Text.RegularExpressions;

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
            else if (Convert.ToDouble(age.Text) < 18 || Convert.ToDouble(age.Text) > 65)
            {
                SignUpWarningText.Text = "Age should not be less than 18 or greater than 65";
            }
            else if (contactNumber.Text.Length != 10 || contactNumber.Text == "" || !Regex.IsMatch(contactNumber.Text, "^([7-9]{1})([0-9]{9})$".ToString()))
            {
                SignUpWarningText.Text = "Enter a valid contact Number";
            }
            else if (weight.Text == "" || Convert.ToDouble(weight.Text) < 0)
            {
                SignUpWarningText.Text = "Enter a valid weight";
            }
            else if (!Regex.IsMatch(email.Text, "^[A-Za-z0-9+_.-]+@(.+)$")) { 
                SignUpWarningText.Text = "Enter a valid email";
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