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

            LoadCategories();

            // Start with no incident date selected
            dtpIncidentDate.Format = DateTimePickerFormat.Custom;
            dtpIncidentDate.CustomFormat = "yyyy/MM/dd";
            dtpIncidentDate.ShowCheckBox = true;
            dtpIncidentDate.Checked = false;
            HideErrorLabels();

            UpdateProgress();

            this.WindowState = FormWindowState.Maximized;
        }

        private void LoadCategories()
        {
            cmbCategory.Items.Clear();

            cmbCategory.Items.Add("Roads & Potholes");
            cmbCategory.Items.Add("Water & Sanitation");
            cmbCategory.Items.Add("Electricity");
            cmbCategory.Items.Add("Street Lighting");
            cmbCategory.Items.Add("Waste Management");
            cmbCategory.Items.Add("Public Safety");
            cmbCategory.Items.Add("Parks & Recreation");
            cmbCategory.Items.Add("Traffic & Transport");
            cmbCategory.Items.Add("Illegal Dumping");
            cmbCategory.Items.Add("Other");

            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
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
            rdoReportIssue.Checked = true;
            rdoRequestService.Checked = false;

            // Clear location
            txtLocation.Clear();

            // Reset category
            cmbCategory.SelectedIndex = -1;

            // Reset incident date
            dtpIncidentDate.Checked = false;

            // Clear description
            txtDescription.Clear();

            // Reset progress
            progressBar1.Value = 0;
            lblProgressMessage.Text = "Let's get started!";

            // Clear attachment display
            lstAttachments.Items.Clear();

            // Update Progress bar
            UpdateProgress();

        }

        private void btnBackToMenu_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();

            this.Hide();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
            {
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

            SubmissionSuccessForm successForm =
                new SubmissionSuccessForm(newIssue, this);

            successForm.ShowDialog();
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

        private bool ValidateForm()
        {
            List<string> missingInformation = new List<string>();

            // Hide all error labels first
            lblRequestTypeError.Visible = false;
            lblLocationError.Visible = false;
            lblCategoryError.Visible = false;
            lblIncidentDateError.Visible = false;
            lblDescriptionError.Visible = false;

            // Request type
            if (!rdoReportIssue.Checked && !rdoRequestService.Checked)
            {
                missingInformation.Add("Please select a request type.");

                lblRequestTypeError.Text = "● Please select a request type.";
                lblRequestTypeError.Visible = true;
            }

            // Location
            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                missingInformation.Add("Please enter the location.");

                lblLocationError.Text = "● Please enter the location.";
                lblLocationError.Visible = true;
            }

            // Category
            if (cmbCategory.SelectedIndex == -1)
            {
                missingInformation.Add("Please select an issue category.");

                lblCategoryError.Text = "● Please select an issue category.";
                lblCategoryError.Visible = true;
            }

            // Incident date
            if (!dtpIncidentDate.Checked)
            {
                missingInformation.Add("Please select the incident date.");

                lblIncidentDateError.Text = "● Please select the incident date.";
                lblIncidentDateError.Visible = true;
            }

            // Description
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                missingInformation.Add("Please provide a description.");

                lblDescriptionError.Text = "● Please provide a description.";
                lblDescriptionError.Visible = true;
            }

            // Show popup if there are missing fields
            if (missingInformation.Count > 0)
            {
                string message = "Some required information is missing:\n\n";

                foreach (string item in missingInformation)
                {
                    message += "• " + item + "\n";
                }

                MessageBox.Show(
                    message,
                    "Municipal Connect",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return false;
            }

            return true;
        }

        private void UpdateProgress()
        {
            int completedFields = 0;

            // Check location
            if (!string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                completedFields++;
            }

            // Check category
            if (cmbCategory.SelectedIndex != -1)
            {
                completedFields++;
            }

            // Check incident date
            if (dtpIncidentDate.Checked)
            {
                completedFields++;
            }

            // Check description
            if (!string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                completedFields++;
            }

            // Calculate progress
            int progress = completedFields * 25;

            progressBar1.Value = progress;
            lblProgressPercent.Text = progress + "%";

            // Update message
            if (progress == 0)
            {
                lblProgressMessage.Text = "Let's get started!";
            }
            else if (progress == 25)
            {
                lblProgressMessage.Text = "Great start!";
            }
            else if (progress == 50)
            {
                lblProgressMessage.Text = "Almost there!";
            }
            else if (progress == 75)
            {
                lblProgressMessage.Text = "Almost there!";
            }
            else if (progress == 100)
            {
                lblProgressMessage.Text = "You're ready to submit!";
            }
        }

        private void HideErrorLabels()
        {
            lblRequestTypeError.Visible = false;
            lblLocationError.Visible = false;
            lblCategoryError.Visible = false;
            lblIncidentDateError.Visible = false;
            lblDescriptionError.Visible = false;
        }

        private void txtLocation_TextChanged(object sender, EventArgs e)
        {
            UpdateProgress();
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateProgress();
        }

        private void dtpIncidentDate_ValueChanged(object sender, EventArgs e)
        {
            UpdateProgress();
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            UpdateProgress();
        }

        private void btnRemoveFile_Click(object sender, EventArgs e)
        {
            if (lstAttachments.SelectedItems.Count == 0)
            {
                MessageBox.Show(
                    "Please select a file to remove.",
                    "No File Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            int selectedIndex = lstAttachments.SelectedIndices[0];

            // Remove the file from the selected files list
            selectedFiles.RemoveAt(selectedIndex);

            // Remove the file from the ListView
            lstAttachments.Items.RemoveAt(selectedIndex);
        }
    }
}
