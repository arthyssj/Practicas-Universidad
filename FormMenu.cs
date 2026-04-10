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
        SoundPlayer sonidoMenu = new SoundPlayer(Properties.Resources.gta_sound);
        System.Media.SoundPlayer sonidoIniciar = new SoundPlayer(Properties.Resources.efecto_iniciar);
        System.Media.SoundPlayer sonidoCancelar = new SoundPlayer(Properties.Resources.efecto_cancelar);

        public FormMenu()
        {

            InitializeComponent();
            sonidoMenu.PlayLooping();
            using var ms = new MemoryStream(Properties.Resources.icon);
            this.Icon = new Icon(ms);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            sonidoCancelar.PlaySync();
            Application.Exit();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            sonidoIniciar.Play();
            //sonidoMenu.Stop();
            System.Threading.Thread.Sleep(100); 
            FormJuego formJuego = new FormJuego();
            formJuego.Show();
            this.Hide();
        }

        private void btnIns_Click(object sender, EventArgs e)
        {
            FormIns formIns = new FormIns();
            formIns.ShowDialog();
        }


        private void FormMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
