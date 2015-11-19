using System.Collections.Generic;

namespace Snake
{
    class Walls
    {
        List<Figure> walls;

        public Walls(int mapWidth, int mapHeight)
        {
            //HorisontalLine Top = new HorisontalLine(0, mapWidth - 1, 0, '=');
            //HorisontalLine Bottom = new HorisontalLine(0, mapWidth - 1, mapHeight - 1, '=');
            VerticalLine Left = new VerticalLine(0, 0, mapHeight - 2, '║');
            VerticalLine Right = new VerticalLine(mapWidth - 1, 0, mapHeight - 2, '║');
        }
    }
}
