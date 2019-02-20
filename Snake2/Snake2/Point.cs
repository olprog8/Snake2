using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake2
{
    //Классы, например, Point ничего не знает о внешнем мире
    //p, food, является объектом класса Point
    
    class Point
    {
        //Поля класса
        public int x;
        public int y;
        public char sym;

        public Point(int _x, int _y, char _sym)
        {
            x = _x;
            y = _y;
            sym = _sym;
        }

        public Point(Point p)
        {
            x = p.x;
            y = p.y;
            sym = p.sym;
        }

        public void Move(int offset, Direction direction)
        {
            if(direction == Direction.RIGHT)
            {
                x = x + offset;
            }
            if (direction == Direction.LEFT)
            {
                x = x - offset;
            }
            if (direction == Direction.UP)
            {
                y = y - offset;
            }
            if (direction == Direction.DOWN)
            {
                y = y + offset;
            }

        }

        internal void Clear()
        {
            //Отрисовываем Пробел
            sym = ' ';
            Draw();
        }

        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
        }

        public override string ToString()
        {
            return x + ", " + y + ", " + sym;
        }

        //12 урок проверка Пересечения
        public bool IsHit(Point p)
        {
            //Интересное условие!!!
            return p.x == this.x && p.y == this.y;
        }
    }
}
