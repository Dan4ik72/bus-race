using UnityEngine;

public class EnemyBusCompositeRoot : CompositeRoot
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private BusConfig _busConfig;
    [SerializeField] private Transform _raycastPoint;

    private BusMover _busMover;
    private EnemyBusInputSetUp _enemyBusInputSetUp;
    private RigidbodyMoveHandler _rigidbodyMoveHandler;


    //set other requiered dependencies

    public override void Compose()
    {
        _rigidbodyMoveHandler = new RigidbodyMoveHandler(_rigidbody);
        
        _busMover = new BusMover(_busConfig.IdleSpeed, _busConfig.GasSpeed, _rigidbodyMoveHandler);
        _enemyBusInputSetUp = new EnemyBusInputSetUp(_busMover, _raycastPoint);
    }

    private void Awake()
    {
        _enemyBusInputSetUp.Awake();
    }

    private void OnEnable()
    {
        _enemyBusInputSetUp.OnEnable();        
    }

    private void OnDisable()
    {
        _enemyBusInputSetUp.OnDisable();
    }

    private void Update()
    {
        _enemyBusInputSetUp.Update();
    }
}

