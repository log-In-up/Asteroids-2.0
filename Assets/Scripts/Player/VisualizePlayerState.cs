using UnityEngine;
using TMPro;

class VisualizePlayerState
{
    Vector3 lastPosition;

    public void ShowPlayerAngles(TextMeshProUGUI anglesText, float angle)
    {
        anglesText.text = $"{angle:F1}";
    }

    public void ShowPlayerPosition(TextMeshProUGUI positionText, Transform player)
    {
        positionText.text = $"{player.position.x:F2} : {player.position.y:F2}";
    }

    public void ShowPlayerSpeed(TextMeshProUGUI speedText, Transform player)
    {
        float speed = (player.position - lastPosition).magnitude / Time.deltaTime;
        lastPosition = player.position;

        speedText.text = $"{speed:F1}";
    }

    public void ShowLaserChargesCount(TextMeshProUGUI chargesCount, int count)
    {
        chargesCount.text = $"{count}";
    }

    public void ShowLaserRollbackTime(TextMeshProUGUI rollbackTime, float time)
    {
        rollbackTime.text = $"{time:F1}";
    }
}
