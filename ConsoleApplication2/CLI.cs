using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace ConsoleApplication2
{
    public class CLI
    {
        private Dictionary<int, Kontener> listaKontenerow;
        private Dictionary<string, Statek> listaStatkow;

        public CLI()
        {
            listaKontenerow = new Dictionary<int, Kontener>();
            listaStatkow = new Dictionary<string, Statek>();
            while (true)
            {
                Commands();
            }
        }

        private void Commands()
        {
            while (true)
            {
                Menu();
                string res = ReadLine();
                switch (res)
                {
                    case "Exit":
                        Environment.Exit(1);
                        break;
                    case "0":
                        Environment.Exit(1);
                        break;
                    case "Dodaj kontenerowiec":
                        AddShip();
                        break;
                    case "1":
                        AddShip();
                        break;
                    case "Usun kontenerowiec":
                        RemoveShip();
                        break;
                    case "2":
                        RemoveShip();
                        break;
                    case "Dodaj Kontener":
                        AddContainer();
                        break;
                    case "3":
                        AddContainer();
                        break;
                    case "Usun Kontener":
                        RemoveContainer();
                        break;
                    case "4":
                        RemoveContainer();
                        break;
                    case "Zaladuj Kontener":
                        LoadContainer();
                        break;
                    case "5":
                        LoadContainer();
                        break;
                    case "Wyladuj Kontener":
                        UnloadContainer();
                        break;
                    case "6":
                        UnloadContainer();
                        break;
                    case "Zaladuj Kontener na statek":
                        LoadContainerOnShip();
                        break;
                    case "7":
                        LoadContainerOnShip();
                        break;
                    case "Zobacz kontynery na statku":
                        ShowContainersOnShip();
                        break;
                    case "8":
                        ShowContainersOnShip();
                        break;
                    default:
                        WriteLine("Bledne polecenie");
                        break;
                }
            }
        }

        public void Menu()
        {
            WriteLine("\nLista kontenerowcow: \n");
            if (ListaStatkow.Any())
            {
                foreach (var statek in ListaStatkow)
                {
                    WriteLine(statek);
                }

                WriteLine("\n");
            }
            else
            {
                WriteLine("Brak \n");
            }

            WriteLine("Lista kontenrow: \n");
            if (ListaKontenerow.Any())
            {
                foreach (var k in Kontener.DictOfCon.Values)
                {
                    WriteLine(k);
                    WriteLine("-------------");
                }

                WriteLine("\n");
            }
            else
            {
                WriteLine("Brak \n");
            }

            WriteLine(
                "Możliwe akcje: " +
                "\n0. Exit" +
                "\n1. Dodaj kontenerowiec" +
                "\n2. Usun kontenerowiec " +
                "\n3. Dodaj Kontener " +
                "\n4. Usun Kontener " +
                "\n5. Zaladuj Kontener " +
                "\n6. Wyladuj Kontener " +
                "\n7. Zaladuj Kontener na statek " +
                "\n8. Zobacz kontynery na statku ");
            {
            }
        }

        private void AddShip()
        {
            WriteLine("Podaj nazwę statku");
            string name = ReadLine();
            WriteLine("Podaj max udziwg");
            double maxU = Convert.ToDouble(ReadLine());
            WriteLine("Podaj predkosc");
            double speed = Convert.ToDouble(ReadLine());
            ListaStatkow.Add(name, new Statek(name, maxU, speed));
            WriteLine($"Dodano statek {name}\n");
        }

        private void RemoveShip()
        {
            Statek s = FindShip("do usunieca");
            if (s == null)
            {
                return;
            }

            ListaStatkow.Remove(s.Nazwa);
            WriteLine($"Usunieto Statek {s.Nazwa}");
        }

        private void AddContainer()
        {
            int con = 0;
            while (true)
            {
                WriteLine("Jaki ma byc rodzaj kontenera: C G L ?");
                string res = ReadLine();
                switch (res.ToUpper())
                {
                    case "L":
                        con = 1;
                        break;
                    case "G":
                        con = 2;
                        break;
                    case "C":
                        con = 3;
                        break;
                    default:
                        WriteLine("Bledne polecenie ");
                        break;
                }

                if (con > 0)
                {
                    break;
                }
            }

            WriteLine("Podaj wysokosc kontenera ");
            double wys = Convert.ToDouble(ReadLine());
            WriteLine("Podaj wage ");
            double waga = Convert.ToDouble(ReadLine());
            WriteLine("Podaj glebokosc ");
            double gleb = Convert.ToDouble(ReadLine());
            WriteLine("Podaj maksymalna ladownosc ");
            double lad = Convert.ToDouble(ReadLine());

            switch (con)
            {
                case 1:
                    bool czy = YesOrNo("Czy ładunek ma byc niebezpieczny?");
                    KontenerL kontenerL = new KontenerL(wys, waga, gleb, lad, czy);
                    ListaKontenerow.Add(kontenerL.Id, kontenerL);
                    WriteLine($"Dodano kontener {kontenerL.Nazwa}");
                    break;
                case 2:
                    WriteLine("Podaj atmosfery kontenera");
                    int atm = (int)Convert.ToDouble(ReadLine());
                    KontenerG kontenerG = new KontenerG(wys, waga, gleb, lad, atm);
                    ListaKontenerow.Add(kontenerG.Id, kontenerG);
                    WriteLine($"Dodano kontener {kontenerG.Nazwa}");
                    break;
                case 3:
                    WriteLine("Podaj typ produktow do kontenera");
                    string typ = ReadLine();
                    WriteLine("Podaj temperature kontenera");
                    double temp = Convert.ToDouble(ReadLine());
                    KontenerC kontenerC = new KontenerC(wys, waga, gleb, lad, typ, temp);
                    ListaKontenerow.Add(kontenerC.Id, kontenerC);
                    WriteLine($"Dodano kontener {kontenerC.Nazwa}");
                    break;
            }
        }

        private void RemoveContainer()
        {
            WriteLine("Podaj id kontenera jaki chcesz usunac ");
            int id = (int)Convert.ToDouble(ReadLine());
            if (ListaKontenerow.ContainsKey(id))
            {
                WriteLine($"Usunieto kontener {ListaKontenerow[id].Nazwa}");
                ListaKontenerow.Remove(id);
            }
            else
            {
                WriteLine($"Brak kontenera o id {id}");
            }
        }

        private void LoadContainer()
        {
            Kontener k = FindContainer();
            if (k == null)
            {
                return;
            }

            WriteLine(
                $"Podaj wartosc jaka zaladowac do {k.Nazwa}," +
                $" obecnie ladunek wynosi {k.MasaLadunku} a limit to {k.MaxLadownosc}");

            int v = (int)Convert.ToDouble(ReadLine());
            k.Zaladowanie(v);
            Kontener.DictOfCon[k.Id] = k;
        }

        private void UnloadContainer()
        {
            Kontener k = FindContainer();
            if (k == null)
            {
                return;
            }

            k.Oproznienie();
            WriteLine($"Oprozniono Kontener {k.Nazwa}");
        }

        private void LoadContainerOnShip()
        {
            Statek s = FindShip("na ktory chcesz zaladowac kontener");
            Kontener k = FindContainer();
            if (k == null || s == null)
            {
                return;
            }

            s.PutContanair(k);
            WriteLine($"Na statek {s.Nazwa} zaladowano {k.Nazwa}");
        }

        private void ShowContainersOnShip()
        {
            Statek s = FindShip(" ");
            if (s == null)
            {
                return;
            }

            WriteLine($"Ladunek Statku {s.Nazwa}");
            foreach (var v in s.Kontynery)
            {
                WriteLine(v.Nazwa);
            }

            WriteLine();
        }

        private Kontener FindContainer()
        {
            WriteLine("Podaj id kontenera który chce zaladowac, dostepne to: ");
            foreach (var val in Kontener.DictOfCon.Values)
            {
                WriteLine(val.Nazwa);
            }

            int id = (int)Convert.ToDouble(ReadLine());
            if (!Kontener.DictOfCon.ContainsKey(id))
            {
                WriteLine($"Brak kontenera o id: {id}");
                return null;
            }

            WriteLine();
            return Kontener.DictOfCon[id];
        }

        private Statek FindShip(string s)
        {
            WriteLine("Podaj nazwe statku " + s);
            string name = ReadLine();
            if (ListaStatkow.ContainsKey(name))
            {
                return ListaStatkow[name];
            }
            else
            {
                WriteLine($"Brak statku {name}");
                return null;
            }
        }

        private bool YesOrNo(string s)
        {
            while (true)
            {
                WriteLine(s);
                string res = ReadLine();
                if (res.ToLower().Equals("tak")) return true;
                else if (res.ToLower().Equals("nie")) return false;
                else
                {
                    WriteLine("Nieprawidlowe polecenie, prosze podaj jeszcze raz");
                }
            }
        }

        public Dictionary<int, Kontener> ListaKontenerow
        {
            get => listaKontenerow;
            set => listaKontenerow = value;
        }

        public Dictionary<string, Statek> ListaStatkow
        {
            get => listaStatkow;
            set => listaStatkow = value;
        }
    }
}