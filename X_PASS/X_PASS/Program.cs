using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace X_PASS
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
    static class Data
    {
        public static string password;
        public static string language;
        public static List<string> dataGridColumns = new List<string>();
        public static List<int> dataGridColumnsWidth = new List<int>();
        public static int numWhenEncryptedPasswordStop = 0;
        public static int numWhenDecryptedPasswordStop = 0;
    }
}
