using UnityEngine;
using System.Collections;

public class PlayerGUI : MonoBehaviour
{
    public GameObject Player;
    public GameObject Menu;
    public GameObject SettingsButton;
    public GameObject Saves;
    public GameObject СonfirmationExit;
    public bool Paused = false;

    public void openSaves()//Открытие меню сохранения
    {
        Menu.SetActive(false);
        Saves.SetActive(true);
    }

    public void CloseSaves()//Закрытие меню сохранения
    {
        Saves.SetActive(false);
        Menu.SetActive(true);
    }

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

    public void СonfirmationYesMainMenu()//Выходим если да
    {
        Application.LoadLevel(1);
        Time.timeScale = 1;
        Paused = false;
    }

    public void СonfirmationNoMainMenu()//Идём в сейв если нет
    {
        СonfirmationExit.SetActive(false);
        Saves.SetActive(true);
    }

    public void EixtToMainMenu()//Выход в главное меню
    {
        Menu.SetActive(false);
        СonfirmationExit.SetActive(true);
    }

    public void СonfirmationYesQuitGame()
    {
        Application.Quit();
    }

    public void СonfirmationNoQuitGame()
    {
        СonfirmationExit.SetActive(false);
        Saves.SetActive(true);
    }

    public void ExitFromGame()//Выход из игры
    {
        Menu.SetActive(false);
        СonfirmationExit.SetActive(true);
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
