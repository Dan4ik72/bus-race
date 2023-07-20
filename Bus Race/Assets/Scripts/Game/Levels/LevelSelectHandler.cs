using UnityEngine.Events;
using UnityEngine;

public class LevelSelectHandler
{
    private LevelsData _levelsData;

    private int _levelViewIndex;

    private ISaveService _saveService;

    public event UnityAction<int> CurrentLevelChanged;

    public LevelSelectHandler(LevelsData levelData, ISaveService saveService)
    {
        _levelsData = levelData;

        _saveService = saveService;

        UploadLevelViewIndex();
    }
    
    public int GetCurrentLevel()
    {
        return _levelViewIndex;
    }

    public void IncrementCurrentLevel()
    {
        int incrementedLevelIndex = _levelsData.GetCurrentLevelIndex() + 1;

        if (_levelViewIndex >= _levelsData.GetLevelsCount()) 
            incrementedLevelIndex = GetRandomLevel();

        _levelsData.SetCurrentLevelIndex(incrementedLevelIndex);

        CurrentLevelChanged?.Invoke(_levelViewIndex);
    }

    private int GetRandomLevel()
    {
        int minRandomLevelIndex = 2;
        int maxRandomLevelIndex = _levelsData.GetLevelsCount();

        _levelViewIndex++;
        SaveLevelViewIndex();

        return Random.Range(minRandomLevelIndex, maxRandomLevelIndex);
    }

    private void UploadLevelViewIndex()
    {
        if (_saveService.CheckKeyOnExist("LevelViewIndex") == false)
        {
            _levelViewIndex = _levelsData.GetCurrentLevelIndex();
            return;
        }

        _levelViewIndex = _saveService.LoadInt("LevelViewIndex");
    }

    private void SaveLevelViewIndex()
    {
        if(_saveService.CheckKeyOnExist("LevelViewIndex") == false)
        {
            _saveService.SaveInt("LevelViewIndex", _levelsData.GetCurrentLevelIndex() + 1);
            return;
        }

        _saveService.SaveInt("LevelViewIndex", _levelViewIndex);
    }
}

