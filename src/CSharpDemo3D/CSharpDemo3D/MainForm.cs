using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpDemo3D
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Demo3DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Plot3D.FrmDemo3D demo3D = new Plot3D.FrmDemo3D();
            demo3D.Show();
        }
    }
}
