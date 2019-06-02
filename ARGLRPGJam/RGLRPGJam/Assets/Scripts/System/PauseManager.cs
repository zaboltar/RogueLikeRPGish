using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{

    private bool isPaused;
    public GameObject pausePanel;
    public string splashScreen;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || (Input.GetKeyDown(KeyCode.Escape)))
        {
           ChangePause();
        }
    }

    public void ChangePause ()
    {
        isPaused = !isPaused;
         if (isPaused)
            {
                pausePanel.SetActive(true);
                Time.timeScale = 0f; // terrible idea, esta
            } else
            {
                pausePanel.SetActive(false);
                Time.timeScale = 1f;
            }
    }

    public void Quit ()
    {
        SceneManager.LoadScene(splashScreen);
        Time.timeScale = 1f;
    }
}
