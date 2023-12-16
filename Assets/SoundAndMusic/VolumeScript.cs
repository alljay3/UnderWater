using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeScript : MonoBehaviour
{
    [SerializeField] float volume = 1;
    private void Start()
    {
        ChangeVolume();
    }

    public void ChangeVolume()
    {
        if (gameObject.GetComponent<AudioSource>() != null)
        {
            AudioSource MyAudio = gameObject.GetComponent<AudioSource>();
            if (gameObject.tag != "Music")
                MyAudio.volume = volume * MainScript.VolumeSound * 5;
            if (gameObject.tag == "Music")
                MyAudio.volume = volume * MainScript.VolumeMusic * 5;
        }
    }

    public void SoundMute()
    {
        if (gameObject.GetComponent<AudioSource>() != null)
        {
            AudioSource MyAudio = gameObject.GetComponent<AudioSource>();
            if (gameObject.tag != "Music")
                MyAudio.volume = 0;
        }
    }

    public void MusicMute()
    {
        if (gameObject.GetComponent<AudioSource>() != null)
        {
            AudioSource MyAudio = gameObject.GetComponent<AudioSource>();
            if (gameObject.tag == "Music")
                MyAudio.volume = 0;
        }
    }

    public void AllMute()
    {
        if (gameObject.GetComponent<AudioSource>() != null)
        {
            AudioSource MyAudio = gameObject.GetComponent<AudioSource>();
            MyAudio.volume = 0;
        }
    }
}
