using System;

namespace Battelship
{
    class Ship
    {
        int x;
        int y;
        //char p;
        //int l;

        bool active;
        ConsoleColor color = ConsoleColor.White;
        public int X { get { return x; } }
        public int Y { get { return y; } }
        public ConsoleColor Color { 
            get { return color; }
            set 
            { 
                if(value== ConsoleColor.Red) { color = value; }

            }
        }
        public bool Active
        {    
          set 
            {
                if (value == false)
                {
                    active = value;

                }
            }
            get { return active; }
        }

        
        

        public Ship(int x, int y)
        {
            this.x = x;
            this.y = y;
            //this.p = p;
            //this.l = l;
            active= true;
            this.color= ConsoleColor.White;

        }
    }
}
