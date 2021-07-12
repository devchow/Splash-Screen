using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Splash_Screen
{
    public partial class Form1 : Form
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        // Form Round Corner Values
        private static extern IntPtr CreateRoundRectRgn
            (
                int nLeftRect,
                int nTopRect,
                int nRightRect,
                int nBottomRect,
                int nWidthEllipse,
                int nHeightEllipse
            );

        public Form1()
        {
            // Make Form have Round corners
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0,0,Width, Height, 25,25));
            progressBar1.Value = 0;
        }

        private void circularProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Add ProgressBar Value using Timer
            progressBar1.Value += 1;
            progressBar1.Text = progressBar1.Value.ToString() + '%';

            // Do this if progress loads to 100%
            if (progressBar1.Value == 100)
            {
                timer1.Enabled = false; // Disable Timer

                SecondScreen form2 = new SecondScreen(); // Get New Form
                form2.Show(); // Show the Second Screen
                this.Hide(); // Hide the Progress Screen
            }
        }
    }
}
