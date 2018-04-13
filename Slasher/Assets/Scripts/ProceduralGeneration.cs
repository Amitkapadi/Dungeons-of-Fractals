using UnityEngine;
using System.Collections;

public class ProceduralGeneration : MonoBehaviour
{
    public int NumberOfIterations = 10;//Кол-во генерируемых комнат
    public int Height = 5;//Высота для всех стен на карте
    public int StartPositionX = 22;
    public int StartPositionY = 0;
    public int StartPositionZ = 25;
    void Start()
    {
        int Length =Random.Range(10,20);//Рандомная длина для комнаты
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
        }
    }
}
