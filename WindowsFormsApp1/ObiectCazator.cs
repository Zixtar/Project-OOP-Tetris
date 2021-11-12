using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public abstract class ObiectCazator
    {
        public int coordCentruX;
        public int coordCentruY;
        public int latime;
        public int inaltime;
        public int[,] MatriceForma;
        bool PoateCobori()
        {
            return false;
        }
    }

    public class Patrat : ObiectCazator
    {

        bool PoateCobori()
        {

            return true;
        }
        public Patrat(int x, int y)
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
}
