﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows;

namespace ConsoleApp1.Ecosystem.Biotic
{
    class Animal
    {
        public Animal()
        {

        }
        public static Random random;
        public Brush colour { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public bool isAlive { get; set; }
        public bool isCarnivore { get; set; }
        public string name { get; set; }
        public float health { get; set; }
        public float attack { get; set; }
        public float speed { get; set; }
        public int age { get; set; }
        public bool sex { get; set; } // 0 - female, 1 - male
        public float hunger { get; set; }
        public bool isAlpha { get; set; }
        public Animal myAlpha { get; set; }




        virtual public void GetHungry()
        {
        }

        virtual public void Hunt(World world)
        {
        }

        virtual public void Eat()
        {
        }


        virtual public void Age()
        {
            age++;
        }

        public void WalkAround()
        {
            int xc = random.Next(0, 2); // 0 - nothing, 1 - E, 2 - W
            int yc = random.Next(0, 2); // 0 - nothing, 2 - S, 1 - N
            if (xc == 2) x -= 1;
            else x += xc;
            if (yc == 2) y -= 1;
            else y += yc;
        }

        protected void Die()
        {
            isAlive = false;
        }

        virtual public void SearchForEnemies(World world)
        {        
        }

        public void NearAlphaX()
        {
            x = random.Next(myAlpha.x - 5, myAlpha.x + 5);
        }

        public void NearAlphaY()
        {
           y = random.Next(myAlpha.y - 5, myAlpha.y + 5);
        }

        public void PaintAnimal(Graphics graphics)
        {
            Rectangle rectangle = new Rectangle(x, y, 3, 3);
            if (isAlpha) colour = Brushes.Red;
            Pen pen = new Pen(colour);
            graphics.DrawRectangle(pen, rectangle);
            graphics.FillRectangle(colour, rectangle);
        }

        virtual public void StayWithAlpha()
        {
            Follow(myAlpha.x, myAlpha.y);
        }

        private void Follow(int x, int y)
        {
            if(this.x == x) // they are already in the same vertical line
            {
                if (this.y < y) this.y++;
                else this.y--;
            }
            if (this.y == y) // they are already in the same horizontal line
            {
                if (this.x < x) this.x++;
                else this.x--;
            }
            else // not either -> 3 options: go vertically, horizontally or diagonally
            {
                int temp = random.Next(0, 4);
                if(temp == 0) // go vertically
                {
                    if (this.y < y) this.y++;
                    else this.y--;
                }
                else if (temp == 1) // go horizontally
                {
                    if (this.x < x) this.x++;
                    else this.x--;
                }
                else
                {
                    if (this.y < y)
                    {
                        if (this.x < x) { this.x++; this.y++; }
                        else { this.x--; this.y++; }
                    }
                    else
                    {
                        if (this.x < x) { this.x++; this.y--; }
                        else { this.x--; this.y--; }

                    }
                }

            }
        }
    }
}
