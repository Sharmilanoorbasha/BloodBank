using BloodBank.DataLayer;
using BloodBank.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BloodBank.UI.DonarDashboard
{
    public partial class ListAllDonationsForDonar : System.Web.UI.Page
    {
        BloodReqDAO reqDAO = new BloodReqDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HospitalDAO hospitalDAO = new HospitalDAO();
                DonarListView.DataSource = reqDAO.GetBloodReqByUser(Session["username"].ToString());
                OthersListView.DataSource = reqDAO.GetBloodReqByOthers(Session["username"].ToString());
                DonarListView.DataBind();
                OthersListView.DataBind();
                var hospitals = hospitalDAO.GetAllHospitals();
                AddHospitalDropDownList.DataSource = hospitals.Select(i => i.HospitalName).ToList();
                EditHospitalDropDownList.DataSource = hospitals.Select(i => i.HospitalName).ToList();
                AddHospitalDropDownList.DataBind();
                EditHospitalDropDownList.DataBind();
            }
        }
        
        protected void AddHospitalDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SlotDAO slotDAO = new SlotDAO();
            AddSlotId.DataSource = slotDAO.GetSlotsByHospital(AddHospitalDropDownList.SelectedValue).Select(i => new { Name = i.SlotTime, Value = i.SlotId }).ToList();
            AddSlotId.DataTextField = "Name";
            AddSlotId.DataValueField = "Value";
            AddSlotId.DataBind();
            AddReqOuterModal.Update();

            /*ScriptManager.RegisterStartupScript(Page, Page.GetType(), "AddBloodReqModal", "$('#AddBloodReq').modal();", true);*/

        }
    
    

        protected void CreateBloodReq_Click(object sender, EventArgs e)
        {
            if (AddPatientName.Text == "")
            {
                DonarRequestWarning.Text = "Patient Name is Required!!";
            }
            else if(AddPatientPhoneNo.Text.Length != 10 || AddPatientPhoneNo.Text == "" || !Regex.IsMatch(AddPatientPhoneNo.Text, "^([7-9]{1})([0-9]{9})$".ToString()))
            {
                DonarRequestWarning.Text = "Enter Valid PhoneNumber";
            }
            else
            {
                Entities.BloodReq req = new BloodReq();
                req.ReqId = Guid.NewGuid();
                req.PatientName = AddPatientName.Text;
                req.PatientPhoneNo = AddPatientPhoneNo.Text;
                req.BloodGroup = AddBloodGroup.Text;
                req.Status = "Open";
                req.UserUserName = Session["username"].ToString();
                Guid id = new Guid(AddSlotId.SelectedValue);
                req.SlotSlotId = id;
                reqDAO.AddBloodReq(req);
                Response.Redirect("ListAllDonationsForDonar.aspx");
            }
        }

        protected void EditBloodReq_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            Guid id = new Guid(btn.CommandArgument.ToString());
            var req = reqDAO.GetBloodReq(id);
            EditReqId.Value = req.ReqId.ToString();
            EditPatientName.Text = req.PatientName;
            EditPatientPhoneNo.Text = req.PatientPhoneNo;
            EditBloodGroup.Text = req.BloodGroup;
            EditUserName.Value = req.UserUserName;
            EditStatus.Value = req.Status;
            SlotDAO slotDAO = new SlotDAO();
            var slot = slotDAO.GetSlot(req.SlotSlotId);
            EditHospitalDropDownList.Text = slot.HospitalHospitalName;
            EditSlotId.AppendDataBoundItems = false;
            EditSlotId.Items.Clear();
            EditSlotId.DataSource = slotDAO.GetSlotsByHospital(slot.HospitalHospitalName).Select(i => new { Name = i.SlotTime, Value = i.SlotId }).ToList();
            EditSlotId.DataTextField = "Name";
            EditSlotId.DataValueField = "Value";
            EditSlotId.DataBind();
            /*Debug.WriteLine(EditSlotId.Items.Count+"\n"+EditSlotId.SelectedValue+"\n"+EditSlotId.SelectedItem);*/
            EditSlotId.SelectedValue = slot.SlotId.ToString();
            EditSlotId.SelectedItem.Text = slot.SlotTime.ToString();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "EditModal", "$('#EditModal').modal();", true);
            upModal.Update();
        }

        protected void DeleteBloodReq_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            Guid id = new Guid(btn.CommandArgument.ToString());
            reqDAO.DeleteBloodReq(id);
            Response.Redirect("ListAllDonationsForDonar.aspx");
        }

        protected void Donate_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            Guid id = new Guid(btn.CommandArgument.ToString());
            var req = reqDAO.GetBloodReq(id);
            req.Status = "Pending";
            reqDAO.EditBloodReq(req);
            Response.Redirect("ListAllDonationsForDonar.aspx");
        }

        protected void EditHospitalDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            SlotDAO slotDAO = new SlotDAO();
            EditSlotId.DataSource = "";
            EditSlotId.DataSource = slotDAO.GetSlotsByHospital(EditHospitalDropDownList.SelectedValue).Select(i => new { Name = i.SlotTime, Value = i.SlotId }).ToList();
            EditSlotId.DataTextField = "Name";
            EditSlotId.DataValueField = "Value";
            EditSlotId.DataBind();
            EditSlotId.ClearSelection();
        }

        protected void SaveEditChanges_Click(object sender, EventArgs e)
        {
            BloodReq req = new BloodReq();
            Guid reqId = new Guid(EditReqId.Value);
            req.ReqId = reqId;
            req.PatientName = EditPatientName.Text;
            req.PatientPhoneNo = EditPatientPhoneNo.Text;
            req.BloodGroup = EditBloodGroup.Text;
            req.Status = EditStatus.Value;
            req.UserUserName = EditUserName.Value;
            Guid slotId = new Guid(EditSlotId.SelectedValue);
            req.SlotSlotId = slotId;
            reqDAO.EditBloodReq(req);
            Response.Redirect("ListAllDonationsForDonar.aspx");
        }

        protected void DonarListView_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            SlotDAO slotDAO = new SlotDAO();
            HospitalDAO hospitalDAO = new HospitalDAO();
            Entities.BloodReq req = (BloodReq)e.Item.DataItem;
            Label l1 = (Label)e.Item.FindControl("DonarHospitalInfo");
            Label l2 = (Label)e.Item.FindControl("DonarSlotInfo");
            var s = slotDAO.GetSlot(req.SlotSlotId);
            var h = hospitalDAO.GetHospital(s.HospitalHospitalName);
            l1.Text = h.HospitalName+", "+h.Area+", "+h.City+", "+h.State+", "+h.Pincode;
            l2.Text = s.SlotTime.ToString();
            
        }

        protected void OthersListView_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            SlotDAO slotDAO = new SlotDAO();
            HospitalDAO hospitalDAO = new HospitalDAO();
            Entities.BloodReq req = (BloodReq)e.Item.DataItem;
            Label l1 = (Label)e.Item.FindControl("DonateHospitalInfo");
            Label l2 = (Label)e.Item.FindControl("DonateSlotInfo");
            var s = slotDAO.GetSlot(req.SlotSlotId);
            var h = hospitalDAO.GetHospital(s.HospitalHospitalName);
            l1.Text = h.HospitalName+", "+h.Area + ", " + h.City + ", " + h.State + ", " + h.Pincode;
            l2.Text = s.SlotTime.ToString();
        }
    }
}