using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{

    public Image Loading_Screen;
    public Text ProgressText;
    public int SceneId;

	void Start ()
    {
        StartCoroutine(AsyncLoad());
	}

    IEnumerator AsyncLoad()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneId);
        while (!operation.isDone)
        {
            float progress = operation.progress / 0.9f;
            Loading_Screen.fillAmount = progress;
            ProgressText.text = string.Format("(0:0)%", progress*100);
            yield return null;
        }
    }
}
