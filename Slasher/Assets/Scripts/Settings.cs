using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Slider MainVolume;

    public void VolumeMainChange()
    {
        AudioListener.volume=MainVolume.value;

    }

    public void Resolution(int r)//Разрешение
    {
        switch(r)
        {
            case 0:Screen.SetResolution(640, 480, isFullScreen);break;
            case 1:Screen.SetResolution(720, 480, isFullScreen);break;
            case 2:Screen.SetResolution(720, 576, isFullScreen);break;
            case 3:Screen.SetResolution(1280,720,isFullScreen);break;
            case 4:Screen.SetResolution(1280, 768, isFullScreen);break;
            case 5:Screen.SetResolution(1280, 1024, isFullScreen);break;
            case 6:Screen.SetResolution(1440, 900, isFullScreen);break;
            case 7:Screen.SetResolution(1600, 900, isFullScreen);break;
            case 8:Screen.SetResolution(1680, 1050, isFullScreen);break;
            case 9:Screen.SetResolution(1920, 1080, isFullScreen);break;
        }
    }

    public bool isFullScreen;

    public void FullScreenToggle()//Полноэкранный режим
    {
        isFullScreen = !isFullScreen;
        Screen.fullScreen = isFullScreen;
    }

    public void Quality(int q)//Для изменения качества графики
    {
        QualitySettings.SetQualityLevel(q);
    }
}