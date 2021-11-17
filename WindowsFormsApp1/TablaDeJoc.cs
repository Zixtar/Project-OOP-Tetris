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
        private int[,] RandComplet;
        public

        TablaDeJoc(int Latime, int Inaltime)
        {
            Width = Latime;
            Heigth = Inaltime;
            MatriceLogicaTablaDeJoc = new int[Heigth, Width];
            RandComplet = new int[1, Width];
            for (int i = 0; i < Width; i++)
            {
                RandComplet[0, i] = 1;
            }
        }
        // functie pentru miscarea obiectelor pe tabla
        public void ModificareTabla(int[,] Obiect, ref int coordX, ref int coordY, int latimeObiect, int inaltimeObiect, int miscareOrizontala, int miscareVerticala)
        {
            if ((coordX + miscareOrizontala >= 0) && (coordX + miscareOrizontala + latimeObiect <= Width)
                && !CevaMargine(Obiect, coordX, coordY, latimeObiect, inaltimeObiect, miscareOrizontala, miscareVerticala))  // verificare atingere margini
            {
                if (((coordY + inaltimeObiect == Heigth) && miscareVerticala > 0)
                    || CevaSub(Obiect, coordX, coordY, latimeObiect, inaltimeObiect, miscareOrizontala, miscareVerticala)) //verificare conditie de oprire
                {
                    VerificareLiniiComplete(coordY, inaltimeObiect);
                    arePiesa = false;
                }
                else
                {
                    StergereObiect(Obiect, coordX, coordY, latimeObiect, inaltimeObiect);
                    for (int i = coordY; i < coordY + inaltimeObiect; i++) //desenare obiect in noua pozitie
                        for (int j = coordX; j < coordX + latimeObiect; j++)
                        {
                            var tempX = j - coordX;
                            var tempY = i - coordY;
                            if (Obiect[tempY, tempX] == 1)//pentru a nu sterge puncte deja puse pe tabla
                                MatriceLogicaTablaDeJoc[i + miscareVerticala, j + miscareOrizontala] = 1;
                        }
                    coordX += miscareOrizontala;
                    coordY += miscareVerticala;
                }
            }
        }
        //functie pentru spawnare de obiecte pe tabla
        public void ModificareTabla(int[,] Obiect, int coordX, int coordY, int latimeObiect, int inaltimeObiect)
        {
            for (int i = coordY; i < coordY + inaltimeObiect; i++)
            {
                for (int j = coordX; j < coordX + latimeObiect; j++)
                {
                    var tempX = j - coordX;
                    var tempY = i - coordY;
                    if (Obiect[tempY, tempX] == 1)//pentru a nu sterge puncte deja puse pe tabla
                        MatriceLogicaTablaDeJoc[i, j] = 1;
                }
            }
            arePiesa = true;
        }

        public void Rotire(ObiectCazator obiect)
        {
            if (VerificareRotire(obiect))
            {
                StergereObiect(obiect.MatriceForma, obiect.coordCentruX, obiect.coordCentruY, obiect.latime, obiect.inaltime);
                obiect = obiect.Rotire();
                ModificareTabla(obiect.MatriceForma, obiect.coordCentruX, obiect.coordCentruY, obiect.latime, obiect.inaltime);
            }
        }

        private bool CevaMargine(int[,] Obiect, int coordX, int coordY, int latimeObiect, int inaltimeObiect, int miscareOrizontala, int miscareVerticala)
        {
            if (miscareOrizontala == 0)
                return false;
            StergereObiect(Obiect, coordX, coordY, latimeObiect, inaltimeObiect); // stergem obiectul pentru a putea compara tabla cu pozitia viitoare a obiectului
                                                                                  // fara ca obiectul sa interactioneze cu el insusi in timpul comparatiei
            for (int i = coordY; i < coordY + inaltimeObiect; i++)
            {
                for (int j = coordX; j < coordX + latimeObiect; j++)
                {
                    var tempX = j - coordX;
                    var tempY = i - coordY;
                    if ((MatriceLogicaTablaDeJoc[i, j + miscareOrizontala] == 1) && (Obiect[tempY, tempX] == 1))
                    {
                        ModificareTabla(Obiect, coordX, coordY, latimeObiect, inaltimeObiect);
                        return true;
                    }
                }
            }
            ModificareTabla(Obiect, coordX, coordY, latimeObiect, inaltimeObiect);
            return false;
        }
        //functie ce verifica daca se afla ceva sub obiectul ce vrea sa se mute
        private bool CevaSub(int[,] Obiect, int coordX, int coordY, int latimeObiect, int inaltimeObiect, int miscareOrizontala, int miscareVerticala)
        {
            StergereObiect(Obiect, coordX, coordY, latimeObiect, inaltimeObiect); // stergem obiectul pentru a putea compara tabla cu pozitia viitoare a obiectului
                                                                                  // fara ca obiectul sa interactioneze cu el insusi in timpul comparatiei
            for (int i = coordY; i < coordY + inaltimeObiect; i++)
            {
                for (int j = coordX; j < coordX + latimeObiect; j++)
                {
                    var tempX = j - coordX;
                    var tempY = i - coordY;
                    if ((MatriceLogicaTablaDeJoc[i + miscareVerticala, j + miscareOrizontala] == 1) && (Obiect[tempY, tempX] == 1))
                    {
                        ModificareTabla(Obiect, coordX, coordY, latimeObiect, inaltimeObiect);
                        return true;
                    }
                }
            }
            ModificareTabla(Obiect, coordX, coordY, latimeObiect, inaltimeObiect);
            return false;
        }

        private bool VerificareRotire(ObiectCazator obiect)
        {
            ObiectCazator obiect2 = (ObiectCazator)obiect.Clone();
            obiect2.Rotire();
            if (obiect2.coordCentruX + obiect2.latime > Width
            || obiect2.coordCentruY + obiect2.inaltime > Heigth)
                return false;
            StergereObiect(obiect.MatriceForma, obiect.coordCentruX, obiect.coordCentruY, obiect.latime, obiect.inaltime);
            for (int i=obiect2.coordCentruY;i<obiect2.coordCentruY+obiect2.inaltime;i++)
            {
                for(int j=obiect2.coordCentruX;j<obiect2.coordCentruX+obiect2.latime;j++)
                {
                    var tempX = j - obiect2.coordCentruX;
                    var tempY = i - obiect2.coordCentruY;
                    if (obiect2.MatriceForma[tempY, tempX] == 1 && MatriceLogicaTablaDeJoc[i, j] == 1)
                    {
                        ModificareTabla(obiect.MatriceForma, obiect.coordCentruX, obiect.coordCentruY, obiect.latime, obiect.inaltime);
                        return false;
                    }
                }
            }
            ModificareTabla(obiect.MatriceForma, obiect.coordCentruX, obiect.coordCentruY, obiect.latime, obiect.inaltime);
            return true;
        }
        private void StergereObiect(int[,] Obiect, int coordX, int coordY, int latimeObiect, int inaltimeObiect)
        {
            for (int i = coordY; i < coordY + inaltimeObiect; i++)
                for (int j = coordX; j < coordX + latimeObiect; j++)
                {
                    var tempX = j - coordX;
                    var tempY = i - coordY;
                    if (Obiect[tempY, tempX] == 1)//pentru a nu sterge puncte deja puse pe tabla ce nu au legatura cu obiectul
                        MatriceLogicaTablaDeJoc[i, j] = 0;
                }
        }
        private void VerificareLiniiComplete(int coordY, int inaltimeObiect)
        {
            int[] randurieliminate = new int[inaltimeObiect];
            for (int i = coordY; i < inaltimeObiect + coordY; i++)
            {
                bool complet = true;

                for (int j = 0; j < Width; j++)
                    if (MatriceLogicaTablaDeJoc[i, j] == 0)
                    {
                        complet = false;
                        break;
                    }
                if (complet)
                {
                    randurieliminate[i - coordY] = 1;
                    StergereObiect(RandComplet, 0, i, RandComplet.Length, 1);
                    CoborareRanduri(i, 1);
                }
            }

        }
        private void CoborareRanduri(int coordY, int nrRanduri)
        {
            for (int i = coordY; i > 0; i--)
                for (int j = 0; j < Width; j++)
                    MatriceLogicaTablaDeJoc[i, j] = MatriceLogicaTablaDeJoc[i - nrRanduri, j];
            for (int i = 0; i < nrRanduri; i++)
                for (int j = 0; j < Width; j++)
                    MatriceLogicaTablaDeJoc[i, j] = 0;
        }
        public void CurataTabla()
        {
            MatriceLogicaTablaDeJoc = new int[Heigth, Width];
        }

        public bool PiesaAreLoc(ObiectCazator obiect)
        {
            for (int i = obiect.coordCentruY; i < obiect.coordCentruY + obiect.inaltime; i++)
            {
                for (int j = obiect.coordCentruX; j < obiect.coordCentruX + obiect.latime; j++)
                {
                    var tempX = j - obiect.coordCentruX;
                    var tempY = i - obiect.coordCentruY;
                    if (obiect.MatriceForma[tempY, tempX] == 1 && MatriceLogicaTablaDeJoc[i, j] == 1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
