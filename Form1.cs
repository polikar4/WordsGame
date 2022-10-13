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
            GameLogic.Construkt(tableLayoutPanel1,len, attempt);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            GameLogic.KeyUp(e.KeyValue);
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
        static int x, y; // size table
        static int now_x = 1, now_y = 1; // now posision 
        static TableLayoutPanel table;
        static Worls worls;
        static string hidden_word;
        public static void Construkt(TableLayoutPanel _table,int len, int attempt)
        {
            table = _table;
            x = len;
            y = attempt;

            // load all word fix len 
            StreamReader sw = new StreamReader(Application.StartupPath + "\\words" + len.ToString() + ".json");
            string json = sw.ReadToEnd();
            sw.Close();
            worls = JsonConvert.DeserializeObject<Worls>(json);

            var rand = new Random();
            hidden_word = worls.words[rand.Next(worls.words.Count)];
        }

        public static void KeyUp(int key)
        {
            if(key == 8 && now_x > 1)  // backspace press
            {
                now_x--;
                Control c = table.Controls.Find("label" + (now_x - 1).ToString() + (now_y - 1).ToString(), true)[0];
                c.Text = "_ _";
            }
            else if(now_x <= x && key >= 65 && key <= 90) // press any letter
            {
                Control c = table.Controls.Find("label" + (now_x-1).ToString() + (now_y-1).ToString(), true)[0];
                c.Text = ((char)key).ToString();
                now_x++;
            }

            else if(now_x > x && key == 32 && now_y < y) // press spase to enter word
            {
                string word = "";
                for(int i = 0; i < x; i++)
                {
                    Control c = table.Controls.Find("label" + (i).ToString() + (now_y - 1).ToString(), true)[0];
                    word += c.Text;
                    word = word.ToLower();
                    
                }
                if (worls.TruWord(word))
                {
                    if (word == hidden_word)
                    {
                        for (int i = 0; i < x; i++)
                        {
                            table.Controls.Find("label" + (i).ToString() + (y - 1).ToString(), true)[0]
                                    .Text = (hidden_word[i]).ToString().ToUpper();
                        }
                    }

                    string tmp = hidden_word;
                    int count = 0;
                    for (int i = 0; i < x; i++)
                    {
                        if (word[i] == hidden_word[i])
                        {
                            table.Controls.Find("label" + (i).ToString() + (now_y - 1).ToString(), true)[0]
                                .BackColor = Color.Green;

                            tmp = tmp.Remove(i - count,1);
                            count++;
                        }
                    }

                    for (int i = 0; i < x; i++)
                    {
                        var e = table.Controls.Find("label" + (i).ToString() + (now_y - 1).ToString(), true)[0];
                        if (e.BackColor != Color.Green) 
                        { 
                            for(int j = 0; j < tmp.Length; j++)
                            {
                                if (tmp[j].ToString() == e.Text.ToLower())
                                {
                                    e.BackColor = Color.Yellow;
                                    tmp = tmp.Remove(j);
                                    j--;
                                }
                            }
                        }
                    }


                    now_y++;
                    now_x = 1;
                }
            }

        }

    }
}
