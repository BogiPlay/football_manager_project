namespace FootballManager
{
    partial class MatchResultForm
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
            label3 = new Label();
            cboMatch = new ComboBox();
            dgvEvents = new DataGridView();
            lblScore = new Label();
            groupBox1 = new GroupBox();
            label2 = new Label();
            label1 = new Label();
            btnAddEvent = new Button();
            cboPlayer = new ComboBox();
            numMinute = new NumericUpDown();
            label4 = new Label();
            cboEventType = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvEvents).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numMinute).BeginInit();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(11, 289);
            label3.Name = "label3";
            label3.Size = new Size(46, 21);
            label3.TabIndex = 16;
            label3.Text = "Мач:";
            // 
            // cboMatch
            // 
            cboMatch.Font = new Font("Segoe UI", 12F);
            cboMatch.FormattingEnabled = true;
            cboMatch.Location = new Point(63, 286);
            cboMatch.Name = "cboMatch";
            cboMatch.Size = new Size(300, 29);
            cboMatch.TabIndex = 15;
            cboMatch.SelectedIndexChanged += cboMatch_SelectedIndexChanged;
            // 
            // dgvEvents
            // 
            dgvEvents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEvents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEvents.Location = new Point(-3, -1);
            dgvEvents.Name = "dgvEvents";
            dgvEvents.ReadOnly = true;
            dgvEvents.Size = new Size(804, 268);
            dgvEvents.TabIndex = 17;
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblScore.Location = new Point(530, 289);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(76, 21);
            lblScore.TabIndex = 18;
            lblScore.Text = "Резултат:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnAddEvent);
            groupBox1.Controls.Add(cboPlayer);
            groupBox1.Controls.Add(numMinute);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(cboEventType);
            groupBox1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(12, 335);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(776, 186);
            groupBox1.TabIndex = 19;
            groupBox1.TabStop = false;
            groupBox1.Text = "Добави събитие";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.Location = new Point(237, 42);
            label2.Name = "label2";
            label2.Size = new Size(59, 21);
            label2.TabIndex = 26;
            label2.Text = "Играч:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.Location = new Point(31, 43);
            label1.Name = "label1";
            label1.Size = new Size(108, 21);
            label1.TabIndex = 25;
            label1.Text = "Тип събитие:";
            // 
            // btnAddEvent
            // 
            btnAddEvent.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddEvent.Location = new Point(280, 132);
            btnAddEvent.Name = "btnAddEvent";
            btnAddEvent.Size = new Size(228, 39);
            btnAddEvent.TabIndex = 24;
            btnAddEvent.Text = "Добави";
            btnAddEvent.UseVisualStyleBackColor = true;
            btnAddEvent.Click += btnAddEvent_Click;
            // 
            // cboPlayer
            // 
            cboPlayer.Font = new Font("Segoe UI", 12F);
            cboPlayer.FormattingEnabled = true;
            cboPlayer.Location = new Point(239, 68);
            cboPlayer.Name = "cboPlayer";
            cboPlayer.Size = new Size(308, 29);
            cboPlayer.TabIndex = 23;
            // 
            // numMinute
            // 
            numMinute.Location = new Point(615, 69);
            numMinute.Name = "numMinute";
            numMinute.Size = new Size(103, 29);
            numMinute.TabIndex = 22;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label4.Location = new Point(612, 43);
            label4.Name = "label4";
            label4.Size = new Size(71, 21);
            label4.TabIndex = 21;
            label4.Text = "Минута:";
            // 
            // cboEventType
            // 
            cboEventType.Font = new Font("Segoe UI", 12F);
            cboEventType.FormattingEnabled = true;
            cboEventType.Location = new Point(34, 69);
            cboEventType.Name = "cboEventType";
            cboEventType.Size = new Size(149, 29);
            cboEventType.TabIndex = 20;
            // 
            // MatchResultForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 531);
            Controls.Add(groupBox1);
            Controls.Add(lblScore);
            Controls.Add(dgvEvents);
            Controls.Add(label3);
            Controls.Add(cboMatch);
            Name = "MatchResultForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Мачове";
            Load += MatchResultForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEvents).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numMinute).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private ComboBox cboMatch;
        private DataGridView dgvEvents;
        private Label lblScore;
        private GroupBox groupBox1;
        private ComboBox cboEventType;
        private ComboBox cboPlayer;
        private NumericUpDown numMinute;
        private Label label4;
        private Button btnAddEvent;
        private Label label1;
        private Label label2;
    }
}