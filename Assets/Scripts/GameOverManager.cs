using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameOverMusicManager musicManager;

    private void Start()
    {
        gameOverPanel.SetActive(false);  // Başlangıçta kapalı
        musicManager = FindObjectOfType<GameOverMusicManager>();
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;

        if (musicManager == null)
        {
            musicManager = FindObjectOfType<GameOverMusicManager>();
        }

        if (musicManager != null)
        {
            musicManager.PlayGameOverSound();
        }
        else
        {
            Debug.LogWarning("GameOverMusicManager not found!");
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
