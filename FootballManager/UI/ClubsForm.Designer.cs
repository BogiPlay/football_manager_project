namespace FootballManager.UI
{
    partial class ClubsForm
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
            dgvClubs = new DataGridView();
            txtName = new TextBox();
            txtCity = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnEdit = new Button();
            btnAdd = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            txtId = new TextBox();
            txtStadium = new TextBox();
            txtFoundedYear = new TextBox();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvClubs).BeginInit();
            SuspendLayout();
            // 
            // dgvClubs
            // 
            dgvClubs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClubs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClubs.Location = new Point(12, 12);
            dgvClubs.Name = "dgvClubs";
            dgvClubs.ReadOnly = true;
            dgvClubs.Size = new Size(635, 268);
            dgvClubs.TabIndex = 0;
            dgvClubs.CellClick += dgvClubs_CellClick;
            // 
            // txtName
            // 
            txtName.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            txtName.Location = new Point(180, 309);
            txtName.Name = "txtName";
            txtName.Size = new Size(134, 29);
            txtName.TabIndex = 1;
            // 
            // txtCity
            // 
            txtCity.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            txtCity.Location = new Point(180, 351);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(134, 29);
            txtCity.TabIndex = 2;
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
            label2.Location = new Point(126, 353);
            label2.Name = "label2";
            label2.Size = new Size(48, 21);
            label2.TabIndex = 4;
            label2.Text = "Град:";
            // 
            // btnEdit
            // 
            btnEdit.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnEdit.Location = new Point(376, 389);
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
            btnAdd.Location = new Point(376, 314);
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
            btnDelete.Location = new Point(519, 314);
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
            btnClear.Location = new Point(519, 389);
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
            txtId.Location = new Point(547, 455);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(100, 29);
            txtId.TabIndex = 10;
            txtId.Visible = false;
            // 
            // txtStadium
            // 
            txtStadium.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            txtStadium.Location = new Point(180, 392);
            txtStadium.Name = "txtStadium";
            txtStadium.Size = new Size(134, 29);
            txtStadium.TabIndex = 11;
            // 
            // txtFoundedYear
            // 
            txtFoundedYear.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            txtFoundedYear.Location = new Point(180, 436);
            txtFoundedYear.Name = "txtFoundedYear";
            txtFoundedYear.Size = new Size(134, 29);
            txtFoundedYear.TabIndex = 12;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label3.Location = new Point(97, 396);
            label3.Name = "label3";
            label3.Size = new Size(77, 21);
            label3.TabIndex = 13;
            label3.Text = "Стадион:";
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
            // ClubsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(657, 488);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtFoundedYear);
            Controls.Add(txtStadium);
            Controls.Add(txtId);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(btnEdit);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtCity);
            Controls.Add(txtName);
            Controls.Add(dgvClubs);
            Name = "ClubsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Управление на клубове";
            Load += ClubsForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvClubs).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvClubs;
        private TextBox txtName;
        private TextBox txtCity;
        private Label label1;
        private Label label2;
        private Button btnEdit;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnClear;
        private TextBox txtId;
        private TextBox txtStadium;
        private TextBox txtFoundedYear;
        private Label label3;
        private Label label4;
    }
}
