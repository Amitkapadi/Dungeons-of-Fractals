using UnityEngine;
using System.Collections;

public class PlayerGUI : MonoBehaviour
{
    public GameObject Player;
    public GameObject Menu;
    public GameObject SettingsButton;
    public bool Paused = false;
    //public void Condition=;
    

    void Update()//Для паузы через escape
    {
       
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Paused == false)
            {
                Time.timeScale = 0;
                Paused = true;
                Menu.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                Paused = false;
                Menu.SetActive(false);
            }
        }
    }

    public void PauseOff()
    {
        Menu.SetActive(false);
        Paused = false;
        Time.timeScale = 1;
    }



    public void EixtToMainMenu()//Выход в главное меню
    {
        Menu.SetActive(false);
        Application.LoadLevel(1);
        Time.timeScale = 1;
        Paused = false;
    }

    public void ExitFromGame()//Выход из игры
    {
        Menu.SetActive(false);
        Application.Quit();
    }

    public void SettingsOn()//Вкладка настроек
    {
        Menu.SetActive(false);
        SettingsButton.SetActive(true);
    }

    public void SettingsOff()//Выключение вкладки натсроек
    {
        Menu.SetActive(true);
        SettingsButton.SetActive(false);
    }

}
