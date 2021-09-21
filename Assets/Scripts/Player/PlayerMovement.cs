using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

class PlayerMovement
{
    private float moveSpeed = 0.0f;

    private const float ANGLE_OFFSET = 90.0f, X_ROTATION_ANGLE = 0.0f, Y_ROTATION_ANGLE = 0.0f, STOPPING_SPEED = 0.0f;
    private const float STOPPED_TIME = 0.0f;

    private Coroutine movement = null, stopMotion = null;

    public void StartMovement(MonoBehaviour monoBehaviour, float movementSpeed)
    {
        if (stopMotion != null)
        {
            monoBehaviour.StopCoroutine(stopMotion);
        }

        if (movement != null)
        {
            monoBehaviour.StopCoroutine(movement);
        }
        movement = monoBehaviour.StartCoroutine(StartMotion(monoBehaviour.transform, movementSpeed));
    }

    public void StopMovement(MonoBehaviour monoBehaviour)
    {
        monoBehaviour.StopCoroutine(movement);
        stopMotion = monoBehaviour.StartCoroutine(StopMotion(monoBehaviour.transform));
    }

    public void RotatePlayerToMousePoint(Transform player, out float rotationAngle)
    {
        if (Time.timeScale != STOPPED_TIME)
        {
            Vector2 mouseOnScreen = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

            float angle = Mathf.Atan2(player.position.y - mouseOnScreen.y, player.position.x - mouseOnScreen.x) * Mathf.Rad2Deg + ANGLE_OFFSET;
            rotationAngle = angle;

            player.rotation = Quaternion.Euler(new Vector3(X_ROTATION_ANGLE, Y_ROTATION_ANGLE, angle));
        }
        else
        {
            rotationAngle = player.eulerAngles.z;
        }
    }

    private IEnumerator StartMotion(Transform player, float movementSpeed)
    {
        while (moveSpeed < movementSpeed)
        {
            moveSpeed += 1.0f * Time.deltaTime;

            player.Translate(moveSpeed * Time.deltaTime * Vector2.up);

            yield return new WaitForEndOfFrame();
        }

        while (true)
        {
            player.Translate(movementSpeed * Time.deltaTime * Vector2.up);

            yield return new WaitForEndOfFrame();
        }
    }

    private IEnumerator StopMotion(Transform player)
    {
        while (moveSpeed > STOPPING_SPEED)
        {
            moveSpeed -= 1.0f * Time.deltaTime;

            player.Translate(moveSpeed * Time.deltaTime * Vector2.up);

            yield return new WaitForEndOfFrame();
        }
    }
}