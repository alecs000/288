using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _28
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            timer1.Start();
            timer1.Interval = 150;
        }
        public int loc;
        public int sch=0;
        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode.ToString())
            {
                case "Right":
                    loc = 1;
                    break;
                case "Left":
                    loc = 2;
                    break;
                case "Up":
                    loc = 3;
                    break;
                case "Down":
                    loc = 4;
                    break;

            }
        }
        int x = 0;
        int y = 0;
        int x1 = 0;
        int y1 = 0;
        int fx = 0;
        int fy = 0;
        PictureBox[] snake = new PictureBox[400];
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pictureBox1.Location.X>725|| pictureBox1.Location.X < 0 || pictureBox1.Location.Y > 425 | pictureBox1.Location.X < 0 )
            {
                throw new Exception("GTAME OVER!");
            }
            if (pictureBox2.Location.X< pictureBox1.Location.X+15 && pictureBox2.Location.X > pictureBox1.Location.X - 15&& pictureBox2.Location.Y < pictureBox1.Location.Y + 15 && pictureBox2.Location.Y > pictureBox1.Location.Y - 15)
            {
                int p1 = panel1.Size.Width;
                int p2 = panel1.Size.Height;
                int s1 = pictureBox2.Size.Width;
                int s2 = pictureBox2.Size.Height;
                

                Random rnd = new Random();
                pictureBox2.Location = new Point(rnd.Next(p1 - s1), rnd.Next(p2 - s2));

                pictureBox2.Visible = true;
                PictureBox pct = new PictureBox();
                pct.Height = 25;
                pct.Width = 25;
                pct.Name = "pct" + sch;
                pct.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y);
                pct.BackColor = Color.Aqua;
                panel1.Controls.Add(pct);
                snake[sch] = pct;
                sch++;

            }
            for (int i = 0; i < sch; i++)
            {

                
                if (i != 0)
                {
                    snake[i].Location = new Point(x1, y1);
                }




                x1 = snake[i].Location.X;
                y1 = snake[i].Location.Y;

                PictureBox p = panel1.Controls["pct" + 0] as PictureBox;

                x = p.Location.X;
                y = p.Location.Y;
                p.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y);




            }

            switch (loc)
            {
                case 1:
                    pictureBox1.Location = new Point(pictureBox1.Location.X + 25, pictureBox1.Location.Y );
                    fx = -25;
                    fy = 0;
                    break;
                case 2:
                    pictureBox1.Location = new Point(pictureBox1.Location.X - 25, pictureBox1.Location.Y);
                    fx = 25;
                    fy = 0;
                    break;
                case 3:
                    pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y - 25);
                    fy = 25;
                    fx = 0;
                    break;
                case 4:
                    pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y + 25);
                    fy = -25;
                    fx = 0;
                    break;

            }
           
        }
        
    }
}
