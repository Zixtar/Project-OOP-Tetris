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
        public Form1()
        {
            InitializeComponent();
            SetTimer();

        }

        void SetTimer()
        {
            timer.Tick += EventTimer;
            timer.Interval = 200;
            timer.Start();
        }

        private TablaDeJoc _tabla1;
        const int PIXELIPEPATRAT = 18;
        const int LATIME = 10;
        const int INALTIME = 20;
        ObiectCazator ObiectCurent;
        private void Form1_Load(object sender, EventArgs e)
        {
            //  BitmapTabla = new Bitmap(picBoxTabla.Width, picBoxTabla.Height);
            panelTabla.Width = LATIME * PIXELIPEPATRAT;
            panelTabla.Height = INALTIME * PIXELIPEPATRAT;
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
            if (!_tabla1.arePiesa)  // daca nu sunt piese active se spawneaza unul de tip random
            {
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
                if (_tabla1.PiesaAreLoc(ObiectCurent))
                    _tabla1.ModificareTabla(ObiectCurent.MatriceForma, ObiectCurent.coordCentruX, ObiectCurent.coordCentruY, ObiectCurent.latime, ObiectCurent.inaltime);
                else
                    _tabla1.CurataTabla();
            }
            else
                _tabla1.ModificareTabla(ObiectCurent.MatriceForma, ref ObiectCurent.coordCentruX, ref ObiectCurent.coordCentruY, ObiectCurent.latime, ObiectCurent.inaltime, 0, 1);

            panelTabla.Refresh();
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
                    while(_tabla1.arePiesa)
                        _tabla1.ModificareTabla(ObiectCurent.MatriceForma, ref ObiectCurent.coordCentruX, ref ObiectCurent.coordCentruY, ObiectCurent.latime, ObiectCurent.inaltime, 0, 1);
                if (e.KeyCode == Keys.R)
                {
                    _tabla1.Rotire(ObiectCurent); 
                }
                panelTabla.Refresh();
            }
        }
    }
}
