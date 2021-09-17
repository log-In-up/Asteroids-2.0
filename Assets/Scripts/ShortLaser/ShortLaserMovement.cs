using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortLaserMovement
{
    public void MoveForward(Transform laser, float movementSpeed)
    {
        laser.Translate(movementSpeed * Time.deltaTime * Vector2.up);
    }
}
