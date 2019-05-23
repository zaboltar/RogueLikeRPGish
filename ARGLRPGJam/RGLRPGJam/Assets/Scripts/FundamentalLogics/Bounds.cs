using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{
    private BoxCollider2D bounds;
    private CameraController theCamera;
    public bool startsLevel;
    
    void Start()
    {
        if (startsLevel)
        {
            bounds = GetComponent<BoxCollider2D>();
            theCamera = FindObjectOfType<CameraController>();
            theCamera.SetBounds(bounds);
        }
        
    }

   
}
