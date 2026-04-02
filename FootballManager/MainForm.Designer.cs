namespace FootballManager
{
    partial class MainForm
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
            btnOpenClubs = new Button();
            btnOpenPlayers = new Button();
            label1 = new Label();
            btnOpenTransfers = new Button();
            btnOpenLeagues = new Button();
            btnOpenSchedule = new Button();
            btnOpenMatches = new Button();
            SuspendLayout();
            // 
            // btnOpenClubs
            // 
            btnOpenClubs.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnOpenClubs.Location = new Point(32, 108);
            btnOpenClubs.Name = "btnOpenClubs";
            btnOpenClubs.Size = new Size(217, 45);
            btnOpenClubs.TabIndex = 0;
            btnOpenClubs.Text = "Управление на Клубове";
            btnOpenClubs.UseVisualStyleBackColor = true;
            btnOpenClubs.Click += btnOpenClubs_Click;
            // 
            // btnOpenPlayers
            // 
            btnOpenPlayers.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnOpenPlayers.Location = new Point(32, 176);
            btnOpenPlayers.Name = "btnOpenPlayers";
            btnOpenPlayers.Size = new Size(217, 45);
            btnOpenPlayers.TabIndex = 1;
            btnOpenPlayers.Text = "Управление на Играчи";
            btnOpenPlayers.UseVisualStyleBackColor = true;
            btnOpenPlayers.Click += btnOpenPlayers_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(181, 35);
            label1.Name = "label1";
            label1.Size = new Size(187, 30);
            label1.TabIndex = 2;
            label1.Text = "Football Manager";
            // 
            // btnOpenTransfers
            // 
            btnOpenTransfers.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnOpenTransfers.Location = new Point(297, 108);
            btnOpenTransfers.Name = "btnOpenTransfers";
            btnOpenTransfers.Size = new Size(217, 45);
            btnOpenTransfers.TabIndex = 3;
            btnOpenTransfers.Text = "Управление на Трансфери";
            btnOpenTransfers.UseVisualStyleBackColor = true;
            btnOpenTransfers.Click += btnOpenTransfers_Click;
            // 
            // btnOpenLeagues
            // 
            btnOpenLeagues.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnOpenLeagues.Location = new Point(297, 176);
            btnOpenLeagues.Name = "btnOpenLeagues";
            btnOpenLeagues.Size = new Size(217, 45);
            btnOpenLeagues.TabIndex = 4;
            btnOpenLeagues.Text = "Управление на Лиги";
            btnOpenLeagues.UseVisualStyleBackColor = true;
            btnOpenLeagues.Click += btnOpenLeagues_Click;
            // 
            // btnOpenSchedule
            // 
            btnOpenSchedule.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnOpenSchedule.Location = new Point(32, 246);
            btnOpenSchedule.Name = "btnOpenSchedule";
            btnOpenSchedule.Size = new Size(217, 45);
            btnOpenSchedule.TabIndex = 5;
            btnOpenSchedule.Text = "Прегледай програмата";
            btnOpenSchedule.UseVisualStyleBackColor = true;
            btnOpenSchedule.Click += btnOpenSchedule_Click;
            // 
            // btnOpenMatches
            // 
            btnOpenMatches.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnOpenMatches.Location = new Point(297, 246);
            btnOpenMatches.Name = "btnOpenMatches";
            btnOpenMatches.Size = new Size(217, 45);
            btnOpenMatches.TabIndex = 6;
            btnOpenMatches.Text = "Мачове";
            btnOpenMatches.UseVisualStyleBackColor = true;
            btnOpenMatches.Click += btnOpenMatches_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(554, 326);
            Controls.Add(btnOpenMatches);
            Controls.Add(btnOpenSchedule);
            Controls.Add(btnOpenLeagues);
            Controls.Add(btnOpenTransfers);
            Controls.Add(label1);
            Controls.Add(btnOpenPlayers);
            Controls.Add(btnOpenClubs);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Football Manager";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnOpenClubs;
        private Button btnOpenPlayers;
        private Label label1;
        private Button btnOpenTransfers;
        private Button btnOpenLeagues;
        private Button btnOpenSchedule;
        private Button btnOpenMatches;
    }
}