namespace GameWorld
{
    partial class Statistics
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
            this.StatisticsLabel = new System.Windows.Forms.Label();
            this.BackButton = new System.Windows.Forms.Button();
            this.GameInfo = new System.Windows.Forms.Label();
            this.ResultList = new System.Windows.Forms.ListBox();
            this.Clean = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StatisticsLabel
            // 
            this.StatisticsLabel.AutoSize = true;
            this.StatisticsLabel.Location = new System.Drawing.Point(8, 21);
            this.StatisticsLabel.Name = "StatisticsLabel";
            this.StatisticsLabel.Size = new System.Drawing.Size(35, 20);
            this.StatisticsLabel.TabIndex = 0;
            this.StatisticsLabel.Text = "Go!";
            // 
            // BackButton
            // 
            this.BackButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BackButton.Location = new System.Drawing.Point(12, 606);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(135, 59);
            this.BackButton.TabIndex = 1;
            this.BackButton.TabStop = false;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // GameInfo
            // 
            this.GameInfo.AutoSize = true;
            this.GameInfo.Location = new System.Drawing.Point(458, 21);
            this.GameInfo.Name = "GameInfo";
            this.GameInfo.Size = new System.Drawing.Size(263, 60);
            this.GameInfo.TabIndex = 2;
            this.GameInfo.Text = "Succexvul                Lenght - 8\r\nWord: xxxxxxxx       Complexity - Easy\r\n    " +
    "                           ";
            // 
            // ResultList
            // 
            this.ResultList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ResultList.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ResultList.FormattingEnabled = true;
            this.ResultList.ItemHeight = 20;
            this.ResultList.Location = new System.Drawing.Point(153, 21);
            this.ResultList.Name = "ResultList";
            this.ResultList.Size = new System.Drawing.Size(299, 644);
            this.ResultList.TabIndex = 4;
            this.ResultList.SelectedIndexChanged += new System.EventHandler(this.List_IndexEdit);
            // 
            // Clean
            // 
            this.Clean.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Clean.Location = new System.Drawing.Point(915, 606);
            this.Clean.Name = "Clean";
            this.Clean.Size = new System.Drawing.Size(119, 59);
            this.Clean.TabIndex = 5;
            this.Clean.Text = "Clean History";
            this.Clean.UseVisualStyleBackColor = true;
            this.Clean.Click += new System.EventHandler(this.Clean_Click);
            // 
            // Statistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 686);
            this.Controls.Add(this.Clean);
            this.Controls.Add(this.ResultList);
            this.Controls.Add(this.GameInfo);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.StatisticsLabel);
            this.Name = "Statistics";
            this.Text = "Statistics";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label StatisticsLabel;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Label GameInfo;
        private System.Windows.Forms.ListBox ResultList;
        private System.Windows.Forms.Button Clean;
    }
}