using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinishObstacle : MonoBehaviour
{
    private GameEndingHandler _gameEndingHandler;

    public void Init(GameEndingHandler gameEndingHandler)
    {
        _gameEndingHandler = gameEndingHandler;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ModifiersCatcher bus) && bus.IsPlayerBus)
            _gameEndingHandler.SetPlayerLose();
    }
}
