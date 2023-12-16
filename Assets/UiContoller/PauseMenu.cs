using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] Slider MusicSlider;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        MainScript.InputOn = false;
        MusicSlider.value = MainScript.VolumeMusic;
    }

    public void Continue()
    {
        Time.timeScale = 1f;
        MainScript.InputOn = true;
        gameObject.SetActive(false);
    }

    public void GoMenu()
    {
        gameObject.SetActive(true);
    }

    void Update()
    {
        Time.timeScale = 0f;
        MainScript.InputOn = false;
        MainScript.VolumeMusic = MusicSlider.value;
        VolumeController.AllUnMute();
    }

    public void Exit()
    {
        Application.Quit();
    }
}
