using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

class PlayerMovement
{
    private const float ANGLE_OFFSET = 90.0f, xRotationAngle = 0.0f, yRotationAngle = 0.0f;

    private Coroutine movement = null;

    public void StartMovement(MonoBehaviour monoBehaviour, Transform player, float movementSpeed)
    {
        if(movement != null)
        {
            monoBehaviour.StopCoroutine(movement);
        }
        movement = monoBehaviour.StartCoroutine(Movement(player, movementSpeed));
    }

    public void StopMovement(MonoBehaviour monoBehaviour)
    {
        monoBehaviour.StopCoroutine(movement);
    }

    private IEnumerator Movement(Transform player, float movementSpeed)
    {
        while(true)
        {
            player.Translate(movementSpeed * Time.deltaTime * Vector2.up);

            yield return new WaitForEndOfFrame();
        }
    }

    public void RotatePlayerToMousePoint(Transform player, out float rotationAngle)
    {
        Vector2 mouseOnScreen = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        float angle = Mathf.Atan2(player.position.y - mouseOnScreen.y, player.position.x - mouseOnScreen.x) * Mathf.Rad2Deg + ANGLE_OFFSET;
        rotationAngle = angle;

        player.rotation = Quaternion.Euler(new Vector3(xRotationAngle, yRotationAngle, angle));
    }
}