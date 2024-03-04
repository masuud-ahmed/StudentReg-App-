using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;

namespace CA216StudentRegSample
{
    public class MainClass
    {
        static string conString = "data source=pc-1;initial catalog=CA216SRDB;integrated security=true";
        public SqlConnection con = new SqlConnection(conString);
        public SqlCommand cmd;
        public SqlDataAdapter da;
        public string query;
        public string insertAlert = "Data has been saved.", updateAlert = "Data has been updated.", deleteAlert = "Data has been deleted.";
        public static string UserType;
        //connect method
        public void Connect()
        {
            if (con.State != ConnectionState.Open)
                con.Open();
        }
        //disconnect method
        public void Disconnect()
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
        }
        //display method
        public void Display(string _query, DataGridView dgv)
        {
            using (da = new SqlDataAdapter(_query, con))
            {
                DataSet ds = new DataSet();
                da.Fill(ds, "tbl");
                dgv.DataSource = ds.Tables["tbl"];
            }
        }
        //ProcessData Method
        public void ProcessData(string _query, string _msg)
        {
            try
            {
                using (cmd = new SqlCommand(_query, con))
                {
                    Connect();//open connection
                    if (cmd.ExecuteNonQuery() > 0)
                        MessageBox.Show(_msg, "Student Registration Sample", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Something went wrong. Please try again", "Student Registration Sample", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    Disconnect();
                }
            }
            catch { }
        }
        //clear method
        public void Clear(params Control[] ctrl)
        {
            for (int index = 0; index < ctrl.Length; index++)
            {
                ctrl[index].Text = "";
            }
            ctrl[0].Focus();
        }
        //fillcontrols method
        public void FillControls(DataGridView dgv, DataGridViewCellEventArgs e, params Control[] ctrl)
        {
            for (int index = 0; index < ctrl.Length; index++)
            {
                ctrl[index].Text = dgv.Rows[e.RowIndex].Cells[index].Value.ToString();
            }
        }
    }
}
