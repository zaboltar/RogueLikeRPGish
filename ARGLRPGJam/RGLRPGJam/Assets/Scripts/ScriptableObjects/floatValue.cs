﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class floatValue : ScriptableObject
{
  
    public float initialValue;

    [HideInInspector]
    public float RuntimeValue;

   

}
