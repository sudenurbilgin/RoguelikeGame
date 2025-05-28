using UnityEngine;

public class StartMenuController : MonoBehaviour
{
    public GameObject startMenuPanel;

    void Start()
    {
        Time.timeScale = 0f; // Oyunu başta durdur
        startMenuPanel.SetActive(true); // Menü paneli görünsün
    }

    public void StartGame()
    {
        startMenuPanel.SetActive(false); // Menü kapanır
        Time.timeScale = 1f; // Oyun devam eder
    }

    public void QuitGame()
{
    Debug.Log("Quit button clicked");
    Application.Quit();
}


    public void ToggleMute()
    {
        AudioListener.pause = !AudioListener.pause;
    }
}
