using UnityEngine;
using UnityEngine.SceneManagement;  // Restart için

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;  // Inspector'dan atayacağız

    private bool isPaused = false;

    void Start()
    {
        pausePanel.SetActive(false);  // Başlangıçta panel kapalı
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;  // Oyun durur
        isPaused = true;
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;  // Oyun devam eder
        isPaused = false;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;  // Oyun hızını normale al
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  // Aynı sahneyi yeniden yükle
    }
    public void QuitGame()
{
    Debug.Log("Oyun kapatılıyor...");

    // Oyunu çalıştırırken durdurur (Editor için)
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        // Derlenmiş oyunda uygulamayı kapatır
        Application.Quit();
    #endif
}

}
