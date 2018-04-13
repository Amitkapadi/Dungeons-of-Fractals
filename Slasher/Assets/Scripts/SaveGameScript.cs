using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveGameScript : MonoBehaviour
{
    public GameObject Character;
    public GameObject Menu;
    public GameObject SucesfullSaving;
    public GameObject SavingMenu;

    [System.Serializable]
    public class Position
    {
        public float Character_x;
        public float Character_y;
        public float Character_z;
    }

    GameObject Triger;
    public bool TrigerToLoad;

    void Start()
    { 
        Triger = GameObject.Find("LoadSavingController");
        if (GameObject.Find("LoadSavingController") == true)
        {
            TrigerToLoad = Triger.GetComponent<LoadSceneFromMenu>().TrigerToContinueGame;
        }
        if (TrigerToLoad == true)
        {
            Load();
        }
    }

    public void saving()
    {
        Position PositionCharacter=new Position();
        PositionCharacter.Character_x = Character.transform.position.x;
        PositionCharacter.Character_y = Character.transform.position.y;
        PositionCharacter.Character_z = Character.transform.position.z;
        if (!Directory.Exists(Application.dataPath + "/saves"))
            Directory.CreateDirectory(Application.dataPath + "/saves");
        FileStream SaveFile = new FileStream(Application.dataPath + "/saves/save.json", FileMode.Create);
        BinaryFormatter formatter=new BinaryFormatter();
        formatter.Serialize(SaveFile, PositionCharacter);
        SaveFile.Close();
        SucesfullSaving.SetActive(true);
        //StartCoroutine(DelayFunc());
        //SucesfullSaving.SetActive(false);
    }

    public void Load()
    {
        if (File.Exists(Application.dataPath + "/saves/save.json"))
        {
            FileStream SaveFile = new FileStream(Application.dataPath+"/saves/save.json",FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                Position PositionCharacter = (Position)formatter.Deserialize(SaveFile);
                Character.transform.position = new Vector3(PositionCharacter.Character_x, PositionCharacter.Character_y,PositionCharacter.Character_z);
            }
            catch (System.Exception e)
            {
                Debug.Log(e.Message);
            }
            finally
            {
                SavingMenu.SetActive(false);
                Menu.SetActive(false);
                SaveFile.Close();
            }
        }
    }
}
