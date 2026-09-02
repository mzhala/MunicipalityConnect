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

        private Form reportIssueForm;
        public SubmissionSuccessForm(Issue issue, Form reportIssueForm)
        {
            InitializeComponent();

            submittedIssue = issue;
            this.reportIssueForm = reportIssueForm;

            DisplaySubmissionDetails();
        }

        private void btnReturnToMenu_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();

            reportIssueForm.Close();

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
            this.Hide();
        }
    }
}