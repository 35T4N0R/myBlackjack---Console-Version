using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasyno___KCK
{
    class Menu
    {

        public int  start(double saldo)
        {
            Console.Clear();
            String title = @"
                               _____                   _    _____          _             
                              |  __ \                 | |  / ____|        (_)            
                              | |__) |___  _   _  __ _| | | |     __ _ ___ _ _ __   ___  
                              |  _  // _ \| | | |/ _` | | | |    / _` / __| | '_ \ / _ \ 
                              | | \ \ (_) | |_| | (_| | | | |___| (_| \__ \ | | | | (_) |
                              |_|  \_\___/ \__, |\__,_|_|  \_____\__,_|___/_|_| |_|\___/ 
                                            __/ |                                        
                                           |___/                                         
";
            Console.Write(title);
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
            int opcja = MiniMenu.MultipleChoice(true, (Console.WindowWidth / 3) + 11, (Console.WindowHeight / 2) - 2, 1, 5, "1.Graj", "2.Zasady Gry","3.Doladuj konto", "4.Autor","5.Wyjdz z Gry");

            return opcja;
        }

        
    }
}
