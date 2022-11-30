using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using Newtonsoft.Json;
using static GameWorld.SaveResult;

namespace GameWorld
{
    public partial class Statistics : Form
    {
        static GameResult[] result;

        public Statistics()
        {
            InitializeComponent();
            WriteStatistics();
            GameInfo.Text = "";
        }

        private void WriteStatistics()
        {
            string text = "";
            foreach (var g in SaveResult.GetResult().games)
            {
                text += "Lenght - " + g.len.ToString() + "\n" +
                    "    win - " + g.win.ToString() + "\n" +
                    "    los - " + g.los.ToString() + "\n";
            }

            AddGameInList();
            StatisticsLabel.Text = text;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Program.OpenMenuForm();
            this.Close();
        }

        private void Form_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape) // Close Form
            {
                Program.OpenMenuForm();
                this.Close();
            }
        }

        private void AddGameInList()
        {
            // Get all result game
            result = SaveResult.JsonsGames();
            
            // Add to list
            foreach(var r in result)
            {
                string tmp = "";
                if (r.win_game)
                    tmp += "successfully    ";
                else
                    tmp += "unsuccessfully  ";

                tmp += r.hidden_word;
                ResultList.Items.Add(tmp);
            }
        }

        private void List_IndexEdit(object sender, EventArgs e)
        {
            GameInfo.Text = JsonConvert.SerializeObject(result[ResultList.SelectedIndex], Formatting.Indented);
        }

        private void Clean_Click(object sender, EventArgs e)
        {
            // Delete?
            var result = MessageBox.Show("Your actions will completely clear the history of games",
                "Clean History",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            // Delete!
            if (result == DialogResult.Yes)
                SaveResult.DeleteResult();

            // Update data
            WriteStatistics();
            ResultList.Items.Clear();
            GameInfo.Text = "";
        }
    }
}
