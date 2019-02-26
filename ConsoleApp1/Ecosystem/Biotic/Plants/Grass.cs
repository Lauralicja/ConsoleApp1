using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Ecosystem.Biotic.Plants
{
    class Grass : Plant
    {
        public Grass()
        {
            name = "Grass";
            nutrients = 5.0f;
            speedOfGrowth = 0.5f;
            isAlive = true;
            x = 15;
            y = 15;
        }

    }
}
