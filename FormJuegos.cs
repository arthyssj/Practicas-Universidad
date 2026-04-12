using System.Media;
using WMPLib;
namespace JuegoLaberinto

{
    public partial class FormJuego : Form
    {
        WindowsMediaPlayer musicaNiveles = new WindowsMediaPlayer();
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
        bool volverAlMenu = false;


        public FormJuego()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            try
            {
                // El archivo debe estar en la carpeta bin/Debug/net8.0-windows
                musicaNiveles.URL = "musicaNiveles.wav";
                musicaNiveles.settings.setMode("loop", true);
                musicaNiveles.settings.volume = 10;
                musicaNiveles.controls.play();
            }
            catch { /* Si no encuentra el archivo, el juego no se crashea */ }

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
            // 1. Calcular el factor de escala (DPI)
            float escala = this.DeviceDpi / 96f;
            foreach (var pared in paredes)
            {
                g.FillRectangle(Brushes.Black, pared);
                using(Pen bordePared = new Pen(Color.LightGreen, 1))
                {
                    g.DrawRectangle(bordePared, pared);
                }
            }
            g.FillRectangle(Brushes.Green, meta);

            using (var font = new Font("Consolas", 18 * escala, FontStyle.Bold, GraphicsUnit.Pixel))
            {
                string textoVidas = $"Vidas: {vidas}";
                string textoTiempo = $"Tiempo: {tiempo}";

                // 1. MEDIR EL TEXTO: Esto nos da el ancho exacto en píxeles
                SizeF tamanoVidas = g.MeasureString(textoVidas, font);
                SizeF tamanoTiempo = g.MeasureString(textoTiempo, font);

                // 2. CALCULAR POSICIÓN X: (Ancho de ventana - Ancho del texto - un pequeño margen de 10px)
                float xVidas = this.ClientSize.Width - tamanoVidas.Width - (10 * escala);
                float xTiempo = this.ClientSize.Width - tamanoTiempo.Width - (10 * escala);

                // 3. POSICIÓN Y
                float yVidas = 15 * escala;
                float yTiempo = 45 * escala;

                // DIBUJAR SOMBRAS
                g.DrawString(textoVidas, font, Brushes.Black, xVidas + (2 * escala), yVidas + (2 * escala));
                g.DrawString(textoTiempo, font, Brushes.Black, xTiempo + (2 * escala), yTiempo + (2 * escala));

                // DIBUJAR TEXTO PRINCIPAL
                g.DrawString(textoVidas, font, Brushes.Crimson, xVidas, yVidas);
                g.DrawString(textoTiempo, font, Brushes.Gold, xTiempo, yTiempo);
            }
            jugador.Dibujar(g);
        }
        public void FormJuego_KeyDown(object sender, KeyEventArgs e)
        {
            // 1. Guardamos la posición por si acaso (aunque ahora reinicias al inicio)
            int xAnterior = jugador.x;
            int yAnterior = jugador.y;

            // 2. Movemos al jugador
            if (e.KeyCode == Keys.Up) jugador.Mover("arriba");
            if (e.KeyCode == Keys.Down) jugador.Mover("abajo");
            if (e.KeyCode == Keys.Left) jugador.Mover("izquierda");
            if (e.KeyCode == Keys.Right) jugador.Mover("derecha");

            // 3. CREAMOS EL HITBOX REDUCIDO (La "Opción B")
            // Le quitamos 6 píxeles de cada lado para que sea más permisivo
            Rectangle hitboxJugador = new Rectangle(jugador.x + 6, jugador.y + 6, jugador.Tamano - 12, jugador.Tamano - 12);

            // 4. VERIFICAMOS COLISIÓN CON LAS PAREDES
            bool huboChoque = false;
            foreach (var pared in paredes)
            {
                if (hitboxJugador.IntersectsWith(pared))
                {
                    huboChoque = true;
                    break;
                }
            }

            if (huboChoque)
            {
                sonidoColision.Play();
                vidas--;

                // Forzamos el redibujado para que se vea el 0 si es la última vida
                if (vidas <= 0)
                {
                    vidas = 0;
                    this.Invalidate();
                    this.Update();
                    tmrCronometro.Stop();
                    musicaNiveles.controls.stop();
                    sonidoGameOver.Play();
                    FormMensaje formMensaje = new FormMensaje("¡Game Over!");
                    formMensaje.ShowDialog();
                    ResetGame();
                    return; // Salimos para no ejecutar lo de la meta
                }
                else
                {
                    // Si aún tiene vidas, lo mandamos al inicio del nivel
                    jugador.x = 50;
                    jugador.y = 50;
                }
            }

            // 5. VERIFICAMOS SI LLEGÓ A LA META
            // Aquí sí usamos el área completa del jugador para que sea justo
            if (jugador.Area().IntersectsWith(meta))
            {
                sonidoNivel.Play();
                if (nivelActual < 3)
                {
                    nivelActual++;
                    FormMensaje formMensaje = new FormMensaje("Pasaste al Nivel " + nivelActual);
                    formMensaje.ShowDialog();
                    CargarNivel();
                }
                else
                {
                    tmrCronometro.Stop();
                    musicaNiveles.controls.stop();
                    sonidoVictoria.Play();
                    FormMensaje formMensaje = new FormMensaje("FELICIDADES\n¡HAZ GANADO EL JUEGO!");
                    formMensaje.ShowDialog();
                    ResetGame();
                    return;
                }
            }

            Invalidate(); // Redibujar todo
        }
        private void FormJuego_Load(object sender, EventArgs e)
        {

        }
        private void ResetGame()
        {
            // reiniciar estado del juego
            musicaNiveles.controls.stop();
            tmrCronometro.Stop();
            volverAlMenu = true;
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
                    vidas = 0;
                    this.Invalidate();
                    this.Update();
                    musicaNiveles.controls.stop();
                    sonidoGameOver.Play();
                    FormMensaje formMensaje = new FormMensaje("¡Game Over!");
                    formMensaje.ShowDialog();

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
                    this.BackColor = Color.DarkOrange;
                    var bounds = new Rectangle(0, 0, Math.Max(Width, 800), Math.Max(Height, 600));
                    // mover meta a otra posición más difícil de alcanzar y crear zona segura alrededor
                    meta = new Rectangle(Math.Min(bounds.Width - 30, 720), 300, 40, 40);
                    var zonaSeguraMeta = meta;
                    zonaSeguraMeta.Inflate(5, 5);
                    var generated = GenerateNonOverlappingRectangles(30, bounds, 40, 80, 40, 60, zonaSeguraMeta);
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
                    zonaSeguraMeta3.Inflate(25, 25);
                    var generated3 = GenerateNonOverlappingRectangles(25, bounds3, 40, 80, 40, 115, zonaSeguraMeta3);

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
                var playerStart = new Rectangle(30, 30, 60, 60);
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

        private void FormJuego_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(volverAlMenu == false)
            {
                Application.Exit();
            }
        }
    }
}
