using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{
    public GameObject buttonsMenu;
    public GameObject buttonsExit;
    public GameObject AboutUsButtons;
    public GameObject Settings;

    public void ShowExitButtons()
    {
        buttonsMenu.SetActive(false);
        buttonsExit.SetActive(true);
    }

    public void BackInMenu()
    {
        buttonsMenu.SetActive(true);
        buttonsExit.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void NewGameLoadScene()
    {
        Application.LoadLevel(1);
    }

    //$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

    public void ShowAboutUs()
    {
        buttonsMenu.SetActive(false);
        AboutUsButtons.SetActive(true);
    }

    public void BackInMenuUs()
    {
        buttonsMenu.SetActive(true);
        AboutUsButtons.SetActive(false);
    }

    public void ShowSettings()
    {
        buttonsMenu.SetActive(false);
        Settings.SetActive(true);
    }

    public void BackInMenuSettings()
    {
        buttonsMenu.SetActive(true);
        Settings.SetActive(false);
    }
}