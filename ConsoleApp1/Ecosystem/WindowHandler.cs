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
        private Timer timer = new Timer();
        public int sizeX = 800;
        public int sizeY = 600;
        private Size buttonSize = new Size(80, 40);
        private Button startSimulation;
        private Button stopSimulation;
        private Button nextStep;
        private int distanceButtons = 40;
        private PictureBox picBox = new PictureBox();
        Creations creations = new Creations();
        Graphics dc;

        public WindowHandler()
        {
            picBox.Dock = DockStyle.Fill;
            picBox.BackColor = Color.White;

            this.Size = new Size(sizeX, sizeY);
            startSimulation = new Button
            {
                Size = buttonSize,
                Location = new Point(sizeX - buttonSize.Width, sizeY - buttonSize.Height + distanceButtons),
                Text = "Start Simulation"
            };
            stopSimulation = new Button
            {
                Size = buttonSize,
                Location = new Point(sizeX - buttonSize.Width, sizeY - buttonSize.Height),
                Text = "Stop Simulation"
            };
            nextStep = new Button
            {
                Size = buttonSize,
                Location = new Point(sizeX - buttonSize.Width, sizeY - buttonSize.Height - distanceButtons),
                Text = "Next Step"
            };


            this.Controls.Add(startSimulation);
            this.Controls.Add(stopSimulation);
            this.Controls.Add(nextStep);
            this.Controls.Add(picBox);
            this.timer.Enabled = true;
            this.timer.Interval = 100;
            startSimulation.Click += new EventHandler(StartSimulationClick);
            stopSimulation.Click += new EventHandler(StopAnimationClick);
            nextStep.Click += new EventHandler(NextStepClick);
        }

        private void CreationsMethods(object sender, PaintEventArgs e)
        {
            dc = e.Graphics;
          //  creations.WriteLogsInConsole();
            base.OnPaint(e);
            creations.PaintAllAnimals(dc);
            creations.PaintAllPlants(dc);
        }

        private void NextStepClick(object sender, EventArgs e)
        {
            this.Refresh();
            this.timer.Stop();
            creations.ecoStructure.Action();
            picBox.Paint += new System.Windows.Forms.PaintEventHandler(CreationsMethods);
        }

        private void StopAnimationClick(object sender, EventArgs e)
        {
            this.Refresh();
            this.timer.Stop();
        }

        private void StartSimulationClick(object sender, EventArgs e)
        {
            if (!timer.Enabled) timer.Start();
            this.timer.Tick += new EventHandler(AnimateClick);
        }

        private void AnimateClick(object sender, EventArgs e)
        {
            this.Refresh();
            creations.ecoStructure.Action();
            picBox.Paint += new System.Windows.Forms.PaintEventHandler(CreationsMethods);
            picBox.Paint -= new System.Windows.Forms.PaintEventHandler(CreationsMethods);
        }


        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // WindowHandler
            // 
            this.ClientSize = new System.Drawing.Size(807, 546);
            this.Name = "WindowHandler";
            this.Text = "Ecosystem simulation";
            this.ResumeLayout(false);

        }
    }
}
