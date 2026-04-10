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
    public partial class FormMenu : Form
    {
        SoundPlayer sonidoMenu = new SoundPlayer(Properties.Resources.sound_menu);

        public FormMenu()
        {

            InitializeComponent();
            sonidoMenu.PlayLooping();
            using var ms = new MemoryStream(Properties.Resources.icon);
            this.Icon = new Icon(ms);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            sonidoMenu.Stop();
            FormJuego formJuego = new FormJuego();
            formJuego.Show();
            this.Hide();
        }

        private void FormMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
