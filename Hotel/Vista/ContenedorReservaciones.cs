using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class ContenedorReservaciones : Form
    {
        public ContenedorReservaciones()
        {
            InitializeComponent();
        }

        private void reservacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reservacion res = new Reservacion();
            res.MdiParent = this;
            res.Show();
        }

        private void reservacionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Reservacion res = new Reservacion();
            res.MdiParent = this;
            res.Show();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cliente cli = new Cliente();
            cli.MdiParent = this;
            cli.Show();
        }
    }
}
