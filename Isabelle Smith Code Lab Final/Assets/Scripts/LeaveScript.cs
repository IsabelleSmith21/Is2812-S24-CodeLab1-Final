using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaveScript : MonoBehaviour
{
    // Function to load a scene
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}