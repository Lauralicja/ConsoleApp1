using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ConsoleApp1.Ecosystem;

namespace ConsoleApp1.Ecosystem
{

    class WindowHandler : Form
    {
        public int sizeX = 600;
        public int sizeY = 400;
        public Button nextStep;
        private List<Rectangle> objects = new List<Rectangle>();
        Creations creations = new Creations();

        public WindowHandler()
        {
            this.Size = new Size(sizeX, sizeY);
            nextStep = new Button
            {
                Size = new Size(80, 40),
                Location = new Point(sizeX, sizeY),
                Text = "Next step"
            };
            this.Controls.Add(nextStep);
            nextStep.Click += new EventHandler(ButtonClick);
            
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            this.Refresh();
            Pen Bluepen = new Pen(Color.Blue, 3);
            Graphics dc = this.CreateGraphics();
            creations.ecoStructure.Action();
            creations.WriteLogsInConsole();
            creations.PaintAllAnimals(dc);
            creations.PaintAllPlants(dc);
        }

        private void ShowNextStep(object sender, PaintEventArgs e)
        {
            foreach (var rectangle in this.objects)
            {
                e.Graphics.DrawRectangle(Pens.Black, rectangle);
            }
        }

        public void MakeSquares(EcoStructure ecostructure)
        {
            int animalCounter = ecostructure.world.animals.Count();
            int plantsCounter = ecostructure.world.plants.Count();

            for(int i = 0; i < animalCounter; i++)
            {
                Rectangle rect = new Rectangle
                {
                    Location = new Point(ecostructure.world.animals[i].x, ecostructure.world.animals[i].y),
                    Size = new Size(10, 10)
                };
                objects.Add(rect);
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Window
            // 
            this.ClientSize = new System.Drawing.Size(900, 550);
            this.Name = "Simulation";
            this.ResumeLayout(false);

        }
    }
}
