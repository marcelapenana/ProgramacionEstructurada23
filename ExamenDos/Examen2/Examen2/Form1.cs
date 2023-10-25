using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void menuStrip1_Click(object sender, EventArgs e)
        {
            
        }

        private void form1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Instancia del frm notasEstudiantes evtclik
            Form2 f2 = new Form2();
            f2.MdiParent = this;
            f2.Show();
        }
    }
}
