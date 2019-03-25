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
        private Timer timer1 = new Timer();
        public int sizeX = 300;
        public int sizeY = 200;
        private Size buttonSize = new Size(80, 40);
        private Button startSimulation;
        private Button stopSimulation;
        private Button nextStep;
        Creations creations = new Creations();
        Graphics dc;

        public WindowHandler()
        {
            dc = this.CreateGraphics();
            this.Size = new Size(2*sizeX, 2*sizeY);
            startSimulation = new Button
            {
                Size = buttonSize,
                Location = new Point(sizeX, sizeY),
                Text = "Start Simulation"
            };
            stopSimulation = new Button
            {
                Size = buttonSize,
                Location = new Point(sizeX, sizeY + 40),
                Text = "Stop Simulation"
            };
            nextStep = new Button
            {
                Size = buttonSize,
                Location = new Point(sizeX, sizeY + 80),
                Text = "Next Step"
            };


            this.Controls.Add(startSimulation);
            this.Controls.Add(stopSimulation);
            this.Controls.Add(nextStep);
            this.timer1.Enabled = true;
            this.timer1.Interval = 100;
            startSimulation.Click += new EventHandler(TimerClick); // works for timer rach 0.1 second
            stopSimulation.Click += new EventHandler(StopAnimationClick);
            nextStep.Click += new EventHandler(NextStepClick);
        }

        private void CreationsMethods()
        {
            creations.WriteLogsInConsole();
            creations.PaintAllAnimals(dc);
            creations.PaintAllPlants(dc);
        }

        private void NextStepClick(object sender, EventArgs e)
        {
            this.Refresh();
            this.timer1.Stop();
            creations.ecoStructure.Action();
            CreationsMethods();
        }

        private void StopAnimationClick(object sender, EventArgs e)
        {
            this.Refresh();
            this.timer1.Stop();
            CreationsMethods();
        }

        private void TimerClick(object sender, EventArgs e)
        {
            if (!timer1.Enabled) timer1.Start();
            this.timer1.Tick += new EventHandler(ButtonClick);
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            this.Refresh();
            creations.ecoStructure.Action();
            CreationsMethods();
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
