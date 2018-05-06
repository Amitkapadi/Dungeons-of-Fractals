using UnityEngine;
using System.Collections;

public class ProceduralGeneration : MonoBehaviour
{
    public Transform SimpleWall;//Для префаба обычной стены вправо
    public Transform WallOut;//Для префаба стены прохода между комнатами
    public int CountOfRooms ;//Кол-во комнат

    public float X_Coordinate = 0;//Начальная координата X
    public float Y_Coordinate = 0;//Начальная координата Y
    public float Z_Coordinate = 0;//Начальная координата Z

    public int Delta_X_Gilbert = 30,Delta_Z_Gilbert=30; //Приращение кривой Гилберта
    public int Delta_X_Serpinskiy=30,Delta_Z_Serpinskiy=30;//Приращение криво Серпинского
    public int DirectOrderGilbert=0;//порядок кривой Гилбрета
    public int DirectOrderSerpinskiy=0;//Порядок кривой Серпинского
    public int CountOfIterations=0;//Рандомное кол-во вызовов отрисовки 

    //Рекурсивные функции для Гилбертовой кривой
    void DrawPart(int Delta_X, int Delta_Z)// Функция DrawPart рисует линию из точки (X,Y) к новой точке и сохраняет координаты точки в переменных X и Y.
    {
        if(Delta_Z_Gilbert==0)
        {
            for(int i_X_Coordinate=X_Coordinate;i<X_Coordinate+Delta_X_Gilbert;i_X_Coordinate++)
            {
                Instantiate(SimpleWall, new Vector3(i_X_Coordinate, Y_Coordinate, Z_Coordinate), Quaternion.identity);
            }
        }
        if(Delta_X_Gilbert==0)
        {
            for(int i_Z_Coordinate=Z_Coordinate;i<Z_Coordinate+Delta_Z_Gilbert;i_Z_Coordinate++)
            {
                Instantiate(SimpleWall, new Vector3(X_Coordinate, Y_Coordinate, i_Z_Coordinate), Quaternion.identity);
            }
        }
        X_Coordinate = X_Coordinate + Delta_X_Gilbert;
        Z_Coordinate = Z_Coordinate + Delta_Z_Gilbert;
        X_Coordinate=X_Coordinate+Delta_X_Serpinskiy;
        Z_Coordinate=Z_Coordinate+Delta_Z_Serpinskiy;
    }

    void function_drawing_Gilbert_1(int i)
    {
        if (i > 0)
        {
            function_drawing_Gilbert_4(i - 1);
            DrawPart(+Delta_X, 0);
            function_drawing_Gilbert_1(i - 1);
            DrawPart(0, Delta_Z);
            function_drawing_Gilbert_1(i - 1);
            DrawPart(-Delta_X, 0);
            function_drawing_Gilbert_3(i - 1);
        }
    }

    void function_drawing_Gilbert_2(int i)
    {
        if (i > 0)
        {
            function_drawing_Gilbert_3(i - 1);
            DrawPart(-Delta_X, 0);
            function_drawing_Gilbert_2(i - 1);
            DrawPart(0, -Delta_Y);
            function_drawing_Gilbert_2(i - 1);
            DrawPart(Delta_X, 0);
            function_drawing_Gilbert_4(i - 1);
        }
    }

    void function_drawing_Gilbert_3(int i)
    {
        if (i > 0)
        {
            function_drawing_Gilbert_2(i - 1);
            DrawPart(0, -Delta_Z);
            function_drawing_Gilbert_3(i - 1); 
            DrawPart(-Delta_X, 0);
            function_drawing_Gilbert_3(i - 1);
            DrawPart(0, Delta_Z);
            function_drawing_Gilbert_1(i - 1);
        }
    }

    void function_drawing_Gilbert_4(int i)
    {
        if (i > 0)
        {
            function_drawing_G1(i - 1);
            DrawPart(0, Delta_Z);
            function_drawing4(i - 1);
            DrawPart(Delta_X, 0);
            function_drawing4(i - 1); 
            DrawPart(0, -Delta_Z);
            function_drawing2(i - 1);
        }
    }

    //Рекурсивные функции для кривой Серпинского
    void function_drawing_Serpinskiy_1(int i)
    {
        if (i > 0)
        {
            function_drawing_Serpinskiy_1(i - 1);
            DrawPart(0, ly);
            function_drawing_Serpinskiy_2(i - 1);
            DrawPart(+lx, 0);
            DrawPart(0, ly);
            function_drawing_Serpinskiy_4(i - 1);
            DrawPart(+lx, 0);
            function_drawing_Serpinskiy_1(i - 1);
        }
    }

    void function_drawing_Serpinskiy_2(int i)
    {
        if (i > 0)
        {
            function_drawing_Serpinskiy_2(i - 1);
            DrawPart(-lx, 0);
            function_drawing_Serpinskiy_3(i - 1);
            DrawPart(0, ly);
            DrawPart(-lx, 0);
            function_drawing_Serpinskiy_1(i - 1);
            DrawPart1(0, ly);
            function_drawing_Serpinskiy_2(i - 1);
        }
    }

    void function_drawing_Serpinskiy_3(int i)
    {
        if (i > 0)
        {
            function_drawing_Serpinskiy_3(i - 1);
            DrawPart(0, -ly);
            function_drawing_Serpinskiy_4(i - 1);
            DrawPart(-lx, 0);
            DrawPart(0, -ly);
            function_drawing_Serpinskiy_2(i - 1);
            DrawPart(-lx, 0);
            function_drawing_Serpinskiy_3(i - 1);
        }
    }

    void function_drawing_Serpinskiy_4(int i)
    {
        if (i > 0)
        {
            function_drawing_Serpinskiy_4(i - 1);
            DrawPart(+lx, 0);
            function_drawing_Serpinskiy_1(i - 1);
            DrawPart(0, -ly);
            DrawPart(lx, 0);
            function_drawing_Serpinskiy_3(i - 1);
            DrawPart(0, -ly);
            function_drawing_Serpinskiy_4(i - 1);
        }
    }

    void Start()
    {
        Random RndGenerator=new Random();
        DirectOrder=RndGenerator.Next(1,2);
        Delta_X=RndGenerator.Next(10,30);
        Delta_Z=RndGenerator.Next(10,30);
        CountOfIterations=RndGenerator.Next(1,3);
        function_drawing_Gilbert_1(DirectOrderGilbert);
        function_drawing_Serpinskiy_1(DirectOrderSerpinskiy);
    }
}
