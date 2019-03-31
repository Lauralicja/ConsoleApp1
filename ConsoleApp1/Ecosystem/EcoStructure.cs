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
        private int numberOfHerdsDeers = 3;
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

        public int GenerateAlpha()
        {
            return randomizer.Next(0, numberOfHerdsDeers);
        }

        public void CreateAlpha() // only deers now
        {
                Deer doeAlpha = new Deer
                {
                    x = GenerateX(),
                    y = GenerateY(),
                    sex = false,
                    isAlpha = true,
                    age = 7
                };
                world.AddAlphaAnimal(doeAlpha);
        }

        public void CreateHerd()
        {
            for (int i = 0; i < 20; i++)
            {
                bool sex = GenerateSex();
                    Deer deer = new Deer
                    {
                        myAlpha = world.alphaAnimals[GenerateAlpha()],
                        sex = sex,
                        isAlpha = false,
                    };
                deer.NearAlphaX();
                deer.NearAlphaY();
                world.AddAnimal(deer);
            }
        }

        public void CreateLife()
        {
            for(int i = 0; i < numberOfHerdsDeers; i++)
            {
                CreateAlpha();
            }
            CreateHerd();
        }

        public void CreatePlants()
        {
            for (int i = 0; i < 10; i++)
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
                    world.animals[i].StayWithAlpha();
                    world.animals[i].GetHungry();
                    world.animals[i].SearchForEnemies(world);
                    world.animals[i].Hunt(world);
                    world.animals[i].Age(); // TODO: out of range excpetipn when killing
                }
            }

            for (int i = 0; i < world.alphaAnimals.Count; i++)
            {
                world.alphaAnimals[i].WalkAround();
                world.alphaAnimals[i].GetHungry();
                world.alphaAnimals[i].SearchForEnemies(world);
                world.alphaAnimals[i].Hunt(world);
                world.alphaAnimals[i].Age(); // TODO: out of range excpetipn when killing
            }

                for (int i = 0; i < world.plants.Count; i++)
            {
                world.plants[i].Grow(world);
                world.plants[i].Age();
            }
        }






    }
}
