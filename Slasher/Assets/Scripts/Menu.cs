using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Menu : MonoBehaviour
{
    public GameObject buttonsMenu;
    public GameObject buttonsExit;
    public GameObject AboutUsButtons;
    public GameObject Settings;
    public GameObject LoadingScree;
    public GameObject OnlineGame;
    public GameObject NetworkManager;

    GameObject Triger;
    public bool TrigerToLoad;

    void SearchLoad()
    {
        Triger = GameObject.Find("LoadSavingController");
        if (GameObject.Find("LoadSavingController") == true)
        {
            Debug.Log("Объект найден!!!");
            TrigerToLoad=Triger.GetComponent<LoadSceneFromMenu>().TrigerToContinueGame;
            Debug.Log(TrigerToLoad);
        }
        else Debug.Log("Объект не найден!!!");
        if (TrigerToLoad == true)
        {
            GetComponent<SaveGameScript>().Load();
        }
        else NewGameLoadScene();

    }

    public void OnlineGameMenuOn()
    {
        buttonsMenu.SetActive(false);
        OnlineGame.SetActive(true);
        NetworkManager.SetActive(true);
    }

    public void OnlineGameMenuOff()
    {
        buttonsMenu.SetActive(true);
        OnlineGame.SetActive(false);
        NetworkManager.SetActive(false);
    }


    public void LoadingSaveGame()
    {
        buttonsMenu.SetActive(false);
        LoadingScree.SetActive(true);
        SearchLoad();
    } 


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
        buttonsMenu.SetActive(false);
        LoadingScree.SetActive(true);
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