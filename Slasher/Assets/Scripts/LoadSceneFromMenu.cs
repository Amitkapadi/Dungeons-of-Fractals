using UnityEngine;
using System.Collections;

public class LoadSceneFromMenu : MonoBehaviour
{
    public bool TrigerToContinueGame=false;

    public void LoadTriger()
    {
        TrigerToContinueGame = true;
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

}
