using UnityEngine;

public class Init : MonoBehaviour
{
    private void Start()
    {
        SceneLoadHandler.Instance.LoadMainMenuScene();
    }
}
