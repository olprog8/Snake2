using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Snake2
{
    //Абстрагирование, выделение значимых характеристик объекта, исключение из рассмотрения незначимых
    class Snake : Figure
    {
        Direction direction;

        public Snake(Point tail, int lenght, Direction _direction)
        {
            //Храним данные направления в котором Змейка должна двигаться, которые передаются
            direction = _direction;

            pList = new List<Point>();

            for (int i = 0; i < lenght; i++)
            {
                Point p = new Point(tail);
                p.Move(i, direction);

                pList.Add(p);
            }
        }

        internal void Move()
        {
            //встроенный метод класса List
            Point tail = pList.First();
            pList.Remove(tail);

            Point head = GetNextPoint();
            pList.Add(head);

            tail.Clear();
            head.Draw();

        }

        public Point GetNextPoint()
        {
            Point head = pList.Last();

            //Копия предыдущего расположения головы
            Point nextPoint = new Point(head);
            nextPoint.Move(1, direction);
            return nextPoint;
        }

        public void HandleKey(ConsoleKey key)
        {
            if (key == ConsoleKey.LeftArrow)
                direction = Direction.LEFT;
            if (key == ConsoleKey.RightArrow)
                direction = Direction.RIGHT;
            if (key == ConsoleKey.UpArrow)
                direction = Direction.UP;
            if (key == ConsoleKey.DownArrow)
                direction = Direction.DOWN;
        }

    }
}
