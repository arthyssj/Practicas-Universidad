using System.Media;
namespace JuegoLaberinto

{
    public partial class FormJuego : Form
    {
        Jugador jugador = new Jugador();
        Random rnd = new Random();
        int nivelActual = 1;
        int vidas = 3;
        int tiempo;
        const int tiempoInicial = 60;
        List<Rectangle> paredes = new List<Rectangle>();
        Rectangle meta;
        SoundPlayer sonidoColision = new SoundPlayer(Properties.Resources.DEAD_STEVE_SOUND);
        SoundPlayer sonidoGameOver = new SoundPlayer(Properties.Resources.sound_gameover);
        SoundPlayer sonidoVictoria = new SoundPlayer(Properties.Resources.efecto_de_victoria);
        SoundPlayer sonidoNivel = new SoundPlayer(Properties.Resources.Efecto_de_FNAF);


        public FormJuego()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            using var ms = new MemoryStream(Properties.Resources.icon);

            this.Icon = new Icon(ms);
            this.KeyPreview = true;
            this.BackColor = Color.Aqua;
            // configurar tiempo y timer
            tiempo = tiempoInicial;
            // si el Timer fue agregado en el diseñador, configurar intervalo y arrancarlo
            if (tmrCronometro != null)
            {
                tmrCronometro.Interval = 1000; // 1 segundo
                tmrCronometro.Enabled = true;
            }
            jugador.x = 50;
            jugador.y = 50;

            // cargar el nivel actual (agrega paredes y posiciona la meta)
            CargarNivel();
            this.Paint += FormJuego_Paint;
            this.KeyDown += FormJuego_KeyDown;


        }
        private void FormJuego_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            foreach (var pared in paredes)
            {
                g.FillRectangle(Brushes.Black, pared);
            }
            g.FillRectangle(Brushes.Green, meta);

            // dibujar texto de vidas en la esquina superior izquierda
            using (var font = new Font("Consolas", 14, FontStyle.Bold))
            {

                g.DrawString($"Vidas: {vidas}", font, Brushes.Black, new PointF(592, 17));
                g.DrawString($"Tiempo: {tiempo}", font, Brushes.Black, new PointF(592, 42));
                g.DrawString($"Vidas: {vidas}", font, Brushes.Crimson, new PointF(590, 15));
                g.DrawString($"Tiempo: {tiempo}", font, Brushes.Gold, new PointF(590, 40));
                
            }
            jugador.Dibujar(g);
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
               
                
                // perder una vida y regresar a la posición 
                vidas--;
                sonidoColision.Play();
                jugador.x = 50;
                jugador.y = 50;
                if (vidas <= 0)
                {
                    sonidoGameOver.Play();
                    MessageBox.Show("Game Over");
                    ResetGame();
                }
            }
            if (jugador.Area().IntersectsWith(meta))
            {
                sonidoNivel.Play();
                if (nivelActual < 3)
                {
                   
                    nivelActual++;
                    MessageBox.Show($"¡Felicidades! Pasaste al Nivel {nivelActual}");
                    CargarNivel();
                }
                else
                {
                    
                    sonidoVictoria.Play();
                    MessageBox.Show("¡HAS GANADO EL JUEGO COMPLETO!");
                    ResetGame();
                }
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
            tmrCronometro.Stop();
            FormMenu formMenu = new FormMenu();
            formMenu.Show();
            this.Close();
        }

        private void tmrCronometro_Tick(object sender, EventArgs e)
        {
            tiempo--;

            if (tiempo <= 0)
            {
                // 1. DETENER EL RELOJ DE INMEDIATO
                tmrCronometro.Stop();
                sonidoColision.Play();

                vidas--;

                if (vidas <= 0)
                {
                    sonidoGameOver.Play();
                   
                    MessageBox.Show("Game Over");
                   
                    ResetGame();
                }
                else
                {
                    ResetLevel();
                }

                // 2. REINICIAR EL RELOJ
                // Solo lo encendemos de nuevo si el juego no ha terminado
                if (vidas > 0)
                {
                    tmrCronometro.Start();
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
            CargarNivel();
        }

        private void CargarNivel()
        {
            paredes.Clear();
            switch (nivelActual)
            {
                case 1:
                    this.BackgroundImage = Properties.Resources.fondo_nivel_1;
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                    this.BackColor = Color.DarkMagenta;
                    paredes.Add(new Rectangle(100, 0, 20, 400));
                    paredes.Add(new Rectangle(200, 50, 20, 400));
                    paredes.Add(new Rectangle(300, 0, 20, 400));
                    paredes.Add(new Rectangle(400, 200, 20, 400));
                    paredes.Add(new Rectangle(500, 50, 20, 400));
                    meta = new Rectangle(700, 500, 40, 40);
                    // velocidad por defecto en nivel 1
                    jugador.Velocidad = 10;
                    break;
                case 2:
                    this.BackgroundImage = Properties.Resources.fondoNivel2;
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                    // generar 10 rectángulos aleatorios que no se encimen
                    this.BackColor = Color.DarkOrange;
                    var bounds = new Rectangle(0, 0, Math.Max(Width, 800), Math.Max(Height, 600));
                    // mover meta a otra posición más difícil de alcanzar y crear zona segura alrededor
                    meta = new Rectangle(Math.Min(bounds.Width - 60, 720), 300, 40, 40);
                    var zonaSeguraMeta = meta;
                    zonaSeguraMeta.Inflate(30, 30);
                    var generated = GenerateNonOverlappingRectangles(15, bounds, 30, 100, 30, 100, zonaSeguraMeta);
                    foreach (var r in generated) paredes.Add(r);
                    jugador.x = 50;
                    jugador.y = 50;
                    // aumentar la velocidad del jugador para mayor dificultad
                    jugador.Velocidad = 20;
                    break;

                case 3:
                    this.BackgroundImage = Properties.Resources.fondoNivel3;
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                    this.BackColor = Color.DarkSlateBlue;
                    var bounds3 = new Rectangle(0, 0, Math.Max(Width, 800), Math.Max(Height, 600));
                    meta = new Rectangle(700, 500, 60, 60);
                    var zonaSeguraMeta3 = meta;
                    zonaSeguraMeta3.Inflate(50, 50);
                    var generated3 = GenerateNonOverlappingRectangles(18, bounds3, 30, 100, 30, 115, zonaSeguraMeta3);

                    foreach (var r in generated3) paredes.Add(r);
                    jugador.Velocidad = 30;
                    jugador.x = 50;
                    jugador.y = 50;
                    break;
                default:
                    nivelActual = 1;
                    CargarNivel();
                    break;
            }
        }

        // Genera n rectángulos no solapados dentro de un area dada
        private List<Rectangle> GenerateNonOverlappingRectangles(int count, Rectangle area, int minW, int maxW, int minH, int maxH, Rectangle? zonaSeguraMeta = null)
        {
            var list = new List<Rectangle>();
            int attempts = 0;
            while (list.Count < count && attempts < count * 200)
            {
                attempts++;
                int w = rnd.Next(minW, maxW + 1);
                int h = rnd.Next(minH, maxH + 1);
                int x = rnd.Next(area.X, Math.Max(area.X, area.Right - w));
                int y = rnd.Next(area.Y, Math.Max(area.Y, area.Bottom - h));
                var candidate = new Rectangle(x, y, w, h);

                // evitar que se empalme con la zona de inicio del jugador
                var playerStart = new Rectangle(40, 40, 80, 80);
                if (candidate.IntersectsWith(playerStart)) continue;
                // evitar que se empalme con la zona segura alrededor de la meta si se proporcionó
                if (zonaSeguraMeta.HasValue && candidate.IntersectsWith(zonaSeguraMeta.Value)) continue;

                bool overlaps = false;
                foreach (var r in list)
                {
                    if (r.IntersectsWith(candidate))
                    {
                        overlaps = true;
                        break;
                    }
                }
                if (!overlaps)
                {
                    list.Add(candidate);
                }
            }
            return list;
        }

       
    }
}
