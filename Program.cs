using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Kasyno___KCK
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.SetWindowSize(120, 30);
            Menu menu = new Menu();
            Gra gra = new Gra();
            Bettowanie bet = new Bettowanie();
            int opcjaMenu = menu.start(bet.saldo);
            int zaklad;
            int graj = 0;

            bool grajDalej = true;
            while (grajDalej)
            {

                switch (opcjaMenu)
                {
                    case 0:
                        Console.Clear();
                        Console.Write(@"
                                ____       _   _                           _      
                               |  _ \     | | | |                         (_)     
                               | |_) | ___| |_| |_ _____      ____ _ _ __  _  ___ 
                               |  _ < / _ \ __| __/ _ \ \ /\ / / _` | '_ \| |/ _ \
                               | |_) |  __/ |_| || (_) \ V  V / (_| | | | | |  __/
                               |____/ \___|\__|\__\___/ \_/\_/ \__,_|_| |_|_|\___|
                                                                                  
                                                    
");
                        zaklad = bet.betuj();
                        if (zaklad == -1) { opcjaMenu = 10; break; }
                        gra = new Gra();
                        opcjaMenu = gra.graj(zaklad, ref bet.saldo);
                        if (opcjaMenu == 1) opcjaMenu = 10;
                        break;
                    case 1:
                        
                        
                        Console.Clear();
                        Console.Write(@"
                                        ______                   _       
                                       |___  /                  | |      
                                          / / __ _ ___  __ _  __| |_   _ 
                                         / / / _` / __|/ _` |/ _` | | | |
                                        / /_| (_| \__ \ (_| | (_| | |_| |
                                       /_____\__,_|___/\__,_|\__,_|\__, |
                                                                    __/ |
                                                                   |___/ 
");
                        Console.SetCursorPosition(20, 11);
                        Console.WriteLine("Aktualnie jedyna dostepna gra jest Blackjack");
                        Console.SetCursorPosition(20, 12);
                        Console.WriteLine("1. Aby wygrac musisz spelnic jeden z ponizszych warunkow: ");
                        Console.CursorLeft = 24;
                        Console.WriteLine("a) wartosc twoich kart musi wynosic dokladnie 21");
                        Console.CursorLeft = 24;
                        Console.WriteLine("b) wartosc twoich kart musi byc wieksza od wartosci kart krupiera");
                        Console.CursorLeft = 27;
                        Console.WriteLine("ale nie przekraczajaca 21");
                        Console.SetCursorPosition(20, 16);
                        Console.WriteLine("2. Przegrywasz w nastepujacych przypadkach: ");
                        Console.CursorLeft = 24;
                        Console.WriteLine("a) gdy wartosc twoich kart przekroczy 21");
                        Console.CursorLeft = 24;
                        Console.WriteLine("b) gdy wartosc kart krupiera wynosi 21");
                        Console.CursorLeft = 24;
                        Console.WriteLine("c) gdy sie poddasz");
                        Console.SetCursorPosition(20, 20);
                        Console.WriteLine("3. Kasyno przyjmuje tylko zaklady bedace wielokrotnoscia 100,");
                        Console.CursorLeft = 24;
                        Console.WriteLine("np. 100, 200, 1000, 5100, 15900, 30200");


                        Console.SetCursorPosition(1, 24);
                        Console.Write("Wcisnij Enter aby powrocic do Menu ...");
                        Console.ReadKey();
                        opcjaMenu = 10;
                        break;
                    case 2:
                        Console.Clear();
                        Console.Write(@"
                                        __          __    _       _         
                                        \ \        / /   | |     | |        
                                         \ \  /\  / / __ | | __ _| |_ _   _ 
                                          \ \/  \/ / '_ \| |/ _` | __| | | |
                                           \  /\  /| |_) | | (_| | |_| |_| |
                                            \/  \/ | .__/|_|\__,_|\__|\__, |
                                                   | |                 __/ |
                                                   |_|                |___/ 
");
                        Console.SetCursorPosition(1, 10);
                        Console.Write(" - - - - - - - - - - ");
                        Console.SetCursorPosition(1, 11);
                        Console.Write("|    Twoje saldo:   |");
                        Console.SetCursorPosition(1, 13);
                        Console.Write("|");
                        Console.SetCursorPosition(7, 13);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(bet.saldo);
                        Console.ResetColor();
                        Console.SetCursorPosition(21, 13);
                        Console.Write("|");
                        Console.SetCursorPosition(1, 14);
                        Console.Write(" - - - - - - - - - - ");

                        Console.SetCursorPosition((Console.WindowWidth / 3) + 3, (Console.WindowHeight / 2) - 4);
                        Console.Write("Podaj ile pieniedzy chcesz wplacic: ");
                        Console.SetCursorPosition((Console.WindowWidth / 3) + 3, (Console.WindowHeight / 2) - 2);

                        int wplata = 0;
                        string _wplata = Console.ReadLine();
                        bool _ok = true;
                        while (_ok)
                        {
                            if (!int.TryParse(_wplata, out wplata))
                            {
                                Console.SetCursorPosition((Console.WindowWidth / 3) + 5, (Console.WindowHeight / 2) - 2);
                                _wplata = Console.ReadLine();

                            }
                            else
                            {
                                if(wplata % 100 == 0 && wplata >= 0)
                                {
                                    _ok = false;

                                }
                                else
                                {
                                    Console.SetCursorPosition((Console.WindowWidth / 3) + 3, (Console.WindowHeight / 2) - 2);
                                    Console.Write("                    ");
                                    Console.SetCursorPosition((Console.WindowWidth / 3) + 5, (Console.WindowHeight / 2) - 2);
                                    _wplata = Console.ReadLine();
                                }
                            }
                        }
                        bet.saldo += wplata;
                        opcjaMenu = 10;
                        break;
                    case 3:
                            Console.Clear();
                            string autor = @"
                               ____    ____   _          __              __          
                              |_   \  /   _| (_)        [  |            [  |         
                                |   \/   |   __   .---.  | |--.   ,--.   | |         
                                | |\  /| |  [  | / /'`\] | .-. | `'_\ :  | |         
                               _| |_\/_| |_  | | | \__.  | | | | // | |, | |         
                              |_____||_____|[___]'.___.'[___]|__]\'-;__/[___]    _   
                              |  __   _|                              [  |  _   (_)  
                              |_/  / /   ,--.    .--.   _ .--.  .--.   | | / ]  __   
                                 .'.' _ `'_\ : / .'`\ \[ `/'`\]( (`\]  | '' <  [  |  
                               _/ /__/ |// | |,| \__. | | |     `'.'.  | |`\ \  | |  
                              |________|\'-;__/ '.__.' [___]   [\__) )[__|  \_][___] 
                                                                                     
";
                        Console.WriteLine(autor);
                        Console.SetCursorPosition(1,15);
                        Console.Write("Wcisnij Enter aby powrocic do Menu ...");
                        Console.ReadKey();
                        opcjaMenu = 10;
                        break;
                    case 4:
                        Console.Clear();
                        Console.Write(@"
                                   __          __              _       _ _ 
                                   \ \        / /             | |     (_|_)
                                    \ \  /\  / / __   __ _  __| |_ __  _ _ 
                                     \ \/  \/ / '_ \ / _` |/ _` | '_ \| | |
                                      \  /\  /| |_) | (_| | (_| | | | | | |
                                      _\/  \/ | .__/ \__,_|\__,_|_| |_|_| |
                                     (_)      | |                      _/ |
                                      _  ___  |_| _______ _______     |__/ 
                                     | |/ _ \/ __|_  / __|_  / _ \         
                                     | |  __/\__ \/ / (__ / /  __/         
                                     | |\___||___/___\___/___\___|         
                                    _/ |                                   
                                   |__/  _          _                      
                                   | |  (_)        | |                     
                                   | | ___  ___  __| |_   _ ___            
                                   | |/ / |/ _ \/ _` | | | / __|           
                                   |   <| |  __/ (_| | |_| \__ \           
                                   |_|\_\_|\___|\__,_|\__, |___/           
                                                       __/ |               
                                                      |___/                
");
                        System.Threading.Thread.Sleep(3000);
                        grajDalej = false;
                        break;
                    case 10:
                        opcjaMenu = menu.start(bet.saldo);
                        break;
                    default:
                        grajDalej = false;
                        break;
                }
            }
        }
    }
}
