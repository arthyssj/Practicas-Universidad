using System;
using System.Drawing;
using System.IO;

namespace JuegoLaberinto
{
    public class Jugador
    {
        // cached player image created from the byte[] resource
        private static Image? _playerImage;

        public int x {  get; set; }
        public int y { get; set; }
        public int Tamano { get; set; } = 25;
        public int Velocidad { get; set; } = 5;
        public Rectangle Area()
        {
            return new Rectangle(x,y, Tamano, Tamano);
        }
        public void Dibujar(Graphics g)
        {
            if (_playerImage == null)
            {
                // create image from byte[] resource once and keep a Bitmap copy so we can dispose the stream
                using var ms = new MemoryStream(Properties.Resources.jaime_icon);
                using var tmp = Image.FromStream(ms);
                _playerImage = new Bitmap(tmp);
            }

            g.DrawImage(_playerImage, Area());
            using(Pen bordeJugador = new Pen(Color.DeepPink, 1))
            {
                g.DrawRectangle(bordeJugador, Area());
            }
        }
        public void Mover(string direccion)
        {
            if (direccion == "arriba") y -= Velocidad;
            if (direccion == "abajo") y += Velocidad;
            if (direccion == "izquierda") x -= Velocidad;
            if (direccion == "derecha") x += Velocidad;
        }
        

    }
}
