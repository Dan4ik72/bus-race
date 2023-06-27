public class GameCompositeRoot : CompositeRoot
{
    private GameLoopSetUp _gameLoopSetUp;

    public GameLoopSetUp GameLoopSetUp => _gameLoopSetUp;

    public override void Compose()
    {
        _gameLoopSetUp = new GameLoopSetUp();
    }

    private void Update()
    {
        _gameLoopSetUp.Update();
    }
}