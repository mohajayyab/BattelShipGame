using Battelship;
using System;

namespace Battelship_new
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Board first = new Board();
            first.loadfile("board1.txt");
            first.loadfile("board2.txt");

            //first.Initialization(10);
            first.placeships1(4);
            first.ship1array();
            first.placeships2();
            first.ship2array();
            first.Visualize();
            first.RunGame();
        }
    }
}
