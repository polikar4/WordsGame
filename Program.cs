using System;
using System.Windows.Forms;

namespace GameWorld
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        /// 
        static private Menu _menu;

        [STAThread]
        private static void Main()
        {
            // Get statistic
            SaveResult.Start();
            
            // Create start form
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            _menu = new Menu();
            Application.Run(_menu);
        }

        public static void OpenGameForm(int len, int count)
        {
            _menu.Hide();
            GameForm gameForm = new GameForm(len, count);
            gameForm.Show();
        }

        public static void OpenMenuForm()
        {
            _menu.Visible = true;
        }

        public static void OpenHistoryForm()
        {
            _menu.Hide();
            Statistics statistics = new Statistics();
            statistics.Show();
        }
    }
}
