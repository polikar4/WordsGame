using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameWorld
{
    public partial class GameForm : Form
    {
        public GameForm(int len, int attempt)
        {
            InitializeComponent(len, attempt);
            GameLogic.Construkt(this, tableLayoutPanel1, len ,attempt, buttons);

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            GameLogic.KeyUp(e.KeyCode);

        }

        private void ClickKeyboard(object sender, EventArgs e)
        {
            ActiveControl = null;
            string text = ((Button)sender).Text;
            if(text.Length == 1)
                GameLogic.KeyUp((Keys)text[0]);
            else if(text == "Space")
                GameLogic.KeyUp(Keys.Space);
            else if (text == "<-")
                GameLogic.KeyUp(Keys.Back);
        }
        private void FormResize(object sender, System.EventArgs e)
        {
            int[] count_keys_line = new int[] { 10, 9, 7 };

            for (int i = 0; i < 3; i++)
            {
                int count = count_keys_line[i];
                for (int j = 0; j < count_keys_line.Max(); j++)
                {
                    if (j >= count)
                        continue;
                    buttons[j, i].Size = new System.Drawing.Size(ClientSize.Width / 12, 30);
                    buttons[j, i].Location = new System.Drawing.Point(ClientSize.Width * j / 12 + i * 30, i * 30 + 300);
                }
            }
            space.Size = new System.Drawing.Size(ClientSize.Width, 30);
            space.Location = new System.Drawing.Point(0, 390);
            backspace.Size = new System.Drawing.Size(ClientSize.Width * 2 / 12, 30);
            backspace.Location = new System.Drawing.Point(ClientSize.Width * 10 / 12, 300);
        }
    } 

    public class Worls // class to json (json hawe all words fix len)
    {
        public int len; 
        public List<string> words;
        
        public bool TruWord(string s)
        {
            s = s.ToLower();
            foreach(var w in words)
            {
                if (w == s)
                    return true;
            }
            return false;
        }
    }

    public static class GameLogic //singletone? hvhvhvhvh. NO
    {
        static int x, y;                 // size table
        static int now_x = 1, now_y = 1; // now posision 
        static TableLayoutPanel table;
        static Worls worls;              //class hawe all words 
        static string hidden_word;
        static Control elem = null;
        static GameForm form;
        static Button[,] buttons;
        public static void Construkt(GameForm _form, TableLayoutPanel _table, int len, int attempt, Button[,] _buttons)
        {
            buttons = _buttons;
            form = _form;
            table = _table;
            x = len;
            y = attempt;

            // load all word fix len 
            StreamReader sw = new StreamReader(Application.StartupPath + "\\words" + len.ToString() + ".json");
            string json = sw.ReadToEnd();
            sw.Close();
            worls = JsonConvert.DeserializeObject<Worls>(json);
            // random word in all words
            var rand = new Random();
            hidden_word = worls.words[rand.Next(worls.words.Count)];
        }

        public static void KeyUp(Keys key)
        {
            if (key == Keys.Back && now_x > 1)  // backspace press
                DeletedLastChar();
            else if (now_x <= x && (int)key >= 65 && (int)key <= 90) // press any letter
                EnterChar((int)key);
            else if (now_x > x && key == Keys.Space && now_y < y) // press spase to enter word
                EnterSpace();

            if (now_y == y) // if u spend all attempt
            {
                for (int i = 0; i < x; i++)  // open hidden word in last string  
                {
                    table.Controls.Find("label" + (i).ToString() + (y - 1).ToString(), true)[0]
                            .Text = (hidden_word[i]).ToString().ToUpper();
                }
                EndGame("U lose");
            }
                
        }
        private static void EndGame(string text)
        {
            MessageBox.Show(text, text, MessageBoxButtons.OK);
            form.Close();
        }
        private static void DeletedLastChar()
        {
            if (now_x <= x)
            {
                elem = table.Controls.Find("label" + (now_x - 1).ToString() + (now_y - 1).ToString(), true)[0];
                elem.Text = "_ _";
            }
            now_x--;
            elem = table.Controls.Find("label" + (now_x - 1).ToString() + (now_y - 1).ToString(), true)[0];
            elem.Text = " / ";
        }
        private static void EnterChar(int key)
        {
            elem = table.Controls.Find("label" + (now_x - 1).ToString() + (now_y - 1).ToString(), true)[0];
            elem.Text = ((char)key).ToString();
            now_x++;
            if (now_x <= x)
            {
                elem = table.Controls.Find("label" + (now_x - 1).ToString() + (now_y - 1).ToString(), true)[0];
                elem.Text = " / ";
            }
        }
        private static void EnterSpace()
        {
            string word = "";
            for (int i = 0; i < x; i++) // read word in now string
            {
                elem = table.Controls.Find("label" + (i).ToString() + (now_y - 1).ToString(), true)[0];
                word += elem.Text.ToLower();
            }
            if (!worls.TruWord(word)) // cheak existence word
                return;

            if (word == hidden_word)
            {
                for (int i = 0; i < x; i++)  // open hidden word in last string  
                {   
                    table.Controls.Find("label" + (i).ToString() + (y - 1).ToString(), true)[0]
                            .Text = (hidden_word[i]).ToString().ToUpper();
                }
                foreach(var b in buttons)
                {
                    foreach(var c in word)
                    {
                        if (b != null && b.Text.ToLower()[0] == c)
                            b.BackColor = Color.Green;
                    }
                }
                EndGame("U won");
            }

            string tmp = hidden_word; 
            for (int i = 0, count = 0; i < x; i++) // change color green right char position
            {
                if (word[i] == hidden_word[i])
                {
                    table.Controls.Find("label" + (i).ToString() + (now_y - 1).ToString(), true)[0]
                        .BackColor = Color.Green;

                    foreach (var b in buttons)
                    {
                        if (b != null && b.Text.ToLower()[0] == word[i])
                            b.BackColor = Color.Green;
                    }
                    tmp = tmp.Remove(i - count, 1);
                    count++;
                }
            }

            for (int i = 0; i < x; i++) // change color yellow right char
            {
                elem = table.Controls.Find("label" + (i).ToString() + (now_y - 1).ToString(), true)[0];
                if (elem.BackColor != Color.Green)
                {
                    for (int j = 0; j < tmp.Length; j++)
                    {
                        if (tmp[j].ToString() == elem.Text.ToLower())
                        {
                            foreach (var b in buttons)
                            {
                                if (b != null && b.Text.ToLower()[0] == tmp[j])
                                    b.BackColor = Color.Yellow;
                            }
                            elem.BackColor = Color.Yellow;
                            tmp = tmp.Remove(j);
                            j--;
                        }
                    }
                }
            }

            // go to next line and " / " to first char
            now_y++; 
            now_x = 1;
            elem = table.Controls.Find("label" + (now_x - 1).ToString() + (now_y - 1).ToString(), true)[0];
            elem.Text = " / ";
        }
    }
}
