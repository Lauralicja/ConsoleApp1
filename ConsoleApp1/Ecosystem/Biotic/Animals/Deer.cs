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
            colour = Brushes.Brown;
            name = "Deer";
            health = 100.0f;
            attack = 12.0f;
            speed = 70.0f;
            hunger = 120.0f;
            isAlive = true;
            isCarnivore = false;
            random = new Random();
        }


        override public void SearchForEnemies(World world)
        {
            int size = world.animals.Count();
                for (int j = 0; j < size; j++)
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
                // Find closest prey
                Plant closestPrey = FindClosestPlant(world);
                if (closestPrey != null) {
                    // Follow horizontally
                    if (x > closestPrey.x) {
                        if (x != 1) x--;
                    } else {
                        if (x != world.sizeX) x++;
                    }

                    // Follow vertically
                    if (y > closestPrey.y) {
                        if (y != 1) y--;
                    } else {
                        if (y != world.sizeY) y++;
                    }

                    // Eat
                    if (x == closestPrey.x && y == closestPrey.y) {
                        Eat();
                        world.plants.Remove(closestPrey);
                    }
                }
            }
        }

        override public void Eat()
        {
            hunger += 10;
        }

        override public void GetHungry()
        {
            hunger -= 0.5f;
        }

    }
    }

