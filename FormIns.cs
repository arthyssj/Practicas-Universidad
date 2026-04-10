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
    public partial class FormIns : Form

    {
        System.Media.SoundPlayer sonidoCancelar = new SoundPlayer(Properties.Resources.efecto_cancelar);
        public FormIns()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            sonidoCancelar.Play();
            this.Close();
        }
    }
}
