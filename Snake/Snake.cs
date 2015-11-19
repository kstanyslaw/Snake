using System;
using System.Collections.Generic;
using System.Linq;

namespace Snake
{
    class Snake : Figure
    {
        private Direction direction;

        public int lenth;

        public Snake(Point tail, int lenth, Direction direction)
        {
            this.direction = direction;
            this.lenth = lenth;
            pList = new List<Point>();
            for (int i = 0; i < lenth; i++)
            {
                Point p = new Point(tail);
                p.Move(i, direction);
                pList.Add(p);
            }
        }

        internal void Grow()
        {
            Point head = GetNextPoint();
            pList.Add(head);
            lenth = lenth + 1;

            head.Draw();
        }

        internal void Move()
        {
            Point tail = pList.First();
            pList.Remove(tail);
            Point head = GetNextPoint();
            pList.Add(head);

            tail.Clear();
            head.Draw();
        }

        private Point GetNextPoint()
        {
            Point head = pList.Last();
            Point nextPoint = new Point(head);
            nextPoint.Move(1, direction);

            return nextPoint;
        }

        internal void HandleKey(ConsoleKey key)
        {
            if (key == ConsoleKey.LeftArrow)
            {
                direction = Direction.LEFT;
            }
            else if (key == ConsoleKey.RightArrow)
            {
                direction = Direction.RIGHT;
            }
            else if (key == ConsoleKey.UpArrow)
            {
                direction = Direction.UP;
            }
            else if (key == ConsoleKey.DownArrow)
            {
                direction = Direction.DOWN;
            }
//
            else if (key == ConsoleKey.A)
            {
                direction = Direction.LEFT;
            }
            else if (key == ConsoleKey.D)
            {
                direction = Direction.RIGHT;
            }
            else if (key == ConsoleKey.W)
            {
                direction = Direction.UP;
            }
            else if (key == ConsoleKey.S)
            {
                direction = Direction.DOWN;
            }
        }

        internal bool TouchItself()
        {
            Point head = GetNextPoint();

            foreach (Point p in pList)
            {
                if (head.IsHit(p))
                {
                    return true;
                }
            }
            return false;
        }

        internal bool Crash(int mapWidth, int mapHeight)
        {
            mapWidth = mapWidth - 1;
            mapHeight = mapHeight - 2;

            Point head = GetNextPoint();
            Point top = new Point(head.x, 0, '=');
            Point bottom = new Point(head.x, mapHeight, '=');
            Point left = new Point(0, head.y, '|');
            Point right = new Point(mapWidth, head.y, '|');

            if (head.IsHit(top) || head.IsHit(bottom) || head.IsHit(left) || head.IsHit(right))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal bool Eat(Point food)
        {
            Point head = GetNextPoint();
            if (head.IsHit(food))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
