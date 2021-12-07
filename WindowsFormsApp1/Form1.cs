using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        Timer timer = new Timer();
        int player = 1;
        public Form1()
        {
            InitializeComponent();
            SetTimer();

        }

        void SetTimer()
        {
            timer.Tick += EventTimer;
            timer.Interval = 500;
            timer.Start();
        }

        private TablaDeJoc _tabla1;
        const int PIXELIPEPATRAT = 18;
        const int LATIME = 10;
        const int INALTIME = 20;
        const int LATIME_ALEGERE = 13;
        const int INALTIME_ALEGERE = 8;
        private TablaAlegere _tabla2;
        ObiectCazator ObiectCurent;
        ObiectCazator NextPiesa = null;
        private void Form1_Load(object sender, EventArgs e)
        {
            //  BitmapTabla = new Bitmap(picBoxTabla.Width, picBoxTabla.Height);
            panelTabla.Width = LATIME * PIXELIPEPATRAT;
            panelTabla.Height = INALTIME * PIXELIPEPATRAT;
            panelAlegere.Width = LATIME_ALEGERE * PIXELIPEPATRAT;
            panelAlegere.Height = INALTIME_ALEGERE * PIXELIPEPATRAT;
            _tabla2 = new TablaAlegere(LATIME_ALEGERE, INALTIME_ALEGERE, PIXELIPEPATRAT);
            initializarePanels();
            _tabla1 = new TablaDeJoc(LATIME, INALTIME);
        }

        private void panelTabla_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int i = 0; i < _tabla1.Heigth; i++)
                for (int j = 0; j < _tabla1.Width; j++)
                    if (_tabla1.MatriceLogicaTablaDeJoc[i, j] == 0)
                        g.FillRectangle(Brushes.MediumOrchid, j * PIXELIPEPATRAT, i * PIXELIPEPATRAT, PIXELIPEPATRAT, PIXELIPEPATRAT);
                    else
                    {
                        g.FillRectangle(Brushes.Black, j * PIXELIPEPATRAT, i * PIXELIPEPATRAT, PIXELIPEPATRAT, PIXELIPEPATRAT);
                    }
        }

        private void EventTimer(Object Source, EventArgs myEventArgs)
        {
            if (player == 1)
            {
                if (!_tabla1.arePiesa)  // daca nu sunt piese active se spawneaza unul de tip random
                {
                    if(NextPiesa == null)
                    {

                    _tabla2.PieseRandom();
                    Random rnd = new Random();
                    int rndAlegereObiect = rnd.Next(0, 7);
                    switch (rndAlegereObiect)
                    {
                        case (int)Forme.PIESA_O:
                            ObiectCurent = new PiesaO(LATIME / 2, 0);
                            break;
                        case (int)Forme.PIESA_T:
                            ObiectCurent = new PiesaT(LATIME / 2, 0);
                            break;
                        case (int)Forme.PIESA_S:
                            ObiectCurent = new PiesaS(LATIME / 2, 0);
                            break;
                        case (int)Forme.PIESA_Z:
                            ObiectCurent = new PiesaZ(LATIME / 2, 0);
                            break;
                        case (int)Forme.PIESA_J:
                            ObiectCurent = new PiesaJ(LATIME / 2, 0);
                            break;
                        case (int)Forme.PIESA_L:
                            ObiectCurent = new PiesaL(LATIME / 2, 0);
                            break;
                        case (int)Forme.PIESA_I:
                            ObiectCurent = new PiesaI(LATIME / 2, 0);
                            break;
                    }
                    }else
                    {
                        ObiectCurent = (ObiectCazator)NextPiesa.Clone();
                        _tabla2.PieseRandom();
                        NextPiesa = null;
                    }
                    if (_tabla1.PiesaAreLoc(ObiectCurent))
                        _tabla1.ModificareTabla(ObiectCurent.MatriceForma, ObiectCurent.coordCentruX, ObiectCurent.coordCentruY, ObiectCurent.latime, ObiectCurent.inaltime);
                    else
                        _tabla1.CurataTabla();
                    panelAlegere.Refresh();
                }
                else
                    _tabla1.ModificareTabla(ObiectCurent.MatriceForma, ref ObiectCurent.coordCentruX, ref ObiectCurent.coordCentruY, ObiectCurent.latime, ObiectCurent.inaltime, 0, 1);

                panelTabla.Refresh();
            }

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
                    while (_tabla1.arePiesa)
                        _tabla1.ModificareTabla(ObiectCurent.MatriceForma, ref ObiectCurent.coordCentruX, ref ObiectCurent.coordCentruY, ObiectCurent.latime, ObiectCurent.inaltime, 0, 1);
                if (e.KeyCode == Keys.R)
                {
                    _tabla1.Rotire(ObiectCurent);
                }
                panelTabla.Refresh();
            }
        }

        private void panelAlegere_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int k = 0; k < 3; k++)
                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 3; j++)
                    {
                        g.FillRectangle(Brushes.White, (_tabla2.sirPanels[k].coordX + j) * PIXELIPEPATRAT, (_tabla2.sirPanels[k].coordY + i) * PIXELIPEPATRAT, PIXELIPEPATRAT, PIXELIPEPATRAT);
                        if (i == 0)
                            g.DrawLine(new Pen(Color.Gray, 2), (_tabla2.sirPanels[k].coordX + j) * PIXELIPEPATRAT, (_tabla2.sirPanels[k].coordY + i) * PIXELIPEPATRAT, (_tabla2.sirPanels[k].coordX + j) * PIXELIPEPATRAT + PIXELIPEPATRAT, (_tabla2.sirPanels[k].coordY + i) * PIXELIPEPATRAT);
                        if (i == 3)
                            g.DrawLine(new Pen(Color.Gray, 2), (_tabla2.sirPanels[k].coordX + j) * PIXELIPEPATRAT, (_tabla2.sirPanels[k].coordY + i) * PIXELIPEPATRAT + PIXELIPEPATRAT, (_tabla2.sirPanels[k].coordX + j) * PIXELIPEPATRAT + PIXELIPEPATRAT, (_tabla2.sirPanels[k].coordY + i) * PIXELIPEPATRAT + PIXELIPEPATRAT);
                        if (j == 0)
                            g.DrawLine(new Pen(Color.Gray, 2), (_tabla2.sirPanels[k].coordX + j) * PIXELIPEPATRAT, (_tabla2.sirPanels[k].coordY + i) * PIXELIPEPATRAT, (_tabla2.sirPanels[k].coordX + j) * PIXELIPEPATRAT, (_tabla2.sirPanels[k].coordY + i) * PIXELIPEPATRAT + PIXELIPEPATRAT);
                        if (j == 2)
                            g.DrawLine(new Pen(Color.Gray, 2), (_tabla2.sirPanels[k].coordX + j) * PIXELIPEPATRAT + PIXELIPEPATRAT, (_tabla2.sirPanels[k].coordY + i) * PIXELIPEPATRAT, (_tabla2.sirPanels[k].coordX + j) * PIXELIPEPATRAT + PIXELIPEPATRAT, (_tabla2.sirPanels[k].coordY + i) * PIXELIPEPATRAT + PIXELIPEPATRAT);
                    }
            for (int k = 0; k < 3; k++)
                for (int i = 0; i < _tabla2.sirPanels[k].OC.inaltime; i++)
                    for (int j = 0; j < _tabla2.sirPanels[k].OC.latime; j++)
                    {
                        if (_tabla2.sirPanels[k].OC.MatriceForma[i, j] == 1)
                            g.FillRectangle(Brushes.Blue, (_tabla2.sirPanels[k].coordX + j) * PIXELIPEPATRAT, (_tabla2.sirPanels[k].coordY + i) * PIXELIPEPATRAT, PIXELIPEPATRAT, PIXELIPEPATRAT); ;
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
            NextPiesa = _tabla2.sirPanels[0].OC;
        }

        private void panelPiesa2_MouseClick(object sender, MouseEventArgs e)
        {
            NextPiesa = _tabla2.sirPanels[1].OC;
        }

        private void panelPiesa3_MouseClick(object sender, MouseEventArgs e)
        {
            NextPiesa = _tabla2.sirPanels[2].OC;
        }

        public static int getLatime()
        {
            return LATIME;
        }
    }
}
