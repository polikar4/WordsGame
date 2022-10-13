using System.Windows.Forms;

namespace GameWorld
{
    partial class GameForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        
        private void CreateTable(int len, int attempt)
        {
            int x = len, y = attempt;
            // create tabel
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            
            // create labels 
            Label[,] labels = new Label[x, y];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    labels[i, j] = new Label();
                    labels[i, j].Text = j + 1 != y ? "_ _" : "*" ;
                    labels[i, j].Name = "label" + i.ToString() + j.ToString();
                    labels[i, j].Location = new System.Drawing.Point(0, 0);
                    labels[i, j].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                }
            }
            // params 
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.ColumnCount = x;
            this.tableLayoutPanel1.RowCount = y;
            this.tableLayoutPanel1.Name = "GameTable";
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Size = new System.Drawing.Size(this.ClientSize.Width, 300);
            this.tableLayoutPanel1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            // add column and row
            for (int i = 0; i < x; i++)
            {
                this.tableLayoutPanel1.ColumnStyles.Add(
                    new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f/x));
            }
            for(int i = 0; i < y; i++)
            {
                this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f/y));
            }
            // add label
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    this.tableLayoutPanel1.Controls.Add(labels[i, j], i, j);
                }
            }
            // start logic 
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.Controls.Add(this.tableLayoutPanel1);
        }
        private void InitializeComponent(int len, int attempt)
        {
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(663, 600);
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Form1";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            CreateTable(len, attempt);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

