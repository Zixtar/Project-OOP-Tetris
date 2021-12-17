using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        int player = 1;                //variabile ce tin de muliplayer
        Thread threadClient;
        TcpClient client;
        NetworkStream DateClient;
        String DatePrimite;
        int contor = 0;
        Form1 formXYZ;
        System.Windows.Media.MediaPlayer musicPLY = new System.Windows.Media.MediaPlayer();

        protected override CreateParams CreateParams   //magie ce scoate flickering-ul
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;

                return cp;
            }
        }
        void PrimireDinServer()
        {
            StreamReader citire = new StreamReader(DateClient);
            string date = citire.ReadLine();
            player = int.Parse(date);
            if (player == 1)
            {
                date = citire.ReadLine();
                if (date == "C")
                    contor++;
            }

            while (true)
            {
                DatePrimite = citire.ReadLine();
                if (DatePrimite[0] == 'R')
                {
                    DatePrimite = DatePrimite.Replace('R', ' ');
                    DatePrimite = DatePrimite.Trim();
                    _tabla1.CurrentMaxH = int.Parse(DatePrimite);
                    DatePrimite = "R";
                }
                else
                    if (DatePrimite[0] == 'S')
                {                                           // switch din player 2 in 1
                    player = 1;
                    contor = 2;
                    _tabla1.CurrentMaxH = 0;
                    _tabla1 = new TablaDeJoc(LATIME, INALTIME);
                    ObiectCurent = null;
                    MethodInvoker n = new MethodInvoker(() => panelPiesa1.Enabled = panelPiesa2.Enabled = panelPiesa3.Enabled = true);
                    formXYZ.Invoke(n);
                    MethodInvoker m = new MethodInvoker(() => panelAlegere.Invalidate());
                    formXYZ.Invoke(m);
                }
                else
                {
                    if (DatePrimite[0] == 'F')
                    {
                        {
                            if (DatePrimite[1] == '0')
                            {
                                MessageBox.Show("Draw");
                            }
                            else
                            if (DatePrimite[1] == '1')
                            {
                                MessageBox.Show("Player 1 Won");
                            }
                            else
                            {
                                MessageBox.Show("Player 2 Won");
                            }
                        }
                    }

                }
            }
        }
        public Form1()
        {

            InitializeComponent();
            formXYZ = this;
            musicPLY.Open(new Uri(@"Tetris.wav", UriKind.Relative));
            musicPLY.Volume = 0;
            musicPLY.Play();
            musicPLY.MediaEnded += Media_Ended;
        }

        void Media_Ended(object sender, EventArgs e)
        {
            musicPLY.Position = TimeSpan.Zero;
        }
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        void SetTimer()
        {
            timer.Tick += EventTimer;
            timer.Interval = 500;
            timer.Start();
        }

        TablaDeJoc _tabla1;     //variabile ce tin de jocul local
        TablaAlegere _tabla2;
        int pieseCazuteContorTimer=0;
        int PIXELIPEPATRAT = 18;  //casplock deoarece era const inainte de adaugarea compatibilitatii pt scaling
        const int LATIME = 10;
        const int INALTIME = 20;
        const int LATIME_ALEGERE = 13;
        const int INALTIME_ALEGERE = 8;

        ObiectCazator ObiectCurent;
        ObiectCazator NextPiesa = null;

        private void Form1_Load(object sender, EventArgs e)
        {
            int procentaj = (int)(100 * Screen.PrimaryScreen.Bounds.Width / System.Windows.SystemParameters.PrimaryScreenWidth);
            PIXELIPEPATRAT = procentaj * PIXELIPEPATRAT / 100;
            //  BitmapTabla = new Bitmap(picBoxTabla.Width, picBoxTabla.Height);
            (panelTab as Control).KeyDown += Form1_KeyDown;
            panelTab.Width = LATIME * PIXELIPEPATRAT;

            panelTab.Height = INALTIME * PIXELIPEPATRAT;
            panelAlegere.Width = LATIME_ALEGERE * PIXELIPEPATRAT;
            panelAlegere.Height = INALTIME_ALEGERE * PIXELIPEPATRAT;
            if (player == 1)
            {
                _tabla1 = new TablaDeJoc(LATIME, INALTIME);
            }
        }

        private void panelTab_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (player == 1)
            {
                for (int i = 0; i < _tabla1.Heigth; i++)
                    for (int j = 0; j < _tabla1.Width; j++)
                        if (_tabla1.MatriceLogicaTablaDeJoc[i, j] == 0)
                            g.FillRectangle(Brushes.MediumOrchid, j * PIXELIPEPATRAT, i * PIXELIPEPATRAT, PIXELIPEPATRAT, PIXELIPEPATRAT);
                        else
                        {
                            g.FillRectangle(Brushes.Black, j * PIXELIPEPATRAT, i * PIXELIPEPATRAT, PIXELIPEPATRAT, PIXELIPEPATRAT);
                            g.DrawRectangle(new Pen(Color.Gray, 2), j * PIXELIPEPATRAT, i * PIXELIPEPATRAT, PIXELIPEPATRAT, PIXELIPEPATRAT);
                        }
            }
            else
            {
                for (int i = INALTIME - _tabla1.CurrentMaxH; i < _tabla1.Heigth; i++)
                    for (int j = 0; j < _tabla1.Width; j++)
                    {
                        if (_tabla1.CurrentMaxH >= 0 && _tabla1.CurrentMaxH <= 0.25 * INALTIME)
                            g.FillRectangle(Brushes.Green, j * PIXELIPEPATRAT, i * PIXELIPEPATRAT, PIXELIPEPATRAT, PIXELIPEPATRAT);
                        else
                            if (_tabla1.CurrentMaxH > 0.25 * INALTIME && _tabla1.CurrentMaxH <= 0.5 * INALTIME)
                            g.FillRectangle(Brushes.GreenYellow, j * PIXELIPEPATRAT, i * PIXELIPEPATRAT, PIXELIPEPATRAT, PIXELIPEPATRAT);
                        else
                                if (_tabla1.CurrentMaxH > 0.5 * INALTIME && _tabla1.CurrentMaxH <= 0.75 * INALTIME)
                            g.FillRectangle(Brushes.Yellow, j * PIXELIPEPATRAT, i * PIXELIPEPATRAT, PIXELIPEPATRAT, PIXELIPEPATRAT);
                        else
                                    if (_tabla1.CurrentMaxH > 0.75 * INALTIME && _tabla1.CurrentMaxH <= 1 * INALTIME)
                            g.FillRectangle(Brushes.OrangeRed, j * PIXELIPEPATRAT, i * PIXELIPEPATRAT, PIXELIPEPATRAT, PIXELIPEPATRAT);
                        g.DrawRectangle(new Pen(Color.Gray, 2), j * PIXELIPEPATRAT, i * PIXELIPEPATRAT, PIXELIPEPATRAT, PIXELIPEPATRAT);
                    }
            }

        }

        private void EventTimer(Object Source, EventArgs myEventArgs)
        {
            if (player == 1 && contor == 2)
            {

                if (!_tabla1.arePiesa)  // daca nu sunt piese active se spawneaza unul de tip random
                {
                    pieseCazuteContorTimer++;
                    if (timer.Interval > 200 && pieseCazuteContorTimer == 10)
                    {
                        timer.Interval -= 50;
                        pieseCazuteContorTimer = 0;
                    }
                    if (ObiectCurent != null && (INALTIME - ObiectCurent.coordCentruY) > _tabla1.CurrentMaxH)
                        _tabla1.CurrentMaxH = INALTIME - ObiectCurent.coordCentruY;
                    StreamWriter scriere = new StreamWriter(DateClient);
                    scriere.AutoFlush = true;
                    scriere.WriteLine("R" + _tabla1.CurrentMaxH);
                    NextPiesa = null;
                    if (DatePrimite != null && DatePrimite[0] == 'P')
                    {
                        NextPiesa = GenerarePiesa(int.Parse(DatePrimite[1].ToString()));
                        DatePrimite = null;
                    }
                    if (NextPiesa == null)
                    {
                        Random rnd = new Random();
                        int rndAlegereObiect = rnd.Next(0, 7);
                        ObiectCurent = GenerarePiesa(rndAlegereObiect);
                    }
                    else
                    {
                        ObiectCurent = (ObiectCazator)NextPiesa.Clone();
                        NextPiesa = null;
                    }
                    if (_tabla1.PiesaAreLoc(ObiectCurent))
                        _tabla1.ModificareTabla(ObiectCurent.MatriceForma, ObiectCurent.coordCentruX, ObiectCurent.coordCentruY, ObiectCurent.latime, ObiectCurent.inaltime);
                    else
                    {                                                       // switch din player 1 in 2
                        timer.Interval=500;
                        player = 2;
                        scriere.WriteLine("S" + player1Score.Text); ;
                        _tabla2 = new TablaAlegere(LATIME_ALEGERE, INALTIME_ALEGERE, PIXELIPEPATRAT);
                        initializarePanels();
                        panelAlegere.Invalidate();
                        panelPiesa1.Enabled = panelPiesa2.Enabled = panelPiesa3.Enabled = true;
                        _tabla1.CurrentMaxH = 0;
                        _tabla1.CurataTabla();
                        ObiectCurent = null;
                    }
                    player1Score.Text = _tabla1.score.ToString();
                }
                else
                    _tabla1.ModificareTabla(ObiectCurent.MatriceForma, ref ObiectCurent.coordCentruX, ref ObiectCurent.coordCentruY, ObiectCurent.latime, ObiectCurent.inaltime, 0, 1);

                panelTab.Invalidate();
            }
            if (player == 2)
            {
                if (DatePrimite != null && DatePrimite[0] == 'R')
                {
                    _tabla2.PieseRandom();
                    panelAlegere.Invalidate();
                    DatePrimite = null;
                }
                panelTab.Invalidate();
            }
        }

        private ObiectCazator GenerarePiesa(int NrPiesa)
        {
            ObiectCazator obiectTmp = null;
            switch (NrPiesa)
            {
                case (int)Forme.PIESA_O:
                    obiectTmp = new PiesaO(LATIME / 2, 0);
                    break;
                case (int)Forme.PIESA_T:
                    obiectTmp = new PiesaT(LATIME / 2, 0);
                    break;
                case (int)Forme.PIESA_S:
                    obiectTmp = new PiesaS(LATIME / 2, 0);
                    break;
                case (int)Forme.PIESA_Z:
                    obiectTmp = new PiesaZ(LATIME / 2, 0);
                    break;
                case (int)Forme.PIESA_J:
                    obiectTmp = new PiesaJ(LATIME / 2, 0);
                    break;
                case (int)Forme.PIESA_L:
                    obiectTmp = new PiesaL(LATIME / 2, 0);
                    break;
                case (int)Forme.PIESA_I:
                    obiectTmp = new PiesaI(LATIME / 2, 0);
                    break;
            }
            return obiectTmp;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (_tabla1.arePiesa)
            {
                if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                    _tabla1.ModificareTabla(ObiectCurent.MatriceForma, ref ObiectCurent.coordCentruX, ref ObiectCurent.coordCentruY, ObiectCurent.latime, ObiectCurent.inaltime, -1, 0);
                if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
                    _tabla1.ModificareTabla(ObiectCurent.MatriceForma, ref ObiectCurent.coordCentruX, ref ObiectCurent.coordCentruY, ObiectCurent.latime, ObiectCurent.inaltime, 1, 0);
                if (e.KeyCode == Keys.Space)
                {
                    _tabla1.score += 5;
                    while (_tabla1.arePiesa)
                        _tabla1.ModificareTabla(ObiectCurent.MatriceForma, ref ObiectCurent.coordCentruX, ref ObiectCurent.coordCentruY, ObiectCurent.latime, ObiectCurent.inaltime, 0, 1);
                }
                    if (e.KeyCode == Keys.R)
                {
                    _tabla1.Rotire(ObiectCurent);
                }
                panelTab.Invalidate();
            }
        }

        private void panelAlegere_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (player == 1 && contor == 2)
            {
                for (int i = 0; i < _tabla2.Heigth; i++)
                    for (int j = 0; j < _tabla2.Width; j++)
                        g.FillRectangle(Brushes.Black, i * PIXELIPEPATRAT, j * PIXELIPEPATRAT, PIXELIPEPATRAT, PIXELIPEPATRAT);

            }
            if (player == 2)
            {
                for (int k = 0; k < 3; k++)
                {
                    Color culoare = new Color();
                    if (k == _tabla2.selectat)
                        culoare = Color.Red;
                    else
                        culoare = Color.Gray;
                    for (int i = 0; i < 4; i++)
                        for (int j = 0; j < 3; j++)
                        {
                            g.FillRectangle(Brushes.White, (_tabla2.sirPanels[k].coordX + j) * PIXELIPEPATRAT, (_tabla2.sirPanels[k].coordY + i) * PIXELIPEPATRAT, PIXELIPEPATRAT, PIXELIPEPATRAT);
                            if (i == 0)
                                g.DrawLine(new Pen(culoare, 2), (_tabla2.sirPanels[k].coordX + j) * PIXELIPEPATRAT, (_tabla2.sirPanels[k].coordY + i) * PIXELIPEPATRAT, (_tabla2.sirPanels[k].coordX + j) * PIXELIPEPATRAT + PIXELIPEPATRAT, (_tabla2.sirPanels[k].coordY + i) * PIXELIPEPATRAT);
                            if (i == 3)
                                g.DrawLine(new Pen(culoare, 2), (_tabla2.sirPanels[k].coordX + j) * PIXELIPEPATRAT, (_tabla2.sirPanels[k].coordY + i) * PIXELIPEPATRAT + PIXELIPEPATRAT, (_tabla2.sirPanels[k].coordX + j) * PIXELIPEPATRAT + PIXELIPEPATRAT, (_tabla2.sirPanels[k].coordY + i) * PIXELIPEPATRAT + PIXELIPEPATRAT);
                            if (j == 0)
                                g.DrawLine(new Pen(culoare, 2), (_tabla2.sirPanels[k].coordX + j) * PIXELIPEPATRAT, (_tabla2.sirPanels[k].coordY + i) * PIXELIPEPATRAT, (_tabla2.sirPanels[k].coordX + j) * PIXELIPEPATRAT, (_tabla2.sirPanels[k].coordY + i) * PIXELIPEPATRAT + PIXELIPEPATRAT);
                            if (j == 2)
                                g.DrawLine(new Pen(culoare, 2), (_tabla2.sirPanels[k].coordX + j) * PIXELIPEPATRAT + PIXELIPEPATRAT, (_tabla2.sirPanels[k].coordY + i) * PIXELIPEPATRAT, (_tabla2.sirPanels[k].coordX + j) * PIXELIPEPATRAT + PIXELIPEPATRAT, (_tabla2.sirPanels[k].coordY + i) * PIXELIPEPATRAT + PIXELIPEPATRAT);
                        }
                }
                for (int k = 0; k < 3; k++)
                    for (int i = 0; i < _tabla2.sirPanels[k].OC.inaltime; i++)
                        for (int j = 0; j < _tabla2.sirPanels[k].OC.latime; j++)
                        {
                            if (_tabla2.sirPanels[k].OC.MatriceForma[i, j] == 1)
                                g.FillRectangle(Brushes.Blue, (_tabla2.sirPanels[k].coordX + j) * PIXELIPEPATRAT, (_tabla2.sirPanels[k].coordY + i) * PIXELIPEPATRAT, PIXELIPEPATRAT, PIXELIPEPATRAT); ;
                        }
            }
        }

        private void initializarePanels() //initilalizeaza clickable panels
        {
            Size siz = new Size(PIXELIPEPATRAT * 3, PIXELIPEPATRAT * 4);
            panelPiesa1.Location = new Point(_tabla2.sirPanels[0].coordX * PIXELIPEPATRAT, _tabla2.sirPanels[0].coordY * PIXELIPEPATRAT);
            panelPiesa2.Location = new Point(_tabla2.sirPanels[1].coordX * PIXELIPEPATRAT, _tabla2.sirPanels[1].coordY * PIXELIPEPATRAT);
            panelPiesa3.Location = new Point(_tabla2.sirPanels[2].coordX * PIXELIPEPATRAT, _tabla2.sirPanels[2].coordY * PIXELIPEPATRAT);
            panelPiesa1.Size = panelPiesa2.Size = panelPiesa3.Size = siz;
            panelPiesa1.BackColor = panelPiesa2.BackColor = panelPiesa3.BackColor = Color.FromArgb(25, Color.Black);
        }
        private void panelPiesa1_MouseClick(object sender, MouseEventArgs e)
        {
            //NextPiesa = _tabla2.sirPanels[0].OC;
            try
            {
                StreamWriter scriere = new StreamWriter(DateClient);
                scriere.AutoFlush = true;
                scriere.WriteLine("P" + _tabla2.sirPanels[0].OC.ToString());
                _tabla2.selectat = 0;
                panelAlegere.Invalidate();
            }
            finally { }
        }

        private void panelPiesa2_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                StreamWriter scriere = new StreamWriter(DateClient);
                scriere.AutoFlush = true;
                scriere.WriteLine("P" + _tabla2.sirPanels[1].OC.ToString());
                _tabla2.selectat = 1;
                panelAlegere.Invalidate();
            }
            finally { }
        }

        private void panelPiesa3_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                StreamWriter scriere = new StreamWriter(DateClient);
                scriere.AutoFlush = true;
                scriere.WriteLine("P" + _tabla2.sirPanels[2].OC.ToString());
                _tabla2.selectat = 2;
                panelAlegere.Invalidate();
            }
            finally { }
        }

        public static int getLatime()
        {
            return LATIME;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {

                contor++;
                System.Net.IPAddress ip = System.Net.IPAddress.Parse(textConnect.Text);
                client = new TcpClient(textConnect.Text, 3000);
                DateClient = client.GetStream();
                btnConnect.Enabled = false;
                threadClient = new Thread(new ThreadStart(PrimireDinServer));
                threadClient.Start();
                SetTimer();
                textConnect.Visible = false;
                textConnect.Enabled = false;
                panelTab.Focus();
                btnConnect.Visible = false;
                btnReguli.Visible = false;
               
                if (player == 2)
                {
                    _tabla2 = new TablaAlegere(LATIME_ALEGERE, INALTIME_ALEGERE, PIXELIPEPATRAT);
                    initializarePanels();
                    panelPiesa1.Enabled = panelPiesa2.Enabled = panelPiesa3.Enabled = true;
                    StreamWriter scriere = new StreamWriter(DateClient);
                    scriere.AutoFlush = true;
                    scriere.WriteLine("C");
                }
            }
            catch
            {
                MessageBox.Show("Couldn't connect to server");
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            musicPLY.Volume = trackBar1.Value / 100f;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            panelTab.Focus();
            //this.Select();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(client !=null && client.Connected)
                client.Close();
        }

        private void btnReguli_Click(object sender, EventArgs e)
        {
            MessageBox.Show("How to play \n" +
                "Player 1:\n" +
                "Use arrows to move the piece left/right\n" +
                "Use \"R\" to rotate the piece\n" +
                "Use \"Space\" to instantly place the piece down (this gives 5 points)\n" +
                "For every line complete you get 100 points\n" +
                "Player 2:\n" +
                "Select next piece by pressing on it\n" +
                "You can see the current max height of player 1 on the main board" +
                "The game ends after both players play once","Rules");
        }
    }
}
