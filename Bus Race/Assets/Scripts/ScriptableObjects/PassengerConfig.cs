using UnityEngine;

[CreateAssetMenu(fileName = "PassengerConfig", menuName = "Passengers/Configs/Create Passenger Config")]
public class PassengerConfig : ScriptableObject
{
    [SerializeField] private float _speedToBus;
    [SerializeField] private float _speedInBus;

    [SerializeField] private int _busFareAmount;

    public float SpeedToBus => _speedToBus;
    public float SpeedInBus => _speedInBus;
    public int BusFareAmount => _busFareAmount;
}
