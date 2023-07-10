using UnityEngine;

[CreateAssetMenu(fileName = "BusConfig", menuName = "Bus/New bus config")]
public class BusConfig : ScriptableObject
{
    [SerializeField] private int _fareAmount = 5;
 
    [Header("Capacity")]
    [SerializeField] private int _startCapacity;

    [Header("Speed")]
    [SerializeField] private float _idleSpeed;
    [SerializeField] private float _gasSpeed;

    [Header("Bus Station Interactions")]
    [SerializeField] private float _busStationIdleTime = 1f;

    public int StartCapacity => _startCapacity;

    public float GasSpeed => _gasSpeed;
    public float IdleSpeed => _idleSpeed;
    public float BusStationIdleTime => _busStationIdleTime;

    public int FareAmount => _fareAmount;
}
