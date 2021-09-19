using UnityEngine;

class PlayerCollisions
{
    private GameManager gameManager = new GameManager();

    public void FinishTheGame()
    {
        gameManager.OnFinishTheGame.Invoke();
    }
}
