using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeManager : MonoBehaviour
{
    public VolumeController [] vcObjs;
    public float currentVolumeLvl;
    public float maxVolumeLvl = 1.0f;

    void Start()
    {
        vcObjs = FindObjectsOfType<VolumeController>();
    
        if (currentVolumeLvl > maxVolumeLvl)
        {
            currentVolumeLvl = maxVolumeLvl;
        }

        for (int i = 0; i < vcObjs.Length; i++)
        {
            vcObjs[i].SetAudioLevel(currentVolumeLvl);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
