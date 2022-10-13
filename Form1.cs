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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GameLogic.Construkt(tableLayoutPanel1);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            GameLogic.KeyUp(e.KeyValue);
        }
    }

    public static class GameLogic //singletone? hvhvhvhvh. NO
    {
        static int x = 5, y = 4; // size table
        static int now_x = 1, now_y = 1; // now posision 
        static TableLayoutPanel table; 
        public static void Construkt(TableLayoutPanel _table)
        {
            table = _table;
        }

        public static void KeyUp(int key)
        {
            if(now_x <= x)
            {
                Control c = table.Controls.Find("label" + (now_x-1).ToString() + (now_y-1).ToString(), true)[0];
                c.Text = ((char)key).ToString();
                now_x++;
            }

            if(now_x > x && key == 32 && now_y < y)
            {
                if(TruWord(x))
                now_y++;
                now_x = 1;
            }
        }


        private static bool TruWord(int len)
        {
            // Checking the existence of the word
            // Maybe in our dictionary, maybe via the Internet

            return true;
        }
    }
}
