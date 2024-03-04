using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CA216StudentRegSample
{
    public partial class FacultyForm : Form
    {
        MainClass mc = new MainClass();
        public FacultyForm()
        {
            InitializeComponent();
        }

        private void FacultyForm_Load(object sender, EventArgs e)
        {
            Reset();
        }
        private void Reset()
        {
            mc.Display("select * from tblFaculty", dataGridView1);
            mc.Clear(txtId, txtFacultyName, txtSearch);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                mc.query = "insert into tblFaculty values(" + txtId.Text + ",'" + txtFacultyName.Text + "')";
                mc.ProcessData(mc.query, mc.insertAlert);
                Reset();
            }
            catch { }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            mc.query = "update tblFaculty set FacultyName='" + txtFacultyName.Text + "' where FacultyId=" + txtId.Text + "";
            mc.ProcessData(mc.query, mc.updateAlert);
            Reset();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            mc.query = "delete from  tblFaculty where FacultyId=" + txtId.Text + "";
            mc.ProcessData(mc.query, mc.deleteAlert);
            Reset();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            mc.FillControls(dataGridView1, e, txtId, txtFacultyName);

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                mc.Display("select * from tblFaculty where FacultyName like '%" + txtSearch.Text + "%'", dataGridView1);

            }
            catch { }
        }
    }
}
