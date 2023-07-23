using UnityEngine;

public class LoadSceneButtonModel : ButtonModel
{
    private int _sceneBuildIndex;

    public LoadSceneButtonModel(int loadSceneBuildIndex = -1)
    {
        _sceneBuildIndex = loadSceneBuildIndex;
    }

    public override void OnButtonClick()
    {
        if (_sceneBuildIndex == -1)
        {
            SceneLoadHandler.Instance.ReloadCurrentScene();
            return;
        }
 
        SceneLoadHandler.Instance.LoadSceneByBuildIndex(_sceneBuildIndex);
            
        base.OnButtonClick();
    }
}
