using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Ecosystem.Biotic
{
    class Animal
    {
        public Animal()
        {

        }

        public int x { get; set; }
        public int y { get; set; }
        public bool isAlive { get; set; }
        public bool isCarnivore { get; set; }
        public string name { get; set; }
        public float health { get; set; }
        public float attack { get; set; }
        public float speed { get; set; }
        public int age { get; set; }
        public bool sex { get; set; } // 0 - female, 1 - male
        public float hunger { get; set; }

        virtual public void GetHungry()
        {
        }

        virtual public void Hunt(World world)
        {
        }

        virtual public void Eat(World world)
        {
        }

        protected void Die()
        {
            isAlive = false;
        }

        virtual public void SearchForEnemies(World world)
        {        
        }


    }
}
