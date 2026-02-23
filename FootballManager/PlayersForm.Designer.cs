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
            btnLoad = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            txtId = new TextBox();
            txtNationality = new TextBox();
            label3 = new Label();
            label4 = new Label();
            numKitNumber = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)dgvPlayers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numKitNumber).BeginInit();
            SuspendLayout();
            // 
            // dgvPlayers
            // 
            dgvPlayers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPlayers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPlayers.Location = new Point(12, 12);
            dgvPlayers.Name = "dgvPlayers";
            dgvPlayers.ReadOnly = true;
            dgvPlayers.Size = new Size(776, 268);
            dgvPlayers.TabIndex = 0;
            dgvPlayers.CellClick += dgvPlayers_CellClick;
            // 
            // txtFirstName
            // 
            txtFirstName.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            txtFirstName.Location = new Point(180, 309);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(134, 29);
            txtFirstName.TabIndex = 1;
            // 
            // txtLastName
            // 
            txtLastName.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            txtLastName.Location = new Point(180, 351);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(134, 29);
            txtLastName.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.Location = new Point(127, 314);
            label1.Name = "label1";
            label1.Size = new Size(47, 21);
            label1.TabIndex = 3;
            label1.Text = "Име:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.Location = new Point(90, 355);
            label2.Name = "label2";
            label2.Size = new Size(84, 21);
            label2.TabIndex = 4;
            label2.Text = "Фамилия:";
            // 
            // btnLoad
            // 
            btnLoad.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnLoad.Location = new Point(656, 316);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(120, 40);
            btnLoad.TabIndex = 5;
            btnLoad.Text = "Зареди";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnEdit
            // 
            btnEdit.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnEdit.Location = new Point(353, 394);
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
            btnAdd.Location = new Point(353, 316);
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
            btnDelete.Location = new Point(505, 316);
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
            btnClear.Location = new Point(505, 394);
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
            txtId.Location = new Point(688, 453);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(100, 29);
            txtId.TabIndex = 10;
            txtId.Visible = false;
            // 
            // txtNationality
            // 
            txtNationality.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            txtNationality.Location = new Point(180, 392);
            txtNationality.Name = "txtNationality";
            txtNationality.Size = new Size(134, 29);
            txtNationality.TabIndex = 11;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label3.Location = new Point(50, 395);
            label3.Name = "label3";
            label3.Size = new Size(124, 21);
            label3.TabIndex = 13;
            label3.Text = "Националност:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label4.Location = new Point(6, 439);
            label4.Name = "label4";
            label4.Size = new Size(168, 21);
            label4.TabIndex = 14;
            label4.Text = "Година на създаване:";
            // 
            // numKitNumber
            // 
            numKitNumber.Location = new Point(180, 440);
            numKitNumber.Name = "numKitNumber";
            numKitNumber.Size = new Size(134, 23);
            numKitNumber.TabIndex = 15;
            // 
            // PlayersForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 488);
            Controls.Add(numKitNumber);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtNationality);
            Controls.Add(txtId);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(btnEdit);
            Controls.Add(btnLoad);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtLastName);
            Controls.Add(txtFirstName);
            Controls.Add(dgvPlayers);
            Name = "PlayersForm";
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
        private Button btnLoad;
        private Button btnEdit;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnClear;
        private TextBox txtId;
        private TextBox txtNationality;
        private Label label3;
        private Label label4;
        private NumericUpDown numKitNumber;
    }
}
