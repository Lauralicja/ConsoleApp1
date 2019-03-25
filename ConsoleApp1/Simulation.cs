using ConsoleApp1.Ecosystem;
using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Forms;

namespace ConsoleApp1
{
    class Simulation
    {
        [STAThread]
        static void Main(string[] args)
        {
            WindowHandler windowHandler = new WindowHandler();
            Application.EnableVisualStyles();
            Application.Run(windowHandler);

            Console.ReadLine();
        }

    }
}
