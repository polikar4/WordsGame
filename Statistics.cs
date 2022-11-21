using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameWorld
{
    public partial class Statistics : Form
    {
        public Statistics()
        {
            InitializeComponent();

            string text = "";
            foreach(var g in SaveResult.GetResult().games)
            {
                text += "Lenght - " + g.len.ToString() +
                    " win - " + g.win.ToString() +
                    " los - " + g.los.ToString() + "\n";
            }

            StatisticsLabel.Text = text;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Program.OpenMenuForm();
            this.Close();
        }
    }
}
