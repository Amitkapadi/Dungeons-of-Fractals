using UnityEngine;
using System.Collections;

public class ProceduralGeneration : MonoBehaviour
{
    public Transform Brick;//Для префаба обычной стены 

    public int X_Coordinate = 0;//Начальная координата X
    public int Y_Coordinate = 0;//Начальная координата Y
    public int Z_Coordinate = 0;//Начальная координата Z

    int Delta_X_Gilbert = 0, Delta_Z_Gilbert = 0; //Приращение кривой Гилберта
    int Delta_X_Serpinskiy = 0, Delta_Z_Serpinskiy = 0;//Приращение криво Серпинского
    int DirectOrderGilbert = 0;//порядок кривой Гилбрета
    int DirectOrderSerpinskiy = 0;//Порядок кривой Серпинского
    int CountOfIterations = 0;//Рандомное кол-во вызовов отрисовки 
    bool DrawType=false;//Так как меняется порядок кривой в зависимости от отрисовывании
    int DeltaForDrawingX=0,DeltaForDrawingZ=0;//Перемнная для различного прироста для разных кривых
    int ThicknessOfCorridor=10;
    //Функция построения никога в жизни больше не открою вот это 
    void DrawPart(int Delta_X, int Delta_Z)
    {   
        if(DrawType==false)//Если false следовательно рисуем Гилберта
        {
            DeltaForDrawingX=Delta_X_Gilbert;
            DeltaForDrawingZ=Delta_Z_Gilbert;
        }
        else//Если true следовательено рисуем Серпинского
        {
            DeltaForDrawingX=Delta_X_Serpinskiy;
            DeltaForDrawingZ=Delta_Z_Serpinskiy;
        }
        if (Delta_Z == 0 && Delta_X < 0)
        {
            Brick.transform.localScale = new Vector3(DeltaForDrawingX,1,ThicknessOfCorridor);
            Instantiate(Brick, new Vector3(X_Coordinate-DeltaForDrawingX/2, Y_Coordinate, Z_Coordinate),Quaternion.identity);
            X_Coordinate = X_Coordinate - DeltaForDrawingX;
        }
        if (Delta_Z == 0 && Delta_X > 0) 
        {
            Brick.transform.localScale = new Vector3(DeltaForDrawingX,1,ThicknessOfCorridor);
            Instantiate(Brick, new Vector3(X_Coordinate+DeltaForDrawingX/2, Y_Coordinate, Z_Coordinate+ThicknessOfCorridor/2),Quaternion.identity);
            X_Coordinate = X_Coordinate + DeltaForDrawingX;
        }
        if (Delta_X == 0 && Delta_Z < 0)
        {
            Brick.transform.localScale = new Vector3(ThicknessOfCorridor,1,DeltaForDrawingZ);
            Instantiate(Brick, new Vector3(X_Coordinate-Delta_X, Y_Coordinate, Z_Coordinate-DeltaForDrawingZ/2), Quaternion.identity);
            Z_Coordinate = Z_Coordinate - DeltaForDrawingZ;
        }
        if (Delta_X == 0 && Delta_Z > 0) 
        {
            Brick.transform.localScale = new Vector3(ThicknessOfCorridor,1,DeltaForDrawingZ);
            Instantiate(Brick, new Vector3(X_Coordinate+ThicknessOfCorridor/2, Y_Coordinate, Z_Coordinate+DeltaForDrawingZ/2), Quaternion.identity);
            Z_Coordinate = Z_Coordinate + DeltaForDrawingZ;
        }
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

    int ParityСheck(int Verifiable,int StartRange,int FinishRange)//Функция для получения рандомных чётных координат
    {
        Verifiable=Random.Range(StartRange,FinishRange);
        while(Verifiable%2!=0)Verifiable=Random.Range(StartRange,FinishRange);
        return Verifiable;
    }
    
    //Основная функция 
    void Start()
    {
        Random Rand = new Random();
        //Делаем случаным всё что можем
        Delta_X_Gilbert = ParityСheck(Delta_X_Gilbert,20,30);
        Delta_Z_Gilbert = ParityСheck(Delta_Z_Gilbert,20,30);
        Delta_X_Serpinskiy = ParityСheck(Delta_X_Serpinskiy,20,30);
        Delta_Z_Serpinskiy = ParityСheck(Delta_Z_Serpinskiy,20,30);
        //Delta_X_Gilbert=Delta_Z_Gilbert=Delta_X_Serpinskiy=Delta_Z_Serpinskiy=20;
        DirectOrderGilbert = Random.Range(2, 3);
        DirectOrderSerpinskiy=Random.Range(1,2);
        CountOfIterations = Random.Range(1, 4);
        bool RandomMove = false;//Определение рандомного порядка отрисовки кривых
        for (int i = 0; i < CountOfIterations; i++)
        {
            RandomMove = Random.Range(0, 1) == 0 ? false : true;//При каждой итерации отрисовка меняет свой порядок(тут порядок в значении последовательности)
            DirectOrderGilbert = Random.Range(1,3);
            DirectOrderSerpinskiy=Random.Range(1,3);
            switch (RandomMove)
            {
                //Если первой будем отрисовывать Гилберта
                case true:
                    DrawType=false;
                    function_drawing_Gilbert_1(DirectOrderGilbert);
                    DrawType=true;
                    function_drawing_Serpinskiy_1(DirectOrderSerpinskiy);
                    break;
                //Если первый будет Серпинский
                case false:
                    DrawType=true;
                    function_drawing_Serpinskiy_1(DirectOrderSerpinskiy);
                    DrawType=false;
                    function_drawing_Gilbert_1(DirectOrderGilbert);
                    break;
            }
        }
    }
}
