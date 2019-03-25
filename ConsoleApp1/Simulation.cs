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
            
           // creations.WriteLogsInConsole();
            
            WindowHandler windowHandler = new WindowHandler();
            // windowHandler.MakeSquares(ecoStructure);
            Application.EnableVisualStyles();
            Application.Run(windowHandler);

            Console.ReadLine();
        }

    }
}
