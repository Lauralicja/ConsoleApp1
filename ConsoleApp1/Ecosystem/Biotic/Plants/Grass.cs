using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Ecosystem.Biotic.Plants
{
    class Grass : Plant
    {
        Random randomizer = new Random();

        public Grass()
        {
            colour = Brushes.Green;
            name = "Grass";
            nutrients = 5.0f;
            speedOfGrowth = 0.5f;
            isAlive = true;
            x = 15;
            y = 15;
            age = 1;
            hasSeed = 0;
        }

        protected int GenerateDirection()
        {
            return randomizer.Next(0, 5);           // 0 -> N, 1 -> E, 2 -> S, 3 -> W for now
        }


        public override void Grow(World world)
        {
            if(age >= 2)
            {
                hasSeed++;
            }
            if (hasSeed >= 3)
            {
                hasSeed = 0;
                bool canPlant;
                int direction = GenerateDirection();
                if (direction == 0) canPlant = CheckForSpace(world, 0, -1);
                else if (direction == 1) canPlant = CheckForSpace(world, 1, 0);
                else if (direction == 2) canPlant = CheckForSpace(world, 0, 1);
                else canPlant = CheckForSpace(world, -1, 0);

                if (canPlant)
                {
                    Grass smallGrass = new Grass();
                    if (direction == 0) { smallGrass.x = x;  smallGrass.y = y - 1; }
                    else if (direction == 1) { smallGrass.x = x + 1; smallGrass.y = y; }
                    else if (direction == 2) { smallGrass.x = x; smallGrass.y = y + 1; }
                    else { smallGrass.x = x - 1; smallGrass.y = y; }
                    world.AddPlant(smallGrass);
                }

            }
        }


    }
}
