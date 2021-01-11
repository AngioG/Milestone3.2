using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace funzioni
{
    public struct corso
    {
        public string codice;
        public string nome;
        public string settore;
        public DateTime data;
        public int durata;
        public decimal prezzo;

    }

    public struct dto_corso
    {
        public int n;
        public corso[] elenco;
    }


    class MyLibrary
    {

        public static dto_corso fascia(corso[] elenco, int num, int min, int max)
        {
            dto_corso ele = default;
            ele.elenco = new corso[num];
            int x = 0;
            int n = 0;

            while (x < num)
            {
                if (elenco[x].durata > min && elenco[x].durata < max)
                {
                    ele.elenco[n] = elenco[x];
                    n++;
                }

                x++;
            }

            ele.n = n;

            return ele;
        }

        public static corso prezzoalto(dto_corso ele)
        {
            corso corsoMax = default;
            int x = 0;

            while (x < ele.n)
            {
                if (ele.elenco[x].prezzo > corsoMax.prezzo)
                {
                    corsoMax = ele.elenco[x];
                }

                x++;
            }

            return corsoMax;
        }

        public static bool ControllaCategoria(int num, string[] elenco, string nuovo)
        {
            int x = 0;

            while (x < num)
            {
                if (nuovo == elenco[x])
                {
                    return false;
                }

                x++;
            }


            return true;
        }

        public static dto_corso categoria(int num, corso[] elenco, string categoria)
        {
            int x = 0;
            int n = 0;
            dto_corso ele = default;
            ele.elenco = new corso[num];


            while (x < num)
            {
                if (elenco[x].settore == categoria)
                {
                    ele.elenco[n] = elenco[x];
                    n++;
                }

                x++;
            }

            ele.n = n;

            return ele;
        }

        public static decimal Media(int num, corso[] ele)
        {

            decimal somma = 0;
            int x = 0;

            while (x < num)
            {
                    somma += ele[x].prezzo;

                x++;
            }


            decimal media = somma / x;

            return media;
        }

        public static void SalvaFile(int n, corso[] ele, string pathArchivio)
        {
            int x = 0;
            StreamWriter miofile;

            miofile = new StreamWriter(pathArchivio);

            while (x < n)
            {
                miofile.WriteLine(ele[x].codice);
                miofile.WriteLine(ele[x].nome);
                miofile.WriteLine(ele[x].settore);
                miofile.WriteLine(ele[x].durata);
                miofile.WriteLine(ele[x].data);
                miofile.WriteLine(ele[x].prezzo);

                x += 1;
            }
            miofile.Close();

        }

        public static bool LeggiFile(ref int num, corso[] ele, string pathArchivio)
        {
            if (!File.Exists(pathArchivio))
            {
                return false;
            }

            StreamReader miofile;
            miofile = new StreamReader(pathArchivio);
            corso nuovo = default;

            while (miofile.EndOfStream == false)
            {
                nuovo.codice = miofile.ReadLine();
                nuovo.nome = miofile.ReadLine();
                nuovo.settore = miofile.ReadLine();
                nuovo.durata = int.Parse(miofile.ReadLine());
                nuovo.data = DateTime.Parse(miofile.ReadLine());
                nuovo.prezzo = Decimal.Parse(miofile.ReadLine());

                ele[num] = nuovo;
                num += 1;
            }

            miofile.Close();

            return true;

        }

        public static void Codice(int num, corso[] ele)
        {
            int x = 0;
            
            while (x<num)
            {
                int y = x + 1;

                while(y<num)
                {
                    if(String.Compare(ele[x].codice,ele[y].codice)>0)
                    {
                        corso temp = ele[x];
                        ele[x] = ele[y];
                        ele[y] = temp;
                    }
                    y++;
                }

                x++;
            }

            return;
        }

        public static void Settore(int num, corso[] ele)
        {
            int x = 0;

            while (x < num)
            {
                int y = x + 1;

                while (y < num)
                {
                    if (String.Compare(ele[x].settore, ele[y].settore) > 0)
                    {
                        corso temp = ele[x];
                        ele[x] = ele[y];
                        ele[y] = temp;
                    }
                    y++;
                }

                x++;
            }

            return;
        }


    }

}
