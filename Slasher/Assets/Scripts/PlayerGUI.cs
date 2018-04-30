using UnityEngine;
using System.Collections;


public class PlayerGUI : MonoBehaviour
{
    public GameObject Player;
    public GameObject Menu;
    public GameObject SettingsButton;
    public GameObject Saves;
    public GameObject СonfirmationExitForMenu;
    public GameObject ConfirmationForExitGame;
    public bool Paused = false;
    bool trigerToShutMenu = true;

    GameObject Triger;//Для удаления сохранения после выхода из игры

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
        if (Time.timeScale == 0 && Paused==false) Time.timeScale = 1;
        if (Input.GetKeyDown(KeyCode.Escape) && Saves.activeInHierarchy == true)
        {
            trigerToShutMenu = false;
            CloseSaves();
        }
        if (Input.GetKeyDown(KeyCode.Escape) && СonfirmationExitForMenu.activeInHierarchy == true)
        {
            trigerToShutMenu = false;
            ExitOffMenu();
        }
        if (Input.GetKeyDown(KeyCode.Escape) && СonfirmationExitForMenu.activeInHierarchy == true)
        {
            trigerToShutMenu = false;
            ExitOffMenu();
        }
        if (Input.GetKeyDown(KeyCode.Escape) && SettingsButton.activeInHierarchy == true)
        {
            trigerToShutMenu = false;
            SettingsOff();
        }
        if (Input.GetKeyDown(KeyCode.Escape) && trigerToShutMenu==true)
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
        trigerToShutMenu = true;
    }

    public void PauseOff()
    {
        Menu.SetActive(false);
        Paused = false;
        Time.timeScale = 1;
    }

    public void СonfirmationYesMainMenu()//Выходим если да в меню
    {
        Application.LoadLevel(1);
        Time.timeScale = 1;
        Triger = GameObject.Find("LoadSavingController");
        if (GameObject.Find("LoadSavingController") == true)
        {
            Destroy(GameObject.Find("LoadSavingController"));
        }
        Paused = false;
    }

    public void СonfirmationNoMainMenu()//Идём в сейв если нет из меню
    {
        СonfirmationExitForMenu.SetActive(false);
        Saves.SetActive(true);
    } 

    public void EixtToMainMenu()//Выход в главное меню
    {
        Menu.SetActive(false);
        СonfirmationExitForMenu.SetActive(true);
    }

    public void СonfirmationYesQuitGame()
    {
        Application.Quit();
    }

    public void СonfirmationNoQuitGame()
    {
        ConfirmationForExitGame.SetActive(false);
        Saves.SetActive(true);
    }

    public void ExitFromGame()//Выход из игры
    {
        Menu.SetActive(false);
        ConfirmationForExitGame.SetActive(true);
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

    public void ExitOffMenu()
    {
        СonfirmationExitForMenu.SetActive(false);
        Menu.SetActive(true);
    }

    public void ExitOffQuit()
    {
        ConfirmationForExitGame.SetActive(false);
        Menu.SetActive(true);
    }
}
