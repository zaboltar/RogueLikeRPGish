using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class boolValue : ScriptableObject
{
    public bool initialValue;

    [HideInInspector]
    public bool RuntimeValue;

  
}
