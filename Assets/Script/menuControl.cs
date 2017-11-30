using UnityEngine;
using UnityEngine.SceneManagement;

public class menuControl : MonoBehaviour
{

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
