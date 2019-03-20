using ManagePatient.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;

namespace ManagePatient
{
    public partial class _Default : Page
    {
        private static List<Patient> Patients = new List<Patient>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ReadAllDB();
                gvDatas.DataSource = Patients.Where(w => !w.IsDeleted);
                gvDatas.DataBind();
            }
        }

        private void ReadAllDB()
        {
            Patients = new List<Patient>();
            foreach (var patientPath in Directory.GetFiles(Path.Combine(ConfigurationManager.AppSettings["DBFolder"])))
            {
                using (FileStream fs = new FileStream(patientPath, FileMode.Open))
                {
                    var patient = new XmlSerializer(typeof(Patient)).Deserialize(fs) as Patient;
                    patient.Id = Guid.Parse(Path.GetFileNameWithoutExtension(patientPath));
                    Patients.Add(patient);
                }
            }
        }

        protected void onPatientUpdate(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void onPatientEdit(object sender, GridViewEditEventArgs e)
        {

        }

        protected void onPatientDelete(object sender, GridViewDeleteEventArgs e)
        {
            var id = (Guid)gvDatas.DataKeys[e.RowIndex].Value;
            var patient = Patients.First(w => w.Id == id);
            patient.IsDeleted = true;
            Save(patient);
            gvDatas.DataSource = Patients.Where(w => !w.IsDeleted);
            gvDatas.DataBind();
        }

        protected void onCancelEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }
        private void Save(Patient patient)
        {
            var filePath = Path.Combine(ConfigurationManager.AppSettings["DBFolder"], $"{patient.Id}.xml");
            File.Delete(filePath);
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                new XmlSerializer(typeof(Patient)).Serialize(fs, patient);
            }
        }

        protected void onAddPatient(object sender, ImageClickEventArgs e)
        {
            var patient = new Patient
            {
                CreatedDate = DateTime.Now,
                LasUpdatedDate = DateTime.Now,
                Email = (gvDatas.FooterRow.FindControl("txtAddEmail") as TextBox).Text,
                Phone = (gvDatas.FooterRow.FindControl("txtAddPhone") as TextBox).Text,
                FirstName = (gvDatas.FooterRow.FindControl("txtAddFirstName") as TextBox).Text,
                LastName = (gvDatas.FooterRow.FindControl("txtAddLastName") as TextBox).Text,
                Notes = (gvDatas.FooterRow.FindControl("txtAddNotes") as TextBox).Text
            };
            Patients.Add(patient);
            Save(patient);
            gvDatas.DataSource = Patients.Where(w => !w.IsDeleted);
            gvDatas.DataBind();
        }
    }
}