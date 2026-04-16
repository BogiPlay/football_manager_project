namespace FootballManager.UI
{
    partial class ScheduleForm
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
            dgvSchedule = new DataGridView();
            btnGenerate = new Button();
            label5 = new Label();
            dtpStartDate = new DateTimePicker();
            label7 = new Label();
            cboLeague = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvSchedule).BeginInit();
            SuspendLayout();
            // 
            // dgvSchedule
            // 
            dgvSchedule.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSchedule.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSchedule.Location = new Point(12, 12);
            dgvSchedule.Name = "dgvSchedule";
            dgvSchedule.ReadOnly = true;
            dgvSchedule.Size = new Size(635, 268);
            dgvSchedule.TabIndex = 1;
            // 
            // btnGenerate
            // 
            btnGenerate.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnGenerate.Location = new Point(209, 383);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(236, 40);
            btnGenerate.TabIndex = 8;
            btnGenerate.Text = "Генерирай";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(332, 313);
            label5.Name = "label5";
            label5.Size = new Size(113, 21);
            label5.TabIndex = 24;
            label5.Text = "Начална дата:";
            // 
            // dtpStartDate
            // 
            dtpStartDate.Location = new Point(451, 312);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(196, 23);
            dtpStartDate.TabIndex = 23;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label7.Location = new Point(34, 313);
            label7.Name = "label7";
            label7.Size = new Size(49, 21);
            label7.TabIndex = 26;
            label7.Text = "Лига:";
            // 
            // cboLeague
            // 
            cboLeague.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLeague.FormattingEnabled = true;
            cboLeague.Location = new Point(89, 315);
            cboLeague.Name = "cboLeague";
            cboLeague.Size = new Size(196, 23);
            cboLeague.TabIndex = 25;
            cboLeague.SelectedIndexChanged += cboLeague_SelectedIndexChanged;
            // 
            // ScheduleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(660, 450);
            Controls.Add(label7);
            Controls.Add(cboLeague);
            Controls.Add(label5);
            Controls.Add(dtpStartDate);
            Controls.Add(btnGenerate);
            Controls.Add(dgvSchedule);
            Name = "ScheduleForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Програма на първенството";
            Load += ScheduleForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSchedule).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvSchedule;
        private Button btnGenerate;
        private Label label5;
        private DateTimePicker dtpStartDate;
        private Label label7;
        private ComboBox cboLeague;
    }
}