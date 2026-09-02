namespace MunicipalityConnect
{
    partial class SubmissionSuccessForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubmissionSuccessForm));
            pictureBox5 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            lblSubmitted = new Label();
            lblStatus = new Label();
            lblIncidentDate = new Label();
            lblCategory = new Label();
            lblType = new Label();
            lblReference = new Label();
            btnOK = new Button();
            btnReturnToMenu = new Button();
            txtSubmittedDescription = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            SuspendLayout();
            // 
            // pictureBox5
            // 
            pictureBox5.Enabled = false;
            pictureBox5.ErrorImage = (Image)resources.GetObject("pictureBox5.ErrorImage");
            pictureBox5.Image = Properties.Resources.check_mark;
            pictureBox5.InitialImage = (Image)resources.GetObject("pictureBox5.InitialImage");
            pictureBox5.Location = new Point(15, 17);
            pictureBox5.Margin = new Padding(4, 4, 4, 4);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(36, 49);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 14;
            pictureBox5.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Green;
            label1.Location = new Point(59, 17);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(284, 21);
            label1.TabIndex = 15;
            label1.Text = "Thank you for helping your community.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Gray;
            label2.Location = new Point(59, 73);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(245, 20);
            label2.TabIndex = 16;
            label2.Text = "Your submission has been recorded.";
            // 
            // lblSubmitted
            // 
            lblSubmitted.AutoSize = true;
            lblSubmitted.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubmitted.ForeColor = Color.Black;
            lblSubmitted.Location = new Point(58, 414);
            lblSubmitted.Margin = new Padding(4, 0, 4, 0);
            lblSubmitted.Name = "lblSubmitted";
            lblSubmitted.Size = new Size(81, 20);
            lblSubmitted.TabIndex = 28;
            lblSubmitted.Text = "Submitted:";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStatus.ForeColor = Color.Black;
            lblStatus.Location = new Point(58, 370);
            lblStatus.Margin = new Padding(4, 0, 4, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(52, 20);
            lblStatus.TabIndex = 27;
            lblStatus.Text = "Status:";
            // 
            // lblIncidentDate
            // 
            lblIncidentDate.AutoSize = true;
            lblIncidentDate.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblIncidentDate.ForeColor = Color.Black;
            lblIncidentDate.Location = new Point(58, 258);
            lblIncidentDate.Margin = new Padding(4, 0, 4, 0);
            lblIncidentDate.Name = "lblIncidentDate";
            lblIncidentDate.Size = new Size(101, 20);
            lblIncidentDate.TabIndex = 26;
            lblIncidentDate.Text = "Incident Date:";
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCategory.ForeColor = Color.Black;
            lblCategory.Location = new Point(58, 213);
            lblCategory.Margin = new Padding(4, 0, 4, 0);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(72, 20);
            lblCategory.TabIndex = 25;
            lblCategory.Text = "Category:";
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblType.ForeColor = Color.Black;
            lblType.Location = new Point(58, 169);
            lblType.Margin = new Padding(4, 0, 4, 0);
            lblType.Name = "lblType";
            lblType.Size = new Size(43, 20);
            lblType.TabIndex = 24;
            lblType.Text = "Type:";
            // 
            // lblReference
            // 
            lblReference.AutoSize = true;
            lblReference.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblReference.ForeColor = Color.Black;
            lblReference.Location = new Point(58, 129);
            lblReference.Margin = new Padding(4, 0, 4, 0);
            lblReference.Name = "lblReference";
            lblReference.Size = new Size(78, 20);
            lblReference.TabIndex = 23;
            lblReference.Text = "Reference:";
            // 
            // btnOK
            // 
            btnOK.BackColor = Color.FromArgb(238, 240, 243);
            btnOK.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnOK.Location = new Point(329, 444);
            btnOK.Margin = new Padding(4, 4, 4, 4);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(96, 56);
            btnOK.TabIndex = 30;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = false;
            // 
            // btnReturnToMenu
            // 
            btnReturnToMenu.BackColor = Color.FromArgb(43, 159, 74);
            btnReturnToMenu.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReturnToMenu.ForeColor = Color.FromArgb(246, 250, 249);
            btnReturnToMenu.Location = new Point(429, 444);
            btnReturnToMenu.Margin = new Padding(0);
            btnReturnToMenu.Name = "btnReturnToMenu";
            btnReturnToMenu.Size = new Size(244, 56);
            btnReturnToMenu.TabIndex = 29;
            btnReturnToMenu.Text = "Return to Main Menu";
            btnReturnToMenu.UseVisualStyleBackColor = false;
            btnReturnToMenu.Click += btnReturnToMenu_Click;
            // 
            // txtSubmittedDescription
            // 
            txtSubmittedDescription.BackColor = SystemColors.Control;
            txtSubmittedDescription.Enabled = false;
            txtSubmittedDescription.ForeColor = Color.Black;
            txtSubmittedDescription.Location = new Point(59, 290);
            txtSubmittedDescription.Margin = new Padding(4, 4, 4, 4);
            txtSubmittedDescription.Multiline = true;
            txtSubmittedDescription.Name = "txtSubmittedDescription";
            txtSubmittedDescription.Size = new Size(613, 68);
            txtSubmittedDescription.TabIndex = 32;
            // 
            // SubmissionSuccessForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(739, 533);
            Controls.Add(txtSubmittedDescription);
            Controls.Add(btnOK);
            Controls.Add(btnReturnToMenu);
            Controls.Add(lblSubmitted);
            Controls.Add(lblStatus);
            Controls.Add(lblIncidentDate);
            Controls.Add(lblCategory);
            Controls.Add(lblType);
            Controls.Add(lblReference);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox5);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 4, 4, 4);
            Name = "SubmissionSuccessForm";
            Text = "Report Submitted Successfully";
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox5;
        private Label label1;
        private Label label2;
        private Label lblSubmitted;
        private Label lblStatus;
        private Label lblIncidentDate;
        private Label lblCategory;
        private Label lblType;
        private Label lblReference;
        private Button btnOK;
        private Button btnReturnToMenu;
        private TextBox txtSubmittedDescription;
    }
}