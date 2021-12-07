using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
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
