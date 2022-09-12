using BloodBank.DataLayer;
using BloodBank.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

        protected void AddHospitalDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SlotDAO slotDAO = new SlotDAO();
            AddSlotId.DataSource = slotDAO.GetSlotsByHospital(AddHospitalDropDownList.SelectedValue).Select(i => new { Name = i.SlotTime, Value=i.SlotId }).ToList();
            AddSlotId.DataTextField = "Name";
            AddSlotId.DataValueField = "Value";
            AddSlotId.DataBind();
            AddReqOuterModal.Update();
            
            /*ScriptManager.RegisterStartupScript(Page, Page.GetType(), "AddBloodReqModal", "$('#AddBloodReq').modal();", true);*/

        }

        protected void CreateBloodReq_Click(object sender, EventArgs e)
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

        protected void EditBloodReq_Click(object sender, EventArgs e)
        {

        }

        protected void DeleteBloodReq_Click(object sender, EventArgs e)
        {

        }

        protected void Donate_Click(object sender, EventArgs e)
        {

        }

        protected void EditHospitalDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void SaveEditChanges_Click(object sender, EventArgs e)
        {

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
            l1.Text = h.Area+", "+h.City+", "+h.State+", "+h.Pincode;
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
            l1.Text = h.Area + ", " + h.City + ", " + h.State + ", " + h.Pincode;
            l2.Text = s.SlotTime.ToString();
        }
    }
}