using UnityEngine;

public abstract class Modifier : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ModifiersTrigger trigger))
            Apply(trigger);
    }

    protected abstract void Apply(ModifiersTrigger trigger);
}