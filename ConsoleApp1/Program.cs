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

            for (int i = 0; i < ecoStructure.animals.Count(); i++) // sprawdzanko czy ładzia
            {
                Console.WriteLine("Animal: " +
                    ecoStructure.animals[i].name + " at: x = " +
                    ecoStructure.animals[i].x + ", y = " +
                    ecoStructure.animals[i].y);
            }

            for (int i = 0; i < ecoStructure.plants.Count(); i++)
            {
                Console.WriteLine("Plant: " +
                    ecoStructure.plants[i].name + " at: x = " +
                    ecoStructure.plants[i].x + ", y = " +
                    ecoStructure.plants[i].y);
            }

            Console.ReadLine();
        }
    }
}
