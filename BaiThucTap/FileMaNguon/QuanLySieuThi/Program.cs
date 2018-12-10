using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySieuThi
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SqlConnection con = new SqlConnection(QuanLySieuThi.Properties.Settings.Default.Conn);
            try
            {
                con.Open();
                con.Close();
                Application.Run(new FrmChaoMung());
            }
            catch(Exception)
            {
                Application.Run(new Frmketnoi());
            }
        }
    }
}
