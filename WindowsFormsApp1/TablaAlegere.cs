using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{

    class SelectablePanel : Panel
    {
        public SelectablePanel()
        {
            this.SetStyle(ControlStyles.Selectable, true);
            this.TabStop = true;
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            this.Focus();
            base.OnMouseDown(e);
        }
        protected override bool IsInputKey(Keys keyData)
        {
            if (keyData == Keys.Up || keyData == Keys.Down) return true;
            if (keyData == Keys.Left || keyData == Keys.Right) return true;
            return base.IsInputKey(keyData);
        }
        protected override void OnEnter(EventArgs e)
        {
            this.Invalidate();
            base.OnEnter(e);
        }
        protected override void OnLeave(EventArgs e)
        {
            this.Invalidate();
            base.OnLeave(e);
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            if (this.Focused)
            {
                var rc = this.ClientRectangle;
                rc.Inflate(-2, -2);
                ControlPaint.DrawFocusRectangle(pe.Graphics, rc);
            }
        }
    }

    class TablaAlegere
    {
        public panelPiesa[] sirPanels = new panelPiesa[3];
        public int Width;
        public int Heigth;
        public struct panelPiesa 
        {
            public int coordX;
            public int coordY;
            public ObiectCazator OC; 
        };
        int PIXELIPEPATRAT;
        public TablaAlegere(int Inaltime,int Latime,int pixeli)
        {
            Width = Latime;
            Heigth = Inaltime;
            PIXELIPEPATRAT = pixeli;
            sirPanels[0].coordX = 1;
            sirPanels[1].coordX = 5;
            sirPanels[2].coordX = 9;
            for(int i=0;i<sirPanels.Length;i++)
                sirPanels[i].coordY = 3;
            PieseRandom();
        }
        public void PieseRandom()
        {
             Random rnd = new Random();
            for(int i = 0; i < 3; i++) 
            { 
                int rndAlegereObiect = rnd.Next(0, 7);
                switch (rndAlegereObiect)
                {
                    case (int)Forme.PIESA_O:
                        sirPanels[i].OC = new PiesaO(10 / 2, 0);
                        break;
                    case (int)Forme.PIESA_T:
                        sirPanels[i].OC = new PiesaT(10 / 2, 0);
                        break;
                    case (int)Forme.PIESA_S:
                        sirPanels[i].OC = new PiesaS(10 / 2, 0);
                        break;
                    case (int)Forme.PIESA_Z:
                        sirPanels[i].OC = new PiesaZ(10 / 2, 0);
                        break;
                    case (int)Forme.PIESA_J:
                        sirPanels[i].OC = new PiesaJ(10 / 2, 0);
                        break;
                    case (int)Forme.PIESA_L:
                        sirPanels[i].OC = new PiesaL(10 / 2, 0);
                        break;
                    case (int)Forme.PIESA_I:
                        sirPanels[i].OC = new PiesaI(10 / 2, 0);
                        break;
                }
            }
        }
    }
}
