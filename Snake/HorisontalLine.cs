using System.Collections.Generic;

namespace Snake
{
    class HorisontalLine : Figure
    {
        public HorisontalLine(int xLeft, int xRight, int y, char sym )
        {
            pList = new List<Point>();
            
            for (int x = xLeft; x < xRight; x++)
                {
                    Point p = new Point(x, y, sym);
                    pList.Add(p);
                }
        }
    }
}
