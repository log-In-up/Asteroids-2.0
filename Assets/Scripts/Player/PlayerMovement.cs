using UnityEngine;
using UnityEngine.InputSystem;

class PlayerMovement
{
    private const float ANGLE_OFFSET = 90.0f, xRotationAngle = 0.0f, yRotationAngle = 0.0f;

    public static void MoveForward(InputAction.CallbackContext inputAction)
    {
        Debug.Log("I'm moving forward.");
    }

    public static void RotatePlayerToMousePoint(Transform player)
    {
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(player.position);
        Vector2 mouseOnScreen = Camera.main.ScreenToViewportPoint(Mouse.current.position.ReadValue());

        float angle = Mathf.Atan2(positionOnScreen.y - mouseOnScreen.y, positionOnScreen.x - mouseOnScreen.x) * Mathf.Rad2Deg;

        player.rotation = Quaternion.Euler(new Vector3(xRotationAngle, yRotationAngle, angle + ANGLE_OFFSET));
    }
}