using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MunicipalityConnect
{
    public partial class ReportIssueForm : Form
    {
        // Store all reported issues
        private List<Issue> issues = new List<Issue>();
        private int queryNumber = 1;
        private List<string> selectedFiles = new List<string>();

        public ReportIssueForm()
        {
            InitializeComponent();

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void ReportIssueForm_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel15_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel17_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void panel21_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel18_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Clear request type
            rdoReportIssue.Checked = false;
            rdoRequestService.Checked = false;

            // Clear location
            txtLocation.Clear();

            // Reset category
            cmbCategory.SelectedIndex = -1;

            // Reset incident date
            dtpIncidentDate.Value = DateTime.Today;

            // Clear description
            txtDescription.Clear();

            // Reset progress
            progressBar1.Value = 0;
            lblProgress.Text = "Let's get started!";

            // Clear attachment display
            lstAttachments.Items.Clear();

        }

        private void btnBackToMenu_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();

            this.Hide();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Validate request type
            if (!rdoReportIssue.Checked && !rdoRequestService.Checked)
            {
                MessageBox.Show(
                    "Please select whether you are reporting an issue or requesting a service.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Validate location
            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                MessageBox.Show(
                    "Please enter the location.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Validate category
            if (string.IsNullOrWhiteSpace(cmbCategory.Text))
            {
                MessageBox.Show(
                    "Please select a category.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Validate description
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show(
                    "Please enter a description.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Generate query code
            string queryCode = $"MC-{DateTime.Now.Year}-{queryNumber:D4}";

            // Create folder for this issue's attachments
            string attachmentsFolder = Path.Combine(
                Application.StartupPath,
                "Attachments"
            );

            string issueFolder = Path.Combine(
                attachmentsFolder,
                queryCode
            );

            if (Directory.Exists(issueFolder))
            {
                Directory.Delete(issueFolder, true);
            }

            Directory.CreateDirectory(issueFolder);

            // Create new Issue
            Issue newIssue = new Issue();

            // Request type
            if (rdoReportIssue.Checked)
            {
                newIssue.RequestType = "Report an Issue";
            }
            else if (rdoRequestService.Checked)
            {
                newIssue.RequestType = "Request a Service";
            }

            // Form details
            newIssue.QueryCode = queryCode;
            newIssue.Location = txtLocation.Text;
            newIssue.Category = cmbCategory.Text;
            newIssue.IncidentDate = dtpIncidentDate.Value;
            newIssue.Description = txtDescription.Text;

            // Initial status
            newIssue.Status = "Submitted";

            // Copy attachments
            foreach (string file in selectedFiles)
            {
                string fileName = Path.GetFileName(file);
                string destinationPath = Path.Combine(issueFolder, fileName);

                File.Copy(file, destinationPath, true);

                Attachment attachment = new Attachment
                {
                    FileName = fileName,
                    FilePath = destinationPath
                };

                newIssue.Attachments.Add(attachment);
            }

            // Add issue to the List
            issues.Add(newIssue);

            // Increase query number for next issue
            queryNumber++;

            MessageBox.Show(
                $"Your report has been submitted successfully.\n\nYour query code is: {queryCode}",
                "Report Submitted",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void btnAttachFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                openFileDialog.Title = "Select Files";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string file in openFileDialog.FileNames)
                    {
                        // Store the full file path
                        selectedFiles.Add(file);

                        // Display only the filename in the ListView
                        lstAttachments.Items.Add(Path.GetFileName(file));
                    }
                }
            }
        }
    }
}
