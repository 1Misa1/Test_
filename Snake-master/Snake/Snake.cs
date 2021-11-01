using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Snake
{
    class Snake
    {
        public List<Point> Tail {get; set;}
        public Point Head {get; set;}
        public double Speed { get; set; }
        public double Direction { get; set; }

        public Snake()
        {
            Head = new Point();
            Tail = new List<Point>();
            
        }

        public Snake(Point head)
        {
            Head = head;
            Tail = new List<Point>();
        }

         public void Forward()
        {
            Tail.Add(Head);
            var x = Speed * Math.Cos(Direction);
            var y = Speed * -Math.Sin(Direction);
            Head = new Point(Tail[Tail.Count - 1].X + Convert.ToInt32(Math.Round(x)),
                            Tail[Tail.Count - 1].Y + Convert.ToInt32(Math.Round(y)));
        }
        public void Left()
        {
            Direction += 0.1;
        }
        public void Right()
        {
            Direction -= 0.1;
        }

        public PictureBox GetSnake(Color color, int size)
        {
            //PictureBox pictureBoxes = new PictureBox();
            //var halfSize = Size / 2F; /// To F za 2 slouží k převodu na číslo float  je to jako float halfSize = size / 2

            //foreach (var point in Tail)
            //{
            //pictureBoxes = new PictureBox() { Location = new , BackColor = color, Height = Size, Width = Size};
            var pictureBoxes = new PictureBox();
            pictureBoxes.Width = size;
            pictureBoxes.Height = size;
            pictureBoxes.BackColor = color;
            pictureBoxes.Location = Head;

            //}
            return pictureBoxes;
        }
    }
}

/// Úkol ----- Oba hadi pojedou, třída nahradí prototajp, Tlačítko pause, pustit, restart - hadi se vrátí na začátek
/// Bonus ----- sražení hadů, reakce, 

