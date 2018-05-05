using UnityEngine;
using System.Collections;

public class ProceduralGeneration : MonoBehaviour
{
    public Transform SimpleWall;//Для префаба обычной стены вправо
    public Transform WallOut;//Для префаба стены прохода
    bool DirectionOfTrun;//Рандомный поворот
    public int LenghtOfRoom;
    public int CountOfRooms ;

    void Start()
    {
        float X_Coordinate = 9;//Начальная координата X
        float Y_Coordinate = 0;//Начальная координата Y
        float Z_Coordinate = 2;//Начальная координата Z
        CountOfRooms = Random.Range(10,15);//Получаем рандомное кол-во комнат
        Instantiate(SimpleWall, new Vector3(X_Coordinate, Y_Coordinate, Z_Coordinate), Quaternion.identity);
        for (int i = 0; i < CountOfRooms; i++)
        {
            Random Rand = new Random();
            DirectionOfTrun = Random.Range(0, 2) == 0 ? false : true;//Рандомный поворот
            LenghtOfRoom = Random.Range(1,3);//Длина комнаты
            for (int j = 0; j < LenghtOfRoom; j++)
            {
                if (DirectionOfTrun == false)
                {
                    Debug.Log("False");
                    Instantiate(SimpleWall, new Vector3(X_Coordinate, Y_Coordinate, Z_Coordinate), Quaternion.RotateTowards(transform.rotation, SimpleWall.rotation, 270));
                    X_Coordinate = X_Coordinate + 9.5f;
                }
                else
                {
                    Debug.Log("true");
                    Instantiate(SimpleWall, new Vector3(X_Coordinate, Y_Coordinate, Z_Coordinate),Quaternion.identity);
                    Z_Coordinate = Z_Coordinate + 9.5f;
                }
            }
        }
    }
}
