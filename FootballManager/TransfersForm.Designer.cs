namespace FootballManager
{
    partial class TransfersForm
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
            dgvTransfers = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            btnTransfer = new Button();
            txtId = new TextBox();
            label3 = new Label();
            label4 = new Label();
            cboPlayer = new ComboBox();
            txtFromClub = new TextBox();
            cboToClub = new ComboBox();
            dtpTransferDate = new DateTimePicker();
            numFee = new NumericUpDown();
            cboPlayerFilter = new ComboBox();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvTransfers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numFee).BeginInit();
            SuspendLayout();
            // 
            // dgvTransfers
            // 
            dgvTransfers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTransfers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTransfers.Location = new Point(12, 41);
            dgvTransfers.Name = "dgvTransfers";
            dgvTransfers.ReadOnly = true;
            dgvTransfers.Size = new Size(705, 254);
            dgvTransfers.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.Location = new Point(90, 320);
            label1.Name = "label1";
            label1.Size = new Size(59, 21);
            label1.TabIndex = 3;
            label1.Text = "Играч:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.Location = new Point(62, 396);
            label2.Name = "label2";
            label2.Size = new Size(87, 21);
            label2.TabIndex = 4;
            label2.Text = "Нов клуб: ";
            // 
            // btnTransfer
            // 
            btnTransfer.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnTransfer.Location = new Point(248, 455);
            btnTransfer.Name = "btnTransfer";
            btnTransfer.Size = new Size(243, 40);
            btnTransfer.TabIndex = 7;
            btnTransfer.Text = "Трансфер";
            btnTransfer.UseVisualStyleBackColor = true;
            btnTransfer.Click += btnTransfer_Click;
            // 
            // txtId
            // 
            txtId.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            txtId.Location = new Point(618, 466);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(100, 29);
            txtId.TabIndex = 10;
            txtId.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label3.Location = new Point(428, 318);
            label3.Name = "label3";
            label3.Size = new Size(49, 21);
            label3.TabIndex = 13;
            label3.Text = "Дата:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label4.Location = new Point(425, 360);
            label4.Name = "label4";
            label4.Size = new Size(52, 21);
            label4.TabIndex = 14;
            label4.Text = "Цена:";
            // 
            // cboPlayer
            // 
            cboPlayer.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPlayer.FormattingEnabled = true;
            cboPlayer.Location = new Point(150, 319);
            cboPlayer.Name = "cboPlayer";
            cboPlayer.Size = new Size(159, 23);
            cboPlayer.TabIndex = 15;
            cboPlayer.SelectedIndexChanged += cboPlayer_SelectedIndexChanged;
            // 
            // txtFromClub
            // 
            txtFromClub.Location = new Point(150, 356);
            txtFromClub.Name = "txtFromClub";
            txtFromClub.ReadOnly = true;
            txtFromClub.Size = new Size(159, 23);
            txtFromClub.TabIndex = 16;
            // 
            // cboToClub
            // 
            cboToClub.DropDownStyle = ComboBoxStyle.DropDownList;
            cboToClub.FormattingEnabled = true;
            cboToClub.Location = new Point(150, 395);
            cboToClub.Name = "cboToClub";
            cboToClub.Size = new Size(159, 23);
            cboToClub.TabIndex = 17;
            // 
            // dtpTransferDate
            // 
            dtpTransferDate.Location = new Point(479, 318);
            dtpTransferDate.Name = "dtpTransferDate";
            dtpTransferDate.Size = new Size(159, 23);
            dtpTransferDate.TabIndex = 18;
            // 
            // numFee
            // 
            numFee.Location = new Point(479, 361);
            numFee.Name = "numFee";
            numFee.Size = new Size(159, 23);
            numFee.TabIndex = 19;
            // 
            // cboPlayerFilter
            // 
            cboPlayerFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPlayerFilter.FormattingEnabled = true;
            cboPlayerFilter.Location = new Point(587, 12);
            cboPlayerFilter.Name = "cboPlayerFilter";
            cboPlayerFilter.Size = new Size(121, 23);
            cboPlayerFilter.TabIndex = 21;
            cboPlayerFilter.SelectedIndexChanged += cboPlayerFilter_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label5.Location = new Point(62, 358);
            label5.Name = "label5";
            label5.Size = new Size(87, 21);
            label5.TabIndex = 22;
            label5.Text = "Стар клуб:";
            // 
            // TransfersForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(730, 507);
            Controls.Add(label5);
            Controls.Add(cboPlayerFilter);
            Controls.Add(numFee);
            Controls.Add(dtpTransferDate);
            Controls.Add(cboToClub);
            Controls.Add(txtFromClub);
            Controls.Add(cboPlayer);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtId);
            Controls.Add(btnTransfer);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvTransfers);
            Name = "TransfersForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Управление на трансфери";
            Load += TransfersForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTransfers).EndInit();
            ((System.ComponentModel.ISupportInitialize)numFee).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvTransfers;
        private Label label1;
        private Label label2;
        private Button btnTransfer;
        private TextBox txtId;
        private Label label3;
        private Label label4;
        private ComboBox cboPlayer;
        private TextBox txtFromClub;
        private ComboBox cboToClub;
        private DateTimePicker dtpTransferDate;
        private NumericUpDown numFee;
        private ComboBox cboPlayerFilter;
        private Label label5;
    }
}
