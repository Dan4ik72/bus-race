using System.Collections.Generic;
using System;
using UnityEngine;

public class LevelsDataStorageService
{
    private ISaveService _saveService;

    private List<LevelData> _levels;

    private LevelsData _levelsData;

    private LevelSelectHandler _levelSelectHandler;

    public LevelsDataStorageService(ISaveService saveService, List<LevelData> levels)
    {
        _saveService = saveService; 
        _levels = levels;

        _levelsData = new LevelsData(levels);
        UploadData();

        _levelSelectHandler = new LevelSelectHandler(_levelsData, _saveService);
    }

    public LevelsData LevelsData => _levelsData;
    public LevelSelectHandler LevelSelectHandler => _levelSelectHandler;

    public void SaveData()
    {
        if(_levels.Count <= 0)
            throw new ArgumentOutOfRangeException(nameof(_levels.Count));
    
        for (int i = 0; i < _levels.Count; i++)
        {
            if (_levelsData.TryGetLevelDataByIndex(i, out LevelData level) == false)
                throw new ArgumentOutOfRangeException(nameof(i));

            _saveService.SaveInt($"{level.name}_isLocked", Convert.ToInt32(_levelsData.CheckLevelLocked(i)));
        }

        _levelsData.TryGetLevelDataByIndex(_levelsData.GetCurrentLevelIndex(), out LevelData levelData);

        _saveService.SaveInt($"CurrentLevel", _levelsData.GetCurrentLevelIndex());
    }

    private void UploadData()
    {
        for (int i = 0; i < _levels.Count; i++)
        {
            if (_levelsData.TryGetLevelDataByIndex(i, out LevelData levelData) == false)
                throw new ArgumentOutOfRangeException(nameof(i));

            if (_saveService.CheckKeyOnExist($"{levelData.name}_isLocked") == false)
                _levelsData.SetLevelLocked(i, false);
            else
                _levelsData.SetLevelLocked(i, Convert.ToBoolean(_saveService.LoadInt($"{levelData.name}_isLocked")));
        }

        if (_saveService.CheckKeyOnExist($"CurrentLevel") == false)
            _levelsData.SetCurrentLevelIndex(0);
        else
            _levelsData.SetCurrentLevelIndex(_saveService.LoadInt($"CurrentLevel"));
    }
}