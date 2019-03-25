using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Ecosystem
{
    class Creations
    {
        public EcoStructure ecoStructure = new EcoStructure();
        public Creations()
        {
            ecoStructure.CreateLife();
            ecoStructure.CreatePlants();
        }

        public void WriteLogsInConsole()
        {
            //for (int j = 0; j < 20; j++)
            //{
            for (int i = 0; i < ecoStructure.world.animals.Count(); i++) // checking "logs" for each creature
            {
                Console.WriteLine("Animal " + i + ".: " +
                        ecoStructure.world.animals[i].name + " at: x = " +
                        ecoStructure.world.animals[i].x + ", y = " +
                        ecoStructure.world.animals[i].y + ", sex: " +
                        ecoStructure.world.animals[i].sex + ", hunger: " +
                        ecoStructure.world.animals[i].hunger);
                }

            for (int i = 0; i < ecoStructure.world.plants.Count(); i++)
            {
                Console.WriteLine("Plant " + i + ".: " +
                        ecoStructure.world.plants[i].name + " at: x = " +
                        ecoStructure.world.plants[i].x + ", y = " +
                        ecoStructure.world.plants[i].y + ", age = " +
                        ecoStructure.world.plants[i].age);
                }
                Console.WriteLine("-----------------------------------------");
            //    ecoStructure.Action();
          //  }
        }

        public void PaintAllAnimals(Graphics g)
        {
            foreach (var animal in ecoStructure.world.animals)
            {
                animal.PaintAnimal(g);
            }
        }

        public void PaintAllPlants(Graphics g)
        {
            foreach (var plant in ecoStructure.world.plants)
            {
                plant.PaintPlant(g);
            }
        }

    }
}
