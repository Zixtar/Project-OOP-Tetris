using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class TablaDeJoc
    {
        public
        int Width;
        public int Heigth;
        public int[,] MatriceLogicaTablaDeJoc;
        public bool arePiesa;
        public
        
        TablaDeJoc(int Latime, int Inaltime)
        {
            Width = Latime;
            Heigth = Inaltime;
            MatriceLogicaTablaDeJoc = new int[Heigth, Width];
        }

        public void ModificareTabla(int[,] Obiect,ref int coordX,ref int coordY, int latimeObiect, int inaltimeObiect, int miscareOrizontala, int miscareVerticala)
        {
            StergereObiect(Obiect, coordX, coordY, latimeObiect, inaltimeObiect);
            for (int i = coordY; i < coordY + inaltimeObiect; i++)
                for (int j = coordX; j < coordX + latimeObiect; j++) {
                    var tempX = i - coordY;
                    var tempY = j - coordX;
                    MatriceLogicaTablaDeJoc[i + miscareVerticala, j + miscareOrizontala] = Obiect[tempX, tempY]; ;
                }
            coordX += miscareOrizontala;
            coordY += miscareVerticala;
        }

        public void ModificareTabla(int[,] Obiect, int coordX, int coordY, int latimeObiect, int inaltimeObiect)
        {
            for (int i = coordY; i < coordY + inaltimeObiect; i++)
            {
                for (int j = coordX; j < coordX + latimeObiect; j++)
                {
                    var tempX = i - coordY;
                    var tempY = j - coordX;
                    MatriceLogicaTablaDeJoc[i, j] = Obiect[tempX, tempY];
                }
            }
        }

        private void StergereObiect(int[,] Obiect, int coordX, int coordY, int latimeObiect, int inaltimeObiect)
        {
            for (int i = coordY; i < coordY +inaltimeObiect; i++)
                for (int j = coordX; j < coordX + latimeObiect; j++)
                    MatriceLogicaTablaDeJoc[i, j] = 0;
        }
        private void VerificareLiniiComplete()
        {

        }

    }
}
