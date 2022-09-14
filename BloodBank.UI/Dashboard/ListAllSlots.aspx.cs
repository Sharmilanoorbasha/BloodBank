using BloodBank.DataLayer;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BloodBank.UI.Dashboard
{
    public partial class ListAllSlots : System.Web.UI.Page
    {
        SlotDAO slotDAO = new SlotDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                HospitalDAO hospitalDAO = new HospitalDAO();
                var hospitals = hospitalDAO.GetAllHospitals();
                AddHospitalDropDownList.DataSource = hospitals.Select(i => i.HospitalName).ToList();
                AddHospitalDropDownList.DataBind();
                SlotListView.DataSource = slotDAO.GetAllSlots();
                SlotListView.DataBind();

            }
        }

        protected void CreateSlot_Click(object sender, EventArgs e)
        {
            if (AddSlotTime.Value == "") {
                SlotWarning.Text = "Slot Time is Required!!";
            }
            else {
                Entities.Slot s = new Entities.Slot();
                s.SlotId = Guid.NewGuid();
                s.SlotTime = Convert.ToDateTime(AddSlotTime.Value.ToString());
                s.HospitalHospitalName = AddHospitalDropDownList.Text;
                slotDAO.AddSlot(s);
                Response.Redirect("ListAllSlots.aspx"); }

        }

        protected void EditSlot_Click(object sender, EventArgs e)
        {
            HospitalDAO hospitalDAO = new HospitalDAO();
            var hospitals = hospitalDAO.GetAllHospitals();
            EditHospitalDropDownList.DataSource = hospitals.Select(i => i.HospitalName).ToList();
            EditHospitalDropDownList.DataBind();


            LinkButton btn = (LinkButton)sender;
            Guid id = new Guid(btn.CommandArgument.ToString());
            var s = slotDAO.GetSlot(id);
            EditSlotId.Value = s.SlotId.ToString();
            EditHospitalDropDownList.SelectedValue = s.HospitalHospitalName;
            //2022-07-16T23:54:00.000
            EditSlotTime.Value = s.SlotTime.ToString("s").ToString();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "EditModal", "$('#EditModal').modal();", true);
            upModal.Update();
        }

        protected void DeleteSlot_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            Guid id = new Guid(btn.CommandArgument.ToString());
            slotDAO.DeleteSlot(id);
            Response.Redirect("ListAllSlots.aspx");
        }

        protected void SaveEditChanges_Click(object sender, EventArgs e)
        {
            if (EditSlotTime.Value == "") {
                SlotWarning.Text = "Slot Time is Required!!";
            }
            else {
                Entities.Slot s = new Entities.Slot();
                Guid id = new Guid(EditSlotId.Value);
                s.SlotId = id;

                s.SlotTime = Convert.ToDateTime(EditSlotTime.Value);
                s.HospitalHospitalName = EditHospitalDropDownList.Text;
                slotDAO.EditSlot(s);
                Response.Redirect("ListAllSlots.aspx"); }
        }
    }
}