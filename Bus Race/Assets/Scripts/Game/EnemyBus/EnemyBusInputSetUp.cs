using UnityEngine;

public class EnemyBusInputSetUp
{
    private BusMover _busMover;
    private BusInputHandler _inputHandler;
    private BusConfig _busConfig;

    private RaycastEnemyBusInput _input;

    private Transform _raycastPoint;
    private int _obstacleLayer = 8;

    private IBusInput _currentInput;

    public EnemyBusInputSetUp(BusMover busMover, Transform raycastPoint, BusConfig busConfig, BusEntryPointTrigger entryPointTrigger)
    {
        _busMover = busMover;
        _raycastPoint = raycastPoint;
        _busConfig = busConfig;

        _input = new RaycastEnemyBusInput(_raycastPoint, entryPointTrigger, _busConfig.BusStationIdleTime, _obstacleLayer);
        _currentInput = _input;
        _inputHandler = new BusInputHandler(_input, _busMover);
    }

    public void Enable()
    {   
        _inputHandler.Enable();
    }

    public void OnDisable()
    {
        _inputHandler.Disable();
    }

    public void Update()
    {
        _currentInput.Update();
    }

}
