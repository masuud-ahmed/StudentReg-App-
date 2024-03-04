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
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
        }

        private void createUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsersForm myForm = new UsersForm();
            myForm.Show();
            myForm.MdiParent = this;
        }

        private void facultyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FacultyForm myForm = new FacultyForm();
            myForm.Show();
            myForm.MdiParent = this;
        }
    }
}
