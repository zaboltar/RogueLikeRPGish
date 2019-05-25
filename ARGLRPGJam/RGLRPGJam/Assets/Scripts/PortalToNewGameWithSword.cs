using UnityEngine.SceneManagement;
using UnityEngine;


public class PortalToNewGameWithSword : MonoBehaviour
{
    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(2);
        }
    }
}
