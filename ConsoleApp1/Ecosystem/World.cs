using ConsoleApp1.Ecosystem.Biotic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ConsoleApp1.Ecosystem
{
    class World
    {
        public int sizeX = 150;
        public int sizeY = 150;
        public List<Animal> animals = new List<Animal>();
        public List<Plant> plants = new List<Plant>();

        public void AddAnimal(Animal animal)
        {
            animals.Add(animal);
        }

        public void AddPlant(Plant plant)
        {
            plants.Add(plant);
        }



    }
}
