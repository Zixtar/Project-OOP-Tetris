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
    public abstract class ObiectCazator
    {
        public int coordCentruX;
        public int coordCentruY;
        public int latime;
        public int inaltime;
        public int[,] MatriceForma;
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
    }
}
