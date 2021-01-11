using System;
using funzioni;

namespace Milestone_3._2_Angioletti
{
    class Program
    {
        

        static void Main(string[] args)
        {

            //Variabili
            corso[] eleCorsi = new corso[1000];
            int num = 0;

            string[] eleCategoria = new string[1000];
            int ncategorie = 0;

            string[] filecaricati = new string[1000];
            int numFile = default;

            bool precaricati = false;

            ConsoleKeyInfo scelta = default;

            do
            {
                Console.Clear();
                Console.WriteLine("|////////////////////////////////////////////////////////|");
                Console.WriteLine("| [1] Aggiungi un nuovo corso                            |");
                Console.WriteLine("| [2] Visualizza tutti i corsi                           |");
                Console.WriteLine("| [3] Elimina i corsi precedenti ad una data             |");
                Console.WriteLine("| [4] Visualizza il corso più breve di un settore        |");
                Console.WriteLine("| [5] Calcola il prezzo medio di tutti i corsi           |");
                Console.WriteLine("| [6] Calcola il prezzo più alto in una fascia di tempo  |");
                Console.WriteLine("| [7] Visualizza i corsi  che partono il prossimo mese   |");
                Console.WriteLine("| [8] Carica i dati da disco                             |");
                Console.WriteLine("| [9] Salva i dati su disco                              |");
                Console.WriteLine("|////////////////////////////////////////////////////////|");
                Console.WriteLine("| [u] Esci senza salvare                                 |");
                Console.WriteLine("|////////////////////////////////////////////////////////|");
                scelta = Console.ReadKey(true);
                Console.Clear();

                switch (scelta.KeyChar.ToString())
                {
                    case "0":
                        {
                            if(precaricati)
                            {
                                Console.WriteLine("Hai già inserito questi prodotti");
                                break;
                            }
                            
                            eleCorsi[num].codice = "C0rs00";
                            eleCorsi[num].nome = "impara c# in 1 ora";
                            eleCorsi[num].settore = "informatica";
                            eleCorsi[num].data = DateTime.Parse("3/12/2020");
                            eleCorsi[num].durata = 1;
                            eleCorsi[num].prezzo = 4.99M;
                            num++;


                            eleCorsi[num].codice = "C0rs01";
                            eleCorsi[num].nome = "corso serio di c#";
                            eleCorsi[num].settore = "informatica";
                            eleCorsi[num].data = DateTime.Parse("25/11/2020");
                            eleCorsi[num].durata = 60;
                            eleCorsi[num].prezzo = 109.99M;
                            num++;

                            eleCorsi[num].codice = "C0rs02";
                            eleCorsi[num].nome = "in cucina con massimo";
                            eleCorsi[num].settore = "cucina";
                            eleCorsi[num].data = DateTime.Parse("01/12/2020");
                            eleCorsi[num].durata = 15;
                            eleCorsi[num].prezzo = 44.99M;
                            num++;


                            eleCorsi[num].codice = "C0rs03";
                            eleCorsi[num].nome = "la cucina del pranzo di natale";
                            eleCorsi[num].settore = "cucina";
                            eleCorsi[num].data = DateTime.Parse("22/12/2020");
                            eleCorsi[num].durata = 3;
                            eleCorsi[num].prezzo = 19.99M;
                            num++;

                            eleCorsi[num].codice = "C0rs04";
                            eleCorsi[num].nome = "Impara a riconoscere i titoli forvianti in sole 3 ore!";
                            eleCorsi[num].settore = "educazione digitale";
                            eleCorsi[num].data = DateTime.Parse("3/12/2020");
                            eleCorsi[num].durata = 3;
                            eleCorsi[num].prezzo = 144.99M;
                            num++;

                            eleCorsi[num].codice = "C0rs05";
                            eleCorsi[num].nome = "Corso di regia e riprese video";
                            eleCorsi[num].settore = "fotografia";
                            eleCorsi[num].data = DateTime.Parse("15/1/2021");
                            eleCorsi[num].durata = 4;
                            eleCorsi[num].prezzo = 69.99M;
                            num++;

                            eleCorsi[num].codice = "C0rs06";
                            eleCorsi[num].nome = "Come cucinare un panino al salame";
                            eleCorsi[num].settore = "cucina";
                            eleCorsi[num].data = DateTime.Parse("27/1/2021");
                            eleCorsi[num].durata = 2;
                            eleCorsi[num].prezzo = 29.99M;
                            num++;

                            bool catEsiste = MyLibrary.ControllaCategoria(ncategorie, eleCategoria, "informatica");
                            if (catEsiste)
                            {
                                eleCategoria[ncategorie] = "informatica";
                                ncategorie++;
                            }

                            catEsiste = MyLibrary.ControllaCategoria(ncategorie, eleCategoria, "cucina");
                            if (catEsiste)
                            {
                                eleCategoria[ncategorie] = "cucina";
                                ncategorie++;
                            }

                            catEsiste = MyLibrary.ControllaCategoria(ncategorie, eleCategoria, "educazione digitale");
                            if (catEsiste)
                            {
                                eleCategoria[ncategorie] = "educazione digitale";
                                ncategorie++;
                            }

                            catEsiste = MyLibrary.ControllaCategoria(ncategorie, eleCategoria, "fotografia");
                            if (catEsiste)
                            {
                                eleCategoria[ncategorie] = "fotografia";
                                ncategorie++;
                            }

                            precaricati = true;

                            break;
                        }
                    
                    
                    case "1":           //Aggiungi corso
                        {
                            if (num >= 950)
                            {
                                Console.WriteLine("Hai inserito troppi corsi!");
                                break;
                            }

                            corso Nuovo = default;

                            bool found = false;
                            int x = 0;
                            Console.Write("Inserisci il codice del corso: ");
                            Nuovo.codice = Console.ReadLine();
                            if(String.IsNullOrWhiteSpace(Nuovo.codice))
                            {
                                Console.WriteLine("Non puoi lasciare il codice vuoto");
                                break;
                            }
                            while(x<num)
                            {
                                if (Nuovo.codice == eleCorsi[x].codice)
                                {
                                    found = true;
                                    break;
                                }

                                x++;
                            }
                            if (found) break;

                            Console.Write("Inserisci il nome del corso: ");
                            Nuovo.nome = Console.ReadLine();
                            if (String.IsNullOrWhiteSpace(Nuovo.nome))
                            {
                                Console.WriteLine("Non puoi lasciare il nome vuoto");
                                break;
                            }

                            Console.Write("Inserisci l'argomento del corso: ");
                            Nuovo.settore = Console.ReadLine();
                            if (String.IsNullOrWhiteSpace(Nuovo.settore))
                            {
                                Console.WriteLine("Non puoi lasciare l'argomento vuoto");
                                break;
                            }
                            

                            Console.Write("Inserisci la data di inizio del corso: ");
                            if (!DateTime.TryParse(Console.ReadLine(), out DateTime provaD))
                            {
                                Console.Write("Devi inserire una data");
                                break;
                            }
                            if (String.IsNullOrWhiteSpace(provaD.ToString()))
                            {
                                Console.WriteLine("Non puoi lasciare la data vuota");
                                break;
                            }
                            Nuovo.data = provaD;

                            Console.Write("Inserisci il numero di ore del corso: ");
                            if (!int.TryParse(Console.ReadLine(), out int provaH))
                            {
                                Console.WriteLine("Devi inserire un numero intero");
                                break;
                            }
                            if (String.IsNullOrWhiteSpace(provaH.ToString()))
                            {
                                Console.WriteLine("Non puoi lasciare la durata vuota");
                                break;
                            }
                            Nuovo.durata = provaH;

                            Console.Write("Inserisci il prezzo del corso: ");
                            if (!Decimal.TryParse(Console.ReadLine(), out Decimal provaP))
                            {
                                Console.WriteLine("Devi inserire una numero");
                                break;
                            }
                            if (String.IsNullOrWhiteSpace(provaP.ToString()))
                            {
                                Console.WriteLine("Non puoi lasciare il prezzo vuoto, se il corso è gratuito scrivi 0");
                                break;
                            }
                            Nuovo.prezzo = provaP;

                            bool catEsiste = MyLibrary.ControllaCategoria(ncategorie, eleCategoria, Nuovo.settore);
                            if (catEsiste)
                            {
                                eleCategoria[ncategorie] = Nuovo.settore;
                                ncategorie++;
                            }

                            eleCorsi[num] = Nuovo;
                            num++;

                            Console.WriteLine("Corso inserito correttamente nell'elenco");

                            break;
                        }


                    case "2":
                        {
                            if (num == 0)
                            {
                                Console.WriteLine("Devi inserire un prodotto");
                                break;
                            }

                            Console.Write("Inserisci settore se vuoi visualizzare i prodotti pe settore o codice se li vuoi visualizzare in ordine di codice:  ");
                            string metodo = Console.ReadLine();

                            if (metodo == "codice")
                                MyLibrary.Codice(num, eleCorsi);

                            if (metodo == "settore")
                                MyLibrary.Settore(num, eleCorsi);

                            if (metodo != "settore " && metodo != "codice")
                                Console.WriteLine("Nessuna scelta valida selesionata");

                            int x = 0;                            

                            Console.WriteLine("Elenco di tutti i corsi\n");
                            Console.WriteLine("////////////////////////////////////////////////////////////////////////////////////////////////////");

                            while (x<num)
                            {
                                Console.WriteLine('\t'+eleCorsi[x].codice);
                                Console.WriteLine($"Il corso: {eleCorsi[x].nome}, che parla di {eleCorsi[x].settore}");
                                Console.WriteLine($"inizia il {eleCorsi[x].data.ToString("dd/MM/yyyy")}, dura {eleCorsi[x].durata} ore e costa {eleCorsi[x].prezzo} euro");
                                Console.WriteLine("////////////////////////////////////////////////////////////////////////////////////////////////////");

                                x += 1;
                            }

                            break;
                        }


                    case "3":
                        {
                            if (num == 0)
                            {
                                Console.Write("Devi inserire un prodotto");
                                break;
                            }

                            int x = 0;
                            int cancellati = 0;

                            Console.WriteLine("Inserisci la data fino a cui eliminare i corsi: ");
                            if (!DateTime.TryParse(Console.ReadLine(), out DateTime provaD))
                            {
                                Console.WriteLine("Devi inserire una data");
                                break;
                            }
                            if (String.IsNullOrWhiteSpace(provaD.ToString()))
                            {
                                Console.WriteLine("devi inserire una data");
                                break;
                            }

                            while (x < num)
                            {
                                if(eleCorsi[x].data < provaD)
                                {
                                    eleCorsi[x] = eleCorsi[num - 1];
                                    num--;
                                    cancellati++;
                                }
                                else
                                    x += 1;
                            }

                            if(ncategorie==0)
                            {
                                Console.WriteLine("Nessun prodotto trovato");
                                break;
                            }

                            Console.WriteLine($"{cancellati} corsi eliminati correttamente");

                            break;
                        }

                    case "4":
                        {
                            if (num == 0)
                            {
                                Console.WriteLine("Devi inserire un prodotto");
                                break;
                            }

                            int y = 0;

                            Console.WriteLine("Categorie dei corsi");
                            while(y < ncategorie)
                            {
                                Console.WriteLine(eleCategoria[y]);

                                y++;
                            }


                            Console.Write("Scegli una categoria da cercare: ");
                            string cerca = Console.ReadLine();

                            dto_corso ele = MyLibrary.categoria(num, eleCorsi, cerca);

                            if (ele.n == 0)
                            {
                                Console.WriteLine($"Nessun corso trovato su {cerca}");
                                break;
                            }

                            int x = 0;
                            decimal min = ele.elenco[x].durata;
                            int pos = default;

                            while(x < ele.n)
                            {
                                if(ele.elenco[x].durata<min)
                                {
                                    min = ele.elenco[x].durata;
                                    pos = x;
                                }

                                x++;
                            }

                            Console.WriteLine($"Il corso {ele.elenco[pos].nome} è il corso più breava su {cerca}, dura {min} ore");

                            break;
                        }


                    case "5":
                        {
                            if (num == 0)
                            {
                                Console.WriteLine("Devi inserire un prodotto");
                                break;
                            }


                            Console.WriteLine("Categorie dei corsi");

                            decimal media = MyLibrary.Media(num, eleCorsi);

                            Console.WriteLine($"La media dei prezzi dei corsi è {media.ToString("0.00")}");

                            break;
                        }


                    case "6":
                        {
                            if (num == 0)
                            {
                                Console.WriteLine("Devi inserire un prodotto");
                                break;
                            }

                            Console.Write("Inserisci l'ora minima: ");
                            if (!int.TryParse(Console.ReadLine(), out int provaM))
                            {
                                Console.WriteLine("Devi inserire una numero intero");
                                break;
                            }
                            if (String.IsNullOrWhiteSpace(provaM.ToString()))
                            {
                                Console.WriteLine("devi inserire una numero intero");
                                break;
                            }
                            int min  = provaM;

                            Console.Write("Inserisci l'ora massima: ");
                            if (!int.TryParse(Console.ReadLine(), out int prova))
                            {
                                Console.WriteLine("Devi inserire una numero intero");
                                break;
                            }
                            if (String.IsNullOrWhiteSpace(prova.ToString()))
                            {
                                Console.WriteLine("devi inserire una numero intero");
                                break;
                            }
                            int max = prova;

                            dto_corso eleT = default;;
                            eleT = MyLibrary.fascia(eleCorsi, num, min, max);

                            if(eleT.n == 0)
                            {
                                Console.WriteLine("Nessun corso trovato");
                                break;
                            }

                            corso maggiore = MyLibrary.prezzoalto(eleT);

                            Console.WriteLine($"Il corso con il prezzo più alto che dura tra le {min} e le {max} ore è {maggiore.nome} che costa {maggiore.prezzo} euro");

                            break;
                        }


                    case "7":
                        {
                            if (num == 0)
                            {
                                Console.WriteLine("Devi inserire un prodotto");
                                break;
                            }

                            int x = 0;
                            bool primo = true;

                            DateTime oggi = DateTime.Today;
                            DateTime compara = oggi.AddMonths(1);

                            while (x < num)
                            {
                                if (eleCorsi[x].data > compara)
                                {
                                    if (primo)
                                    {
                                        Console.WriteLine($"Elenco corsi che partiranno dopo il prossimo mese\n");
                                        Console.WriteLine("////////////////////////////////////////////////////////////////////////////////////////////////////");
                                    }

                                    Console.WriteLine('\t' + eleCorsi[x].codice);
                                    Console.WriteLine($"Il corso: {eleCorsi[x].nome}, che parla di {eleCorsi[x].settore}");
                                    Console.WriteLine($"Il corso inizia il {eleCorsi[x].data.ToString("dd/MM/yyyy")}, dura {eleCorsi[x].durata} ore e costa {eleCorsi[x].prezzo}");
                                    Console.WriteLine("////////////////////////////////////////////////////////////////////////////////////////////////////");
                                }                            

                            x++;
                            }

                        if (primo)
                        {
                            Console.WriteLine("Nessun corso trovato");
                        }

                        break;
                        }


                    case "8":
                        {
                            Console.Write("Inserisci il nome del file da leggere: ");
                            string file = Console.ReadLine() +".txt";
                            int y = num;
                            int b = 0;
                            bool caricato = false;
                            while (b < numFile)
                            {
                                if(filecaricati[b] ==file)
                                {
                                    caricato = true;
                                    break;
                                }
                                b++;
                            }

                            if(caricato)
                            {
                                Console.WriteLine("Hai già inserito i dati da questo file");
                                break;
                            }
                            if (!caricato)
                            {
                                filecaricati[numFile] = file;
                                numFile++;

                            }

                            bool trovato = MyLibrary.LeggiFile(ref num, eleCorsi, file);


                            if (!trovato)          //else
                            {
                                Console.WriteLine("Nessun file trovato");
                                break;
                            }

                            while(y<num)
                            {
                                bool found = MyLibrary.ControllaCategoria(ncategorie, eleCategoria, eleCorsi[y].settore);
                                if (found)
                                {
                                    eleCategoria[ncategorie] = eleCorsi[y].settore;
                                    ncategorie++;
                                }

                                y++;
                            }

                            if(trovato)
                            Console.WriteLine("Informazioni caricate correttamente");


                            break;
                        }


                    case "9":
                        {
                            Console.Write("Inserisci il nome del file: ");
                            string file = Console.ReadLine() + ".txt";

                            MyLibrary.SalvaFile(num, eleCorsi, file);

                            Console.WriteLine("Informazioni salvate correttamente");

                            break;
                        }


                    case "u":           //esci
                        { return; }


                    default:            //comando errato
                        {
                            Console.WriteLine("Hai inserito un comando non valido");
                            break;
                        }
                }


                Console.WriteLine("Premi un tasto per continuare");
                Console.ReadKey(true);

            } while (scelta.KeyChar.ToString() != "u");

        }
    }
}
