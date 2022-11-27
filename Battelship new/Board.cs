using Battelship_new;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Battelship
{
    class Board
    {
        Random RNG = new Random();
        int size;
        char [,] matrix1;
        char [,] matrix2;
        Ship[] ships1;
        Ship[] ships2;
        int score1=0;
        int score2=0;

        public void loadfile(string filename)
        {
            string[] alldate1 = File.ReadAllLines(filename);
            int height = alldate1.Length;
            int width = alldate1[0].Length;
            matrix1 = new char[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    matrix1[i, j] = alldate1[i][j];
                }
            }

            string[] alldate2 = File.ReadAllLines(filename);
            int h = alldate2.Length;
            int w = alldate2[0].Length;
            matrix2 = new char[h, w];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    matrix2[i, j] = alldate1[i][j];
                }
            }



        }
        //public void Initialization(int size)
        //{
        //    this.size = size;
        //    //matrix1 = new string[size, size];
        //    //for (int i = 0; i < matrix1.GetLength(0); i++)
        //    //{
        //    //    for (int j = 0; j < matrix1.GetLength(1); j++)
        //    //    {
        //    //        matrix1[i, j] = "*";
        //    //    }
        //    //}


        //    matrix2 = new string[size, size];
        //    for (int i = 0; i < matrix2.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < matrix2.GetLength(1); j++)
        //        {
        //            matrix2[i, j] = "*";
        //        }
        //    }
        //}


        public void placeships1(int num)
        {
            int count = 0;
            for (int i = 0; i < 4 + count; i++)  // if the palce is taken so it will not affect on for loop 
            {
                Console.WriteLine("Give me the lenght of the ship from 1 to 4");
                int L = int.Parse(Console.ReadLine());
                if (L > 0 && L <= 4)
                {
                    Console.WriteLine("Give me X start piont from 0 to 9");
                    int X = int.Parse(Console.ReadLine());
                    Console.WriteLine("Give me Y start piont from 0 t0 9");
                    int Y = int.Parse(Console.ReadLine());
                    Console.WriteLine("Give me the position H or V");
                    char D = Console.ReadKey().KeyChar;
                    Console.WriteLine("    Done");
                    
                    if (matrix1[X, Y] == '*') //prevent overwritte and to show the place is available .
                    {
                        if (D == 'V')
                        {
                            switch (L)
                            {
                                case 1:
                                    matrix1[X, Y] = '=';
                                    
                                    break;
                                case 2:
                                    matrix1[X, Y] = '=';

                                    if (X + 1 < matrix1.GetLength(0)) //prevent out of array
                                    {
                                        matrix1[X + 1, Y] = '=';

                                    }
                                    break;
                                case 3:
                                    matrix1[X, Y] = '=';

                                    if (X + 1 < matrix1.GetLength(0))
                                    {
                                        matrix1[X + 1, Y] = '=';

                                    }
                                    if (X + 2 < matrix1.GetLength(0))
                                    {
                                        matrix1[X + 2, Y] = '=';

                                    }
                                    break;
                                case 4:
                                    matrix1[X, Y] = '=';

                                    if (X + 1 < matrix1.GetLength(0))
                                    {
                                        matrix1[X + 1, Y] = '=';

                                    }
                                    if (X + 2 < matrix1.GetLength(0))
                                    {
                                        matrix1[X + 2, Y] = '=';

                                    }
                                    if (X + 3 < matrix1.GetLength(0))
                                    {
                                        matrix1[X + 3, Y] = '=';

                                    }

                                    break;
                            }
                        }

                        else if (D == 'H')
                        {
                            switch (L)
                            {
                                case 1:
                                    matrix1[X, Y] = '=';

                                    break;
                                case 2:
                                    matrix1[X, Y] = '=';

                                    if (Y + 1 < matrix1.GetLength(1))
                                    {
                                        matrix1[X, Y + 1] = '=';

                                    }
                                    break;
                                case 3:
                                    matrix1[X, Y] = '=';

                                    if (Y + 1 < matrix1.GetLength(1))
                                    {
                                        matrix1[X, Y + 1] = '=';
                                    }
                                    if (Y + 2 < matrix1.GetLength(1))
                                    {
                                        matrix1[X, Y + 2] = '=';

                                    }
                                    break;
                                case 4:
                                    matrix1[X, Y] = '=';

                                    if (Y + 1 < matrix1.GetLength(1))
                                    {
                                        matrix1[X, Y + 1] = '=';

                                    }
                                    if (Y + 2 < matrix1.GetLength(1))
                                    {
                                        matrix1[X, Y + 2] = '=';
                                    }
                                    if (Y + 3 < matrix1.GetLength(1))
                                    {
                                        matrix1[X, Y + 3] = '=';

                                    }

                                    break;
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("the place is taken");
                        count++;
                    }
                }
                else
                {
                    Console.WriteLine("Not Valid Value");
                }

            }
        }

        public void ship1array()
        {
            int counter = 0;
            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix1.GetLength(1); j++)
                {
                    if (matrix1[i, j] == '=')
                    {
                        counter++;
                    }
                }
            }
            ships1 = new Ship[counter];
            int k = 0;
            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix1.GetLength(1); j++)
                {
                    if (matrix1[i, j] == '=')
                    {
                        ships1[k] = new Ship(i, j);
                        k++;
                    }
                }
            }





        } //array for ships1 


        public void placeships2()
        {
           

            string position = "HV";
            for (int i = 0; i < 4; i++)
            {
                int L = RNG.Next(1, 5);
                int X = RNG.Next(0, matrix2.GetLength(0));
                int Y = RNG.Next(0, matrix2.GetLength(1));
                char D = position[RNG.Next(position.Length)];
                if (matrix2[X, Y] == '*')
                {
                    if (D == 'V')
                    {
                        switch (L)
                        {
                            case 1:
                                matrix2[X, Y] = '=';

                                break;
                            case 2:
                                matrix2[X, Y] = '=';
                                if (X + 1 < matrix2.GetLength(0))
                                {
                                    matrix2[X + 1, Y] = '=';
                                }
                                break;
                            case 3:
                                matrix2[X, Y] = '=';
                                if (X + 1 < matrix2.GetLength(0))
                                {
                                    matrix2[X + 1, Y] = '=';
                                }
                                if (X + 2 < matrix2.GetLength(0))
                                {
                                    matrix2[X + 2, Y] = '=';
                                }
                                break;
                            case 4:
                                matrix2[X, Y] = '=';
                                if (X + 1 < matrix2.GetLength(0))
                                {
                                    matrix2[X + 1, Y] = '=';
                                }
                                if (X + 2 < matrix2.GetLength(0))
                                {
                                    matrix2[X + 2, Y] = '=';
                                }
                                if (X + 3 < matrix2.GetLength(0))
                                {
                                    matrix2[X + 3, Y] = '=';
                                }

                                break;
                        }
                    }

                    else if (D == 'H')
                    {
                        switch (L)
                        {
                            case 1:
                                matrix2[X, Y] = '=';
                                break;
                            case 2:
                                matrix2[X, Y] = '=';
                                if (Y + 1 < matrix2.GetLength(1))
                                {
                                    matrix2[X, Y + 1] = '=';
                                }
                                break;
                            case 3:
                                matrix2[X, Y] = '=';
                                if (Y + 1 < matrix2.GetLength(1))
                                {
                                    matrix2[X, Y + 1] = '=';
                                }
                                if (Y + 2 < matrix2.GetLength(1))
                                {
                                    matrix2[X, Y + 2] = '=';
                                }
                                break;
                            case 4:
                                matrix2[X, Y] = '=';
                                if (Y + 1 < matrix2.GetLength(1))
                                {
                                    matrix2[X, Y + 1] = '=';
                                }
                                if (Y + 2 < matrix2.GetLength(1))
                                {
                                    matrix2[X, Y + 2] = '=';
                                }
                                if (Y + 3 < matrix2.GetLength(1))
                                {
                                    matrix2[X, Y + 3] = '=';
                                }

                                break;
                        }
                    }
                }
            }
        }

        public void ship2array() //array for ships2
        {
            int counter = 0;
            for (int i = 0; i < matrix2.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2.GetLength(1); j++)
                {
                    if (matrix2[i, j] == '=')
                    {
                        counter++;
                    }
                }
            }
            ships2 = new Ship[counter];
            int k = 0;
            for (int i = 0; i < matrix2.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2.GetLength(1); j++)
                {
                    if (matrix2[i, j] == '=')
                    {
                        ships2[k] = new Ship(i, j);
                        k++;
                    }
                }
            }





        } 
        public void Visualize()
        {
            Console.Clear();
            for (int i = 0; i < matrix1.GetLength(1); i++)
            {
                for (int j = 0; j < matrix1.GetLength(0); j++)
                    
                {
                    char currentchar = matrix1[i, j];
                    if (currentchar == '*')
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    

                    Console.SetCursorPosition(2 * j, 2 * i);
                    Console.Write(" ");
                    Console.ResetColor();

                }
                Console.WriteLine();
            }

            for (int m = 0; m < matrix2.GetLength(0); m++)
            {
                for (int n = 0; n < matrix2.GetLength(1); n++)
                {
                    char currentchar2 = matrix2[m, n];
                        if (currentchar2 == '*')
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                        }
                        Console.SetCursorPosition(50 + (2 * n), 2 * m);
                        Console.Write(" ");
                        Console.ResetColor();

                    }
                    Console.WriteLine();
                }

            for (int i = 0; i < ships1.Length; i++)
            {
                Console.SetCursorPosition(2 * ships1[i].Y, 2 * ships1[i].X);
                Console.BackgroundColor = ships1[i].Color;
                Console.Write(" ");
                Console.ResetColor();

            }


            for (int i = 0; i < ships2.Length; i++)
            {
                Console.SetCursorPosition(50 + (2 * ships2[i].Y), 2 * ships2[i].X);
                Console.BackgroundColor = ships2[i].Color;
                Console.Write(" ");
                Console.ResetColor();

            }
        }

        public void shoot1(int x, int y)
        {
            

            for (int i = 0; i < ships2.Length; i++)
            {
                if (ships2[i].X == x && ships2[i].Y == y)
                {
                    //ships2[i].Active = false;
                    ships2[i].Color = ConsoleColor.Red;
                    Console.SetCursorPosition(50 +(2 * ships2[i].Y), 2 * ships2[i].X);
                    Console.BackgroundColor = ships2[i].Color;
                    Console.Write(" ");
                    Console.ResetColor();
                    score1++;

                }
                
            }
        }

        public void shoot2(int x, int y)
        {
            
            for (int i = 0; i < ships1.Length; i++)
            {
                if (ships1[i].X == x && ships1[i].Y == y)
                {
                    //ships1[i].Active = false;
                    ships2[i].Color = ConsoleColor.Red;
                    Console.SetCursorPosition(2 * ships1[i].Y, 2 * ships1[i].X);
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write(" ");
                    Console.ResetColor();
                    score2++;

                }
                

            }
        }

        public void RunGame()

        {
            
            //while (ships1[i].Color == ConsoleColor.White && ships1[i].Color == ConsoleColor.White)
            do
            {
                Console.SetCursorPosition(0, 20);
                Console.WriteLine("X = ;");
                int x = int.Parse(Console.ReadLine());
                Console.WriteLine("Y = ;");
                int y = int.Parse(Console.ReadLine());
                shoot1(x, y);
                int m = RNG.Next(10);
                int n = RNG.Next(10);
                shoot2(m, n);
                
                
            } while (score1<ships2.Length && score2<ships1.Length);

            if (score1 > score2)
            {
                Console.SetCursorPosition(0, 25);
                Console.Write("You Win!!");
            }
            else if (score1 < score2)
            {
                Console.SetCursorPosition(0, 25);
                Console.Write("You Lose!!");
            }
            


        }













    }

}
