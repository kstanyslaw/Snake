using System;
using System.Threading;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int mapWidth = 80;
            int mapHeight = 25;
            bool GameIn = true;
            Console.CursorVisible = false;
            Console.SetBufferSize(mapWidth, mapHeight);

            //Draw PlayGround
            HorisontalLine TopHorisontalLine = new HorisontalLine(0, mapWidth - 1, 0, '═');
            HorisontalLine BottomHorisontalLine = new HorisontalLine(0, mapWidth - 1, mapHeight - 1, '═');
            VerticalLine LeftVerticalLine = new VerticalLine(0, 0, mapHeight - 2, '║');
            VerticalLine RightVerticalLine = new VerticalLine(mapWidth - 1, 0, mapHeight - 2, '║');

            BottomHorisontalLine.Draw();
            TopHorisontalLine.Draw();
            LeftVerticalLine.Draw();
            RightVerticalLine.Draw();

            //Draw Food
            FoodCreator foodCreator = new FoodCreator(mapWidth, mapHeight, '*');
            Point food = foodCreator.Create();
            food.Draw();

            //Draw Snake
            Point p = new Point(38, 13, '#');
            Snake snake = new Snake(p, 3, Direction.RIGHT);
            snake.Draw();

            while (GameIn)
            {
                if (snake.Crash(mapWidth, mapHeight) || snake.TouchItself())
                {
                    GameOver();
                    GameIn = false;
                }
                if (snake.Eat(food))
                {
                    food = foodCreator.Create();
                    food.Draw();
                    snake.Grow();
                }

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    snake.HandleKey(key.Key);
                }
                Thread.Sleep(200);
                snake.Move();
            }
            Console.ReadLine();
        }

        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void GameOver()
        {
            int x = 15;
            int y = 10;
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition(x, y);
            Console.WriteLine("  @@@   @@   @   @  @@@@     @@@   @   @  @@@@  @@@  ");
            Console.SetCursorPosition(x, y+1);
            Console.WriteLine(" @     @  @  @@ @@  @       @   @  @   @  @     @  @ ");
            Console.SetCursorPosition(x, y+2);
            Console.WriteLine(" @ @@  @  @  @@ @@  @@@@    @   @  @   @  @@@@  @@@  ");
            Console.SetCursorPosition(x, y+3);
            Console.WriteLine(" @  @  @@@@  @ @ @  @       @   @   @ @   @     @ @  ");
            Console.SetCursorPosition(x, y+4);
            Console.WriteLine(" @@@@  @  @  @   @  @@@@     @@@     @    @@@@  @  @ ");
        }
    }
}
