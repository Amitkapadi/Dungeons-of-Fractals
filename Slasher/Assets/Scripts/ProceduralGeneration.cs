using UnityEngine;
using System.Collections;

public class ProceduralGeneration : MonoBehaviour
{
    public int CountOfTurns = 0;//Кол-во поворотов кривой
    public int CorridorLength = 0;//Переменная для определения длины коррдиров
    public int X_Coordinate = 0;//Начальная координата x
    public int Y_Coordinate = 0;//Начальная координата y
    bool DirectionOfTrun;
    void Start()
    {
        CountOfTurns = Random.Range(10, 20);
        for (int iteration = 0; iteration < CountOfTurns; iteration++)
        {
            CorridorLength = Random.Range(10, 10);
            Random Rand = new Random();
            DirectionOfTrun = Random.Range(0, 2) == 0 ? false : true;
            for (int j = 0; j < CorridorLength; j++)
            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = new Vector3(X_Coordinate,1,Y_Coordinate);
                switch (DirectionOfTrun)
                {
                    case true:
                        X_Coordinate++;
                        break;
                    case false:
                        Y_Coordinate++;
                        break;
                }
            }
        }

        /*int Length =Random.Range(10,20);//Рандомная длина для комнаты
        int Width=Random.Range(5,15);//Рандомная ширина для комнаты
        Debug.Log(Length);Debug.Log(Width);
        for (int CoordinateY = StartPositionY; CoordinateY < Height; CoordinateY++)
        {
            for (int CoordinateX = StartPositionX; CoordinateX < StartPositionX + Length; CoordinateX++)
            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                //cube.AddComponent<Rigidbody>();
                cube.transform.position = new Vector3(CoordinateX, CoordinateY,StartPositionZ);
            }
        }
        for (int CoordinateY = StartPositionY; CoordinateY < Height; CoordinateY++)
        {
            for (int CoordinateX = StartPositionX; CoordinateX < StartPositionX + Length; CoordinateX++)
            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                //cube.AddComponent<Rigidbody>();
                cube.transform.position = new Vector3(CoordinateX, CoordinateY, StartPositionZ - Width);
            }
        }*/
    }
}
