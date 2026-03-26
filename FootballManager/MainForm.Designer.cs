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
            SuspendLayout();
            // 
            // btnOpenClubs
            // 
            btnOpenClubs.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnOpenClubs.Location = new Point(85, 108);
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
            btnOpenPlayers.Location = new Point(85, 176);
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
            label1.Location = new Point(100, 41);
            label1.Name = "label1";
            label1.Size = new Size(187, 30);
            label1.TabIndex = 2;
            label1.Text = "Football Manager";
            // 
            // btnOpenTransfers
            // 
            btnOpenTransfers.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnOpenTransfers.Location = new Point(85, 246);
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
            btnOpenLeagues.Location = new Point(85, 319);
            btnOpenLeagues.Name = "btnOpenLeagues";
            btnOpenLeagues.Size = new Size(217, 45);
            btnOpenLeagues.TabIndex = 4;
            btnOpenLeagues.Text = "Управление на Лиги";
            btnOpenLeagues.UseVisualStyleBackColor = true;
            btnOpenLeagues.Click += btnOpenLeagues_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(385, 397);
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
    }
}