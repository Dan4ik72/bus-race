using UnityEngine;

[CreateAssetMenu(fileName = "BusUpgradeConfig", menuName = "Bus Upgrade Config / New bus upgrade config")]
public class BusUpgradeConfig : ScriptableObject
{
    [SerializeField] private int _fareAmountIncreaseStep;
    [SerializeField] private int _fareAmountIncreasePriceMultiplier;
    [SerializeField] private int _maxFareAmount;

    [SerializeField] private float _busSpeedValueIncreaseStep;
    [SerializeField] private int _busSpeedIncreasePriceMultiplier;
    [SerializeField] private float _maxBusSpeed;

    [SerializeField] private int _upgradePriceStep;

    public int FareAmountIncreaseStep => _fareAmountIncreaseStep;
    public int FareAmountIncreasePriceMultiplier => _fareAmountIncreasePriceMultiplier;
    public int MaxFareAmount => _maxFareAmount;

    public float BusSpeedValueIncreaseStep => _busSpeedValueIncreaseStep;
    public int BusSpeedPriceIncreaseMultiplier => _busSpeedIncreasePriceMultiplier;
    public float MaxBusSpeed => _maxBusSpeed;
}