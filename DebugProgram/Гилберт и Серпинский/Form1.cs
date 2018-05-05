using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Гилберт_и_Серпинский
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int p = 0;//порядок кривой Гилбрета
        void randomFuncForGilbert()
        {
            Random rnd = new Random();//Инициализация рандома
            p = rnd.Next(1, 3);
        }

        int p1 = 2; //Порядок кривой Серпинсого
        void randomFuncForilbert()
        {
            Random rnd = new Random();
            p1 = rnd.Next(1, 3);
        }


        int lx = 30, ly = 30; //определяем значения, дающие направление,в котором должна рисоваться кривая
        int X = 50, Y = 50;//Графический курсор устанавливаем в начальную точку

        
        private void DrawPart(Graphics g, int lx, int ly)// Функция DrawPart рисует линию из точки (X,Y) к новой точке и сохраняет координаты точки в переменных X и Y.
        {
            g.DrawLine(Pens.Black, X, Y, X + lx, Y + ly);
            X = X + lx;
            Y = Y + ly;
        }

        private void DrawPart1(Graphics g1, int lx, int ly)
        {
            g1.DrawLine(Pens.Black, X, Y, X + lx, Y + ly);
            X = X + lx;
            Y = Y + ly;
        }//Тоже самое для Серпинского

        //Кривая Серпинского
        void a1(int i, Graphics g1)
        {
            if (i > 0)
            {
                a1(i - 1, g1);
                //От последней точки проводится вниз отрезок длиной 5 пикселей
                DrawPart1(g1, 0, ly);
                b1(i - 1, g1);
                //От последней точки проводится вправо отрезок длиной 5 пикселей
                DrawPart1(g1, +lx, 0);
                //От последней точки проводится вниз отрезок длиной 5 пикселей
                DrawPart1(g1, 0, ly);
                d1(i - 1, g1);
                //От последней точки проводится вправо отрезок длиной 5 пикселей
                DrawPart1(g1, +lx, 0);
                a1(i - 1, g1);
            }
        }//Первая рекурсивня функция для Серпинсого

        void b1(int i, Graphics g1)
        {
            if (i > 0)
            {
                b1(i - 1, g1);
                //От последней точки проводится влево отрезок длиной 5 пикселей
                DrawPart1(g1, -lx, 0);
                c1(i - 1, g1);
                //От последней точки проводится вниз отрезок длиной 5 пикселей
                DrawPart1(g1, 0, ly);
                //От последней точки проводится влево отрезок длиной 5 пикселей
                DrawPart1(g1, -lx, 0);
                a1(i - 1, g1);
                //От последней точки проводится вниз отрезок длиной 5 пикселей
                DrawPart1(g1, 0, ly);
                b1(i - 1, g1);
            }
        }//Вторая рекурсивня функция для Серпинсого

        void c1(int i, Graphics g1)
        {
            if (i > 0)
            {
                c1(i - 1, g1);
                //От последней точки проводится вверх отрезок длиной 5 пикселей
                DrawPart1(g1, 0, -ly);
                d1(i - 1, g1);
                //От последней точки проводится влево отрезок длиной 5 пикселей
                DrawPart1(g1, -lx, 0);
                //От последней точки проводится вверх отрезок длиной 5 пикселей
                DrawPart1(g1, 0, -ly);
                b1(i - 1, g1);
                //От последней точки проводится влево отрезок длиной 5 пикселей
                DrawPart1(g1, -lx, 0);
                c1(i - 1, g1);
            }
        }//Третья рекурсивня функция для Серпинсого

        void d1(int i, Graphics g1)
        {
            if (i > 0)
            {
                d1(i - 1, g1);
                //От последней точки проводится вправо отрезок длиной 5 пикселей
                DrawPart1(g1, +lx, 0);
                a1(i - 1, g1);
                //От последней точки проводится вверх отрезок длиной 5 пикселей
                DrawPart1(g1, 0, -ly);
                //От последней точки проводится вправо отрезок длиной 5 пикселей
                DrawPart1(g1, lx, 0);
                c1(i - 1, g1);
                //От последней точки проводится вверх отрезок длиной 5 пикселей
                DrawPart1(g1, 0, -ly);
                d1(i - 1, g1);
            }
        }//Четвёртая рекурсивня функция для Серпинсого

        //Кривая Гилберта
        //  Кривую Гильберта можно получить путем
        //  соединения элементов а,b,с и d.
        //  Каждый элемент строит
        //  соответствующая функция.

        // Рекурсивно берем четыре маленькие кривые Гильберта и соединяем их линиями.
        // Процедуры рисования четырех разновидностей кривых Гильберта(направленных в разные стороны)
        void a(int i, Graphics g)
        {
            if (i > 0)
            {
                d(i - 1, g);
                //От последней точки проводится вправо отрезок длиной 5 пикселей
                DrawPart(g, +lx, 0);
                a(i - 1, g);
                //От последней точки (на нее указывает графический курсор) проводится вниз отрезок длиной 5 пикселей
                DrawPart(g, 0, ly);
                a(i - 1, g);
                //От последней точки проводится влево отрезок длиной 5 пикселей
                DrawPart(g, -lx, 0);
                c(i - 1, g);
            }
        }//Первая рекурсивня функция для Гилберта

        void b(int i, Graphics g)
        {
            if (i > 0)
            {
                c(i - 1, g);
                //От последней точки проводится влево отрезок длиной 5 пикселей
                DrawPart(g, -lx, 0);
                b(i - 1, g);
                //От последней точки проводится вверх отрезок длиной 5 пикселей
                DrawPart(g, 0, -ly);
                b(i - 1, g);
                //От последней точки проводится вправо отрезок длиной 5 пикселей  
                DrawPart(g, lx, 0);
                d(i - 1, g);
            }
        }//Вторая рекурсивня функция для Гилберта

        void c(int i, Graphics g)
        {
            if (i > 0)
            {

                b(i - 1, g);
                //От последней точки проводится вверх отрезок длиной 5 пикселей  
                DrawPart(g, 0, -ly);
                c(i - 1, g);
                //От последней точки проводится влево отрезок длиной 5 пикселей  
                DrawPart(g, -lx, 0);
                c(i - 1, g);
                //От последней точки проводится вниз отрезок длиной 5 пикселей  
                DrawPart(g, 0, ly);
                a(i - 1, g);
            }
        }//Третья рекурсивня функция для Гилберта

        void d(int i, Graphics g)
        {
            if (i > 0)
            {
                a(i - 1, g);
                //От последней точки проводится вниз отрезок длиной 5 пикселей  
                DrawPart(g, 0, ly);
                d(i - 1, g);
                //От последней точки проводится вправо отрезок длиной 5 пикселей  
                DrawPart(g, lx, 0);
                d(i - 1, g);
                //От последней точки проводится вверх отрезок длиной 5 пикселей  
                DrawPart(g, 0, -ly);
                b(i - 1, g);
            }
        }//Четвёртая рекурсивня функция для Гилберта

        //Серпинский отрисовка
        /*private void Draw1(object sender, EventArgs e)
        {
            Graphics g1 = Graphics.FromHwnd(pictureBox1.Handle);
            //вызываем функцию рисования фрактала
            a1(p1, g1);
        }*/

        //Гилберт отрисовка
        private void Draw(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            //вызываем функцию рисования фрактала
            a(p, g);
            a1(p1, g);
        } 

        //О программе
        private void button4_Click(object sender, EventArgs e)
        {
            AboutBox1 a = new AboutBox1();
            a.Show();
        }



        // Пока чо пустые поля
        private void Drow_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}