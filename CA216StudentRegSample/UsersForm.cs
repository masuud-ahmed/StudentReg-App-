using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CA216StudentRegSample
{
    public partial class UsersForm : Form
    {
        MainClass mc = new MainClass();

        public UsersForm()
        {
            InitializeComponent();
        }
        private void UsersForm_Load(object sender, EventArgs e)
        {
            Reset();
        }
        private void Reset()
        {
            mc.Display("select * from tblUsers", dataGridView1);
            mc.Clear(txtId, txtUsername, txtPassword, txtConfirm);
            comboBoxUserType.SelectedIndex = 0;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == txtConfirm.Text)
            {
                if (comboBoxUserType.SelectedIndex != 0)
                {
                    mc.query = "insert into tblUsers values(" + txtId.Text + ",'" + txtUsername.Text + "'," +
                        "'" + txtPassword.Text + "','" + comboBoxUserType.Text + "')";
                    mc.ProcessData(mc.query, mc.insertAlert);
                    Reset();
                }
                else
                {
                    MessageBox.Show("Select user type.", "Student Registration Sample", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Password mismatch.", "Student Registration Sample", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mc.Clear(txtPassword, txtConfirm);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == txtConfirm.Text)
            {
                if (comboBoxUserType.SelectedIndex != 0)
                {
                    mc.query = "update tblUsers set Username='" + txtUsername.Text + "',Password=" +
                        "'" + txtPassword.Text + "',UserType='" + comboBoxUserType.Text + "' where UserId="+txtId.Text+"";
                    mc.ProcessData(mc.query, mc.updateAlert);
                    Reset();
                }
                else
                {
                    MessageBox.Show("Select user type.", "Student Registration Sample", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Password mismatch.", "Student Registration Sample", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mc.Clear(txtPassword, txtConfirm);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            mc.query = "delete from tblUsers where UserId=" + txtId.Text + "";
            mc.ProcessData(mc.query, mc.deleteAlert);
            Reset();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            mc.Display("select * from tblUsers where Username like '%"+txtSearch.Text+"%'", dataGridView1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            mc.FillControls(dataGridView1, e, txtId, txtUsername, txtPassword, comboBoxUserType);
            txtConfirm.Text = txtPassword.Text;
        }
    }
}
