using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMe : MonoBehaviour
{
    private static bool MyselfExists;
    // Start is called before the first frame update
    void Start()
    {
                if (!MyselfExists)
        {
            MyselfExists = true;
            DontDestroyOnLoad(transform.gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
