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
        private static bool tmoove = true;

        static void Main(string[] args)
        {
            GraphicsWindow.KeyDown += GraphicsWindow_KeyDown;
            Turtle.PenUp();

            GraphicsWindow.BrushColor = "Green";
            var eat = Shapes.AddRectangle(10, 10);
            Shapes.Move(eat, 200, 200);
            while (tmoove == true)
            {
                Turtle.Move(1);
            }

        }

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
