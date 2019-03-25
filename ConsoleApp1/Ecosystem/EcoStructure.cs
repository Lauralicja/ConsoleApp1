using ConsoleApp1.Ecosystem.Biotic;
using ConsoleApp1.Ecosystem.Biotic.Animals;
using ConsoleApp1.Ecosystem.Biotic.Plants;
using System;
using System.Collections.Generic;


namespace ConsoleApp1.Ecosystem
{
    class EcoStructure
    {
        public World world = new World();
        Random randomizer = new Random();

        public int CreateAnimal()
        {
            return randomizer.Next(0, 2);
        }

        public int GenerateX()
        {
            return randomizer.Next(1, world.sizeX);
        }

        public int GenerateY()
        {
            return randomizer.Next(1, world.sizeY);
        }

        public bool GenerateSex()
        {
            int which = randomizer.Next(0, 2);
            if (which == 0) return false;
            else return true;
        }

        public void CreateLife()
        {
            for (int i = 0; i < 4; i++)
            {
                int which = CreateAnimal();
                Wolf wolf = new Wolf();
                Deer deer = new Deer();

                int x = GenerateX();
                int y = GenerateY();
                bool sex = GenerateSex();

                if (which == 0)
                {
                    wolf.x = x;
                    wolf.y = y;
                    wolf.sex = sex; 
                    world.AddAnimal(wolf);
                }
                else
                {
                    deer.x = x;
                    deer.y = y;
                    deer.sex = sex;
                    world.AddAnimal(deer);
                }
            }
        }

        public void CreatePlants()
        {
            for (int i = 0; i < 1; i++)
            {
                Grass grass = new Grass();

                int x = GenerateX();
                int y = GenerateY();

                grass.x = x;
                grass.y = y;
                world.plants.Add(grass);
            }
        }



        public void Action()
        {
            for(int i  = 0; i < world.animals.Count; i++)
            {
                if (world.animals[i].isAlive)
                {
                    world.animals[i].GetHungry();
                    world.animals[i].SearchForEnemies(world);
                    world.animals[i].Hunt(world);
                    world.animals[i].Age();
                }
            }
            for(int i = 0; i < world.plants.Count; i++)
            {
                world.plants[i].Grow(world);
                world.plants[i].Age();
            }
        }






    }
}
