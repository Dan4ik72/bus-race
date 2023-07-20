using System;
using System.Collections.Generic;
using System.Linq;

public class LevelsData
{
    private Dictionary<LevelData, bool> _levels = new Dictionary<LevelData, bool>();

    private int _currentLevelIndex = 0;

    public LevelsData(List<LevelData> levelsData)
    {
        foreach(var level in levelsData)
            _levels.Add(level, false);
    }

    public int GetLevelsCount() => _levels.Count;

    public bool CheckLevelLocked(int levelIndex)
    {
        if (CheckLevelExistingByIndex(levelIndex) == false)
            throw new ArgumentOutOfRangeException(nameof(levelIndex));

        LevelData levelData = _levels.FirstOrDefault(level => level.Key.Index == levelIndex).Key;

        return _levels[levelData];
    }

    public void SetCurrentLevelIndex(int currentLevel)
    {
        if(CheckLevelExistingByIndex(currentLevel) == false) 
            throw new ArgumentOutOfRangeException( nameof(currentLevel));

        _currentLevelIndex = currentLevel;
    }

    public bool TryGetLevelDataByIndex(int index, out LevelData levelData)
    {
        if(CheckLevelExistingByIndex(index) == false)
        {
            levelData = null;
            return false;
        }

        levelData = _levels.FirstOrDefault(level => level.Key.Index == index).Key;
        return true;
    }

    public void SetLevelLocked(int levelIndex ,bool isLocked)
    {
        if (CheckLevelExistingByIndex(levelIndex) == false)
            throw new ArgumentOutOfRangeException(nameof(levelIndex));

        LevelData levelData = _levels.FirstOrDefault(level => level.Key.Index == levelIndex).Key;

        _levels[levelData] = isLocked;
    }

    public LevelData GetCurrentLevel()
    {
        return _levels.FirstOrDefault(level => level.Key.Index == _currentLevelIndex).Key;
    }

    public int GetCurrentLevelIndex()
    {
        if (CheckLevelExistingByIndex(_currentLevelIndex) == false)
            throw new ArgumentOutOfRangeException(nameof(_currentLevelIndex));

        return _currentLevelIndex;
    }

    private bool CheckLevelExistingByIndex(int index)
    {
        LevelData levelData = _levels.FirstOrDefault(level => level.Key.Index == index).Key;

        if (levelData == null)
            return false;

        return true;
    }
}

