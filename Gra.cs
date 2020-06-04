using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasyno___KCK
{
    class Gra
    {
        public int czyOdNowa()
        {
            Console.SetCursorPosition(Console.WindowWidth / 3, (Console.WindowHeight / 2)-2);
            Console.Write("Czy chcesz zagrac jeszcze raz ???");
            int opcja = MiniMenu.MultipleChoice(true, Console.WindowWidth / 3, (Console.WindowHeight / 2),1,5, "1.Tak", "2.Nie");
            return opcja;
        }
        public int graj(int zaklad, ref double saldo)
        {
            Console.Clear();

            Console.SetCursorPosition(90, 15);
            Console.Write(" - - - - - - - - - - ");
            Console.SetCursorPosition(90, 16);
            Console.Write("|    Twoj zaklad:   |");
            Console.SetCursorPosition(90, 18);
            Console.Write("|");
            Console.SetCursorPosition(97, 18);
            Console.Write(zaklad);
            Console.SetCursorPosition(110, 18);
            Console.Write("|");
            Console.SetCursorPosition(90, 19);
            Console.Write(" - - - - - - - - - - ");

            Console.SetCursorPosition(90, 10);
            Console.Write(" - - - - - - - - - - ");
            Console.SetCursorPosition(90, 11);
            Console.Write("|    Twoje saldo:   |");
            Console.SetCursorPosition(90, 13);
            Console.Write("|");
            Console.SetCursorPosition(97, 13);
            Console.Write(saldo-zaklad);
            Console.SetCursorPosition(110, 13);
            Console.Write("|");
            Console.SetCursorPosition(90, 14);
            Console.Write(" - - - - - - - - - - ");


            int odLewejKrupiera = Console.WindowWidth / 3;
            int odLewejGracza = Console.WindowWidth / 3;

            int counterKartyKrupiera = 0;
            int counterKartyGracza = 0;
            int wartoscZakrytej = 0;
            string kolorZakrytej = "Kier";

            int odGory;

            odGory = 0;
            Karta kartaKrupiera, kartaGracza;
            for (int i = 0; i < 2; i++)
            {
                odGory = 0;

                if (i == 0)
                {
                    kartaKrupiera = new Karta();
                    wartoscZakrytej = kartaKrupiera._value;
                    kartaKrupiera._value = 0;
                    kolorZakrytej = kartaKrupiera._suit;
                }
                else
                {
                    kartaKrupiera = new Karta();
                    if (kartaKrupiera._value > 10) counterKartyKrupiera += 10;
                    else counterKartyKrupiera += kartaKrupiera._value;
                    Console.SetCursorPosition(20, 3);
                    Console.Write("Wartosc Kart: " + counterKartyKrupiera);
                }

                kartaKrupiera.rysujKarte(odLewejKrupiera, odGory);

                odGory = Console.WindowHeight - 7;

                kartaGracza = new Karta();
                kartaGracza.rysujKarte(odLewejGracza, odGory);

                if (kartaGracza._value > 10) counterKartyGracza += 10;
                else counterKartyGracza += kartaGracza._value;
                Console.SetCursorPosition(20, Console.WindowHeight - 3);
                Console.Write("Wartosc Kart: " + counterKartyGracza);
                odLewejKrupiera += 12;
                odLewejGracza += 12;
            }
            int wybranaOpcja = 5;
            bool czekaj = false;
            bool czyStand = false;
            bool koniecGry = false;
            bool czyOdkryto = false;
            bool stop = false;
            bool surrender = false;

            while (true)
            {
                if (!stop)
                {
                    wybranaOpcja = MiniMenu.MultipleChoice(true,5 ,10 ,1,5, "1.Hit", "2.Stand", "3.Surrender");

                }

                if (!surrender && counterKartyGracza == 21)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 3, (Console.WindowHeight / 2) - 5);
                    Console.Write("KONIEC GRY! WYGRALES! MASZ BLACKJACK'A");
                    saldo += 1.5 * zaklad;
                    koniecGry = false;
                    return czyOdNowa();
                }

                if (!surrender && koniecGry && (counterKartyGracza > 21 || ((counterKartyKrupiera > counterKartyGracza) && counterKartyKrupiera < 22)))
                {
                    Console.SetCursorPosition(Console.WindowWidth / 3, (Console.WindowHeight / 2) - 5);
                    Console.Write("KONIEC GRY! PRZEGRALES !");
                    saldo -= zaklad;
                    koniecGry = false;
                    return czyOdNowa();
                }

                if (!surrender && koniecGry && counterKartyGracza == counterKartyKrupiera)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 3, (Console.WindowHeight / 2) - 5);
                    Console.Write("KONIEC GRY! REMIS !");
                    koniecGry = false;
                    return czyOdNowa();
                }

                if (!surrender && koniecGry && (counterKartyKrupiera > 21 || counterKartyKrupiera < counterKartyGracza))
                {
                    Console.SetCursorPosition(Console.WindowWidth / 3, (Console.WindowHeight / 2) - 5);
                    Console.Write("KONIEC GRY! WYGRALES !");
                    saldo += zaklad;
                    koniecGry = false;
                    return czyOdNowa();
                }

                if (!koniecGry && wybranaOpcja == 0 && counterKartyGracza < 21 && czyStand == false)
                {

                    kartaGracza = new Karta();

                    odGory = Console.WindowHeight - 7;

                    kartaGracza.rysujKarte(odLewejGracza, odGory);
                    if (kartaGracza._value > 10) counterKartyGracza += 10;
                    else counterKartyGracza += kartaGracza._value;
                    Console.SetCursorPosition(20, Console.WindowHeight - 3);
                    Console.Write("Wartosc Kart: " + counterKartyGracza);
                    if (counterKartyGracza >= 21) { stop = true; koniecGry = true; }
                    odLewejGracza += 12;

                }
                if (!koniecGry && wybranaOpcja == 1)
                {
                    stop = true;
                    czyStand = true;
                }
                if (!koniecGry && czyStand)
                {

                    if (!czyOdkryto)
                    {
                        odGory = 0;
                        odLewejKrupiera = Console.WindowWidth / 3;
                        kartaKrupiera = new Karta();
                        kartaKrupiera._value = wartoscZakrytej;
                        kartaKrupiera._suit = kolorZakrytej;
                        kartaKrupiera.rysujKarte(odLewejKrupiera, odGory);
                        if (wartoscZakrytej > 10) counterKartyKrupiera += 10;
                        else counterKartyKrupiera += wartoscZakrytej;
                        Console.SetCursorPosition(20, 3);
                        Console.Write("Wartosc Kart: " + counterKartyKrupiera);
                        if (counterKartyKrupiera > 16) { koniecGry = true; stop = true; }
                        czyOdkryto = true;
                        odLewejKrupiera += 12;
                    }

                    System.Threading.Thread.Sleep(2000);

                    if (counterKartyKrupiera <= 16)
                    {

                        kartaKrupiera = new Karta();
                        odLewejKrupiera += 12;
                        kartaKrupiera.rysujKarte(odLewejKrupiera, odGory);
                        if (kartaKrupiera._value > 10) counterKartyKrupiera += 10;
                        else counterKartyKrupiera += kartaKrupiera._value;
                        Console.SetCursorPosition(20, 3);
                        Console.Write("Wartosc Kart: " + counterKartyKrupiera);
                        if (counterKartyKrupiera > 16) { koniecGry = true; stop = true; }
                    }
                }
                if (!surrender && wybranaOpcja == 2)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 3, (Console.WindowHeight / 2) - 5);
                    Console.Write("KONIEC GRY! PODDALES SIE!");
                    saldo -= zaklad;
                    surrender = true;
                    koniecGry = true;
                    stop = true;
                    return czyOdNowa();
                }

            }

        }
    }
}
