using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadro_de_salarios
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void validarTexto(object sender,KeyPressEventArgs e)
        {
            if(char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        public void validarNumero(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled= true;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        //evento keypress para que solo se puedan poner letras
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarTexto(sender, e);
        }

        private void txtSalarioHora_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarNumero(sender, e);
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            double salxh, Htr, HourEx, SalBas, imp, SalNet;
            try 
            {
                salxh = Convert.ToDouble(txtSalarioHora.Text);
                Htr = Convert.ToDouble(txtHorasTrabajadas.Text);
                HourEx = Convert.ToDouble(txtHorasExtras.Text);

                SalBas = (salxh * Htr) + (2 * (salxh * HourEx));
                imp = SalBas * 0.15;
                SalNet = SalBas - imp;

                txtSalarioBase.Text = SalBas.ToString();
                txtImpuestos.Text = imp.ToString();
                txtSalarioNeto.Text = SalNet.ToString();
            }
            catch(Exception error)
            {
                MessageBox.Show("Error deneotado por:\n" + error.Message, "ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            foreach (Control datos in this.groupBox1.Controls)
            {
                if (datos is TextBox)
                    datos.Text = string.Empty;
            }
            foreach(Control res in this.groupBox2.Controls)
            {
                if(res is TextBox)
                {
                    res.Text = string.Empty;
                }
                
            }
            txtNombre.Focus();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Desea Salir?", "Confirmar salida", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
