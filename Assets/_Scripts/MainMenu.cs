using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("placeholder");
    }

    public void QuitQame()
    {        
        Application.Quit();
    }
}
