using UnityEngine;
using TMPro;

class VisualizePlayerState
{
    public void ShowPlayerAngles(TextMeshProUGUI anglesText, float angle)
    {
        anglesText.text = $"{angle:F1}";
    }

    public void ShowPlayerPosition(TextMeshProUGUI playerPositionText, Transform player)
    {
        playerPositionText.text = $"{player.position.x:F2} : {player.position.y:F2}";
    }
}
