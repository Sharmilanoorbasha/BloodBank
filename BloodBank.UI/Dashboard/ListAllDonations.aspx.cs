using BloodBank.DataLayer;
using BloodBank.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BloodBank.UI.Dashboard
{
    public partial class ListAllDonations : System.Web.UI.Page
    {
        BloodReqDAO reqDAO = new BloodReqDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                DonationsListView.DataSource = reqDAO.GetAllBloodReqs();
                DonationsListView.DataBind();
            }
        }

        protected void DonationsListView_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            SlotDAO slotDAO = new SlotDAO();
            HospitalDAO hospitalDAO = new HospitalDAO();
            Entities.BloodReq req = (BloodReq)e.Item.DataItem;
            Label l1 = (Label)e.Item.FindControl("DonationHospitalInfo");
            Label l2 = (Label)e.Item.FindControl("DonationSlotInfo");
            var s = slotDAO.GetSlot(req.SlotSlotId);
            var h = hospitalDAO.GetHospital(s.HospitalHospitalName);
            l1.Text = h.HospitalName + ", " + h.Area + ", " + h.City + ", " + h.State + ", " + h.Pincode;
            l2.Text = s.SlotTime.ToString();
        }

        protected void OpenDonation_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            Guid id = new Guid(btn.CommandArgument.ToString());
            var req = reqDAO.GetBloodReq(id);
            req.Status = "Open";
            reqDAO.EditBloodReq(req);
            Response.Redirect("ListAllDonations.aspx");
        }

        protected void CloseDonation_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            Guid id = new Guid(btn.CommandArgument.ToString());
            var req = reqDAO.GetBloodReq(id);
            req.Status = "Close";
            reqDAO.EditBloodReq(req);
            Response.Redirect("ListAllDonations.aspx");
        }
    }
}