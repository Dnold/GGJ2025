using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void TryAgain()
    {
        GameManager.instance.RestartLevel();
        
    }
}
