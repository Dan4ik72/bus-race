using UnityEngine;

[CreateAssetMenu(fileName = "BusUpgradeConfig", menuName = "Bus Upgrade Config / New bus upgrade config")]
public class BusUpgradeConfig : ScriptableObject
{
    [SerializeField] private int _fareAmountIncreaseStep;
    [SerializeField] private float _busSpeedValueIncreaseStep;

    public int FareAmountIncreaseStep => _fareAmountIncreaseStep;
    public float BusSpeedValueIncreaseStep => _busSpeedValueIncreaseStep;
}
