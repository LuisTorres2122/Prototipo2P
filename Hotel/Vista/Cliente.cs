using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controlador;

namespace Vista
{
    public partial class Cliente : Form
    {
        int opcion;
        cscontrolador cn = new cscontrolador();
        public Cliente()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            cn.llenartablaa(dataGridView1.Tag.ToString(), dataGridView1);
        }

        private void btningresar_Click(object sender, EventArgs e)
        {
            Button[] botongc = { btnguardar, btneliminar };
            TextBox[] textbox = { textBox1, textBox2,  textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9 };
            TextBox[] textboxi = { textBox1, textBox2 };
            opcion = 1;
            cn.limpiar(this);
            cn.activar(this);
            cn.crearid(textboxi, dataGridView1);
            cn.bloquearbotonesGC(botongc, false);
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            opcion = 3;
            int permiso = cn.comprobacionvacio(dataGridView1);
            if (permiso != 0)
            {
                Button[] botongc = { btnguardar, btneliminar };
                cn.bloquearbotonesGC(botongc, false);
            }
        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            TextBox[] textboxi = { textBox1, textBox2 };
            opcion = 2;
            int permiso = cn.comprobacionvacio(dataGridView1);
            if (permiso != 0)
            {
                cn.activar(this);
                cn.enfocar(textboxi);
                Button[] botongc = { btnguardar, btneliminar };
                cn.bloquearbotonesGC(botongc, false);
            }
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            Button[] botongc = { btnguardar, btneliminar };
            TextBox[] textbox = { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9 };
            TextBox[] textboxi = { textBox1, textBox2 };
            
            if (opcion == 1)
            {
                cn.ingresar(textbox, dataGridView1);
                //cn.bloquearbotonesGC(botongc, true);
            }
            else if (opcion == 2)
            {
                cn.actualizar(textbox, dataGridView1);
                // cn.bloquearbotonesGC(botongc, true);
            }
            else if (opcion == 3)
            {
                DialogResult resultado = MessageBox.Show("Desea eliminar el Resgistro", "Eliminar", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    cn.delete(textbox, dataGridView1);
                    //cn.bloquearbotonesGC(botongc, true);
                }
                else if (resultado == DialogResult.No)
                {

                    cn.limpiar(this);
                    cn.desactivar(this);
                    cn.llenartxt(textbox, dataGridView1);
                    cn.bloquearbotonesGC(botongc, true);
                }

            }
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            TextBox[] textbox = { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9 };
            cn.limpiar(this);
            cn.desactivar(this);
            cn.llenartxt(textbox, dataGridView1);
            Button[] botongc = { btnguardar, btneliminar };
            cn.bloquearbotonesGC(botongc, true);
        }

        private void Cliente_Load(object sender, EventArgs e)
        {
            TextBox[] textbox = { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9 };

            cn.inicializargrid(dataGridView1);
            cn.llenartablainicio(dataGridView1.Tag.ToString(), dataGridView1, textbox);
           
            cn.desactivar(this);
        }
    }
}
