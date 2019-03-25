using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Ecosystem.Biotic.Animals
{
    class Deer : Animal
    {

        public Deer()
        {
            name = "Deer";
            health = 100.0f;
            attack = 12.0f;
            speed = 70.0f;
            hunger = 120.0f;
            isAlive = true;
            isCarnivore = false;
        }


        override public void SearchForEnemies(World world)
        {
                for (int j = 0; j < world.animals.Count; j++)
                {
                    if (world.animals[j].name == "Wolf")
                    {
                        if (Math.Abs(world.animals[j].x - x) <= 10)
                        {
                           x++;
                        }
                        if (Math.Abs(world.animals[j].y - y) <= 10)
                        {
                            y++;
                        }
                    }
                }
            }

        public override void Hunt(World world) // duplicated code -> gotta change it
        {
            if (hunger <= 80.0f)
            {
                int closest = 0;
                for (int j = 0; j < world.plants.Count; j++)
                {
                    int preyX = world.plants[j].x;
                    int preyY = world.plants[j].y;

                    if (world.plants[j].name == "Grass") // im pretty sure they don't eat grass, just for the sake of checking 
                    {
                        double distance = Math.Pow(preyX - x, 2) + Math.Pow(preyY - y, 2);
                        if (Math.Pow(preyX - x, 2) + Math.Pow(preyY - y, 2) >= closest) // temporary -> without any obstacles and in straight line
                        {
                            closest = (int)distance;
                            if (x > preyX)
                            {
                                if (x == 1) x = 1;
                                else x--;
                            }
                            else
                            {
                                if (x == world.sizeX) x = world.sizeX;
                                else x++;
                            }
                            if (y > preyY)
                            {
                                if (y == 1) y = 1;
                                else y--;
                            }
                            else
                            {
                                if (y == world.sizeY) y = world.sizeY;
                                else y++;
                            }
                            if (x == preyX && y == preyY)
                            {
                                Eat(world);
                                world.plants.Remove(world.plants[j]);
                            }
                        }
                    }
                }
            }
        }

        override public void Eat(World world)
        {
            hunger += 10;
        }

        override public void GetHungry()
        {
            hunger -= 5;
        }

        public override void PaintAnimal(Graphics graphics)
        {
            Rectangle rectangle = new Rectangle(x, y, 10, 10);
            graphics.DrawRectangle(Pens.Brown, rectangle);
            graphics.FillRectangle(Brushes.Brown, rectangle);
        }

    }
    }

