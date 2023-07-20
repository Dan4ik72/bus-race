using UnityEngine;
using System.Collections;
using YG;

public class Init : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(InitYandexSdk());
    }

    private IEnumerator InitYandexSdk()
    {
        var delay = new WaitForSecondsRealtime(0.1f);

        while (YandexGame.SDKEnabled == false)
            yield return delay;

        LoadMainMenuScene();
    }

    private void LoadMainMenuScene()
    {
        SceneLoadHandler.Instance.LoadMainMenuScene();
    }
}