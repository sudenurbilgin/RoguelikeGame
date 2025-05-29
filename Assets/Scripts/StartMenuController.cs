using UnityEngine;

public class StartMenuController : MonoBehaviour
{
    public GameObject startMenuPanel;

    void Start()
    {
        Time.timeScale = 0f; // Oyunu başta durdur
        startMenuPanel.SetActive(true); // Menü paneli görünsün
       
        if (MenuMusicManager.instance != null)
        {
            MenuMusicManager.instance.PlayMenuMusic();
        }
    }

    public void StartGame()
    {
        startMenuPanel.SetActive(false); // Menü kapanır
        Time.timeScale = 1f; // Oyun devam eder
        MenuMusicManager.instance.StopMenuMusic();
    }

    public void QuitGame()
{
    Debug.Log("Quit button clicked");
    Application.Quit();
}


    public void ToggleMute()
    {
        if (MenuMusicManager.instance != null)
        {
            MenuMusicManager.instance.Mute();
        }
    }
}
