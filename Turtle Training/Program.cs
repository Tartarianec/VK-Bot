using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SmallBasic.Library;

namespace Turtle_Training
{
    class Program
    {
        
        static void Main(string[] args)
        {
            GraphicsWindow.KeyDown += GraphicsWindow_KeyDown;
            Turtle.PenUp();
            GraphicsWindow.BrushColor = "Green";            
            var eat = Shapes.AddRectangle(10, 10);
            int x, y, life=3;
            int score =0;
            Random rand = new Random();
            x = rand.Next(0, GraphicsWindow.Width);
            y = rand.Next(0, GraphicsWindow.Height);
            Shapes.Move(eat, x, y);            
            while (life>0)
            {
                Turtle.Move(1);
                if (Turtle.X >= x && Turtle.X <= x + 10 && Turtle.Y >= y && Turtle.Y <= y + 10)
                {
                    x = rand.Next(0, GraphicsWindow.Width);
                    y = rand.Next(0, GraphicsWindow.Height);
                    Shapes.Move(eat, x, y);
                    Turtle.Speed++;
                    score++;
                    
                    GraphicsWindow.DrawText(GraphicsWindow.Width - 100, GraphicsWindow.Height - 100, score);
                }
                else if (Turtle.X < 0 || Turtle.X>GraphicsWindow.Width || Turtle.Y < 0 || Turtle.Y > GraphicsWindow.Height) 
                {
                    Turtle.X = GraphicsWindow.Width / 2;
                    Turtle.Y = GraphicsWindow.Height / 2;
                    life--;
                }
            }            
        }

        //Обработка нажатий клавиш
        private static void GraphicsWindow_KeyDown()        
        {
            if (GraphicsWindow.LastKey == "Up")
            {
                Turtle.Angle = 0;
            }
            else if(GraphicsWindow.LastKey == "Right")
            {
                Turtle.Angle = 90;
            }
            else if(GraphicsWindow.LastKey == "Down")
            {
                Turtle.Angle = 180;
            }
            else if(GraphicsWindow.LastKey == "Left")
            {
                Turtle.Angle = 270;
            }
            else if (GraphicsWindow.LastKey == "Escape")
            {
                Environment.Exit(0);              
            }       
               
        } 
    }
}
