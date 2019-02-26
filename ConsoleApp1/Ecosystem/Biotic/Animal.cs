using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Ecosystem.Biotic
{
    class Animal
    {
        public Animal() { }

        public int x;
        public int y;
        public bool isAlive;
        public bool isCarnivore;
        public string name;
        public float health;
        public float attack;
        public float speed;
        public float hunger;

        public void GetHungry()
        {
            hunger -= 10;
        }

        protected void Eat(Animal prey)
        {
            prey.isAlive = false;
            hunger += 10;
        }

        protected void Eat(Plant plant)
        {
            
        }

        protected void Die()
        {
            isAlive = false;
        }



    }
}
