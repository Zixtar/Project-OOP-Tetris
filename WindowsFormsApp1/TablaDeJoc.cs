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
        // functie pentru miscarea obiectelor pe tabla
        public void ModificareTabla(int[,] Obiect, ref int coordX, ref int coordY, int latimeObiect, int inaltimeObiect, int miscareOrizontala, int miscareVerticala)
        {
            if ((coordX + miscareOrizontala >= 0) && (coordX + miscareOrizontala + latimeObiect <= Width)
                && !CevaMargine(Obiect, coordX, coordY, latimeObiect, inaltimeObiect, miscareOrizontala, miscareVerticala))  // verificare atingere margini
            {
                if ((coordY + inaltimeObiect == Heigth)
                    || CevaSub(Obiect, coordX, coordY, latimeObiect, inaltimeObiect, miscareOrizontala, miscareVerticala)) //verificare conditie de oprire
                {
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
        private void VerificareLiniiComplete()
        {

        }

    }
}
