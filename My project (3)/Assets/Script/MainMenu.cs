using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("main");
    }

    public void CloseGame()
    {
        Application.Quit(0);
    }
    
}
