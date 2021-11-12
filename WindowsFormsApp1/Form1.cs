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
            timer.Interval = 500;
            timer.Start();
        }

        private TablaDeJoc _tabla1;
        const int PixeliPePatrat = 16;
        ObiectCazator ObiectCurent;
        private void Form1_Load(object sender, EventArgs e)
        {
            //  BitmapTabla = new Bitmap(picBoxTabla.Width, picBoxTabla.Height);
            panelTabla.Width = 15 * PixeliPePatrat;
            panelTabla.Height = 20 * PixeliPePatrat;
             ObiectCurent = new Patrat(15/2,0);
            _tabla1 = new TablaDeJoc(15, 20);
            _tabla1.ModificareTabla(ObiectCurent.MatriceForma, ObiectCurent.coordCentruX, ObiectCurent.coordCentruY, ObiectCurent.latime, ObiectCurent.inaltime);
        }
       
        private void panelTabla_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for(int i=0;i< _tabla1.Heigth; i++)
                for(int j=0;j<_tabla1.Width;j++)
                    if(_tabla1.MatriceLogicaTablaDeJoc[i,j]==0)
                        g.FillRectangle(Brushes.Purple, j*PixeliPePatrat, i*PixeliPePatrat, PixeliPePatrat, PixeliPePatrat);
                    else
                    {
                        g.FillRectangle(Brushes.Black, j*PixeliPePatrat, i*PixeliPePatrat, PixeliPePatrat, PixeliPePatrat);
                    }
        }

        private void EventTimer(Object Source, EventArgs myEventArgs)
        {
     
            _tabla1.ModificareTabla(ObiectCurent.MatriceForma,ref ObiectCurent.coordCentruX,ref ObiectCurent.coordCentruY, ObiectCurent.latime, ObiectCurent.inaltime,0,1);
  
                panelTabla.Refresh();
        }
    }
}
