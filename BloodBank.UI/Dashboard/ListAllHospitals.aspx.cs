using BloodBank.DataLayer;
using System;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BloodBank.UI.Dashboard
{
    public partial class ListAllHospitals : System.Web.UI.Page
    {
        HospitalDAO hosDAO = new HospitalDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            HospitalListView.DataSource = hosDAO.GetAllHospitals();
            HospitalListView.DataBind();
        }
        protected void SlotsInfoBtn_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string hospitalName = btn.CommandArgument.ToString();
            SlotDAO slotDAO = new SlotDAO();
            ModalListView.DataSource = slotDAO.GetSlotsByHospital(hospitalName);
            ModalListView.DataBind();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "SlotsInfoModal", "$('#SlotsInfoModal').modal();", true);
            ModalUpdatePanel.Update();
        }

        protected void EditHospital_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            var hos = hosDAO.GetHospital(btn.CommandArgument.ToString());
            EditHospitalName.Value = hos.HospitalName;
            EditArea.Text = hos.Area;
            EditCity.Text = hos.City;
            EditState.Text = hos.State;
            EditPincode.Text = hos.Pincode;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "EditModal", "$('#EditModal').modal();", true);
            upModal.Update();
        }

        protected void SaveEditChanges_Click(object sender, EventArgs e)
        {
            if (EditArea.Text == "")
            {
                HospitalWarning.Text = "Area is Required!!";
            }
            else if (EditCity.Text == "")
            {
                HospitalWarning.Text = "City is Required!!";
            }
            else if (EditState.Text == "")
            {
                HospitalWarning.Text = "State is Required!!";
            }
            else if (!Regex.IsMatch(EditPincode.Text, "^([1-9][0-9]{5})$") || EditPincode.Text == "")
            {
                HospitalWarning.Text = "Invaild Pincode!!";
            }
            else
            {
                Entities.Hospital hos = new Entities.Hospital();
                hos.HospitalName = EditHospitalName.Value;
                hos.Area = EditArea.Text;
                hos.City = EditCity.Text;
                hos.State = EditState.Text;
                hos.Pincode = EditPincode.Text;
                hosDAO.EditHospital(hos);
                Response.Redirect("ListAllHospitals.aspx");
            }
        }

        protected void DeleteHospital_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            hosDAO.DeleteHospital(btn.CommandArgument.ToString());
            Response.Redirect("ListAllHospitals.aspx");
        }

        protected void CreateHospital_Click(object sender, EventArgs e)
        {
            if (AddHospitalName.Text == "") {
                HospitalWarning.Text = "Hospital Name is Required!!";
            }
            else if (AddArea.Text == "") {
                HospitalWarning.Text = "Area is Required!!";
            }else if (AddCity.Text == "") {
                HospitalWarning.Text = "City is Required!!";
            }else if (AddState.Text == "") {
                HospitalWarning.Text = "State is Required!!";
            }else if (!Regex.IsMatch(AddPincode.Text,"^([0-9]{6})$") || AddPincode.Text == "") {
                HospitalWarning.Text = "Invaild Pincode!!";
            }
            else
            {
                Entities.Hospital hos = new Entities.Hospital();
                hos.HospitalName = AddHospitalName.Text;
                hos.Area = AddArea.Text;
                hos.City = AddCity.Text;
                hos.State = AddState.Text;
                hos.Pincode = AddPincode.Text;
                hosDAO.AddHospital(hos);
                Response.Redirect("ListAllHospitals.aspx");
            }

        }
    }
}