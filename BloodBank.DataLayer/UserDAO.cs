using BloodBank.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.DataLayer
{
    public class UserDAO
    {
        public static string Connstr;
        public UserDAO()
        {
            Connstr = "Data Source=DESKTOP-7MPIGBL\\SQLEXPRESS;Initial Catalog=BloodBank;Integrated Security=True";
        }

        public void AddUser(User user)
        {
            using (SqlConnection con = new SqlConnection(Connstr))
            {
                SqlCommand cmd = new SqlCommand("Insert into Users Values(@UserName,@FirstName,@LastName,@Age,@Gender,@ContactNumber,@Email," +
                    "@Password,@Weight,@BloodGroup,@Role)", con);
                cmd.Parameters.AddWithValue("@UserName", user.UserName);
                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@Age", user.Age);
                cmd.Parameters.AddWithValue("@Gender", user.Gender);
                cmd.Parameters.AddWithValue("@ContactNumber", user.ContactNumber);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@Weight", user.Weight);
                cmd.Parameters.AddWithValue("@BloodGroup", user.BloodGroup);
                cmd.Parameters.AddWithValue("@Role", user.Role);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void EditUser(User user)
        {
            using (SqlConnection con = new SqlConnection(Connstr))
            {
                SqlCommand cmd = new SqlCommand("Update Users set FirstName=@Firstname,LastName=@LastName,Age=@Age,Gender=@Gender,ContactNumber=@ContactNumber,Email=@Email,Password=@Password,Weight=@Weight,BloodGroup=@BloodGroup,Role=@Role where UserName=@UserName", con);
                cmd.Parameters.AddWithValue("@UserName", user.UserName);
                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@Age", user.Age);
                cmd.Parameters.AddWithValue("@Gender", user.Gender);
                cmd.Parameters.AddWithValue("@ContactNumber", user.ContactNumber);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@Weight", user.Weight);
                cmd.Parameters.AddWithValue("@BloodGroup", user.BloodGroup);
                cmd.Parameters.AddWithValue("@Role", user.Role);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteUser(String UserName)
        {
            using (SqlConnection con = new SqlConnection(Connstr))
            {
                SqlCommand cmd = new SqlCommand("Delete from Users Where UserName=@UserName", con);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public User GetUser(string UserName)
        {
            User user = new User();
            using (SqlConnection con = new SqlConnection(Connstr))
            {
                SqlCommand cmd = new SqlCommand("Select * From Users Where UserName=@UserName", con);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    user.UserName = reader["UserName"].ToString();
                    user.FirstName = reader["FirstName"].ToString();
                    user.LastName = reader["LastName"].ToString();
                    user.Age = reader["Age"].ToString();
                    user.Gender = reader["Gender"].ToString();
                    user.ContactNumber = reader["ContactNumber"].ToString();
                    user.Email = reader["Email"].ToString();
                    user.Password = reader["Password"].ToString();
                    user.Weight = reader["Weight"].ToString();
                    user.BloodGroup = reader["BloodGroup"].ToString();
                    user.Role = reader["Role"].ToString();

                }
                return user;
            }
        }
        public bool isUserNameAvailable(String UserName)
        {
            User user = new User();
            using (SqlConnection con = new SqlConnection(Connstr))
            {
                SqlCommand cmd = new SqlCommand("Select * From Users Where UserName=@UserName", con);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                con.Open();
                return cmd.ExecuteReader().HasRows;
            }
            
        }
    }
}
