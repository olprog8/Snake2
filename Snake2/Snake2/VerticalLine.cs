using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake2
{
    //Наследование - это созвучно с понятием ЯВЛЯЕТСЯ частью
    class VerticalLine : Figure
    {

        public VerticalLine(int yFirst, int yLast, int x, char sym)
        {

            pList = new List<Point>();

            for (int y = yFirst; y <= yLast; y++)
            {
                Point p = new Point(x, y, sym);
                pList.Add(p);
            }

        }

    }
}
