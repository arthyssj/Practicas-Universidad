using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JuegoLaberinto
{

    public partial class FormMensaje : Form
    {
        System.Media.SoundPlayer sonidoOK = new SoundPlayer(Properties.Resources.efecto_cancelar);

        public FormMensaje(string mensaje)
        {
            InitializeComponent();
            lblMensaje.Text = mensaje;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            sonidoOK.Play();
            this.Close();
        }
    }
}
