using UnityEngine;

class PlayerCollisions
{
    public void FinishTheGame()
    {
        GameManager gameManager = new GameManager();
        gameManager.OnFinishTheGame.Invoke();
    }
}
