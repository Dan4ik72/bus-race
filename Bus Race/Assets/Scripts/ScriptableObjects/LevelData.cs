using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Level Data/Create new level data")]
public class LevelData : ScriptableObject
{
    [SerializeField] private Level _level;
    [SerializeField] private int _index;

    public Level Level => _level;
    public int Index => _index;
}
