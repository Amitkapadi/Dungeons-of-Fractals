using UnityEngine;
using System.Collections;

public class PlayerGUI : MonoBehaviour
{
    public GameObject Player;
    public GameObject Menu;

    public void MenuOn()//Включение паузы
    {
        Player.SetActive(false);
        Menu.SetActive(true);
    }

    public void MenuOff()//Конец паузы
    {
        Player.SetActive(true);
        Menu.SetActive(false);
    }

    public void EixtToMainMenu()//Выход в главное меню
    {
        Menu.SetActive(false);
        Application.LoadLevel(0);
    }

    public void ExitFromGame()
    {
        Menu.SetActive(false);
        Application.Quit();
    }

}
