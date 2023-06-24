using UnityEngine;

public class EnemyBusInputSetUp
{
    private BusMover _busMover;

    private BusInputHandler _inputHandler;

    private RaycastEnemyBusInput _input;

    private Transform _raycastPoint;
    private int _obstacleLayer = 8;

    public EnemyBusInputSetUp(BusMover busMover, Transform raycastPoint)
    {
        _busMover = busMover;
        _raycastPoint = raycastPoint;
    }

    public void Awake()
    {
        _input = new RaycastEnemyBusInput(_raycastPoint, _obstacleLayer);
        _inputHandler = new BusInputHandler(_input, _busMover);
    }

    public void OnEnable()
    {
        _inputHandler.Enable();
    }

    public void OnDisable()
    {
        _inputHandler.Disable();
    }

    public void Update()
    {
        _input.RaycastForward();
    }

}
