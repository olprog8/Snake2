using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Snake2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetBufferSize(130, 30);
            //Console.SetWindowSize(1, 1);
            //Console.SetBufferSize(80, 25);

            //Класс Program становится предельно читаемым, когда мы создаем его из Разных мелких классов
            //Самый плохой вариант, когда мы всё сваливаем в одну функцию, Самый хороший - умные классы, которые все скрывают в своем коде.

            //Отрисовка линий
            HorizontalLine upLine = new HorizontalLine(0, 78, 0,'+');
            HorizontalLine downLine = new HorizontalLine(0, 78, 24, '+');

            VerticalLine leftLine = new VerticalLine(0, 24, 0, '+');
            VerticalLine rightLine = new VerticalLine(0, 24, 78, '+');


            upLine.Draw();
            downLine.Draw();
            leftLine.Draw();
            rightLine.Draw();

            Point p = new Point(4,5,'*');

            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();

            //Рисуем еду на экране
            FoodCreator foodCreator = new FoodCreator(80, 25, '$');
            Point food = foodCreator.CreateFood();
            food.Draw();

            while(true)
            {
                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    food.Draw();
                }
                else
                {
                    snake.Move();
                }

                Thread.Sleep(500);

                if(Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);

                }

                Thread.Sleep(300);
                snake.Move();

            }

            Console.ReadLine();
        }

    }
}
