using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private List<Modifier> _modifiers = new List<Modifier>();
    [SerializeField] private GameEndingTrigger _gameEndingTrigger;

    private PassengersSpawner _spawner;

    public void Init(PassengersSpawner spawner)
    {
        _spawner = spawner;

        InitModifiers();
    }

    public GameEndingTrigger GameEndingTrigger => _gameEndingTrigger;
 
    private void InitModifiers()
    {
        foreach (var modifier in _modifiers)
            modifier.Init(_spawner);
    }
}
