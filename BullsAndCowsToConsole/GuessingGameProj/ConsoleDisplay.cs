using System;
using System.Threading;
using Ex02.ConsoleUtils;

namespace GameDisplay
{
    public class ConsoleDisplay
    {
        public void PrintGameLogo(int i_SecondDelay = 0)
        {
            Console.WriteLine("               =====================================================================      ");
            Console.WriteLine("               ______    _    _    _____     _____    _____    _    ______    ______      ");
            Console.WriteLine("              /  ____|  | |  | |  | ____|   |  ___|  |  ___|  | |  |  __  |  /  ____|     ");
            Console.WriteLine("              | |   _   | |  | |  | |_      | |___   | |___   | |  | |  | |  | |   _      ");
            Console.WriteLine("              | |  | |  | |  | |  |  _|     |___  |  |___  |  | |  | |  | |  | |  | |     ");
            Console.WriteLine("              | |__| |  | |  | |  | |___     ___| |   ___| |  | |  | |  | |  | |__| |     ");
            Console.WriteLine("              \\______/  \\______/  |_____|   |_____|  |_____|  |_|  |_|  |_|  \\______/  ");
            Console.WriteLine("                                                                                          ");
            Console.WriteLine("                              ______    ______    ___________     _____                   ");
            Console.WriteLine("                             /  ____|  |  __  |  /  __   __  \\   | ____|                 ");
            Console.WriteLine("                             | |   _   | |__| |  | |  | |  | |   | |_                     ");
            Console.WriteLine("                             | |  | |  |  __  |  | |  | |  | |   |  _|                    ");
            Console.WriteLine("                             | |__| |  | |  | |  | |  | |  | |   | |___                   ");
            Console.WriteLine("                             \\______/  |_|  |_|  |_|  |_|  |_|   |_____|                 ");
            Console.WriteLine("               =====================================================================      ");
            Thread.Sleep(i_SecondDelay * 1000);
        }

        public void PrintToConsole(string i_Str, int i_SecondDelay = 0)
        {
            Console.WriteLine(i_Str);
            Thread.Sleep(i_SecondDelay * 1000);
        }

        public string GetFromConsole()
        {
            return Console.ReadLine(); ;
        }

        public void CleanScreen()
        {
            Screen.Clear();
        }

        public void PrintMatrixToConsole(string[,] i_GameMatrix)
        {
            CleanScreen();
            Console.WriteLine();
            for (int row = 0; row < i_GameMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < i_GameMatrix.GetLength(1); col++)
                {
                    Console.Write("|");
                    if (i_GameMatrix[row, col] != null)
                    {
                        Console.Write(i_GameMatrix[row, col]);
                        PrintSpaces(10 - i_GameMatrix[row, col].Length);
                    }
                    else
                    {
                        PrintSpaces(10);
                    }
                }

                Console.WriteLine("|");
                Console.WriteLine("+==========+==========+");
            }

            Console.WriteLine();
        }

        public void PrintSpaces(int i_NumOfSpaces)
        {
            for (int index = 0; index < i_NumOfSpaces; index++)
            {
                Console.Write(" ");
            }
        }
    }
}