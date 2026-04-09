namespace JuegoLaberinto

{
    public partial class FormJuego : Form
    {
        Jugador jugador = new Jugador();
        List<Rectangle> paredes = new List<Rectangle>();
        Rectangle meta;
        public FormJuego()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.BackColor = Color.Aqua;

            jugador.x = 50; 
            jugador.y = 50;

            //crear paredes
            paredes.Add(new Rectangle(100, 0, 20, 400));
            paredes.Add(new Rectangle(200,50, 20, 400));
            paredes.Add(new Rectangle(300, 0, 20, 400));
            paredes.Add(new Rectangle(400, 200, 20, 400));
            paredes.Add(new Rectangle(500, 50, 20, 400));
            

            //meta
            meta = new Rectangle(700,500,40,40);
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
        }
        public void FormJuego_KeyDown(object sender, KeyEventArgs e) 
        {
            int xAnterior = jugador.x;
            int yAnterior = jugador.y;
            if (e.KeyCode == Keys.Up)jugador.Mover("arriba");
            if (e.KeyCode == Keys.Down)jugador.Mover("abajo");
            if (e.KeyCode == Keys.Left)jugador.Mover("izquierda");
            if (e.KeyCode == Keys.Right)jugador.Mover("derecha");

            if(ColisionPared())
            {
                jugador.x = xAnterior;
                jugador.y = yAnterior;
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
                if(jugador.Area().IntersectsWith(pared))
                    return true;
            }
            return false;
        }
        private void FormJuego_Load(object sender, EventArgs e)
        {

        }
    }
}
