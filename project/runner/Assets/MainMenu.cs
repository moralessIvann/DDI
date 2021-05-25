using UnityEngine.SceneManagement;
using UnityEngine;


public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Level");
        //SceneManager.LoadScene("vuforia&voice");
    }

    public void QuitGame()
    {
        Application.Quit();

    }
}
