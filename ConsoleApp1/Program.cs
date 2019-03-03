using ConsoleApp1.Ecosystem;
using ConsoleApp1.Ecosystem.Biotic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            EcoStructure ecoStructure = new EcoStructure();
            ecoStructure.CreateLife();
            ecoStructure.CreatePlants();


            for (int j = 0; j < 20; j++)
            {
                for (int i = 0; i < ecoStructure.world.animals.Count(); i++) // checking "logs" for each creature
                {
                    Console.WriteLine("Animal: " +
                        ecoStructure.world.animals[i].name + " at: x = " +
                        ecoStructure.world.animals[i].x + ", y = " +
                        ecoStructure.world.animals[i].y + ", sex: " +
                        ecoStructure.world.animals[i].sex + ", hunger: " +
                        ecoStructure.world.animals[i].hunger);
                }

                for (int i = 0; i < ecoStructure.world.plants.Count(); i++)
                {
                    Console.WriteLine("Plant: " +
                        ecoStructure.world.plants[i].name + " at: x = " +
                        ecoStructure.world.plants[i].x + ", y = " +
                        ecoStructure.world.plants[i].y);
                }
                Console.WriteLine("-----------------------------------------");
                ecoStructure.Action();
            }
            Console.ReadLine();
        }
    }
}
