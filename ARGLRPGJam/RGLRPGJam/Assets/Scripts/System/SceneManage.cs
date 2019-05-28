using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManage : MonoBehaviour
{
     public void SceneLoader(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }
}
