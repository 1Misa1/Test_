using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form1 : Form
    {
        bool a, d, j, k;

        Snake player1;
        Snake player2;

        PictureBox snake1;
        List<PictureBox> snake1tail;

        PictureBox snake2;
        List<PictureBox> snake2tail;

        Point startPoint1;
        Point startPoint2;

        Timer timer;
       
        public Form1()
        {
            InitializeComponent();

            VytvorHady();

            timer = new Timer();
            timer.Interval = 30;
            timer.Tick += Timer_Tick;

            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown1;
            this.KeyUp += Form1_KeyUp1;
        }

        private void Form1_KeyUp1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                a = false;
            }
            else if (e.KeyCode == Keys.D)
            {
                d = false;
            }

            if (e.KeyCode == Keys.J)
            {
                j = false;
            }
            else if (e.KeyCode == Keys.K)
            {
                k = false;
            }
        }

        private void pause_Click(object sender, EventArgs e)
        {
            timer.Enabled = !timer.Enabled;
            if (timer.Enabled)
            {
                pause.Text = "Pause";
            }
            else
            {
                pause.Text = "Play";
            }
        }

        private void quit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_KeyDown1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                a = true;
            }
            else if (e.KeyCode == Keys.D)
            {
                d = true;
            }

            if (e.KeyCode == Keys.J)
            {
                j = true;
            }
            else if (e.KeyCode == Keys.K)
            {
                k = true;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (a)
            {
                player1.Left();
            }
            if (d)
            {
                player1.Right();
            }
            if (j)
            {
                player2.Left();
            }
            if (k)
            {
                player2.Right();
            }
            this.Text = player1.Direction.ToString();

            snake1tail.Add(snake1);
            player1.Forward();
            snake1 = player1.GetSnake(Color.DarkBlue, 15);
            this.Controls.Add(snake1);

            

            snake2tail.Add(snake2);
            player2.Forward();
            player2.GetSnake(Color.Red, 15);
            this.Controls.Add(snake2);
        }

        private void VytvorHady()
        {
            startPoint1 = new Point(10,10);
            startPoint2 = new Point(ClientSize.Width - 10,10);

            player1 = new Snake(startPoint1);
            player1.Speed = 2;
            snake1tail = new List<PictureBox>();
            snake1 = player1.GetSnake(Color.DarkBlue, 15);
            this.Controls.Add(snake1);


            player2 = new Snake(startPoint2);
            player2.Speed = 2;
            snake2tail = new List<PictureBox>();
            snake2 = player1.GetSnake(Color.Red, 15);
            this.Controls.Add(snake2);
        }
        
    }

}
