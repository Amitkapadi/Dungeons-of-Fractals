using UnityEngine;
using System.Collections;

public class ProceduralGeneration : MonoBehaviour
{
    public Transform SimpleWall;//Для префаба обычной стены вправо
    public Transform WallOut;//Для префаба стены прохода между комнатами

    public int X_Coordinate = 0;//Начальная координата X
    public int Y_Coordinate = 0;//Начальная координата Y
    public int Z_Coordinate = 0;//Начальная координата Z

    int Delta_X_Gilbert = 0, Delta_Z_Gilbert = 0; //Приращение кривой Гилберта
    int Delta_X_Serpinskiy = 0, Delta_Z_Serpinskiy = 0;//Приращение криво Серпинского
    int DirectOrderGilbert = 0;//порядок кривой Гилбрета
    int DirectOrderSerpinskiy = 0;//Порядок кривой Серпинского
    int CountOfIterations = 0;//Рандомное кол-во вызовов отрисовки 

    //Функция построения никога в жизни больше не открою вот это 
    void DrawPart(int Delta_X, int Delta_Z)
    {
        if (Delta_Z == 0 && Delta_X < 0)
        {
                for (int i_X_Coordinate = X_Coordinate; i_X_Coordinate > X_Coordinate - Delta_X_Gilbert; i_X_Coordinate--)
                {
                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.transform.position = new Vector3(i_X_Coordinate, Y_Coordinate, Z_Coordinate);
                }
                X_Coordinate = X_Coordinate - Delta_X_Gilbert;
        }
        if (Delta_Z == 0 && Delta_X > 0) 
        {
                for (int i_X_Coordinate = X_Coordinate; i_X_Coordinate < X_Coordinate + Delta_X_Gilbert; i_X_Coordinate++)
                {
                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.transform.position = new Vector3(i_X_Coordinate, Y_Coordinate, Z_Coordinate);
                }
                X_Coordinate = X_Coordinate + Delta_X_Gilbert;
        }
        if (Delta_X == 0 && Delta_Z < 0)
        {
            for (int i_Z_Coordinate = Z_Coordinate; i_Z_Coordinate > Z_Coordinate - Delta_Z_Gilbert; i_Z_Coordinate--)
            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = new Vector3(X_Coordinate, Y_Coordinate, i_Z_Coordinate);
            }
            Z_Coordinate = Z_Coordinate - Delta_Z_Gilbert;
        }
        if (Delta_X == 0 && Delta_Z > 0) 
        {
            for (int i_Z_Coordinate = Z_Coordinate; i_Z_Coordinate < Z_Coordinate + Delta_Z_Gilbert; i_Z_Coordinate++)
            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = new Vector3(X_Coordinate, Y_Coordinate, i_Z_Coordinate);
            }
            Z_Coordinate = Z_Coordinate + Delta_Z_Gilbert;
        }

        //Тест работаспособности


    }

    //Рекурсивные функции для кривой Гилберта
    void function_drawing_Gilbert_1(int i)
    {
        if (i > 0)
        {
            function_drawing_Gilbert_4(i - 1);
            DrawPart(+Delta_Z_Gilbert, 0);
            function_drawing_Gilbert_1(i - 1);
            DrawPart(0, Delta_X_Gilbert);
            function_drawing_Gilbert_1(i - 1);
            DrawPart(-(Delta_Z_Gilbert), 0);
            function_drawing_Gilbert_3(i - 1);
        }
    }

    void function_drawing_Gilbert_2(int i)
    {
        if (i > 0)
        {
            function_drawing_Gilbert_3(i - 1);
            DrawPart(-(Delta_Z_Gilbert), 0);
            function_drawing_Gilbert_2(i - 1);
            DrawPart(0, (-Delta_X_Gilbert));
            function_drawing_Gilbert_2(i - 1);
            DrawPart(Delta_Z_Gilbert, 0);
            function_drawing_Gilbert_4(i - 1);
        }
    }

    void function_drawing_Gilbert_3(int i)
    {
        if (i > 0)
        {
            function_drawing_Gilbert_2(i - 1);
            DrawPart(0, (-Delta_X_Gilbert));
            function_drawing_Gilbert_3(i - 1);
            DrawPart((-Delta_Z_Gilbert), 0);
            function_drawing_Gilbert_3(i - 1);
            DrawPart(0, Delta_X_Gilbert);
            function_drawing_Gilbert_1(i - 1);
        }
    }

    void function_drawing_Gilbert_4(int i)
    {
        if (i > 0)
        {
            function_drawing_Gilbert_1(i - 1);
            DrawPart(0, Delta_X_Gilbert);
            function_drawing_Gilbert_4(i - 1);
            DrawPart(Delta_Z_Gilbert, 0);
            function_drawing_Gilbert_4(i - 1);
            DrawPart(0, (-Delta_X_Gilbert));
            function_drawing_Gilbert_2(i - 1);
        }
    }

    //Рекурсивные функции для кривой Серпинского
    void function_drawing_Serpinskiy_1(int i)
    {
        if (i > 0)
        {
            function_drawing_Serpinskiy_1(i - 1);
            DrawPart(0, Delta_Z_Serpinskiy);
            function_drawing_Serpinskiy_2(i - 1);
            DrawPart(+Delta_X_Serpinskiy, 0);
            DrawPart(0, Delta_Z_Serpinskiy);
            function_drawing_Serpinskiy_4(i - 1);
            DrawPart(+Delta_X_Serpinskiy, 0);
            function_drawing_Serpinskiy_1(i - 1);
        }
    }

    void function_drawing_Serpinskiy_2(int i)
    {
        if (i > 0)
        {
            function_drawing_Serpinskiy_2(i - 1);
            DrawPart(-Delta_X_Serpinskiy, 0);
            function_drawing_Serpinskiy_3(i - 1);
            DrawPart(0, Delta_Z_Serpinskiy);
            DrawPart(-Delta_X_Serpinskiy, 0);
            function_drawing_Serpinskiy_1(i - 1);
            DrawPart(0, Delta_Z_Serpinskiy);
            function_drawing_Serpinskiy_2(i - 1);
        }
    }

    void function_drawing_Serpinskiy_3(int i)
    {
        if (i > 0)
        {
            function_drawing_Serpinskiy_3(i - 1);
            DrawPart(0, -Delta_Z_Serpinskiy);
            function_drawing_Serpinskiy_4(i - 1);
            DrawPart(-Delta_X_Serpinskiy, 0);
            DrawPart(0, -Delta_Z_Serpinskiy);
            function_drawing_Serpinskiy_2(i - 1);
            DrawPart(-Delta_X_Serpinskiy, 0);
            function_drawing_Serpinskiy_3(i - 1);
        }
    }

    void function_drawing_Serpinskiy_4(int i)
    {
        if (i > 0)
        {
            function_drawing_Serpinskiy_4(i - 1);
            DrawPart(+Delta_X_Serpinskiy, 0);
            function_drawing_Serpinskiy_1(i - 1);
            DrawPart(0, -Delta_Z_Serpinskiy);
            DrawPart(Delta_X_Serpinskiy, 0);
            function_drawing_Serpinskiy_3(i - 1);
            DrawPart(0, -Delta_Z_Serpinskiy);
            function_drawing_Serpinskiy_4(i - 1);
        }
    }
    
    //Основная функция 
    void Start()
    {
        Random Rand = new Random();
        //Делаем случаным всё что можем
        Delta_X_Gilbert = Random.Range(5, 20);
        Delta_Z_Gilbert = Random.Range(5, 20);
        Delta_X_Serpinskiy = Random.Range(5, 20);
        Delta_Z_Serpinskiy = Random.Range(5, 20);
        DirectOrderGilbert = Random.Range(2, 3);
        DirectOrderSerpinskiy=Random.Range(1,2);
        CountOfIterations = Random.Range(1, 3);
        bool RandomMove = false;//Определение рандомного порядка отрисовки кривых
        for (int i = 0; i < CountOfIterations; i++)
        {
            RandomMove = Random.Range(0, 1) == 0 ? false : true;//При каждой итерации отрисовка меняет свой порядок(тут порядок в значении последовательности)
            switch (RandomMove)
            {
                case true:
                    function_drawing_Gilbert_1(DirectOrderGilbert);
                    function_drawing_Serpinskiy_1(DirectOrderSerpinskiy);
                    function_drawing_Gilbert_1(DirectOrderGilbert);
                    break;
                case false:
                    function_drawing_Serpinskiy_1(DirectOrderSerpinskiy);
                    function_drawing_Gilbert_1(DirectOrderGilbert);
                    function_drawing_Serpinskiy_1(DirectOrderSerpinskiy);
                    break;
            }
        }
    }
}
