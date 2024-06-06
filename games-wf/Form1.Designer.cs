namespace games_wf
{
    partial class Form1
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
            labelHealth = new Label();
            labelCoins = new Label();
            labelLevel = new Label();
            labelRequiredCoins = new Label();
            buttonNextLevel = new Button();
            labelStrength = new Label();
            SuspendLayout();
            // 
            // labelHealth
            // 
            labelHealth.AutoSize = true;
            labelHealth.Font = new Font("Segoe UI", 14F);
            labelHealth.Location = new Point(39, 15);
            labelHealth.Margin = new Padding(4, 0, 4, 0);
            labelHealth.Name = "labelHealth";
            labelHealth.Size = new Size(99, 25);
            labelHealth.TabIndex = 0;
            labelHealth.Text = "Здоровье:";
            // 
            // labelCoins
            // 
            labelCoins.AutoSize = true;
            labelCoins.Font = new Font("Segoe UI", 14F);
            labelCoins.Location = new Point(695, 19);
            labelCoins.Margin = new Padding(4, 0, 4, 0);
            labelCoins.Name = "labelCoins";
            labelCoins.Size = new Size(86, 25);
            labelCoins.TabIndex = 1;
            labelCoins.Text = "Монеты:";
            // 
            // labelLevel
            // 
            labelLevel.AutoSize = true;
            labelLevel.Font = new Font("Segoe UI", 14F);
            labelLevel.Location = new Point(388, 15);
            labelLevel.Margin = new Padding(4, 0, 4, 0);
            labelLevel.Name = "labelLevel";
            labelLevel.Size = new Size(90, 25);
            labelLevel.TabIndex = 2;
            labelLevel.Text = "Уровень:";
            // 
            // labelRequiredCoins
            // 
            labelRequiredCoins.AutoSize = true;
            labelRequiredCoins.Font = new Font("Segoe UI", 14F);
            labelRequiredCoins.Location = new Point(695, 52);
            labelRequiredCoins.Margin = new Padding(4, 0, 4, 0);
            labelRequiredCoins.Name = "labelRequiredCoins";
            labelRequiredCoins.Size = new Size(132, 25);
            labelRequiredCoins.TabIndex = 3;
            labelRequiredCoins.Text = "Нужно монет:";
            // 
            // buttonNextLevel
            // 
            buttonNextLevel.Location = new Point(473, 19);
            buttonNextLevel.Name = "buttonNextLevel";
            buttonNextLevel.Size = new Size(107, 23);
            buttonNextLevel.TabIndex = 17;
            buttonNextLevel.Text = "NEXT LEVEL";
            buttonNextLevel.UseVisualStyleBackColor = true;
            // 
            // labelStrength
            // 
            labelStrength.AutoSize = true;
            labelStrength.Font = new Font("Segoe UI", 14F);
            labelStrength.Location = new Point(39, 52);
            labelStrength.Name = "labelStrength";
            labelStrength.Size = new Size(59, 25);
            labelStrength.TabIndex = 18;
            labelStrength.Text = "Сила:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 443);
            Controls.Add(labelStrength);
            Controls.Add(buttonNextLevel);
            Controls.Add(labelRequiredCoins);
            Controls.Add(labelLevel);
            Controls.Add(labelCoins);
            Controls.Add(labelHealth);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelHealth;
        private System.Windows.Forms.Label labelCoins;
        private System.Windows.Forms.Label labelLevel;
        private System.Windows.Forms.Label labelRequiredCoins;
        private Button buttonNextLevel;
        private Label labelStrength;
    }

}
