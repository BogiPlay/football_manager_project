namespace FootballManager
{
    partial class PlayersForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvPlayers = new DataGridView();
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnEdit = new Button();
            btnAdd = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            txtId = new TextBox();
            txtNationality = new TextBox();
            label3 = new Label();
            label4 = new Label();
            numKitNumber = new NumericUpDown();
            cboClubFilter = new ComboBox();
            cboPositionFilter = new ComboBox();
            cboPosition = new ComboBox();
            cboClub = new ComboBox();
            txtSearchName = new TextBox();
            dtpBirthDate = new DateTimePicker();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvPlayers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numKitNumber).BeginInit();
            SuspendLayout();
            // 
            // dgvPlayers
            // 
            dgvPlayers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPlayers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPlayers.Location = new Point(12, 56);
            dgvPlayers.Name = "dgvPlayers";
            dgvPlayers.ReadOnly = true;
            dgvPlayers.Size = new Size(845, 288);
            dgvPlayers.TabIndex = 0;
            dgvPlayers.CellClick += dgvPlayers_CellClick;
            // 
            // txtFirstName
            // 
            txtFirstName.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            txtFirstName.Location = new Point(149, 395);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(134, 29);
            txtFirstName.TabIndex = 1;
            // 
            // txtLastName
            // 
            txtLastName.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            txtLastName.Location = new Point(149, 437);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(134, 29);
            txtLastName.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.Location = new Point(96, 400);
            label1.Name = "label1";
            label1.Size = new Size(47, 21);
            label1.TabIndex = 3;
            label1.Text = "Име:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.Location = new Point(59, 441);
            label2.Name = "label2";
            label2.Size = new Size(84, 21);
            label2.TabIndex = 4;
            label2.Text = "Фамилия:";
            // 
            // btnEdit
            // 
            btnEdit.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnEdit.Location = new Point(737, 466);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(120, 40);
            btnEdit.TabIndex = 6;
            btnEdit.Text = "Редактирай";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnAdd.Location = new Point(737, 359);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(120, 40);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "Добави";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnDelete.Location = new Point(737, 410);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(120, 40);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Изтрий";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnClear.Location = new Point(737, 524);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(120, 40);
            btnClear.TabIndex = 9;
            btnClear.Text = "Изчисти";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // txtId
            // 
            txtId.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            txtId.Location = new Point(304, 18);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(100, 29);
            txtId.TabIndex = 10;
            txtId.Visible = false;
            // 
            // txtNationality
            // 
            txtNationality.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            txtNationality.Location = new Point(149, 478);
            txtNationality.Name = "txtNationality";
            txtNationality.Size = new Size(134, 29);
            txtNationality.TabIndex = 11;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label3.Location = new Point(19, 481);
            label3.Name = "label3";
            label3.Size = new Size(124, 21);
            label3.TabIndex = 13;
            label3.Text = "Националност:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label4.Location = new Point(76, 524);
            label4.Name = "label4";
            label4.Size = new Size(67, 21);
            label4.TabIndex = 14;
            label4.Text = "Номер:";
            // 
            // numKitNumber
            // 
            numKitNumber.Location = new Point(149, 526);
            numKitNumber.Name = "numKitNumber";
            numKitNumber.Size = new Size(134, 23);
            numKitNumber.TabIndex = 15;
            // 
            // cboClubFilter
            // 
            cboClubFilter.FormattingEnabled = true;
            cboClubFilter.Location = new Point(722, 23);
            cboClubFilter.Name = "cboClubFilter";
            cboClubFilter.Size = new Size(121, 23);
            cboClubFilter.TabIndex = 16;
            cboClubFilter.SelectedIndexChanged += cboClubFilter_SelectedIndexChanged;
            // 
            // cboPositionFilter
            // 
            cboPositionFilter.FormattingEnabled = true;
            cboPositionFilter.Location = new Point(508, 23);
            cboPositionFilter.Name = "cboPositionFilter";
            cboPositionFilter.Size = new Size(121, 23);
            cboPositionFilter.TabIndex = 17;
            cboPositionFilter.SelectedIndexChanged += cboPositionFilter_SelectedIndexChanged;
            // 
            // cboPosition
            // 
            cboPosition.FormattingEnabled = true;
            cboPosition.Location = new Point(508, 442);
            cboPosition.Name = "cboPosition";
            cboPosition.Size = new Size(196, 23);
            cboPosition.TabIndex = 18;
            // 
            // cboClub
            // 
            cboClub.FormattingEnabled = true;
            cboClub.Location = new Point(508, 492);
            cboClub.Name = "cboClub";
            cboClub.Size = new Size(196, 23);
            cboClub.TabIndex = 19;
            // 
            // txtSearchName
            // 
            txtSearchName.Location = new Point(30, 24);
            txtSearchName.Name = "txtSearchName";
            txtSearchName.Size = new Size(253, 23);
            txtSearchName.TabIndex = 20;
            txtSearchName.TextChanged += txtSearchName_TextChanged;
            // 
            // dtpBirthDate
            // 
            dtpBirthDate.Location = new Point(508, 398);
            dtpBirthDate.Name = "dtpBirthDate";
            dtpBirthDate.Size = new Size(196, 23);
            dtpBirthDate.TabIndex = 21;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(364, 397);
            label5.Name = "label5";
            label5.Size = new Size(140, 21);
            label5.TabIndex = 22;
            label5.Text = "Дата на раждане:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label6.Location = new Point(451, 490);
            label6.Name = "label6";
            label6.Size = new Size(51, 21);
            label6.TabIndex = 23;
            label6.Text = "Клуб:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label7.Location = new Point(420, 442);
            label7.Name = "label7";
            label7.Size = new Size(82, 21);
            label7.TabIndex = 24;
            label7.Text = "Позиция:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label8.Location = new Point(420, 23);
            label8.Name = "label8";
            label8.Size = new Size(82, 21);
            label8.TabIndex = 25;
            label8.Text = "Позиция:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label9.Location = new Point(664, 24);
            label9.Name = "label9";
            label9.Size = new Size(51, 21);
            label9.TabIndex = 26;
            label9.Text = "Клуб:";
            // 
            // PlayersForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(869, 584);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(dtpBirthDate);
            Controls.Add(txtSearchName);
            Controls.Add(cboClub);
            Controls.Add(cboPosition);
            Controls.Add(cboPositionFilter);
            Controls.Add(cboClubFilter);
            Controls.Add(numKitNumber);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtNationality);
            Controls.Add(txtId);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(btnEdit);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtLastName);
            Controls.Add(txtFirstName);
            Controls.Add(dgvPlayers);
            Name = "PlayersForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Управление на играчи";
            Load += PlayersForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPlayers).EndInit();
            ((System.ComponentModel.ISupportInitialize)numKitNumber).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvPlayers;
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private Label label1;
        private Label label2;
        private Button btnEdit;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnClear;
        private TextBox txtId;
        private TextBox txtNationality;
        private Label label3;
        private Label label4;
        private NumericUpDown numKitNumber;
        private ComboBox cboClubFilter;
        private ComboBox cboPositionFilter;
        private ComboBox cboPosition;
        private ComboBox cboClub;
        private TextBox txtSearchName;
        private DateTimePicker dtpBirthDate;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
    }
}
