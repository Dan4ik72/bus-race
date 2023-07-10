using Unity.Properties;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class SceneLoadHandler : MonoBehaviour
{
    private int _initSceneBuildIndex = 0;
    private int _mainMenuSceneBuildIndex = 1;
    private int _gameSceneBuildIndex = 2;

    public static SceneLoadHandler Instance { get; private set; }

    private void Awake()
    {
        TryInstance();
    }

    private void TryInstance()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(_gameSceneBuildIndex);     
    }

    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene(_mainMenuSceneBuildIndex);
    }

    public void LoadInitScene()
    {
        SceneManager.LoadScene(_initSceneBuildIndex);
    }
}
