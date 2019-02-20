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
            //            Console.SetBufferSize(130, 30);

            //
            Console.SetWindowSize(80, 25);
            //
            Console.SetBufferSize(80, 25);


            //Класс - это описание однотипных объектов
            //Класс Program становится предельно читаемым, когда мы создаем его из Разных мелких классов
            //Самый плохой вариант, когда мы всё сваливаем в одну функцию, Самый хороший - умные классы, которые все скрывают в своем коде.
            //Инкапсуляция - это упаковка данных или функций в единый компонент, так называемый класс.
            //Инкапсуляция - это механизм, (черный ящик) который объединяет данные и код манипулирующий этими данными, 
            // а так же защищает и то и другое от внешнего вмешательства или неправильного использования
            //Сокрытие - ключевое проявление принципа Инкапсуляции
            //Наследование позволяет создавать новые классы, которые повторно используют, расширяют и изменяют поведение 
            //определенное в других классах (пример, Figure, наследники Snake, HorizontalLine, VerticalLine)
            //Полиморфизм - это ситуация, когда объекты производного класса, могут рассматриваться, как объекты базового класса, 
            // в таких местах как: параметры метода, коллекции или массивы. 
            //Когда это происходит, объявленный тип объекта перестаёт соответствовать своему типу во время выполнения
            // Figure fSnake = new Snake(p,4,Direction.RIGHT);
            // Draw(fSnake);
            // Snake snake = (Snake) fSnake; //Явное приведение типа

            //Также, пример полиморфизма класс Walls

            // List<Figure> figures = new List<Figure>();
            // figures.Add(fSnake);
            // figures.Add(v1);
            // figures.Add(h1);
            // foreach(var f in figures)
            //{
            //    f.Draw();
            //}

            // чтобы была возможность переопределения метода Draw
            // public virtual void Draw()
            // foreach (Point p in pList)
            //{
            //    p.Draw();
            //}
            // в наследнике надо использовать слово override
            // public override void Draw()
            // также можно использовать в классе наследнике реализацию метода из базового класса 
            // base.Draw();


            Walls walls = new Walls(80,25);
            walls.Draw();




            Point p = new Point(4,5,'*');

            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();

            //Рисуем еду на экране
            FoodCreator foodCreator = new FoodCreator(80, 25, '$');
            Point food = foodCreator.CreateFood();
            food.Draw();

            while(true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    break;
                }
                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    food.Draw();
                }
                else
                {
                    snake.Move();
                }

                Thread.Sleep(600);

                if(Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);

                }

                //Thread.Sleep(300);
                //snake.Move();

            }

            Console.ReadLine();
        }

    }


}
