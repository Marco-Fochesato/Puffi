using System;

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
        Punto posCasa = new Punto();
        Punto posPuffo = new Punto();
        Punto posGarga = new Punto();
        Punto[] posAlberi = new Punto[10];
        Panel[] pnlAlberi = new Panel[10];
        int puntiPuffo = 0;
        int puntiGarga = 0;
        bool turnoPuffo = true;
        int contatorePassi = 0;
        public Form1()
        {
            InitializeComponent();
            // Inizializza l'array dei pannelli degli alberi
            pnlAlberi[0] = pnl1;
            pnlAlberi[1] = pnl2;
            pnlAlberi[2] = pnl3;
            pnlAlberi[3] = pnl4;
            pnlAlberi[4] = pnl5;
            pnlAlberi[5] = pnl6;
            pnlAlberi[6] = pnl7;
            pnlAlberi[7] = pnl8;
            pnlAlberi[8] = pnl9;
            pnlAlberi[9] = pnl10;
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            posCasa.x = 0;
            posCasa.y = 0;
            pnlCasa.Location = new Point(posCasa.x, posCasa.y);
            SpostaCasa(false); // Posiziona la casa in una posizione casuale all'avvio senza incrementare i punti
            SpostaAlberi(); // Posiziona gli alberi randomicamente all'avvio
        }

        private void PressTasto(object sender, KeyEventArgs e)
        {
            int passo = 20; // Distanza in pixel per ogni spostamento (clcik di tasto)

            switch (e.KeyCode)
            {
                case Keys.S:
                    {
                        if (!turnoPuffo) return; // Se non è il turno di Puffo, ignora

                        posPuffo.y += passo;
                        if (posPuffo.y > pnlArea.Height - pnlPuffo.Height) // se con il prossimo passo rischia di uscire dall'area 
                        {
                            posPuffo.y = pnlArea.Height - pnlPuffo.Height; // limita la posizione al bordo inferiore
                        }
                        pnlPuffo.Location = new Point(posPuffo.x, posPuffo.y);

                        contatorePassi++;
                        if (!CollidePulse()) // Se non collide con albero, continua normalmente
                        {
                            CambiaTurno();
                            Collisione();
                        }
                        else
                        {
                            contatorePassi--; // Annulla l'incremento del contatore se c'è collisione
                            turnoPuffo = false; // Perde il turno
                            CambiaTurno(); // Passa direttamente al turno dell'avversario
                        }
                    }
                    break;
                case Keys.W:
                    {
                        if (!turnoPuffo) return; // Se non è il turno di Puffo, ignora

                        posPuffo.y -= passo;
                        if (posPuffo.y < 0)
                        {
                            posPuffo.y = 0; // Limita la posizione al bordo superiore
                        }
                        pnlPuffo.Location = new Point(posPuffo.x, posPuffo.y);

                        contatorePassi++;
                        if (!CollidePulse()) // Se non collide con albero, continua normalmente
                        {
                            CambiaTurno();
                            Collisione();
                        }
                        else
                        {
                            contatorePassi--; // Annulla l'incremento del contatore se c'è collisione
                            turnoPuffo = false; // Perde il turno
                            CambiaTurno(); // Passa direttamente al turno dell'avversario
                        }
                    }
                    break;
                case Keys.A:
                    {
                        if (!turnoPuffo) return; // Se non è il turno di Puffo, ignora

                        posPuffo.x -= passo;
                        if (posPuffo.x < 0)
                        {
                            posPuffo.x = 0; // Limita la posizione al bordo sinistro
                        }
                        pnlPuffo.Location = new Point(posPuffo.x, posPuffo.y);

                        contatorePassi++;
                        if (!CollidePulse()) // Se non collide con albero, continua normalmente
                        {
                            CambiaTurno();
                            Collisione();
                        }
                        else
                        {
                            contatorePassi--; // Annulla l'incremento del contatore se c'è collisione
                            turnoPuffo = false; // Perde il turno
                            CambiaTurno(); // Passa direttamente al turno dell'avversario
                        }
                    }
                    break;
                case Keys.D:
                    {
                        if (!turnoPuffo) return; // Se non è il turno di Puffo, ignora

                        posPuffo.x += passo;
                        if (posPuffo.x > pnlArea.Width - pnlPuffo.Width)
                        {
                            posPuffo.x = pnlArea.Width - pnlPuffo.Width; // Limita la posizione al bordo destro
                        }
                        pnlPuffo.Location = new Point(posPuffo.x, posPuffo.y);

                        contatorePassi++;
                        if (!CollidePulse()) // Se non collide con albero, continua normalmente
                        {
                            CambiaTurno();
                            Collisione();
                        }
                        else
                        {
                            contatorePassi--; // Annulla l'incremento del contatore se c'è collisione
                            turnoPuffo = false; // Perde il turno
                            CambiaTurno(); // Passa direttamente al turno dell'avversario
                        }
                    }
                    break;
            }
            switch (e.KeyCode)
            {
                case Keys.I:
                    {
                        if (turnoPuffo) return; // Se è il turno di Puffo, ignora

                        posGarga.y -= passo;
                        if (posGarga.y < 0)
                        {
                            posGarga.y = 0; // Limita la posizione al bordo superiore
                        }
                        pnlGarga.Location = new Point(posGarga.x, posGarga.y);

                        contatorePassi++;
                        if (!CollideGarga()) // Se non collide con albero, continua normalmente
                        {
                            CambiaTurno();
                            Collisione();
                        }
                        else
                        {
                            contatorePassi--; // Annulla l'incremento del contatore se c'è collisione
                            turnoPuffo = true; // Perde il turno, passa a Puffo
                            CambiaTurno(); // Passa direttamente al turno dell'avversario
                        }
                    }
                    break;
                case Keys.K:
                    {
                        if (turnoPuffo) return; // Se è il turno di Puffo, ignora

                        posGarga.y += passo;
                        if (posGarga.y > pnlArea.Height - pnlGarga.Height)
                        {
                            posGarga.y = pnlArea.Height - pnlGarga.Height; // Limita la posizione al bordo inferiore
                        }
                        pnlGarga.Location = new Point(posGarga.x, posGarga.y);

                        contatorePassi++;
                        if (!CollideGarga()) // Se non collide con albero, continua normalmente
                        {
                            CambiaTurno();
                            Collisione();
                        }
                        else
                        {
                            contatorePassi--; // Annulla l'incremento del contatore se c'è collisione
                            turnoPuffo = true; // Perde il turno, passa a Puffo
                            CambiaTurno(); // Passa direttamente al turno dell'avversario
                        }
                    }
                    break;
                case Keys.L:
                    {
                        if (turnoPuffo) return; // Se è il turno di Puffo, ignora

                        posGarga.x += passo;
                        if (posGarga.x > pnlArea.Width - pnlGarga.Width)
                        {
                            posGarga.x = pnlArea.Width - pnlGarga.Width; // Limita la posizione al bordo destro
                        }
                        pnlGarga.Location = new Point(posGarga.x, posGarga.y);

                        contatorePassi++;
                        if (!CollideGarga()) // Se non collide con albero, continua normalmente
                        {
                            CambiaTurno();
                            Collisione();
                        }
                        else
                        {
                            contatorePassi--; // Annulla l'incremento del contatore se c'è collisione
                            turnoPuffo = true; // Perde il turno, passa a Puffo
                            CambiaTurno(); // Passa direttamente al turno dell'avversario
                        }
                    }
                    break;
                case Keys.J:
                    {
                        if (turnoPuffo) return; // Se è il turno di Puffo, ignora

                        posGarga.x -= passo;
                        if (posGarga.x < 0)
                        {
                            posGarga.x = 0; // Limita la posizione al bordo sinistro
                        }
                        pnlGarga.Location = new Point(posGarga.x, posGarga.y);

                        contatorePassi++;
                        if (!CollideGarga()) // Se non collide con albero, continua normalmente
                        {
                            CambiaTurno();
                            Collisione();
                        }
                        else
                        {
                            contatorePassi--; // Annulla l'incremento del contatore se c'è collisione
                            turnoPuffo = true; // Perde il turno, passa a Puffo
                            CambiaTurno(); // Passa direttamente al turno dell'avversario
                        }
                    }
                    break;
            }
        }
        private void CambiaTurno()
        {
            if (contatorePassi >= 10)
            {
                contatorePassi = 0;
                turnoPuffo = !turnoPuffo;
            }
        }
        private void Collisione()
        {
            if (pnlPuffo.Bounds.IntersectsWith(pnlCasa.Bounds))
            {
                SpostaCasa(true);
            }
            if (pnlGarga.Bounds.IntersectsWith(pnlPuffo.Bounds))
            {
                SpostaPuffo();
            }
        }
        private void SpostaCasa(bool incrPunti)
        {
            if (incrPunti)
            {
                puntiPuffo++; // Incrementa i punti
                txtPuntiPuffo.Text = "Punti: " + puntiPuffo.ToString(); //mette i punti sulla txtPunti
                SpostaAlberi(); // Sposta gli alberi quando Puffo raggiunge la casa
            }
            Random rand = new Random();
            int maxX = pnlArea.Width - pnlCasa.Width;  // trova max in x
            int maxY = pnlArea.Height - pnlCasa.Height;  // trova max in y
            int x = rand.Next(0, maxX + 1); // genera un numero casuale in x rispettando max
            int y = rand.Next(0, maxY + 1); // genera un numero casuale in y rispettando max
            pnlCasa.Location = new Point(x, y); //sposta la casa

        }

        private void SpostaPuffo()
        {
            puntiGarga++; // Incrementa i punti
            puntiPuffo--; // Decrementa i punti di Puffo
            txtPuntiGarga.Text = "Punti: " + puntiGarga.ToString(); //mette i punti sulla txtPunti
            txtPuntiPuffo.Text = "Punti: " + puntiPuffo.ToString(); //mette i punti sulla txtPunti
            Random rand = new Random();
            int maxX = pnlArea.Width - pnlPuffo.Width;  // trova max in x
            int maxY = pnlArea.Height - pnlPuffo.Height;  // trova max in y
            int x = rand.Next(0, maxX + 1); // genera un numero casuale in x rispettando max
            int y = rand.Next(0, maxY + 1); // genera un numero casuale in y rispettando max
            posPuffo.x = x;  // AGGIORNA posPuffo
            posPuffo.y = y;  // AGGIORNA posPuffo
            pnlPuffo.Location = new Point(x, y); //sposta il puffo
        }

        private void SpostaAlberi()
        {
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                int maxX = pnlArea.Width - pnlAlberi[i].Width;  // trova max in x
                int maxY = pnlArea.Height - pnlAlberi[i].Height;  // trova max in y
                int x = rand.Next(0, maxX + 1); // genera un numero casuale in x rispettando max
                int y = rand.Next(0, maxY + 1); // genera un numero casuale in y rispettando max
                posAlberi[i].x = x;  // AGGIORNA posAlberi
                posAlberi[i].y = y;  // AGGIORNA posAlberi
                pnlAlberi[i].Location = new Point(x, y); //sposta l'albero
            }
        }

        private bool CollidePulse()
        {
            for (int i = 0; i < 10; i++)
            {
                if (pnlPuffo.Bounds.IntersectsWith(pnlAlberi[i].Bounds))
                {
                    // Ripristina la posizione precedente di Puffo
                    pnlPuffo.Location = new Point(posPuffo.x - (pnlPuffo.Left - posPuffo.x), posPuffo.y - (pnlPuffo.Top - posPuffo.y));
                    return true;
                }
            }
            return false;
        }

        private bool CollideGarga()
        {
            for (int i = 0; i < 10; i++)
            {
                if (pnlGarga.Bounds.IntersectsWith(pnlAlberi[i].Bounds))
                {
                    // Ripristina la posizione precedente di Garga
                    pnlGarga.Location = new Point(posGarga.x - (pnlGarga.Left - posGarga.x), posGarga.y - (pnlGarga.Top - posGarga.y));
                    return true;
                }
            }
            return false;
        }
    }
}
