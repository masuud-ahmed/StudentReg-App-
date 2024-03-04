using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace CA216StudentRegSample
{
    public partial class LoginForm : Form
    {
        public bool loginSuccessful=false;

        MainClass mc = new MainClass();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                mc.query = "select * from tblUsers where Username='" + txtUsername.Text + "' and Password='" + txtPassword.Text + "'";
                using (mc.cmd = new SqlCommand(mc.query, mc.con))
                {
                    mc.Connect();
                    SqlDataReader dr = mc.cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        loginSuccessful = true;
                        this.Close();
                    }
                    else
                    {
                        loginSuccessful = false;
                        MessageBox.Show("Invalid username or password.", "Student Registration Sample", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        mc.Clear(txtPassword);
                    }
                    mc.Disconnect();
                }
            }
            catch { mc.Disconnect(); }

        }
    }
}
