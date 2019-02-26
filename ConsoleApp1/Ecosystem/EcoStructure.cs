using ConsoleApp1.Ecosystem.Biotic;
using ConsoleApp1.Ecosystem.Biotic.Animals;
using ConsoleApp1.Ecosystem.Biotic.Plants;
using System;
using System.Collections.Generic;


namespace ConsoleApp1.Ecosystem
{
    class EcoStructure
    {

        public List<Animal> animals = new List<Animal>();
        public List<Plant> plants = new List<Plant>();
        Random randomizer = new Random();

        public int CreateAnimal()
        {
            return randomizer.Next(0, 2);
        }

        public void CreateLife()
        {
            for (int i = 0; i < 10; i++)
            {
                int which = CreateAnimal();
                Wolf wolf = new Wolf();
                Deer deer = new Deer();
                Grass grass = new Grass();

                if (which == 0) animals.Add(wolf);
                else animals.Add(deer);
                plants.Add(grass);
            }
        }






    }
}
