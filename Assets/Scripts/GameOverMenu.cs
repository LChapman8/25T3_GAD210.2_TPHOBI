using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    // Call this to load the Main Menu scene
    public void ReturnToMainMenu()
    {
        // Replace "MainMenu" with your actual main menu scene name
        SceneManager.LoadScene("MainMenu");
    }

    // Call this to quit the game entirely
    public void ExitGame()
    {
        Debug.Log("Quitting game..."); // Works in editor to confirm button works
        Application.Quit();
    }
}
