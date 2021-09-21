class PlayerCollisions
{
    public void FinishTheGame(GameManager gameManager)
    {
        gameManager.OnFinishTheGame.Invoke();
    }
}
