using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void StartGame()
    {
        SceneManager.LoadScene("Game Scene");
    }

    public void ExitGame()
    {
        Debug.Log("Exiting Game... ");
        Application.Quit();
    }
}
