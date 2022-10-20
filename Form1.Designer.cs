using System.Drawing;
using System.Linq;
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
            string[] keys = new string[] { "QWERTYUIOP", "ASDFGHJKL", "ZXCVBNM" };
            int[] count_keys_line = new int[] { 10, 9, 7 };
            // create tabel
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            // create keyboard and inform
            buttons = new Button[10, 3];
            for (int i = 0; i < 3; i++)
            {
                int count = count_keys_line[i];
                for (int j = 0; j < count_keys_line.Max(); j++)
                {
                    if (j >= count)
                        continue;
                    buttons[j, i] = new Button();
                    buttons[j, i].Text = keys[i][j].ToString();
                    buttons[j, i].Size = new System.Drawing.Size(ClientSize.Width/12, 30);
                    buttons[j, i].Location = new System.Drawing.Point(ClientSize.Width * j /12 + i*30, i*30+300);
                    buttons[j, i].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    buttons[j, i].Name = "button" + j.ToString() + i.ToString() ;
                    buttons[j, i].TabStop = false;
                    buttons[j, i].UseVisualStyleBackColor = true;
                    buttons[j, i].Click += new System.EventHandler(this.ClickKeyboard);
                    Controls.Add(buttons[j, i]);
                }
            }
            // create button space
            space = new Button();
            space.Text = "Space";
            space.Size = new System.Drawing.Size(ClientSize.Width, 30);
            space.Location = new System.Drawing.Point(0, 390);
            space.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            space.Name = "buttonspace";
            space.TabStop = false;
            space.UseVisualStyleBackColor = true;
            space.Click += new System.EventHandler(this.ClickKeyboard);
            Controls.Add(space);
            // create backspace
            backspace = new Button();
            backspace.Text = "<-";
            backspace.Size = new System.Drawing.Size(ClientSize.Width * 2 / 12, 30);
            backspace.Location = new System.Drawing.Point(ClientSize.Width * 10 / 12, 300);
            backspace.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            backspace.Name = "buttonspace";
            backspace.TabStop = false;
            backspace.UseVisualStyleBackColor = true;
            backspace.Click += new System.EventHandler(this.ClickKeyboard);
            Controls.Add(backspace);
            // create labels 
            labels = new Label[x, y];
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
            labels[0, 0].Text = " / ";
            // params 
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.ColumnCount = x;
            this.tableLayoutPanel1.RowCount = y;
            this.tableLayoutPanel1.Name = "GameTable";
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Size = new System.Drawing.Size(this.ClientSize.Width, 300);
            this.tableLayoutPanel1.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
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
            this.ClientSize = new System.Drawing.Size(600, 600);
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            CreateTable(len, attempt);
            this.ResumeLayout(false);
            this.Resize += new System.EventHandler(this.FormResize);
        }

        #endregion

        private System.Windows.Forms.Button[,] buttons;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button space, backspace;
        private System.Windows.Forms.Label[,] labels;
    }
}

