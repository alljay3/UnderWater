using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : MonoBehaviour
{
    public static void AllMute()
    {
        VolumeScript[] audioSources = GameObject.FindObjectsOfType<VolumeScript>();
        foreach (VolumeScript i in audioSources)
        {
            i.AllMute();
        }
    }


    public static void AllUnMute()
    {
        VolumeScript[] audioSources = GameObject.FindObjectsOfType<VolumeScript>();
        foreach (VolumeScript i in audioSources)
        {
            i.ChangeVolume();
        }
    }
}
