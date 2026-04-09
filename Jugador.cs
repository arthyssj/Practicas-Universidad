using System;
using System.Drawing;

namespace JuegoLaberinto
{
    public class Jugador
    {
        public int x {  get; set; }
        public int y { get; set; }
        public int Tamano { get; set; } = 10;
        public int Velocidad { get; set; } = 10;
        public Rectangle Area()
        {
            return new Rectangle(x,y, Tamano, Tamano);
        }
        public void Dibujar(Graphics g)
        {
            //color del jugador
            g.FillRectangle(Brushes.Red, Area());
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
