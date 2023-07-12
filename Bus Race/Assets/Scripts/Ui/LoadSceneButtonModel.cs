public class LoadSceneButtonModel : ButtonModel
{
    public override void OnButtonClick()
    {
        SceneLoadHandler.Instance.LoadGameScene();

        base.OnButtonClick();
    }
}
