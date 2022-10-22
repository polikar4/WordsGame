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
    
    public partial class Menu : Form
    {
        
        public Menu()
        {
            InitializeComponent();
            
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            int len = 0, count = 0;
            Random random = new Random();

            if (LenBox.SelectedItem == null)
                len = 4;
            else if ((string)LenBox.SelectedItem == "Random")
                len = random.Next(4, 9);
            else
                len = Int32.Parse((string)LenBox.SelectedItem);

            if (CountBox.SelectedItem == null)
                count = 8;
            switch ((string)CountBox.SelectedItem)
            { 
                case "Easy":
                    count = 8;
                    break;
                case "Medium":
                    count = 6;
                    break;
                case "Hard":
                    count = 4;
                    break;
                case "Impossible":
                    count = 3;
                    break;
            }
            Program.OpenGameForm(this, len, count);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
