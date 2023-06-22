using UnityEngine;

[CreateAssetMenu(fileName = "PassengerConfig", menuName = "Passengers/Configs/Create Passenger Config")]
public class PassengerConfig : ScriptableObject
{
    [Header("Speed")]
    [SerializeField] private float _speedToBus;
    [SerializeField] private float _speedInBus;

    [Header("Distance values")]
    [SerializeField] private float _maxDistanceToBusTrigger = 5f;

    [Header("Bus Fare values")]
    [SerializeField] private int _busFareAmount;

    public float SpeedToBus => _speedToBus;
    public float SpeedInBus => _speedInBus;
    public float MaxDistanceToBusTrigger => _maxDistanceToBusTrigger;
    public int BusFareAmount => _busFareAmount;
}
