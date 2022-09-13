using BloodBank.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.DataLayer
{
    public class BloodReqDAO
    {
        public static string Connstr;
        public BloodReqDAO()
        {
            Connstr = "Data Source=DESKTOP-7MPIGBL\\SQLEXPRESS;Initial Catalog=BloodBank;Integrated Security=True";
        }

        public void AddBloodReq(BloodReq req)
        {
            using (SqlConnection con = new SqlConnection(Connstr))
            {
                SqlCommand cmd = new SqlCommand("Insert into BloodReqs Values(@ReqId,@PatientName,@PatientPhoneNo,@BloodGroup,@Status,@UserName, @SlotId)", con);
                cmd.Parameters.AddWithValue("@ReqId", req.ReqId);
                cmd.Parameters.AddWithValue("@PatientName", req.PatientName);
                cmd.Parameters.AddWithValue("@PatientPhoneNo", req.PatientPhoneNo);
                cmd.Parameters.AddWithValue("@BloodGroup", req.BloodGroup);
                cmd.Parameters.AddWithValue("@Status", req.Status);
                cmd.Parameters.AddWithValue("@UserName", req.UserUserName);
                cmd.Parameters.AddWithValue("@SlotId", req.SlotSlotId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void EditBloodReq(BloodReq req)
        {
            using (SqlConnection con = new SqlConnection(Connstr))
            {
                SqlCommand cmd = new SqlCommand("Update BloodReqs set PatientName=@PatientName,PatientPhoneNo=@PatientPhoneNo,BloodGroup=@BloodGroup,Status=@Status,UserUserName=@UserName,SlotSlotId=@SlotId where ReqId=@ReqId", con);
                cmd.Parameters.AddWithValue("@ReqId", req.ReqId);
                cmd.Parameters.AddWithValue("@PatientName", req.PatientName);
                cmd.Parameters.AddWithValue("@PatientPhoneNo", req.PatientPhoneNo);
                cmd.Parameters.AddWithValue("@BloodGroup", req.BloodGroup);
                cmd.Parameters.AddWithValue("@Status", req.Status);
                cmd.Parameters.AddWithValue("@UserName", req.UserUserName);
                cmd.Parameters.AddWithValue("@SlotId", req.SlotSlotId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteBloodReq(Guid ReqId) {
            using (SqlConnection con = new SqlConnection(Connstr)) {
                SqlCommand cmd = new SqlCommand("Delete from BloodReqs where ReqId=@ReqId",con);
                cmd.Parameters.AddWithValue("@ReqId", ReqId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<BloodReq> GetBloodReqByUser(string UserName) {
            List<BloodReq> lst = new List<BloodReq>();
            using (SqlConnection con = new SqlConnection(Connstr)) {
                SqlCommand cmd = new SqlCommand("Select * from BloodReqs where UserUserName=@UserName", con);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader()) {
                    while (reader.Read()) {
                        BloodReq req = new BloodReq();
                        req.ReqId = (Guid)reader["ReqId"];
                        req.PatientName = reader["PatientName"].ToString();
                        req.PatientPhoneNo = reader["PatientPhoneNo"].ToString();
                        req.BloodGroup = reader["BloodGroup"].ToString();
                        req.Status = reader["Status"].ToString();
                        req.UserUserName = reader["UserUserName"].ToString();
                        req.SlotSlotId = (Guid)reader["SlotSlotId"];
                        lst.Add(req);
                    }
                }
                return lst;
            }
        }

        public BloodReq GetBloodReq(Guid ReqId) {
            BloodReq req = new BloodReq();
            using (SqlConnection con = new SqlConnection(Connstr))
            {
                SqlCommand cmd = new SqlCommand("Select * from BloodReqs where ReqId=@ReqId", con);
                cmd.Parameters.AddWithValue("@ReqId", ReqId);
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    req.ReqId = (Guid)reader["ReqId"];
                    req.PatientName = reader["PatientName"].ToString();
                    req.PatientPhoneNo = reader["PatientPhoneNo"].ToString();
                    req.BloodGroup = reader["BloodGroup"].ToString();
                    req.Status = reader["Status"].ToString();
                    req.UserUserName = reader["UserUserName"].ToString();
                    req.SlotSlotId = (Guid)reader["SlotSlotId"];
                }
                return req;
            }
        }

        public IEnumerable<BloodReq> GetBloodReqByOthers(string UserName) {
            List<BloodReq> lst = new List<BloodReq>();
            using (SqlConnection con = new SqlConnection(Connstr))
            {
                SqlCommand cmd = new SqlCommand("Select * from BloodReqs where UserUserName!=@UserName", con);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        BloodReq req = new BloodReq();
                        req.ReqId = (Guid)reader["ReqId"];
                        req.PatientName = reader["PatientName"].ToString();
                        req.PatientPhoneNo = reader["PatientPhoneNo"].ToString();
                        req.BloodGroup = reader["BloodGroup"].ToString();
                        req.Status = reader["Status"].ToString();
                        req.UserUserName = reader["UserUserName"].ToString();
                        req.SlotSlotId = (Guid)reader["SlotSlotId"];
                        lst.Add(req);
                    }
                }
                return lst;
            }
        } public IEnumerable<BloodReq> GetAllBloodReqs() {
            List<BloodReq> lst = new List<BloodReq>();
            using (SqlConnection con = new SqlConnection(Connstr))
            {
                SqlCommand cmd = new SqlCommand("Select * from BloodReqs", con);
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        BloodReq req = new BloodReq();
                        req.ReqId = (Guid)reader["ReqId"];
                        req.PatientName = reader["PatientName"].ToString();
                        req.PatientPhoneNo = reader["PatientPhoneNo"].ToString();
                        req.BloodGroup = reader["BloodGroup"].ToString();
                        req.Status = reader["Status"].ToString();
                        req.UserUserName = reader["UserUserName"].ToString();
                        req.SlotSlotId = (Guid)reader["SlotSlotId"];
                        lst.Add(req);
                    }
                }
                return lst;
            }
        }

        public IEnumerable<BloodReq> GetBloodReqByStatus(string Status) {
            List<BloodReq> lst = new List<BloodReq>();
            using (SqlConnection con = new SqlConnection(Connstr))
            {
                SqlCommand cmd = new SqlCommand("Select * from BloodReqs where Status=@Status", con);
                cmd.Parameters.AddWithValue("@Status", Status);
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        BloodReq req = new BloodReq();
                        req.ReqId = (Guid)reader["ReqId"];
                        req.PatientName = reader["PatientName"].ToString();
                        req.PatientPhoneNo = reader["PatientPhoneNo"].ToString();
                        req.BloodGroup = reader["BloodGroup"].ToString();
                        req.Status = reader["Status"].ToString();
                        req.UserUserName = reader["UserUserName"].ToString();
                        req.SlotSlotId = (Guid)reader["SlotSlotId"];
                        lst.Add(req);
                    }
                }
                return lst;
            }
        }
    }
}
