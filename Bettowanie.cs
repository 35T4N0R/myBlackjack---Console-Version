using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasyno___KCK
{
    class Bettowanie
    {
        public double saldo;
        public Bettowanie()
        {
            Random rnd = new Random();
            int liczba = rnd.Next(1000, 50000) / 100;
            saldo = liczba * 100;
        }

        public int betuj()
        {
            
            Console.SetCursorPosition(1, 10);
            Console.Write(" - - - - - - - - - - ");
            Console.SetCursorPosition(1, 11);
            Console.Write("|    Twoje saldo:   |");
            Console.SetCursorPosition(1, 13);
            Console.Write("|");
            Console.SetCursorPosition(7, 13);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(saldo);
            Console.ResetColor();
            Console.SetCursorPosition(21, 13);
            Console.Write("|");
            Console.SetCursorPosition(1, 14);
            Console.Write(" - - - - - - - - - - ");

            if (saldo == 0)
            {
                Console.SetCursorPosition(1, 16);
                Console.Write("Nie masz juz pieniedzy.");
                Console.SetCursorPosition(1, 17);
                Console.Write("Wroc do Menu poprzez wcisniecie klawisza ESC");
                Console.SetCursorPosition(1, 18);
                Console.Write("i wplac wiecej pieniedzy");
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    return -1;
                }
            }

            Console.SetCursorPosition((Console.WindowWidth / 3) + 5, (Console.WindowHeight / 2) - 5);
            Console.Write("Podaj wartosc zakladu: ");
            Console.SetCursorPosition((Console.WindowWidth / 3) + 5, (Console.WindowHeight / 2) - 2);

            int zaklad = 0;
            string _zaklad = Console.ReadLine();
            bool ok = true;
            while (ok)
            {
                if (!int.TryParse(_zaklad, out zaklad))
                {
                    Console.SetCursorPosition((Console.WindowWidth / 3) + 5, (Console.WindowHeight / 2) - 2);
                    _zaklad = Console.ReadLine();

                }
                else ok = false;
            }
            while(zaklad > saldo || zaklad <= 99 || zaklad % 100 != 0)
            {
                Console.SetCursorPosition(75, 8);
                Console.Write("                                  ");
                Console.SetCursorPosition(75, 10);
                Console.Write("                                           ");
                Console.SetCursorPosition(75, 12);
                Console.Write("                                            ");

                if (zaklad > saldo)
                {
                    Console.SetCursorPosition(90, 8);
                    Console.Write("Blad! ");
                    Console.SetCursorPosition(75, 10);
                    Console.Write("Wartosc twojego zakladu przekracza ");
                    Console.SetCursorPosition(75, 12);
                    Console.Write("ilosc posiadanych przez ciebie pieniedzy !!!");
                }else if (zaklad <= 99)
                {
                    Console.SetCursorPosition(90, 8);
                    Console.Write("Blad! ");
                    Console.SetCursorPosition(75, 10);
                    Console.Write("Wartosc twojego zakladu jest za mala!!!");
                    Console.SetCursorPosition(75, 12);
                    Console.Write("Minimalna stawka wynosi 100");
                }else if(zaklad % 100 != 0)
                {
                    Console.SetCursorPosition(90, 8);
                    Console.Write("Blad! ");
                    Console.SetCursorPosition(75, 10);
                    Console.Write("Wartosc zakladu jest bledna !!!");
                    Console.SetCursorPosition(75, 12);
                    Console.Write("Akceptowany zaklad jest wielokrotnoscia 100");
                }

                Console.SetCursorPosition((Console.WindowWidth / 3) + 5, (Console.WindowHeight / 2) - 2);
                Console.Write("                      ");
                Console.SetCursorPosition((Console.WindowWidth / 3) + 5, (Console.WindowHeight / 2) - 2);

                _zaklad = Console.ReadLine();
                ok = true;
                while (ok)
                {
                    if (!int.TryParse(_zaklad, out zaklad))
                    {
                        Console.SetCursorPosition((Console.WindowWidth / 3) + 5, (Console.WindowHeight / 2) - 2);
                        _zaklad = Console.ReadLine();

                    }
                    else ok = false;
                }

            }

            Console.SetCursorPosition(75, 8);
            Console.Write("                                            ");
            Console.SetCursorPosition(75, 10);
            Console.Write("                                            ");
            Console.SetCursorPosition(75, 12);
            Console.Write("                                            ");

            Console.SetCursorPosition(35, 17);
            Console.Write("Czy akceptujesz rozpoczecie tego zakladu ?");
            int wybranaOpcja = MiniMenu.MultipleChoice(true, 47, 19,2,10, "1.Tak", "2.Nie");

            switch (wybranaOpcja)
            {
                case 0:
                    {
                        break;
                    }
                case 1:
                    {
                        Console.SetCursorPosition((Console.WindowWidth / 3) + 5, (Console.WindowHeight / 2) - 2);
                        Console.Write("                                            ");
                        Console.SetCursorPosition(35, 17);
                        Console.Write("                                            ");
                        Console.SetCursorPosition(47, 19);
                        Console.Write("                                            ");

                        zaklad = betuj();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            return zaklad;
        }



    }
}
