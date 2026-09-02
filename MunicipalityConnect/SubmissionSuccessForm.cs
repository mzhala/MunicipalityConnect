using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MunicipalityConnect
{
    public partial class SubmissionSuccessForm : Form
    {
        private Issue submittedIssue;

        public SubmissionSuccessForm(Issue issue)
        {
            InitializeComponent();

            submittedIssue = issue;

            DisplaySubmissionDetails();
        }

        private void btnReturnToMenu_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();

            this.Hide();
        }

        private void DisplaySubmissionDetails()
        {
            lblReference.Text = $"Reference: {submittedIssue.QueryCode}";
            lblType.Text = $"Type: {submittedIssue.RequestType}";
            lblCategory.Text = $"Category: {submittedIssue.Category}";
            lblIncidentDate.Text =
                $"Incident Date: {submittedIssue.IncidentDate:yyyy-MM-dd}";
            txtSubmittedDescription.Text =
                $"Description: {submittedIssue.Description}";
            lblStatus.Text = $"Status: {submittedIssue.Status}";
            lblSubmitted.Text =
                $"Submitted: {DateTime.Now:M/d/yyyy h:mm:ss tt}";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ReportIssueForm reportIssueForm = new ReportIssueForm();
            reportIssueForm.Show();

            this.Hide();
        }
    }
}