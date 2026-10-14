namespace MunicipalityConnect
{
    partial class ReportIssueForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportIssueForm));
            panel13 = new Panel();
            pictureBox5 = new PictureBox();
            label3 = new Label();
            label4 = new Label();
            panel14 = new Panel();
            panel2 = new Panel();
            panel7 = new Panel();
            panel6 = new Panel();
            panel4 = new Panel();
            panel3 = new Panel();
            panel1 = new Panel();
            panel12 = new Panel();
            panel11 = new Panel();
            panel10 = new Panel();
            panel9 = new Panel();
            panel8 = new Panel();
            panel5 = new Panel();
            label2 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            panel15 = new Panel();
            lblDescriptionError = new Label();
            lblIncidentDateError = new Label();
            lblCategoryError = new Label();
            lblLocationError = new Label();
            lblRequestTypeError = new Label();
            panel17 = new Panel();
            txtDescription = new RichTextBox();
            label10 = new Label();
            dtpIncidentDate = new DateTimePicker();
            label9 = new Label();
            cmbCategory = new ComboBox();
            label8 = new Label();
            txtLocation = new TextBox();
            label7 = new Label();
            panel16 = new Panel();
            rdoRequestService = new RadioButton();
            rdoReportIssue = new RadioButton();
            label5 = new Label();
            label6 = new Label();
            panel18 = new Panel();
            btnRemoveFile = new Button();
            panel20 = new Panel();
            lstAttachments = new ListView();
            pictureBox2 = new PictureBox();
            btnAttachFile = new Button();
            panel19 = new Panel();
            label15 = new Label();
            label16 = new Label();
            panel21 = new Panel();
            panel22 = new Panel();
            lblProgressMessage = new Label();
            lblProgressPercent = new Label();
            progressBar1 = new ProgressBar();
            panel23 = new Panel();
            label13 = new Label();
            btnBackToMenu = new Button();
            btnSubmit = new Button();
            btnClear = new Button();
            panel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel15.SuspendLayout();
            panel16.SuspendLayout();
            panel18.SuspendLayout();
            panel20.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel21.SuspendLayout();
            panel22.SuspendLayout();
            SuspendLayout();
            // 
            // panel13
            // 
            panel13.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel13.BackColor = Color.FromArgb(235, 247, 255);
            panel13.BorderStyle = BorderStyle.FixedSingle;
            panel13.Controls.Add(pictureBox5);
            panel13.Controls.Add(label3);
            panel13.Controls.Add(label4);
            panel13.Controls.Add(panel14);
            panel13.Location = new Point(25, 149);
            panel13.Margin = new Padding(3, 4, 3, 4);
            panel13.Name = "panel13";
            panel13.Size = new Size(1323, 122);
            panel13.TabIndex = 11;
            // 
            // pictureBox5
            // 
            pictureBox5.Enabled = false;
            pictureBox5.ErrorImage = (Image)resources.GetObject("pictureBox5.ErrorImage");
            pictureBox5.Image = Properties.Resources.google_docs;
            pictureBox5.InitialImage = (Image)resources.GetObject("pictureBox5.InitialImage");
            pictureBox5.Location = new Point(32, 23);
            pictureBox5.Margin = new Padding(3, 4, 3, 4);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(53, 71);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 13;
            pictureBox5.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Gray;
            label3.Location = new Point(114, 64);
            label3.Name = "label3";
            label3.Size = new Size(464, 23);
            label3.TabIndex = 10;
            label3.Text = "Provide the details below so the municipality can assist you.";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(27, 60, 109);
            label4.Location = new Point(109, 17);
            label4.Name = "label4";
            label4.Size = new Size(527, 41);
            label4.TabIndex = 9;
            label4.Text = "Report an Issue or Request a Service";
            label4.Click += label4_Click;
            // 
            // panel14
            // 
            panel14.BackColor = Color.FromArgb(0, 170, 171);
            panel14.Location = new Point(0, 0);
            panel14.Margin = new Padding(3, 4, 3, 4);
            panel14.Name = "panel14";
            panel14.Size = new Size(6, 121);
            panel14.TabIndex = 8;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.FromArgb(0, 170, 171);
            panel2.Controls.Add(panel7);
            panel2.Controls.Add(panel6);
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(panel3);
            panel2.Location = new Point(1, 105);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(1381, 7);
            panel2.TabIndex = 10;
            // 
            // panel7
            // 
            panel7.BackColor = Color.FromArgb(0, 124, 217);
            panel7.Location = new Point(643, 1);
            panel7.Margin = new Padding(3, 4, 3, 4);
            panel7.Name = "panel7";
            panel7.Size = new Size(185, 13);
            panel7.TabIndex = 7;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(43, 159, 74);
            panel6.Location = new Point(826, 1);
            panel6.Margin = new Padding(3, 4, 3, 4);
            panel6.Name = "panel6";
            panel6.Size = new Size(185, 13);
            panel6.TabIndex = 6;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(231, 192, 58);
            panel4.Location = new Point(1010, 1);
            panel4.Margin = new Padding(3, 4, 3, 4);
            panel4.Name = "panel4";
            panel4.Size = new Size(185, 13);
            panel4.TabIndex = 5;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(228, 130, 18);
            panel3.Location = new Point(1195, 1);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(185, 13);
            panel3.TabIndex = 4;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(27, 60, 109);
            panel1.Controls.Add(panel12);
            panel1.Controls.Add(panel11);
            panel1.Controls.Add(panel10);
            panel1.Controls.Add(panel9);
            panel1.Controls.Add(panel8);
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1381, 104);
            panel1.TabIndex = 9;
            // 
            // panel12
            // 
            panel12.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel12.BackColor = Color.FromArgb(143, 104, 203);
            panel12.Location = new Point(1341, 24);
            panel12.Margin = new Padding(3, 4, 3, 4);
            panel12.Name = "panel12";
            panel12.Size = new Size(16, 29);
            panel12.TabIndex = 12;
            // 
            // panel11
            // 
            panel11.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel11.BackColor = Color.FromArgb(43, 159, 74);
            panel11.Location = new Point(1318, 24);
            panel11.Margin = new Padding(3, 4, 3, 4);
            panel11.Name = "panel11";
            panel11.Size = new Size(16, 29);
            panel11.TabIndex = 11;
            // 
            // panel10
            // 
            panel10.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel10.BackColor = Color.FromArgb(228, 130, 18);
            panel10.Location = new Point(1295, 24);
            panel10.Margin = new Padding(3, 4, 3, 4);
            panel10.Name = "panel10";
            panel10.Size = new Size(16, 29);
            panel10.TabIndex = 10;
            // 
            // panel9
            // 
            panel9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel9.BackColor = Color.FromArgb(231, 192, 58);
            panel9.Location = new Point(1272, 24);
            panel9.Margin = new Padding(3, 4, 3, 4);
            panel9.Name = "panel9";
            panel9.Size = new Size(16, 29);
            panel9.TabIndex = 9;
            // 
            // panel8
            // 
            panel8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel8.BackColor = Color.FromArgb(0, 170, 171);
            panel8.Location = new Point(1249, 24);
            panel8.Margin = new Padding(3, 4, 3, 4);
            panel8.Name = "panel8";
            panel8.Size = new Size(16, 29);
            panel8.TabIndex = 8;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(231, 192, 58);
            panel5.Location = new Point(823, 104);
            panel5.Margin = new Padding(3, 4, 3, 4);
            panel5.Name = "panel5";
            panel5.Size = new Size(185, 13);
            panel5.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(195, 204, 217);
            label2.Location = new Point(102, 59);
            label2.Name = "label2";
            label2.Size = new Size(316, 23);
            label2.TabIndex = 2;
            label2.Text = "Report issues. Improve your community.";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(96, 12);
            label1.Name = "label1";
            label1.Size = new Size(429, 41);
            label1.TabIndex = 1;
            label1.Text = "Ethekwini Municipal Connect";
            // 
            // pictureBox1
            // 
            pictureBox1.Enabled = false;
            pictureBox1.ErrorImage = (Image)resources.GetObject("pictureBox1.ErrorImage");
            pictureBox1.Image = Properties.Resources.ethekwini_logo;
            pictureBox1.InitialImage = (Image)resources.GetObject("pictureBox1.InitialImage");
            pictureBox1.Location = new Point(25, 16);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(53, 71);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel15
            // 
            panel15.BackColor = Color.White;
            panel15.BorderStyle = BorderStyle.FixedSingle;
            panel15.Controls.Add(lblDescriptionError);
            panel15.Controls.Add(lblIncidentDateError);
            panel15.Controls.Add(lblCategoryError);
            panel15.Controls.Add(lblLocationError);
            panel15.Controls.Add(lblRequestTypeError);
            panel15.Controls.Add(panel17);
            panel15.Controls.Add(txtDescription);
            panel15.Controls.Add(label10);
            panel15.Controls.Add(dtpIncidentDate);
            panel15.Controls.Add(label9);
            panel15.Controls.Add(cmbCategory);
            panel15.Controls.Add(label8);
            panel15.Controls.Add(txtLocation);
            panel15.Controls.Add(label7);
            panel15.Controls.Add(panel16);
            panel15.Controls.Add(label5);
            panel15.Location = new Point(26, 307);
            panel15.Margin = new Padding(3, 4, 3, 4);
            panel15.Name = "panel15";
            panel15.Size = new Size(800, 575);
            panel15.TabIndex = 14;
            panel15.Paint += panel15_Paint;
            // 
            // lblDescriptionError
            // 
            lblDescriptionError.AutoSize = true;
            lblDescriptionError.BackColor = Color.Transparent;
            lblDescriptionError.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDescriptionError.ForeColor = Color.Red;
            lblDescriptionError.Location = new Point(631, 537);
            lblDescriptionError.Name = "lblDescriptionError";
            lblDescriptionError.Size = new Size(168, 15);
            lblDescriptionError.TabIndex = 29;
            lblDescriptionError.Text = "*  Describe the issue or service.";
            lblDescriptionError.TextAlign = ContentAlignment.TopRight;
            // 
            // lblIncidentDateError
            // 
            lblIncidentDateError.AutoSize = true;
            lblIncidentDateError.BackColor = Color.Transparent;
            lblIncidentDateError.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblIncidentDateError.ForeColor = Color.Red;
            lblIncidentDateError.Location = new Point(625, 348);
            lblIncidentDateError.Name = "lblIncidentDateError";
            lblIncidentDateError.Size = new Size(176, 15);
            lblIncidentDateError.TabIndex = 28;
            lblIncidentDateError.Text = "* Please select the incident date.";
            lblIncidentDateError.TextAlign = ContentAlignment.TopRight;
            // 
            // lblCategoryError
            // 
            lblCategoryError.AutoSize = true;
            lblCategoryError.BackColor = Color.Transparent;
            lblCategoryError.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCategoryError.ForeColor = Color.Red;
            lblCategoryError.Location = new Point(622, 268);
            lblCategoryError.Name = "lblCategoryError";
            lblCategoryError.Size = new Size(178, 15);
            lblCategoryError.TabIndex = 27;
            lblCategoryError.Text = "* Please select an issue category.";
            lblCategoryError.TextAlign = ContentAlignment.TopRight;
            // 
            // lblLocationError
            // 
            lblLocationError.AutoSize = true;
            lblLocationError.BackColor = Color.Transparent;
            lblLocationError.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLocationError.ForeColor = Color.Red;
            lblLocationError.Location = new Point(649, 192);
            lblLocationError.Name = "lblLocationError";
            lblLocationError.Size = new Size(147, 15);
            lblLocationError.TabIndex = 26;
            lblLocationError.Text = "* Please enter the location.";
            lblLocationError.TextAlign = ContentAlignment.TopRight;
            // 
            // lblRequestTypeError
            // 
            lblRequestTypeError.AutoSize = true;
            lblRequestTypeError.BackColor = Color.Transparent;
            lblRequestTypeError.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRequestTypeError.ForeColor = Color.Red;
            lblRequestTypeError.Location = new Point(672, 107);
            lblRequestTypeError.Name = "lblRequestTypeError";
            lblRequestTypeError.Size = new Size(119, 15);
            lblRequestTypeError.TabIndex = 25;
            lblRequestTypeError.Text = "* Select Request Type";
            lblRequestTypeError.TextAlign = ContentAlignment.TopRight;
            // 
            // panel17
            // 
            panel17.BackColor = Color.FromArgb(0, 170, 171);
            panel17.Location = new Point(-1, -1);
            panel17.Margin = new Padding(3, 4, 3, 4);
            panel17.Name = "panel17";
            panel17.Size = new Size(799, 3);
            panel17.TabIndex = 24;
            panel17.Paint += panel17_Paint;
            // 
            // txtDescription
            // 
            txtDescription.BorderStyle = BorderStyle.FixedSingle;
            txtDescription.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDescription.Location = new Point(16, 389);
            txtDescription.Margin = new Padding(3, 4, 3, 4);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(762, 144);
            txtDescription.TabIndex = 23;
            txtDescription.Text = "";
            txtDescription.TextChanged += txtDescription_TextChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.Black;
            label10.Location = new Point(16, 363);
            label10.Name = "label10";
            label10.Size = new Size(96, 23);
            label10.TabIndex = 22;
            label10.Text = "Description";
            // 
            // dtpIncidentDate
            // 
            dtpIncidentDate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpIncidentDate.Location = new Point(16, 305);
            dtpIncidentDate.Margin = new Padding(3, 4, 3, 4);
            dtpIncidentDate.Name = "dtpIncidentDate";
            dtpIncidentDate.Size = new Size(762, 34);
            dtpIncidentDate.TabIndex = 21;
            dtpIncidentDate.ValueChanged += dtpIncidentDate_ValueChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.Black;
            label9.Location = new Point(16, 279);
            label9.Name = "label9";
            label9.Size = new Size(113, 23);
            label9.TabIndex = 20;
            label9.Text = "Incident Date";
            // 
            // cmbCategory
            // 
            cmbCategory.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(16, 225);
            cmbCategory.Margin = new Padding(3, 4, 3, 4);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(762, 36);
            cmbCategory.TabIndex = 19;
            cmbCategory.SelectedIndexChanged += cmbCategory_SelectedIndexChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Black;
            label8.Location = new Point(16, 199);
            label8.Name = "label8";
            label8.Size = new Size(79, 23);
            label8.TabIndex = 18;
            label8.Text = "Category";
            // 
            // txtLocation
            // 
            txtLocation.BorderStyle = BorderStyle.FixedSingle;
            txtLocation.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLocation.Location = new Point(16, 149);
            txtLocation.Margin = new Padding(3, 4, 3, 4);
            txtLocation.Name = "txtLocation";
            txtLocation.Size = new Size(762, 34);
            txtLocation.TabIndex = 17;
            txtLocation.TextChanged += txtLocation_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(16, 123);
            label7.Name = "label7";
            label7.Size = new Size(75, 23);
            label7.TabIndex = 16;
            label7.Text = "Location";
            // 
            // panel16
            // 
            panel16.BackColor = Color.White;
            panel16.BorderStyle = BorderStyle.FixedSingle;
            panel16.Controls.Add(rdoRequestService);
            panel16.Controls.Add(rdoReportIssue);
            panel16.Location = new Point(16, 61);
            panel16.Margin = new Padding(3, 4, 3, 4);
            panel16.Name = "panel16";
            panel16.Size = new Size(762, 43);
            panel16.TabIndex = 15;
            // 
            // rdoRequestService
            // 
            rdoRequestService.AutoSize = true;
            rdoRequestService.Location = new Point(157, 8);
            rdoRequestService.Margin = new Padding(3, 4, 3, 4);
            rdoRequestService.Name = "rdoRequestService";
            rdoRequestService.Size = new Size(146, 24);
            rdoRequestService.TabIndex = 1;
            rdoRequestService.TabStop = true;
            rdoRequestService.Text = "Request a Service";
            rdoRequestService.UseVisualStyleBackColor = true;
            // 
            // rdoReportIssue
            // 
            rdoReportIssue.AutoSize = true;
            rdoReportIssue.Location = new Point(14, 8);
            rdoReportIssue.Margin = new Padding(3, 4, 3, 4);
            rdoReportIssue.Name = "rdoReportIssue";
            rdoReportIssue.Size = new Size(131, 24);
            rdoReportIssue.TabIndex = 0;
            rdoReportIssue.TabStop = true;
            rdoReportIssue.Text = "Report an Issue";
            rdoReportIssue.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(16, 29);
            label5.Name = "label5";
            label5.Size = new Size(111, 23);
            label5.TabIndex = 10;
            label5.Text = "Request Type";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.FromArgb(252, 254, 255);
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(0, 170, 171);
            label6.Location = new Point(43, 291);
            label6.Name = "label6";
            label6.Size = new Size(73, 28);
            label6.TabIndex = 9;
            label6.Text = "Details";
            // 
            // panel18
            // 
            panel18.BackColor = Color.White;
            panel18.BorderStyle = BorderStyle.FixedSingle;
            panel18.Controls.Add(btnRemoveFile);
            panel18.Controls.Add(panel20);
            panel18.Controls.Add(pictureBox2);
            panel18.Controls.Add(btnAttachFile);
            panel18.Controls.Add(panel19);
            panel18.Controls.Add(label15);
            panel18.Location = new Point(850, 307);
            panel18.Margin = new Padding(3, 4, 3, 4);
            panel18.Name = "panel18";
            panel18.Size = new Size(498, 418);
            panel18.TabIndex = 15;
            // 
            // btnRemoveFile
            // 
            btnRemoveFile.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRemoveFile.ImageAlign = ContentAlignment.MiddleLeft;
            btnRemoveFile.Location = new Point(238, 71);
            btnRemoveFile.Margin = new Padding(3, 4, 3, 4);
            btnRemoveFile.Name = "btnRemoveFile";
            btnRemoveFile.Size = new Size(141, 53);
            btnRemoveFile.TabIndex = 28;
            btnRemoveFile.Text = "Remove File";
            btnRemoveFile.UseVisualStyleBackColor = true;
            btnRemoveFile.Click += btnRemoveFile_Click;
            // 
            // panel20
            // 
            panel20.Controls.Add(lstAttachments);
            panel20.Location = new Point(16, 149);
            panel20.Margin = new Padding(3, 4, 3, 4);
            panel20.Name = "panel20";
            panel20.Size = new Size(458, 251);
            panel20.TabIndex = 27;
            // 
            // lstAttachments
            // 
            lstAttachments.Location = new Point(-2, 0);
            lstAttachments.Margin = new Padding(3, 4, 3, 4);
            lstAttachments.Name = "lstAttachments";
            lstAttachments.Size = new Size(460, 249);
            lstAttachments.TabIndex = 0;
            lstAttachments.UseCompatibleStateImageBehavior = false;
            lstAttachments.View = View.List;
            // 
            // pictureBox2
            // 
            pictureBox2.Enabled = false;
            pictureBox2.ErrorImage = (Image)resources.GetObject("pictureBox2.ErrorImage");
            pictureBox2.Image = Properties.Resources.documents;
            pictureBox2.InitialImage = (Image)resources.GetObject("pictureBox2.InitialImage");
            pictureBox2.Location = new Point(16, 61);
            pictureBox2.Margin = new Padding(3, 4, 3, 4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(45, 63);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 26;
            pictureBox2.TabStop = false;
            // 
            // btnAttachFile
            // 
            btnAttachFile.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAttachFile.ImageAlign = ContentAlignment.MiddleLeft;
            btnAttachFile.Location = new Point(78, 71);
            btnAttachFile.Margin = new Padding(3, 4, 3, 4);
            btnAttachFile.Name = "btnAttachFile";
            btnAttachFile.Size = new Size(141, 53);
            btnAttachFile.TabIndex = 25;
            btnAttachFile.Text = "Attach File";
            btnAttachFile.UseVisualStyleBackColor = true;
            btnAttachFile.Click += btnAttachFile_Click;
            // 
            // panel19
            // 
            panel19.BackColor = Color.FromArgb(151, 115, 207);
            panel19.Location = new Point(-1, -1);
            panel19.Margin = new Padding(3, 4, 3, 4);
            panel19.Name = "panel19";
            panel19.Size = new Size(498, 3);
            panel19.TabIndex = 24;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label15.ForeColor = Color.Black;
            label15.Location = new Point(16, 29);
            label15.Name = "label15";
            label15.Size = new Size(456, 23);
            label15.TabIndex = 10;
            label15.Text = "Add photos or documents that may help explain the issue.";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.BackColor = Color.FromArgb(252, 254, 255);
            label16.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label16.ForeColor = Color.FromArgb(151, 115, 207);
            label16.Location = new Point(865, 291);
            label16.Name = "label16";
            label16.Size = new Size(127, 28);
            label16.TabIndex = 16;
            label16.Text = "Attachments";
            // 
            // panel21
            // 
            panel21.BackColor = Color.White;
            panel21.BorderStyle = BorderStyle.FixedSingle;
            panel21.Controls.Add(panel22);
            panel21.Controls.Add(lblProgressPercent);
            panel21.Controls.Add(progressBar1);
            panel21.Controls.Add(panel23);
            panel21.Location = new Point(850, 760);
            panel21.Margin = new Padding(3, 4, 3, 4);
            panel21.Name = "panel21";
            panel21.Size = new Size(498, 122);
            panel21.TabIndex = 17;
            panel21.Paint += panel21_Paint;
            // 
            // panel22
            // 
            panel22.BackColor = Color.FromArgb(255, 241, 189);
            panel22.Controls.Add(lblProgressMessage);
            panel22.Location = new Point(16, 71);
            panel22.Margin = new Padding(3, 4, 3, 4);
            panel22.Name = "panel22";
            panel22.Size = new Size(415, 31);
            panel22.TabIndex = 30;
            // 
            // lblProgressMessage
            // 
            lblProgressMessage.AutoSize = true;
            lblProgressMessage.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProgressMessage.ForeColor = Color.Black;
            lblProgressMessage.Location = new Point(2, 3);
            lblProgressMessage.Name = "lblProgressMessage";
            lblProgressMessage.Size = new Size(137, 23);
            lblProgressMessage.TabIndex = 28;
            lblProgressMessage.Text = "Let's get started!";
            // 
            // lblProgressPercent
            // 
            lblProgressPercent.AutoSize = true;
            lblProgressPercent.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProgressPercent.ForeColor = Color.FromArgb(0, 170, 171);
            lblProgressPercent.Location = new Point(438, 29);
            lblProgressPercent.Name = "lblProgressPercent";
            lblProgressPercent.Size = new Size(39, 25);
            lblProgressPercent.TabIndex = 29;
            lblProgressPercent.Text = "0%";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(16, 29);
            progressBar1.Margin = new Padding(3, 4, 3, 4);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(415, 31);
            progressBar1.TabIndex = 28;
            // 
            // panel23
            // 
            panel23.BackColor = Color.FromArgb(19, 134, 220);
            panel23.Location = new Point(-1, -1);
            panel23.Margin = new Padding(3, 4, 3, 4);
            panel23.Name = "panel23";
            panel23.Size = new Size(571, 3);
            panel23.TabIndex = 24;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.FromArgb(252, 254, 255);
            label13.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.FromArgb(19, 134, 220);
            label13.Location = new Point(870, 744);
            label13.Name = "label13";
            label13.Size = new Size(158, 28);
            label13.TabIndex = 18;
            label13.Text = "Report Progress";
            // 
            // btnBackToMenu
            // 
            btnBackToMenu.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnBackToMenu.Location = new Point(26, 912);
            btnBackToMenu.Margin = new Padding(0);
            btnBackToMenu.Name = "btnBackToMenu";
            btnBackToMenu.Size = new Size(229, 55);
            btnBackToMenu.TabIndex = 19;
            btnBackToMenu.Text = "Back to Main Menu";
            btnBackToMenu.UseVisualStyleBackColor = true;
            btnBackToMenu.Click += btnBackToMenu_Click;
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.FromArgb(43, 159, 74);
            btnSubmit.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSubmit.ForeColor = Color.FromArgb(246, 250, 249);
            btnSubmit.Location = new Point(1162, 912);
            btnSubmit.Margin = new Padding(0);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(186, 55);
            btnSubmit.TabIndex = 20;
            btnSubmit.Text = "Submit Report";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(238, 240, 243);
            btnClear.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnClear.Location = new Point(967, 912);
            btnClear.Margin = new Padding(0);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(186, 55);
            btnClear.TabIndex = 21;
            btnClear.Text = "Clear Form";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // ReportIssueForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(252, 254, 255);
            ClientSize = new Size(1378, 976);
            Controls.Add(btnClear);
            Controls.Add(btnSubmit);
            Controls.Add(btnBackToMenu);
            Controls.Add(label13);
            Controls.Add(panel21);
            Controls.Add(label16);
            Controls.Add(panel18);
            Controls.Add(label6);
            Controls.Add(panel15);
            Controls.Add(panel13);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "ReportIssueForm";
            Text = "ReportIssueForm";
            Load += ReportIssueForm_Load;
            panel13.ResumeLayout(false);
            panel13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel15.ResumeLayout(false);
            panel15.PerformLayout();
            panel16.ResumeLayout(false);
            panel16.PerformLayout();
            panel18.ResumeLayout(false);
            panel18.PerformLayout();
            panel20.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel21.ResumeLayout(false);
            panel21.PerformLayout();
            panel22.ResumeLayout(false);
            panel22.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel13;
        private PictureBox pictureBox5;
        private Label label3;
        private Label label4;
        private Panel panel14;
        private Panel panel2;
        private Panel panel7;
        private Panel panel6;
        private Panel panel4;
        private Panel panel3;
        private Panel panel1;
        private Panel panel12;
        private Panel panel11;
        private Panel panel10;
        private Panel panel9;
        private Panel panel8;
        private Panel panel5;
        private Label label2;
        private Label label1;
        private PictureBox pictureBox1;
        private Panel panel15;
        private Label label6;
        private Panel panel16;
        private RadioButton rdoReportIssue;
        private Label label5;
        private TextBox txtLocation;
        private Label label7;
        private RadioButton rdoRequestService;
        private RichTextBox txtDescription;
        private Label label10;
        private DateTimePicker dtpIncidentDate;
        private Label label9;
        private ComboBox cmbCategory;
        private Label label8;
        private Panel panel17;
        private Panel panel18;
        private Panel panel19;
        private Label label15;
        private Button btnAttachFile;
        private Label label16;
        private Panel panel20;
        private PictureBox pictureBox2;
        private Panel panel21;
        private Panel panel23;
        private Panel panel22;
        private Label lblProgressMessage;
        private Label lblProgressPercent;
        private ProgressBar progressBar1;
        private Label label13;
        private Button btnBackToMenu;
        private Button btnSubmit;
        private Button btnClear;
        private Button btnRemoveFile;
        private ListView lstAttachments;
        private Label lblRequestTypeError;
        private Label lblDescriptionError;
        private Label lblIncidentDateError;
        private Label lblCategoryError;
        private Label lblLocationError;
    }
}