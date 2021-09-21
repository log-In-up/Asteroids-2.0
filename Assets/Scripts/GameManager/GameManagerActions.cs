using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManagerActions
{
    private int totalPoints;

    public void SetTimeScale(float timeScale)
    {
        Time.timeScale = timeScale;
    }

    public void RestartGame()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void ResetScorePoints(TextMeshProUGUI totalScoreInGame, TextMeshProUGUI totalScoreFailedGame)
    {
        totalPoints = 0;

        totalScoreInGame.text = $"{totalPoints}";
        totalScoreInGame.text = $"{totalPoints}";
    }

    public void AddScorePoints(int points, TextMeshProUGUI totalScoreInGame, TextMeshProUGUI totalScoreFailedGame)
    {
        totalPoints += points;

        totalScoreInGame.text = $"{totalPoints}";
        totalScoreFailedGame.text = $"{totalPoints}";
    }

    public void KeepPlayerInBounds(Transform player, Camera camera)
    {
        if (player.position.x > BoundsMax(camera).x)
        {
            player.position = new Vector3(BoundsMin(camera).x, player.position.y, player.position.z);
        }

        if (player.position.x < BoundsMin(camera).x)
        {
            player.position = new Vector3(BoundsMax(camera).x, player.position.y, player.position.z);
        }

        if (player.position.y > BoundsMax(camera).y)
        {
            player.position = new Vector3(player.position.x, BoundsMin(camera).y, player.position.z);
        }

        if (player.position.y < BoundsMin(camera).y)
        {
            player.position = new Vector3(player.position.x, BoundsMax(camera).y, player.position.z);
        }
    }

    private Vector2 BoundsMin(Camera camera)
    {
        return (Vector2)camera.transform.position - Extents(camera);
    }

    private Vector2 BoundsMax(Camera camera)
    {
        return (Vector2)camera.transform.position + Extents(camera);
    }

    private Vector2 Extents(Camera camera)
    {
        if (camera.orthographic)
            return new Vector2(camera.orthographicSize * Screen.width / Screen.height, camera.orthographicSize);
        else
        {
            Debug.LogError("Camera is not orthographic!", camera);
            return new Vector2();
        }
    }

}
