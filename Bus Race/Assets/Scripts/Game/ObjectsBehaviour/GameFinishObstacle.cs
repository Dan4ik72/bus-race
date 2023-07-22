using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinishObstacle : MonoBehaviour
{
    private GameLoopSetUp _gameLoopSetUp;

    public void Init(GameLoopSetUp gameLoopSetUp)
    {
        _gameLoopSetUp = gameLoopSetUp;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ModifiersCatcher bus) && bus.IsPlayerBus)
            _gameLoopSetUp.RestartLevel();
    }
}
