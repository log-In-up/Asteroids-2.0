using UnityEngine;

[CreateAssetMenu(fileName = "TagManager", menuName = "ScriptableObjects/TagManager", order = 1)]
public class TagManager : ScriptableObject
{
    [SerializeField] private string asteroidTag = "Asteroid";
    [SerializeField] private string enemyTag = "Enemy";
    [SerializeField] private string playerTag = "Player";

    public string Asteroid => asteroidTag;

    public string Enemy => enemyTag;

    public string Player => playerTag;
}
