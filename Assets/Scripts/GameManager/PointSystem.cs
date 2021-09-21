using UnityEngine;

[CreateAssetMenu(fileName = "PointSystem", menuName = "ScriptableObjects/PointSystem", order = 1)]
public class PointSystem : ScriptableObject
{
    [SerializeField, Min(0)] private int asteroid = 5;
    [SerializeField, Min(0)] private int enemy = 1;
    [SerializeField, Min(0)] private int smallAsteroid = 2;

    public int Asteroid => asteroid;

    public int Enemy => enemy;

    public int SmallAsteroid => smallAsteroid;
}
