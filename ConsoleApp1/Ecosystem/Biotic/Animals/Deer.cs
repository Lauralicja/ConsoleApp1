using System;
using System.Collections.Generic;
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
                        if (Math.Abs(world.animals[j].x - x) <= 2)
                        {
                           x++;
                        }
                        if (Math.Abs(world.animals[j].y - y) <= 2)
                        {
                            y++;
                        }
                    }
                }
            }

        public override void Hunt(World world) // doubled code -> gotta change it
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
                                x--;
                            }
                            else
                            {
                                x++;
                            }
                            if (y > preyY)
                            {
                                y--;
                            }
                            else
                            {
                                y++;
                            }
                            if(x == preyX && y == preyY)
                            {
                                Eat(world);
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

    }
    }

