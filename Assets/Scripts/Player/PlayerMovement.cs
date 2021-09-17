using UnityEngine;
using UnityEngine.InputSystem;

class PlayerMovement
{
    private const float ANGLE_OFFSET = 90.0f, xRotationAngle = 0.0f, yRotationAngle = 0.0f;

    public void MoveForward(Transform player, float movementSpeed)
    {
        player.Translate(movementSpeed * Time.deltaTime * Vector2.up);

        Debug.Log("I'm moving");
    }

    public void RotatePlayerToMousePoint(Transform player, out float rotationAngle)
    {
        Vector2 mouseOnScreen = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        float angle = Mathf.Atan2(player.position.y - mouseOnScreen.y, player.position.x - mouseOnScreen.x) * Mathf.Rad2Deg + ANGLE_OFFSET;
        rotationAngle = angle;

        player.rotation = Quaternion.Euler(new Vector3(xRotationAngle, yRotationAngle, angle));
    }
}