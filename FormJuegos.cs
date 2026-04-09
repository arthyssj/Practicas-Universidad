namespace JuegoLaberinto

{
    public partial class FormJuego : Form
    {
        Jugador jugador = new Jugador();
        int vidas = 3;
        int tiempo;
        const int tiempoInicial = 30;
        List<Rectangle> paredes = new List<Rectangle>();
        Rectangle meta;
        public FormJuego()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.BackColor = Color.Aqua;
            // configurar tiempo y timer
            tiempo = tiempoInicial;
            // si el Timer fue agregado en el diseñador, configurar intervalo y arrancarlo
            if (tmrCronometro != null)
            {
                tmrCronometro.Interval = 2000; // 1 segundo
                tmrCronometro.Enabled = true;
                tmrCronometro.Tick += tmrCronometro_Tick;
            }
            jugador.x = 50;
            jugador.y = 50;

            //crear paredes
            paredes.Add(new Rectangle(100, 0, 20, 400));
            paredes.Add(new Rectangle(200, 50, 20, 400));
            paredes.Add(new Rectangle(300, 0, 20, 400));
            paredes.Add(new Rectangle(400, 200, 20, 400));
            paredes.Add(new Rectangle(500, 50, 20, 400));


            //meta
            meta = new Rectangle(700, 500, 40, 40);
            this.Paint += FormJuego_Paint;
            this.KeyDown += FormJuego_KeyDown;


        }
        private void FormJuego_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            jugador.Dibujar(g);
            foreach (var pared in paredes)
            {
                g.FillRectangle(Brushes.Black, pared);
            }
            g.FillRectangle(Brushes.Green, meta);
            // dibujar texto de vidas en la esquina superior izquierda
            using (var font = new Font("Arial", 10))
            {
                g.DrawString($"Vidas: {vidas}", font, Brushes.White, new PointF(650, 15));
                g.DrawString($"Tiempo: {tiempo}", font, Brushes.White, new PointF(650, 35));
            }
        }
        public void FormJuego_KeyDown(object sender, KeyEventArgs e)
        {
            int xAnterior = jugador.x;
            int yAnterior = jugador.y;
            if (e.KeyCode == Keys.Up) jugador.Mover("arriba");
            if (e.KeyCode == Keys.Down) jugador.Mover("abajo");
            if (e.KeyCode == Keys.Left) jugador.Mover("izquierda");
            if (e.KeyCode == Keys.Right) jugador.Mover("derecha");

            if (ColisionPared())
            {
                // perder una vida y regresar a la posición (50,50)
                vidas--;
                jugador.x = 50;
                jugador.y = 50;
                if (vidas <= 0)
                {
                    MessageBox.Show("Game Over");
                    ResetGame();
                }
            }
            if (jugador.Area().IntersectsWith(meta))
            {
                MessageBox.Show("Ganaste!!!");

            }
            Invalidate();
        }
        private bool ColisionPared()
        {
            foreach (var pared in paredes)
            {
                if (jugador.Area().IntersectsWith(pared))
                    return true;
            }
            return false;
        }
        private void FormJuego_Load(object sender, EventArgs e)
        {

        }
        private void ResetGame()
        {
            // reiniciar estado del juego
            vidas = 3;
            jugador.x = 50;
            jugador.y = 50;
            tiempo = tiempoInicial;
            Invalidate();
        }

        private void tmrCronometro_Tick(object sender, EventArgs e)
        {
            // disminuir tiempo cada segundo
            tiempo--;
            if (tiempo <= 0)
            {
                // tiempo agotado: perder vida y reiniciar nivel
                vidas--;
                if (vidas <= 0)
                {
                    MessageBox.Show("Game Over");
                    ResetGame();
                }
                else
                {
                    ResetLevel();
                }
            }
            Invalidate();
        }

        private void ResetLevel()
        {
            // reinicia la posición del jugador y el tiempo del nivel
            jugador.x = 50;
            jugador.y = 50;
            tiempo = tiempoInicial;
            Invalidate();
        }

    }
}
