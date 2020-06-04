using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasyno___KCK
{
    class Karta
    {
        private string patern;
        private string[] kolory = new string[] { "Kier", "Karo", "Trefl", "Pik" };
        public int _value;
        public string _suit;

        public Karta()
        {
            Random rnd = new Random();
            int numer = rnd.Next(1, 13);
            int kolor = rnd.Next(0, 3);
            _value = numer;
            _suit = kolory[kolor];
        }

        public void rysujKarte(int left, int top)
        {
            if(_value == 0)
            {
                patern =
                    "     _     " +
                    @"   /   \   " +
                    "  |     |  " +
                    "       /   " +
                    "      /    " +
                    "     |     " +
                    "     .     ";
                rysuj(left, top);
            }
            if (_value == 1)
            {
                patern =
                    " V         " +
                    "           " +
                    "           " +
                    "     S     " +
                    "           " +
                    "           " +
                    "         V ";
                rysuj(left,top);
            }
            if (_value == 2)
            {
                patern =
                    " V         " +
                    "     S     " +
                    "           " +
                    "           " +
                    "           " +
                    "     S     " +
                    "         V ";
                rysuj(left,top);
            }
            if (_value == 3)
            {
                patern =
                    " V         " +
                    "     S     " +
                    "           " +
                    "     S     " +
                    "           " +
                    "     S     " +
                    "         V ";
                rysuj(left,top);
            }
            if (_value == 4)
            {
                patern =
                    " V         " +
                    "   S   S   " +
                    "           " +
                    "           " +
                    "           " +
                    "   S   S   " +
                    "         V ";
                rysuj(left,top);
            }
            if (_value == 5)
            {
                patern =
                    " V         " +
                    "   S   S   " +
                    "           " +
                    "     S     " +
                    "           " +
                    "   S   S   " +
                    "         V ";
                rysuj(left,top);
            }
            if (_value == 6)
            {
                patern =
                    " V         " +
                    "   S   S   " +
                    "           " +
                    "   S   S   " +
                    "           " +
                    "   S   S   " +
                    "         V ";
                rysuj(left,top);
            }
            if (_value == 7)
            {
                patern =
                    " V         " +
                    "   S   S   " +
                    "     S     " +
                    "   S   S   " +
                    "           " +
                    "   S   S   " +
                    "         V ";
                rysuj(left,top);
            }
            if (_value == 8)
            {
                patern =
                    " V         " +
                    "   S   S   " +
                    "     S     " +
                    "   S   S   " +
                    "     S     " +
                    "   S   S   " +
                    "         V ";
                rysuj(left,top);
            }
            if (_value == 9)
            {
                patern =
                    " V         " +
                    "   S S S   " +
                    "           " +
                    "   S S S   " +
                    "           " +
                    "   S S S   " +
                    "         V ";
                rysuj(left,top);
            }
            if (_value == 10 || _value == 11 || _value == 12 || _value == 13)
            {
                patern =
                    " V         " +
                    "    S S    " +
                    "     S     " +
                    "  S S S S  " +
                    "     S     " +
                    "    S S    " +
                    "         V ";
                rysuj(left,top);
            }
        }
        private void rysuj(int left, int top)
        {
            bool hasWrittenFirstNumber = false;
            Console.CursorLeft = left;
            Console.CursorTop = top;

            if(Console.CursorLeft + 12 > Console.WindowWidth)
            {

                return;
            }

            switch (_suit)
            {
                case "Kier":
                case "Karo":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "Trefl":
                case "Pik":
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
            }

            for (int i = 0; i < patern.Length; i++)
            {
                Console.BackgroundColor = ConsoleColor.White;
                if (i % 11 == 0 && i != 0)
                {
                    Console.CursorLeft -= 11;
                    Console.CursorTop += 1;
                }
                if (patern[i] == 'S')
                {
                    switch (_suit)
                    {
                        case "Kier":
                            Console.Write('♥');
                            break;
                        case "Trefl":
                            Console.Write("♣");
                            break;
                        case "Karo":
                            Console.Write("♦");
                            break;
                        case "Pik":
                            Console.Write("♠");
                            break;
                    }
                    continue;
                }
                else if (patern[i] == 'V')
                {
                    if (_value == 10)
                    {
                        if (hasWrittenFirstNumber == false)
                        {
                            Console.Write(10);
                            hasWrittenFirstNumber = true;
                            i++;
                        }
                        else
                        {
                            Console.CursorLeft--;
                            Console.Write(10);
                        }
                        continue;
                    }
                    else if (_value == 11)
                    {
                        Console.Write("J");
                    }
                    else if (_value == 12)
                    {
                        Console.Write("Q");
                    }
                    else if (_value == 13)
                    {
                        Console.Write("K");
                    }
                    else if (_value == 1)
                    {
                        Console.Write("A");
                    }
                    else
                    {
                        Console.Write(_value);
                    }
                }
                else
                {
                    Console.Write(patern[i]);
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
