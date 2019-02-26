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
            hunger = 120.0f;
            isAlive = true;
            isCarnivore = true;
            x = 10;
            y = 10;
         }


    }
}
