using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameWorld
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            var rand = new Random();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Menu());
        }

        public static void OpenGameForm(Form form, int len, int count)
        {
            form.Hide();
            GameForm gameForm = new GameForm(len, count);
            gameForm.Show();
        }

        public static void OpenMenuForm()
        {

        }
        
    }
}
