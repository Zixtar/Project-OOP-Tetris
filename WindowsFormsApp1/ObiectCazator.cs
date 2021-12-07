using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public enum Forme
    {
        PIESA_O,
        PIESA_T,
        PIESA_S,
        PIESA_Z,
        PIESA_J,
        PIESA_L,
        PIESA_I
    }
    public abstract class ObiectCazator: ICloneable
    {
        public int coordCentruX;
        public int coordCentruY;
        public int latime;
        public int inaltime;
        public int[,] MatriceForma;
        public ObiectCazator Rotire()
        {
            int[,] matrice90Grade = new int[latime, inaltime];
            int continaltime90Grade = 0;
            int contlatime90Grade = 0;
            int continaltimeForma = inaltime - 1;
            int contlatimeForma = 0;
            for (; contlatimeForma < latime; contlatimeForma++, continaltime90Grade++)
            {
                for (; continaltimeForma >= 0; continaltimeForma--, contlatime90Grade++)
                {
                    matrice90Grade[continaltime90Grade, contlatime90Grade] = MatriceForma[continaltimeForma, contlatimeForma];

                }
                contlatime90Grade = 0;
                continaltimeForma = inaltime - 1;
            }
            latime = matrice90Grade.GetLength(1);
            inaltime = matrice90Grade.GetLength(0);
            MatriceForma = new int[matrice90Grade.GetLength(1), matrice90Grade.GetLength(0)];
            MatriceForma = matrice90Grade;
            return this;
        }
        public object Clone()
        {
            return MemberwiseClone();
        }
    }

    public class PiesaO : ObiectCazator
    {

        public PiesaO(int x, int y)
        {
            MatriceForma = new int[,]
            { { 1, 1 },
              { 1, 1 } };
            latime = MatriceForma.GetLength(0);
            inaltime = MatriceForma.GetLength(1);
            coordCentruX = x;
            coordCentruY = y;
        }
        override
        public string ToString()
        {
            return ((int)Forme.PIESA_O).ToString(); 
        }
    }
    public class PiesaT : ObiectCazator
    {
        public PiesaT(int x, int y)
        {
            MatriceForma = new int[,]
            { { 0, 1, 0 },
              { 1, 1, 1 }};
            latime = MatriceForma.GetLength(1);
            inaltime = MatriceForma.GetLength(0);
            coordCentruX = x;
            coordCentruY = y;
        }
        override
        public string ToString()
        {
            return ((int)Forme.PIESA_T).ToString();
        }
    }

    public class PiesaI : ObiectCazator
    {
        public PiesaI(int x, int y)
        {
            MatriceForma = new int[,]
            { { 1 },
              { 1 },
              { 1 },
              { 1 } };
            latime = MatriceForma.GetLength(1);
            inaltime = MatriceForma.GetLength(0);
            coordCentruX = x;
            coordCentruY = y;
        }
        override
        public string ToString()
        {
            return ((int)Forme.PIESA_I).ToString();
        }
    }

    public class PiesaZ : ObiectCazator
    {
        public PiesaZ(int x, int y)
        {
            MatriceForma = new int[,]
            { { 1, 0, 0 },
              { 1, 1, 1 }, };
            latime = MatriceForma.GetLength(1);
            inaltime = MatriceForma.GetLength(0);
            coordCentruX = x;
            coordCentruY = y;
        }
        override
        public string ToString()
        {
            return ((int)Forme.PIESA_Z).ToString();
        }
    }

    public class PiesaS : ObiectCazator
    {
        public PiesaS(int x, int y)
        {
            MatriceForma = new int[,]
            { { 0, 1, 1 },
              { 1, 1, 0 }};
            latime = MatriceForma.GetLength(1);
            inaltime = MatriceForma.GetLength(0);
            coordCentruX = x;
            coordCentruY = y;
        }
        override
        public string ToString()
        {
            return ((int)Forme.PIESA_S).ToString();
        }
    }

    public class PiesaL : ObiectCazator
    {
        public PiesaL(int x, int y)
        {
            MatriceForma = new int[,]
            { { 0, 0, 1 },
              { 1, 1, 1 }};
            latime = MatriceForma.GetLength(1);
            inaltime = MatriceForma.GetLength(0);
            coordCentruX = x;
            coordCentruY = y;
        }
        override
        public string ToString()
        {
            return ((int)Forme.PIESA_L).ToString();
        }
    }

    public class PiesaJ : ObiectCazator
    {
        public PiesaJ(int x, int y)
        {
            MatriceForma = new int[,]
            { { 1, 0, 0 },
              { 1, 1, 1 }};
            latime = MatriceForma.GetLength(1);
            inaltime = MatriceForma.GetLength(0);
            coordCentruX = x;
            coordCentruY = y;
        }
        override
        public string ToString()
        {
            return ((int)Forme.PIESA_J).ToString();
        }
    }
}
