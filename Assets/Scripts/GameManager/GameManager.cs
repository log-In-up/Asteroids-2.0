using UnityEngine;
using UnityEngine.Events;

[DisallowMultipleComponent]
public class GameManager : MonoBehaviour
{


    [HideInInspector] public UnityEvent OnFinishTheGame = null;

    private void OnEnable()
    {
        OnFinishTheGame.AddListener(FinishTheGame);
    }

    private void OnDisable()
    {
        OnFinishTheGame.RemoveListener(FinishTheGame);        
    }

    private void FinishTheGame()
    {

    }
}
