using BloodBank.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.DataLayer
{
    public class HospitalDAO
    {
        public static string Connstr;
        public HospitalDAO() { 
            Connstr = "Data Source=DESKTOP-7MPIGBL\\SQLEXPRESS;Initial Catalog=BloodBank;Integrated Security=True";
        }

        public void AddHospital(Hospital hos) {
            using (SqlConnection con = new SqlConnection(Connstr)) {
                SqlCommand cmd = new SqlCommand("Insert into Hospitals Values(@HospitalName, @City, @State, @Area, @Pincode)", con);
                cmd.Parameters.AddWithValue("@HospitalName",hos.HospitalName);
                cmd.Parameters.AddWithValue("@City",hos.City);
                cmd.Parameters.AddWithValue("@State",hos.State);
                cmd.Parameters.AddWithValue("@Area",hos.Area);
                cmd.Parameters.AddWithValue("@Pincode",hos.Pincode);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void EditHospital(Hospital hos) {
            using (SqlConnection con = new SqlConnection(Connstr))
            {
                SqlCommand cmd = new SqlCommand("Update Hospitals set City=@City,State=@State,Area=@Area,Pincode=@Pincode where HospitalName=@HospitalName", con);
                cmd.Parameters.AddWithValue("@HospitalName", hos.HospitalName);
                cmd.Parameters.AddWithValue("@City", hos.City);
                cmd.Parameters.AddWithValue("@State", hos.State);
                cmd.Parameters.AddWithValue("@Area", hos.Area);
                cmd.Parameters.AddWithValue("@Pincode", hos.Pincode);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteHospital(string HospitalName) {
            using (SqlConnection con = new SqlConnection(Connstr)) {
                SqlCommand cmd = new SqlCommand("Delete from Hospitals where HospitalName=@HospitalName",con);
                cmd.Parameters.AddWithValue("@HospitalName",HospitalName);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Hospital GetHospital(string HospitalName) {
            Hospital hos = new Hospital();
            using (SqlConnection con = new SqlConnection(Connstr)) {
                SqlCommand cmd = new SqlCommand("Select * from Hospitals where HospitalName=@HospitalName", con);
                cmd.Parameters.AddWithValue("@HospitalName", HospitalName);
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader()) {
                    reader.Read();
                    hos.HospitalName = reader["HospitalName"].ToString();
                    hos.City = reader["City"].ToString();
                    hos.State = reader["State"].ToString();
                    hos.Area = reader["Area"].ToString();
                    hos.Pincode= reader["PinCode"].ToString();
                }
                return hos;
            }
        }

        public IEnumerable<Hospital> GetAllHospitals() {
            List<Hospital> lst = new List<Hospital>();
            using (SqlConnection con = new SqlConnection(Connstr)) {
                SqlCommand cmd = new SqlCommand("Select * from Hospitals", con);
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader()) {
                    while (reader.Read()) {
                        Hospital hos = new Hospital();
                        hos.HospitalName = reader["HospitalName"].ToString();
                        hos.City = reader["City"].ToString();
                        hos.State = reader["State"].ToString();
                        hos.Area = reader["Area"].ToString();
                        hos.Pincode = reader["PinCode"].ToString();
                        lst.Add(hos);
                    }
                }
                return lst;
            }
        }
    }
}
