namespace FootballManager.UI
{
    partial class StandingsForm
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
            cboLeague = new ComboBox();
            dgvStandings = new DataGridView();
            btnRefresh = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvStandings).BeginInit();
            SuspendLayout();
            // 
            // cboLeague
            // 
            cboLeague.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboLeague.FormattingEnabled = true;
            cboLeague.Location = new Point(228, 341);
            cboLeague.Name = "cboLeague";
            cboLeague.Size = new Size(256, 29);
            cboLeague.TabIndex = 0;
            cboLeague.SelectedIndexChanged += cboLeague_SelectedIndexChanged;
            // 
            // dgvStandings
            // 
            dgvStandings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStandings.Location = new Point(-6, 0);
            dgvStandings.Name = "dgvStandings";
            dgvStandings.Size = new Size(644, 322);
            dgvStandings.TabIndex = 1;
            // 
            // btnRefresh
            // 
            btnRefresh.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRefresh.Location = new Point(241, 387);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(155, 41);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "Презареди";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.Location = new Point(114, 343);
            label1.Name = "label1";
            label1.Size = new Size(108, 21);
            label1.TabIndex = 4;
            label1.Text = "Избери лига:";
            // 
            // StandingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(634, 450);
            Controls.Add(label1);
            Controls.Add(btnRefresh);
            Controls.Add(dgvStandings);
            Controls.Add(cboLeague);
            Name = "StandingsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Класиране";
            Load += StandingsForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvStandings).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboLeague;
        private DataGridView dgvStandings;
        private Button btnRefresh;
        private Label label1;
    }
}