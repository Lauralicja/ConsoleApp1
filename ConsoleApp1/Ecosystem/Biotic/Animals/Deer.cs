using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Ecosystem.Biotic.Animals
{
    class Deer : Animal
    {
        public Deer()
        {
            name = "Deer";
            health = 100.0f;
            attack = 12.0f;
            speed = 70.0f;
            hunger = 120.0f;
            isAlive = true;
            isCarnivore = false;
            x = 20;
            y = 20;
        }
    }
}
