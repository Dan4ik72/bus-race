using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEndingTrigger : MonoBehaviour
{
    private GameLoopSetUp _gameLoop;

    public void Init(GameLoopSetUp gameLoopSetUp) => _gameLoop = gameLoopSetUp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ModifiersCatcher bus) && bus.IsPlayerBus)
            _gameLoop.SetEndingGameState();
    }
}
