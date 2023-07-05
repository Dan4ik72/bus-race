using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEndingTrigger : MonoBehaviour
{
    public event UnityAction BusArrived;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ModifiersCatcher bus))
            BusArrived?.Invoke();
    }
}
