using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Ecosystem.Biotic.Animals
{
    class Wolf : Animal
    {
       
        public Wolf()
        {
            name = "Wolf";
            health = 100.0f;
            attack = 12.0f;
            speed = 48.0f;
            hunger = 80.0f;
            isAlive = true;
            isCarnivore = true;
         }

        public override void Hunt(World world)
        {
            if(hunger <= 60.0f)
            {
                int closest = 0;
                for (int j = 0; j < world.animals.Count; j++)
                {
                    int preyX = world.animals[j].x;
                    int preyY = world.animals[j].y;
                    if (world.animals[j].name == "Deer")
                    {
                        if (Math.Pow(preyX - x, 2) + Math.Pow(preyY - y, 2) >= closest) // temporary -> without any obstacles and in straight line
                        {
                            if(x > preyX)
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
            hunger += 25;
        }

        override public void GetHungry()
        {
            hunger -= 10;
        }


    }
}
