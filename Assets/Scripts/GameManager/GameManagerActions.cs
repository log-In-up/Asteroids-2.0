using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerActions
{
    public void SetTimeScale(float timeScale)
    {
        Time.timeScale = timeScale;
    }

    public void RestartGame()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
