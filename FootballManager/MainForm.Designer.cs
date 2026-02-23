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
            SuspendLayout();
            // 
            // btnOpenClubs
            // 
            btnOpenClubs.Location = new Point(183, 204);
            btnOpenClubs.Name = "btnOpenClubs";
            btnOpenClubs.Size = new Size(162, 47);
            btnOpenClubs.TabIndex = 0;
            btnOpenClubs.Text = "Управление на Клубове";
            btnOpenClubs.UseVisualStyleBackColor = true;
            btnOpenClubs.Click += btnOpenClubs_Click;
            // 
            // btnOpenPlayers
            // 
            btnOpenPlayers.Location = new Point(436, 204);
            btnOpenPlayers.Name = "btnOpenPlayers";
            btnOpenPlayers.Size = new Size(173, 47);
            btnOpenPlayers.TabIndex = 1;
            btnOpenPlayers.Text = "Управление на Играчи";
            btnOpenPlayers.UseVisualStyleBackColor = true;
            btnOpenPlayers.Click += btnOpenPlayers_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(337, 66);
            label1.Name = "label1";
            label1.Size = new Size(100, 15);
            label1.TabIndex = 2;
            label1.Text = "Football Manager";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(btnOpenPlayers);
            Controls.Add(btnOpenClubs);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnOpenClubs;
        private Button btnOpenPlayers;
        private Label label1;
    }
}