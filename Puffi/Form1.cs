namespace Puffi
{
    struct Punto
    {
        public int x;
        public int y;

        public Punto(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public partial class Form1 : Form
    {
        Punto pos = new Punto();
        int punti = 0;
        public Form1()
        {
            InitializeComponent();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            pos.x = 0;
            pos.y = 0;
            pnlPuffo.Location = new Point(pos.x, pos.y);
            SpostaCasa(false); // Posiziona la casa in una posizione casuale all'avvio senza incrementare i punti
        }

        private void PressTasto(object sender, KeyEventArgs e)
        {
            int passo= 20; // Distanza in pixel per ogni spostamento (clcik di tasto)

            switch (e.KeyCode)
            {
                case Keys.S:
                    {
                        pos.y += passo;
                        if (pos.y > pnlArea.Height - pnlPuffo.Height) // se con il prossimo passo rischia di uscire dall'area 
                        {
                            pos.y = pnlArea.Height - pnlPuffo.Height; // limita la posizione al bordo inferiore
                        }
                        pnlPuffo.Location = new Point(pos.x, pos.y);

                        if (pnlPuffo.Bounds.IntersectsWith(pnlCasa.Bounds))
                        {
                            SpostaCasa(true);
                        }
                    }
                    break;
                case Keys.W:
                    {
                        pos.y -= passo;
                        if (pos.y < 0)
                        {
                            pos.y = 0; // Limita la posizione al bordo superiore
                        }
                        pnlPuffo.Location = new Point(pos.x, pos.y);
                        if (pnlPuffo.Bounds.IntersectsWith(pnlCasa.Bounds))
                        {
                            SpostaCasa(true);
                        }
                    }
                    break;
                case Keys.A:
                    {
                        pos.x -= passo;
                        if (pos.x < 0)
                        {
                            pos.x = 0; // Limita la posizione al bordo sinistro
                        }
                        pnlPuffo.Location = new Point(pos.x, pos.y);
                        if (pnlPuffo.Bounds.IntersectsWith(pnlCasa.Bounds))
                        {
                            SpostaCasa(true);
                        }
                    }
                    break;
                case Keys.D:
                    {
                        pos.x += passo;
                        if (pos.x > pnlArea.Width - pnlPuffo.Width)
                        {
                            pos.x = pnlArea.Width - pnlPuffo.Width; // Limita la posizione al bordo destro
                        }
                        pnlPuffo.Location = new Point(pos.x, pos.y);
                        if (pnlPuffo.Bounds.IntersectsWith(pnlCasa.Bounds))
                        {
                            SpostaCasa(true);
                        }
                    }
                    break;
            }
        }
        private void SpostaCasa(bool incrPunti )
        {
            if (incrPunti)
            {
                punti++; // Incrementa i punti
                txtPunti.Text = "Punti: " + punti.ToString(); //mette i punti sulla txtPunti
            }
            var rand = new Random();
            int maxX = Math.Max(0, pnlArea.Width - pnlCasa.Width); // trova max in x
            int maxY = Math.Max(0, pnlArea.Height - pnlCasa.Height); // trova max in y
            int x = rand.Next(0, maxX + 1); // genera un numero casuale in x rispettando max
            int y = rand.Next(0, maxY + 1); // genera un numero casuale in y rispettando max
            pnlCasa.Location = new Point(x, y); //sposta la casa
            
        }
    }
}

