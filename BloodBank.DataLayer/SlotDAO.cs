using BloodBank.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.DataLayer
{
    public class SlotDAO
    {
        public static string Connstr;
        public SlotDAO() {
            Connstr = "Data Source=DESKTOP-7MPIGBL\\SQLEXPRESS;Initial Catalog=BloodBank;Integrated Security=True";
        }

        public void AddSlot(Slot slot) {
            using (SqlConnection con = new SqlConnection(Connstr)) {
                SqlCommand cmd = new SqlCommand("Insert into Slots Values(@SlotId, @SlotTime, @HospitalName)", con);
                cmd.Parameters.AddWithValue("@SlotId", slot.SlotId);
                cmd.Parameters.AddWithValue("@SlotTime", slot.SlotTime);
                cmd.Parameters.AddWithValue("@HospitalName", slot.HospitalHospitalName);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void EditSlot(Slot slot) {
            slot.SlotId = Guid.NewGuid();
            using (SqlConnection con = new SqlConnection(Connstr))
            {
                SqlCommand cmd = new SqlCommand("Update Slots set SlotTime=@SlotTime, HospitalHospitalName=@HospitalName where SlotId=@SlotId", con);
                cmd.Parameters.AddWithValue("@SlotId", slot.SlotId);
                cmd.Parameters.AddWithValue("@SlotTime", slot.SlotTime);
                cmd.Parameters.AddWithValue("@HospitalName", slot.HospitalHospitalName);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteSlot(Guid SlotId) {
            using (SqlConnection con = new SqlConnection(Connstr)) {
                SqlCommand cmd = new SqlCommand("Delete from Slots where SlotId=@SlotId", con);
                cmd.Parameters.AddWithValue("@SlotId", SlotId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Slot GetSlot(Guid SlotId) {
            Slot s = new Slot();
            using (SqlConnection con = new SqlConnection(Connstr)) {
                SqlCommand cmd = new SqlCommand("Select * from Slots where SlotId=@SlotId", con);
                cmd.Parameters.AddWithValue("@SlotId",SlotId);
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader()) { 
                    reader.Read();
                    s.SlotId = (Guid)reader["SlotId"];
                    s.SlotTime = (DateTime)reader["SlotTime"];
                    s.HospitalHospitalName = reader["HospitalHospitalName"].ToString();
                }
                return s;
            }
        }

        public IEnumerable<Slot> GetAllSlots()
        {
            
            using (SqlConnection con = new SqlConnection(Connstr))
            {
                List<Slot> lst = new List<Slot>();
                SqlCommand cmd = new SqlCommand("Select * from Slots", con);
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read()){
                        Slot s = new Slot();
                        s.SlotId = (Guid)reader["SlotId"];
                        s.SlotTime = (DateTime)reader["SlotTime"];
                        s.HospitalHospitalName = reader["HospitalHospitalName"].ToString();
                        lst.Add(s);
                    }
                }
                return lst;
            }
        }

        public IEnumerable<Slot> GetSlotsByHospital(string HospitalName){
            List<Slot> lst = new List<Slot>();
            using (SqlConnection con = new SqlConnection(Connstr)) {
                SqlCommand cmd = new SqlCommand("Select * from Slots where HospitalHospitalName=@HospitalName", con);
                cmd.Parameters.AddWithValue("@HospitalName", HospitalName);
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader()) {
                    while (reader.Read()) {
                        Slot s = new Slot();
                        s.SlotId = (Guid)reader["SlotId"];
                        s.SlotTime = (DateTime)reader["SlotTime"];
                        s.HospitalHospitalName = reader["HospitalHospitalName"].ToString();
                        lst.Add(s);
                    }
                }
                return lst;
            }

        }
    }
}
