namespace FootballManager
{
    partial class LeaguesForm
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
            dgvLeagues = new DataGridView();
            txtId = new TextBox();
            txtName = new TextBox();
            txtSeason = new TextBox();
            btnAddLeague = new Button();
            btnEditLeague = new Button();
            btnDeleteLeague = new Button();
            btnClearLeague = new Button();
            dgvParticipants = new DataGridView();
            cboAvailableClubs = new ComboBox();
            btnAddClubToLeague = new Button();
            btnRemoveClubFromLeague = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvLeagues).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvParticipants).BeginInit();
            SuspendLayout();
            // 
            // dgvLeagues
            // 
            dgvLeagues.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLeagues.Location = new Point(21, 46);
            dgvLeagues.Name = "dgvLeagues";
            dgvLeagues.Size = new Size(403, 339);
            dgvLeagues.TabIndex = 0;
            dgvLeagues.SelectionChanged += dgvLeagues_SelectionChanged;
            // 
            // txtId
            // 
            txtId.Location = new Point(689, 608);
            txtId.Name = "txtId";
            txtId.Size = new Size(100, 23);
            txtId.TabIndex = 1;
            txtId.Visible = false;
            // 
            // txtName
            // 
            txtName.Font = new Font("Segoe UI", 12F);
            txtName.Location = new Point(194, 409);
            txtName.Name = "txtName";
            txtName.Size = new Size(168, 29);
            txtName.TabIndex = 2;
            // 
            // txtSeason
            // 
            txtSeason.Font = new Font("Segoe UI", 12F);
            txtSeason.Location = new Point(194, 455);
            txtSeason.Name = "txtSeason";
            txtSeason.Size = new Size(168, 29);
            txtSeason.TabIndex = 3;
            // 
            // btnAddLeague
            // 
            btnAddLeague.Font = new Font("Segoe UI", 12F);
            btnAddLeague.Location = new Point(80, 511);
            btnAddLeague.Name = "btnAddLeague";
            btnAddLeague.Size = new Size(106, 39);
            btnAddLeague.TabIndex = 4;
            btnAddLeague.Text = "Добави";
            btnAddLeague.UseVisualStyleBackColor = true;
            btnAddLeague.Click += btnAddLeague_Click;
            // 
            // btnEditLeague
            // 
            btnEditLeague.Font = new Font("Segoe UI", 12F);
            btnEditLeague.Location = new Point(80, 575);
            btnEditLeague.Name = "btnEditLeague";
            btnEditLeague.Size = new Size(106, 39);
            btnEditLeague.TabIndex = 5;
            btnEditLeague.Text = "Редактирай";
            btnEditLeague.UseVisualStyleBackColor = true;
            btnEditLeague.Click += btnEditLeague_Click;
            // 
            // btnDeleteLeague
            // 
            btnDeleteLeague.Font = new Font("Segoe UI", 12F);
            btnDeleteLeague.Location = new Point(247, 511);
            btnDeleteLeague.Name = "btnDeleteLeague";
            btnDeleteLeague.Size = new Size(106, 39);
            btnDeleteLeague.TabIndex = 6;
            btnDeleteLeague.Text = "Изтрий";
            btnDeleteLeague.UseVisualStyleBackColor = true;
            btnDeleteLeague.Click += btnDeleteLeague_Click;
            // 
            // btnClearLeague
            // 
            btnClearLeague.Font = new Font("Segoe UI", 12F);
            btnClearLeague.Location = new Point(247, 575);
            btnClearLeague.Name = "btnClearLeague";
            btnClearLeague.Size = new Size(106, 39);
            btnClearLeague.TabIndex = 7;
            btnClearLeague.Text = "Изчисти";
            btnClearLeague.UseVisualStyleBackColor = true;
            btnClearLeague.Click += btnClearLeague_Click;
            // 
            // dgvParticipants
            // 
            dgvParticipants.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvParticipants.Location = new Point(481, 46);
            dgvParticipants.Name = "dgvParticipants";
            dgvParticipants.Size = new Size(301, 340);
            dgvParticipants.TabIndex = 8;
            // 
            // cboAvailableClubs
            // 
            cboAvailableClubs.Font = new Font("Segoe UI", 12F);
            cboAvailableClubs.FormattingEnabled = true;
            cboAvailableClubs.Location = new Point(597, 414);
            cboAvailableClubs.Name = "cboAvailableClubs";
            cboAvailableClubs.Size = new Size(149, 29);
            cboAvailableClubs.TabIndex = 9;
            // 
            // btnAddClubToLeague
            // 
            btnAddClubToLeague.Font = new Font("Segoe UI", 12F);
            btnAddClubToLeague.Location = new Point(512, 480);
            btnAddClubToLeague.Name = "btnAddClubToLeague";
            btnAddClubToLeague.Size = new Size(106, 39);
            btnAddClubToLeague.TabIndex = 10;
            btnAddClubToLeague.Text = "Добави";
            btnAddClubToLeague.UseVisualStyleBackColor = true;
            btnAddClubToLeague.Click += btnAddClubToLeague_Click;
            // 
            // btnRemoveClubFromLeague
            // 
            btnRemoveClubFromLeague.Font = new Font("Segoe UI", 12F);
            btnRemoveClubFromLeague.Location = new Point(649, 480);
            btnRemoveClubFromLeague.Name = "btnRemoveClubFromLeague";
            btnRemoveClubFromLeague.Size = new Size(106, 39);
            btnRemoveClubFromLeague.TabIndex = 11;
            btnRemoveClubFromLeague.Text = "Премахни";
            btnRemoveClubFromLeague.UseVisualStyleBackColor = true;
            btnRemoveClubFromLeague.Click += btnRemoveClubFromLeague_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.Location = new Point(45, 412);
            label1.Name = "label1";
            label1.Size = new Size(120, 21);
            label1.TabIndex = 12;
            label1.Text = "Име на лигата:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.Location = new Point(104, 458);
            label2.Name = "label2";
            label2.Size = new Size(59, 21);
            label2.TabIndex = 13;
            label2.Text = "Сезон:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label3.Location = new Point(532, 418);
            label3.Name = "label3";
            label3.Size = new Size(51, 21);
            label3.TabIndex = 14;
            label3.Text = "Клуб:";
            // 
            // label4
            // 
            label4.BorderStyle = BorderStyle.Fixed3D;
            label4.Location = new Point(452, 72);
            label4.Name = "label4";
            label4.Size = new Size(1, 500);
            label4.TabIndex = 15;
            label4.Text = "label4";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            label5.Location = new Point(190, 13);
            label5.Name = "label5";
            label5.Size = new Size(58, 25);
            label5.TabIndex = 16;
            label5.Text = "Лиги";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            label6.Location = new Point(591, 13);
            label6.Name = "label6";
            label6.Size = new Size(91, 25);
            label6.TabIndex = 17;
            label6.Text = "Клубове";
            // 
            // LeaguesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(801, 643);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnRemoveClubFromLeague);
            Controls.Add(btnAddClubToLeague);
            Controls.Add(cboAvailableClubs);
            Controls.Add(dgvParticipants);
            Controls.Add(btnClearLeague);
            Controls.Add(btnDeleteLeague);
            Controls.Add(btnEditLeague);
            Controls.Add(btnAddLeague);
            Controls.Add(txtSeason);
            Controls.Add(txtName);
            Controls.Add(txtId);
            Controls.Add(dgvLeagues);
            Name = "LeaguesForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Управление на Лиги";
            Load += LeaguesForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvLeagues).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvParticipants).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvLeagues;
        private TextBox txtId;
        private TextBox txtName;
        private TextBox txtSeason;
        private Button btnAddLeague;
        private Button btnEditLeague;
        private Button btnDeleteLeague;
        private Button btnClearLeague;
        private DataGridView dgvParticipants;
        private ComboBox cboAvailableClubs;
        private Button btnAddClubToLeague;
        private Button btnRemoveClubFromLeague;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}