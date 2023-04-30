using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

[CreateAssetMenu(fileName = "BusConfig", menuName = "Bus/New bus config")]
public class BusConfig : ScriptableObject
{
    [Header("Capacity")]
    [SerializeField] private int _startCapacity;

    [Header("Speed")]
    [SerializeField] private float _idleSpeed;
    [SerializeField] private float _gasSpeed;

    public int StartCapacity => _startCapacity;

    public float GasSpeed => _gasSpeed;
    public float IdleSpeed => _idleSpeed;
}
