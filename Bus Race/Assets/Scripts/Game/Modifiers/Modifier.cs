using UnityEngine;

public abstract class Modifier : MonoBehaviour
{
    public void Init(PassengersSpawner passengerSpawner)
    {
        PassengerSpawner = passengerSpawner;
    }

    protected PassengersSpawner PassengerSpawner { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ModifiersCatcher trigger))
        {
            Apply(trigger);
            Destroy(gameObject);
        }
    }

    protected abstract void Apply(ModifiersCatcher trigger);
}